using WebApplication1.DataAccessLayer.Repositories.Interfaces;
using WebApplication1.Models;
using WebApplication1.DataAccessLayer.DatabaseContexts;
using WebApplication1.DataAccessLayer.Entities;

namespace WebApplication1.DataAccessLayer.Repositories.Implementation
{
    public class TodoImplementation : ITodoRepository
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

        public List<TodoItemEntity> GetAllTodoItems()
        {
            var items = _dbContext.TodoItems.ToList();
            return items;
        }

        public Task<TodoItemEntity> GetTodoItemById(int id)
        {
            return _dbContext.TodoItems.Find(id);

        }

        public TodoItemEntity UpdateTodoItem(TodoItemEntity todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
