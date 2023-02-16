
using WebApplication1.DataAccessLayer.Entities;

namespace WebApplication1.DataAccessLayer.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Todo GetTodoItemById(int id);
        Task<Todo> AddTodoItem(Todo todoItem);
        Task<Todo> UpdateTodoItem(Todo todoItem);
        public void DeleteTodoItem(int id);
        Task<List<Todo>> GetAllTodoItems();

    }
}
