using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer;
using WebApplication1.DataAccessLayer.Entities;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoItemsController(ITodoService service)
        {
            _service = service;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemEntity>>> GetTodoItems()
        {
            return await _service.GetAllTodoItems();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemEntity>> GetTodoItem(int id)
        {
            var todoItem = _service.GetTodoItemById(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItemEntity todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            await _service.UpdateTodoItem(todoItem);

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemEntity>> PostTodoItem(TodoItemEntity todoItem)
        {
            await _service.AddTodoItem(todoItem);

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem =  _service.GetTodoItemById(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _service.DeleteTodoItem(id);

            return NoContent();
        }

        private bool TodoItemExists(int id)
        {
            var listItems = _service.GetAllTodoItems().Result;
            return listItems.Any(e => e.Id == id);
        }
    }
}
