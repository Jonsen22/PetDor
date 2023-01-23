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
    public class AdminController : ControllerBase
    {

        private AmazonDynamoDBClient client;
        private DynamoDBContext context;
        private readonly string tableName = "Administrador";
        // private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            // _context = context;
            client = new AmazonDynamoDBClient(AWSEnvironment.getAccessKey(), AWSEnvironment.getPrivateAccessKey(),
            new AmazonDynamoDBConfig
            {
                ServiceURL = AWSEnvironment.getServiceURL(),
                UseHttp = true
            });

        }

        // GET: api/Admin
        [HttpGet]
        public async Task<List<Dictionary<string, AttributeValue>>> getAdmins()
        {

            var request = new ScanRequest { TableName = this.tableName };

            var response = await client.ScanAsync(request);

            return response.Items;
        }

        // GET: api/Admin/04
        [HttpGet("{id}")]
        public async Task<Dictionary<string, Amazon.DynamoDBv2.Model.AttributeValue>> getAdminById(string id)
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
            return response.Item;
        }

        // PUT: api/Admin
        [HttpPut("{id}")]
        public async Task<bool> putAdmin(string id, Admin Admin)
        {

            Dictionary<string, AttributeValue> currentAdmin = await this.getAdminById(id);

            Admin newAdmin = new Admin();

            if (Admin.login != null) newAdmin.login = Admin.login;
            else newAdmin.login = currentAdmin["login"].S;

            if (Admin.senha != null) newAdmin.senha = Admin.senha;
            else newAdmin.senha = currentAdmin["senha"].S;

            var request = new PutItemRequest
            {
                TableName = this.tableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    ["id"] = new AttributeValue { S = id },
                    ["login"] = new AttributeValue { S = newAdmin.login },
                    ["senha"] = new AttributeValue { S = newAdmin.senha }
                }
            };

            var response = await client.PutItemAsync(request);

            return (response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        // POST: api/Admin
        [HttpPost]
        public async Task<bool> insertAdmin(Admin Admin)
        {

            var describeReq = new DescribeTableRequest { TableName = this.tableName };

            var tableDescription = await client.DescribeTableAsync(describeReq);

            int id = (int)tableDescription.Table.ItemCount + 1;
            string formattedId;

            if (id < 10) formattedId = ("0" + id.ToString());
            else formattedId = id.ToString();

            var item = new Dictionary<string, AttributeValue>
            {
                ["id"] = new AttributeValue { S = formattedId },
                ["login"] = new AttributeValue { S = Admin.login },
                ["senha"] = new AttributeValue { S = Admin.senha }
            };

            var request = new PutItemRequest
            {
                TableName = this.tableName,
                Item = item
            };

            var response = await client.PutItemAsync(request);
            return (response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        // DELETE: api/Admin/04
        [HttpDelete("{id}")]
        public async Task<bool> deleteAdmin(string id)
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
