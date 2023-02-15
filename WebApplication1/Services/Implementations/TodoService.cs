using WebApplication1.DataAccessLayer.Entities;
using WebApplication1.DataAccessLayer.Repositories.Interfaces;
using WebApplication1.Models.RequestViewModel;
using WebApplication1.Models.ResponseViewModel;
using WebApplication1.Services.Interfaces;
using WebApplication1.Extensions;


namespace WebApplication1.Services.Implementations
{
    public class TodoService : ITodoService
    {
        private ITodoRepositoryInterface _repository;

        public TodoService(ITodoRepositoryInterface repository) { _repository = repository; }

        Todo todo = new Todo();

        public async Task<TodoResponseViewModel> AddTodoItem(TodoRequestViewModel todoItem)
        {
            var obj = todoItem.PropertyValueExtensionMethod<TodoRequestViewModel, Todo>() as Todo;
            await _repository.AddTodoItem(obj);
            return todo.PropertyValueExtensionMethod<Todo, TodoResponseViewModel>() as TodoResponseViewModel;
        }

        public TodoResponseViewModel UpdateTodoItem(TodoRequestViewModel todoItem)
        {
            var obj = todoItem.PropertyValueExtensionMethod<TodoRequestViewModel, Todo>() as Todo;
            _repository.UpdateTodoItem(obj);    

            return obj.PropertyValueExtensionMethod<Todo, TodoResponseViewModel>() as TodoResponseViewModel;
        }

        public void DeleteTodoItem(int id)
        {
            todo = _repository.GetAllTodoItems().Result.Where(t => t.Id.Equals(id)).FirstOrDefault();
            if (todo != null) { _repository.DeleteTodoItem(id); }

        }

 

        TodoResponseViewModel ITodoService.GetTodoItemById(int id)
        {
            todo = _repository.GetAllTodoItems().Result.Where(t => t.Id.Equals(id)).FirstOrDefault();
            return todo.PropertyValueExtensionMethod<Todo, TodoResponseViewModel>() as TodoResponseViewModel;
        }

        List<TodoResponseViewModel> ITodoService.GetAllTodoItems()
        {
            var items = _repository.GetAllTodoItems().Result;
            List<TodoResponseViewModel> result = new List<TodoResponseViewModel>();

            foreach (Todo item in items)
            {
                var obj = item.PropertyValueExtensionMethod<Todo, TodoResponseViewModel>() as TodoResponseViewModel;

                result.Add(obj);
            }

            return result;
        }
    }
}
