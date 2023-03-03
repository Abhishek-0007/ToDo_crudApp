using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoItemsController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.GetRequiredService<ITodoService>();
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return await _service.GetAllTodoAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<TodoItem> GetTodoItem(int id)
        {
           return await _service.GetTodoByIdAsync(id);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutTodoItem(TodoItem todoItem)
        {

            return await _service.UpdateTodoASync(todoItem);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTodoItem(TodoItem todoItem)
        {
            return await _service.AddTodoAsync(todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            return await _service.DeleteTodoAsync(id);
        }
    }
}
