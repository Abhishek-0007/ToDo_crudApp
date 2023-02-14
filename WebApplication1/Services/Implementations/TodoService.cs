using WebApplication1.DataAccessLayer.Entities;
using WebApplication1.DataAccessLayer.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class TodoService : ITodoService
    {
        private ITodoRepositoryInterface _repository;

        public TodoService(ITodoRepositoryInterface repository) { _repository = repository; }
        public async Task<TodoItemEntity> AddTodoItem(TodoItemEntity todoItem)
        {
           await _repository.AddTodoItem(todoItem);
           return todoItem;

        }

        public TodoItemEntity DeleteTodoItem(int id)
        {
            TodoItemEntity todoItem = _repository.GetTodoItemById(id);
            if(todoItem != null) { _repository.DeleteTodoItem(id); }

            return todoItem;
        }

        public Task<List<TodoItemEntity>> GetAllTodoItems()
        {
            return _repository.GetAllTodoItems();
        }

        public TodoItemEntity GetTodoItemById(int id)
        {
            TodoItemEntity todoItem = _repository.GetTodoItemById(id);
            return todoItem;
        }

        public async Task<TodoItemEntity> UpdateTodoItem(TodoItemEntity todoItem)
        {
            await _repository.UpdateTodoItem(todoItem);
            return todoItem;
        }
    }
}
