using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetDoor.Models;
using PetDoor.Services;
using PetDoor.Exceptions;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;

namespace PetDoor.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private AmazonDynamoDBClient client;
        private DynamoDBContext context;
        private readonly string tableName = "User";
        // private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            // _context = context;
            client = new AmazonDynamoDBClient(AWSEnvironment.getAccessKey(), AWSEnvironment.getPrivateAccessKey(),
            new AmazonDynamoDBConfig
            {
                ServiceURL = AWSEnvironment.getServiceURL(),
                UseHttp = true
            });

        }

        // GET: api/User
        [HttpGet]
        public async Task<List<User>> getUsers()
        {

            var request = new ScanRequest { TableName = this.tableName };

            var response = await client.ScanAsync(request);

            List<User> userList = new List<User>();

            foreach (var item in response.Items)
            {
                User newUser = new User();

                newUser.id = item["id"].S;
                newUser.login = item["login"].S;
                newUser.senha = item["senha"].S;
                newUser.tutorId = item["tutorId"].S;

                userList.Add(newUser);
            }

            return userList;
        }

        // GET: api/User/04
        [HttpGet("{id}")]
        public async Task<User> getUserById(string id)
        {

            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>()
            {
                { "id", new AttributeValue { S = id} }
            };

            // Create GetItem request
            GetItemRequest request = new GetItemRequest
            {
                TableName = this.tableName,
                Key = key
            };

            // Issue request
            var response = await client.GetItemAsync(request);

            User newUser = new User();

            newUser.id = response.Item["id"].S;
            newUser.login = response.Item["login"].S;
            newUser.senha = response.Item["senha"].S;
            newUser.tutorId = response.Item["tutorId"].S;

            return newUser;
        }

        // PUT: api/User
        [HttpPut("{id}")]
        public async Task<bool> putUser(string id, User user)
        {

            User currentUser = await this.getUserById(id);

            User newUser = new User();

            if (user.login != null) newUser.login = user.login;
            else newUser.login = currentUser.login;

            if (user.senha != null) newUser.senha = user.senha;
            else newUser.senha = currentUser.senha;

            if (user.tutorId != null) newUser.tutorId = user.tutorId;
            else newUser.tutorId = currentUser.tutorId;

            var request = new PutItemRequest
            {
                TableName = this.tableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    ["id"] = new AttributeValue { S = id },
                    ["login"] = new AttributeValue { S = newUser.login },
                    ["senha"] = new AttributeValue { S = newUser.senha },
                    ["tutorId"] = new AttributeValue { S = newUser.tutorId }
                }
            };

            var response = await client.PutItemAsync(request);

            return (response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        // POST: api/User
        [HttpPost]
        public async Task<string> insertUser(User user)
        {

            var describeReq = new DescribeTableRequest { TableName = this.tableName };

            var tableDescription = await client.DescribeTableAsync(describeReq);

            string id = (tableDescription.Table.ItemCount + 1).ToString();

            var item = new Dictionary<string, AttributeValue>
            {
                ["id"] = new AttributeValue { S = id },
                ["login"] = new AttributeValue { S = user.login },
                ["senha"] = new AttributeValue { S = user.senha },
                ["tutorId"] = new AttributeValue { S = user.tutorId }
            };

            var request = new PutItemRequest
            {
                TableName = this.tableName,
                Item = item
            };

            var response = await client.PutItemAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK) return "Ok";
            else return "Não";
        }

        // DELETE: api/User/04
        [HttpDelete("{id}")]
        public async Task<bool> deleteUser(string id)
        {

            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>()
            {
                { "id", new AttributeValue { S = id} }
            };

            var request = new DeleteItemRequest
            {
                TableName = this.tableName,
                Key = key
            };

            var response = await client.DeleteItemAsync(request);
            return (response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

    }

}
