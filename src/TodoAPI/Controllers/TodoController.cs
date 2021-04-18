using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;

namespace TodoAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

      private ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET: TodoController

        [HttpGet]
        [Route("get")]
        public async Task<List<TodoItem>> GetItems()
        {
            return await _repository.AllItems();
        }

        [HttpPost]
        [Route("Insert")]
        [ValidateAntiForgeryToken]
        public async Task InsertItem([FromBody]TodoItem value)
        {
             await _repository.AddNewItem(value);
        }


        // POST api/todo
        [HttpPost]
        [Route("Update")]
        public async Task UpdatePostAsync([FromBody]TodoItem value)
        {
             await _repository.Update(value);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task DeleteItemAsync(int Id)
        {
           await _repository.DeleteItem(Id);
      
        }
    }


}