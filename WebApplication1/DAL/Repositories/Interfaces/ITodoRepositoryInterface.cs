
using WebApplication1.DataAccessLayer.Entities;

namespace WebApplication1.DataAccessLayer.Repositories.Interfaces
{
    public interface ITodoRepositoryInterface
    {
        Todo GetTodoItemById(int id);
        Task<Todo> AddTodoItem(Todo todoItem);
        Task<Todo> UpdateTodoItem(Todo todoItem);
        Todo DeleteTodoItem(int id);
        Task<List<Todo>> GetAllTodoItems();

    }
}
