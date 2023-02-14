using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccessLayer.Entities;
using WebApplication1.Models.RequestViewModel;
using WebApplication1.Models.ResponseViewModel;
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
        public async Task<ActionResult<IEnumerable<TodoResponseViewModel>>> GetTodoItems()
        {
            return _service.GetAllTodoItems();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponseViewModel>> GetTodoItem(int id)
        {
            return _service.GetTodoItemById(id);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoRequestViewModel todoItem)
        {
            var item = _service.GetAllTodoItems().Find(x => x.Id == id);

            if (item.Id != todoItem.Id)
            {
                return BadRequest();
            }
            else
            {
                _service.UpdateTodoItem(todoItem);
                return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            }

            
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodoItem(TodoRequestViewModel todoItem)
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
            var listItems = _service.GetAllTodoItems();
            return listItems.Any(e => e.Id == id);
        }
    }
}
