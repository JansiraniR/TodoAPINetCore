using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;

namespace TodoAPI
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;

        public TodoRepository()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_client);
        }
        public async Task AddNewItem(TodoItem task)
        {
            var item = new TodoItem
            {
                Id = task.Id,
                Notes = task.Notes,
                Tasks = task.Tasks,
                Status =task.Status ,
                DateTime =task.DateTime,
                Done=task.Done
            };
            await _context.SaveAsync<TodoItem>(item);
        }

        public async Task<List<TodoItem>> AllItems()
        {
            var conditions = new List<ScanCondition>();

            return await _context.ScanAsync<TodoItem>(conditions).GetRemainingAsync();
        
        }

        public async Task DeleteItem(int id)
        {
          await _context.DeleteAsync<TodoItem>(id);
        }

        public async Task Update(TodoItem task)
        {
            var item = await _context.LoadAsync<TodoItem>(task.Id);
                item.Notes=task.Notes;
                item.Done=task.Done;
                item.Status=task.Status;
                item.Tasks=task.Tasks;
                item.DateTime=task.DateTime;

            await _context.SaveAsync<TodoItem>(item);
        }
    }
}