using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        public TodoService(IServiceProvider serviceProvider) 
        {
            _repository = serviceProvider.GetRequiredService<ITodoRepository>();
        }

        public async Task<IActionResult> AddTodoAsync(TodoItem todo)
        {
           return await _repository.AddTodoAsync(todo);
        }

        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            return await _repository.DeleteTodoAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoAsync()
        {
            return await _repository.GetAllTodoAsync();
        }

        public async Task<TodoItem> GetTodoByIdAsync(int id)
        {
            return await _repository.GetTodoByIdAsync(id);
        }

        public async Task<IActionResult> UpdateTodoASync(TodoItem todo)
        {
            return await _repository.UpdateTodoASync(todo);
        }
    }
}
