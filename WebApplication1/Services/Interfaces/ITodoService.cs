using WebApplication1.DataAccessLayer.Entities;
using WebApplication1.Models.RequestViewModel;
using WebApplication1.Models.ResponseViewModel;

namespace WebApplication1.Services.Interfaces
{
    public interface ITodoService
    {
        TodoResponseViewModel GetTodoItemById(int id);
        Task<TodoResponseViewModel> AddTodoItem(TodoRequestViewModel todoItem);
        public TodoResponseViewModel UpdateTodoItem(TodoRequestViewModel todoItem);
        public void DeleteTodoItem(int id);
        List<TodoResponseViewModel> GetAllTodoItems();

    }
}
