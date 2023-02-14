using WebApplication1.DataAccessLayer.Repositories.Interfaces;
using WebApplication1.DataAccessLayer.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer.Entities;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.DataAccessLayer.Repositories.Implementation
{
    public class TodoImplementation : ITodoRepositoryInterface
    {
        readonly private TodoDatabaseContext _dbContext;
        public TodoImplementation(TodoDatabaseContext dbContext) { _dbContext = dbContext; }
        public async Task<Todo> AddTodoItem(Todo todoItem)
        {
            _dbContext.Add(todoItem);
            await _dbContext.SaveChangesAsync();
            return todoItem;
        }

        public Todo DeleteTodoItem(int id)
        {
            var items = _dbContext.TodoItems;
            foreach (var item in items)
            {
                if (item.Id == id) { _dbContext.Remove(item); }
            }

            return _dbContext.TodoItems.Find(id);

        }

        public async Task<List<Todo>> GetAllTodoItems()
        {
            var items = await _dbContext.TodoItems.ToListAsync();
            await _dbContext.SaveChangesAsync();
            return items;
        }

        public Todo GetTodoItemById(int id)
        {
            var items = _dbContext.TodoItems;
            Todo todoItem = null;
            foreach (var item in items)
            {
                if (item.Id == id) { todoItem = item; }
            }

            return todoItem;

        }

        public async Task<Todo> UpdateTodoItem(Todo todoItem)
        {

            var items = _dbContext.TodoItems;
            foreach (var item in items)
            {
                if (item.Id == todoItem.Id) { _dbContext.Update(todoItem); }
            }
            await _dbContext.SaveChangesAsync();
            return todoItem;
        }
    }
}
