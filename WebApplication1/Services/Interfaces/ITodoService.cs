using WebApplication1.DataAccessLayer.Entities;

namespace WebApplication1.Services.Interfaces
{
    public interface ITodoService
    {
        TodoItemEntity GetTodoItemById(int id);
        Task<TodoItemEntity> AddTodoItem(TodoItemEntity todoItem);
        Task<TodoItemEntity> UpdateTodoItem(TodoItemEntity todoItem);
        TodoItemEntity DeleteTodoItem(int id);
        Task<List<TodoItemEntity>> GetAllTodoItems();

    }
}
