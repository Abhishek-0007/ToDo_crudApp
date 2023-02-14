using WebApplication1.DataAccessLayer.Repositories.Interfaces;
using WebApplication1.DataAccessLayer.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer.Entities;

namespace WebApplication1.DataAccessLayer.Repositories.Implementation
{
    public class TodoImplementation : ITodoRepositoryInterface
    {
        readonly private TodoDatabaseContext _dbContext;
        public TodoImplementation(TodoDatabaseContext dbContext) { _dbContext = dbContext; }
        public async Task<TodoItemEntity> AddTodoItem(TodoItemEntity todoItem)
        {
            _dbContext.Add(todoItem);
            await _dbContext.SaveChangesAsync();
            return todoItem;
        }

        public TodoItemEntity DeleteTodoItem(int id)
        {
            TodoItemEntity? todoItem = _dbContext.TodoItems.Find(id);
            if (todoItem != null)
            {
                _dbContext.Remove(todoItem);
            }

            return todoItem;

        }

        public async Task<List<TodoItemEntity>> GetAllTodoItems()
        {
            var items = await _dbContext.TodoItems.ToListAsync();
            return items;
        }

        public TodoItemEntity GetTodoItemById(int id)
        {
            return  _dbContext.TodoItems.Find(id);

        }

        public async Task<TodoItemEntity> UpdateTodoItem(TodoItemEntity todoItem)
        {
            _dbContext.Update(todoItem);
            await _dbContext.SaveChangesAsync();
            return todoItem;
        }
    }
}
