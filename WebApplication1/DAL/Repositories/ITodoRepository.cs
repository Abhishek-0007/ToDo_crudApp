using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.DAL.Repositories
{
    public interface ITodoRepository
    {
        public Task<IActionResult> AddTodoAsync(TodoItem todo);
        public Task<IActionResult> UpdateTodoASync(TodoItem todo);
        public Task<IActionResult> DeleteTodoAsync(int id);
        public Task<IEnumerable<TodoItem>> GetAllTodoAsync();
        public Task<TodoItem> GetTodoByIdAsync(int id);
    }
}
