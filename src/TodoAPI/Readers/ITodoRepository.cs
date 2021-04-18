using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoAPI
{
    public interface ITodoRepository
    {
       
        Task<List<TodoItem>> AllItems();
        Task AddNewItem(TodoItem task);
        Task DeleteItem(int id);
        Task Update(TodoItem task);
    }
}