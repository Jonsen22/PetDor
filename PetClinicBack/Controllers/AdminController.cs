using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetDoor.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace PetDoor.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private AmazonDynamoDBClient client;
        private readonly string tableName = "Administrador";

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
        public async Task<List<Admin>> getAdmins()
        {

            var request = new ScanRequest { TableName = this.tableName };

            var response = await client.ScanAsync(request);

            List<Admin> admList = new List<Admin>();

            foreach (var item in response.Items)
            {
                Admin newAdmin = new Admin();

                newAdmin.id = item["id"].S;
                newAdmin.login = item["login"].S;
                newAdmin.senha = item["senha"].S;

                admList.Add(newAdmin);
            }

            return admList;
        }

        // GET: api/Admin/04
        [HttpGet("{id}")]
        public async Task<Admin> getAdminById(string id)
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

            Admin newAdmin = new Admin();

            newAdmin.id = response.Item["id"].S;
            newAdmin.login = response.Item["login"].S;
            newAdmin.senha = response.Item["senha"].S;

            return newAdmin;
        }

        // PUT: api/Admin
        [HttpPut("{id}")]
        public async Task<bool> putAdmin(string id, Admin Admin)
        {

            Admin currentAdmin = await this.getAdminById(id);

            Admin newAdmin = new Admin();

            if (Admin.login != null) newAdmin.login = Admin.login;
            else newAdmin.login = currentAdmin.login;

            if (Admin.senha != null) newAdmin.senha = Admin.senha;
            else newAdmin.senha = currentAdmin.senha;

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
