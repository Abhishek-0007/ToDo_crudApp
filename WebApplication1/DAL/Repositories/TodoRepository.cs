using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DAL.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;
        public TodoRepository(IServiceProvider serviceProvider) 
        {
            _context = serviceProvider.GetRequiredService<TodoContext>();
        }

        public async Task<IActionResult> AddTodoAsync(TodoItem todo)
        {
            try
            {
                if (!_context.TodoItems.Where(t => t.Id.Equals(todo.Id)).Any())
                {
                    await _context.TodoItems.AddAsync(todo);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else { return new BadRequestResult(); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return new BadRequestResult(); }
        }

        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            try
            {
                var item = await _context.TodoItems.Where(item => item.Id.Equals(id)).FirstOrDefaultAsync();
                if (item != null)
                {
                    _context.TodoItems.Remove(item);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else { return new BadRequestResult(); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return new BadRequestResult(); }
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoAsync()
        {
            try
            {
                return await _context.TodoItems.ToListAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<TodoItem>();
            }
        }

        public async Task<TodoItem> GetTodoByIdAsync(int id)
        {
            try
            {
                var item = await _context.TodoItems.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
                if (item != null)
                {
                    return item;
                }
                else { return null; }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
        }

        public async Task<IActionResult> UpdateTodoASync(TodoItem todo)
        {
            try
            {
                if (_context.TodoItems.Where(t => t.Id.Equals(todo.Id)).Any())
                {
                    _context.TodoItems.Update(todo);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else { return new BadRequestResult(); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return new BadRequestResult(); }
        }
    }
}
