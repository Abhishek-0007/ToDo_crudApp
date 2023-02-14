
using WebApplication1.DataAccessLayer.Entities;

namespace WebApplication1.DataAccessLayer.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        TodoItemEntity GetTodoItemById(int id);
        Task<TodoItemEntity> AddTodoItem(TodoItemEntity todoItem);
        Task<TodoItemEntity> UpdateTodoItem(TodoItemEntity todoItem);
        TodoItemEntity DeleteTodoItem(int id);
        Task<List<TodoItemEntity>> GetAllTodoItems();


    }
}
