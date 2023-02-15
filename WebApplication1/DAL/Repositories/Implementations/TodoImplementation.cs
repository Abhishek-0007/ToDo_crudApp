using WebApplication1.DataAccessLayer.Repositories.Interfaces;
using WebApplication1.DataAccessLayer.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer.Entities;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApplication1.Extensions;

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

        public async void DeleteTodoItem(int id)
        {
            var items = _dbContext.TodoItems;
            foreach (var item in items)
            {
                if (item.Id == id) { 
                    _dbContext.Remove(item);
                    await _dbContext.SaveChangesAsync();
                }
            }

        }

        public async Task<List<Todo>> GetAllTodoItems()
        {
            var items = await _dbContext.TodoItems.ToListAsync();
            await _dbContext.SaveChangesAsync();
            return items;
        }

        public Todo GetTodoItemById(int id)
        {
            Todo todoItem = _dbContext.TodoItems.Where(t => t.Id.Equals(id)).FirstOrDefault();
            return todoItem;

        }

        public async Task<Todo> UpdateTodoItem(Todo todoItem)
        {

            var previoudItem = _dbContext.TodoItems.Where(t => t.Id.Equals(todoItem.Id)).FirstOrDefault();

            previoudItem.Name = todoItem.Name;
            previoudItem.isComplete = todoItem.isComplete;

            _dbContext.SaveChangesAsync();

            return todoItem;
        }
    }
}
