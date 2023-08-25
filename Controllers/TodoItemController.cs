using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ToDo;
using System.Collections.Generic;


namespace ToDoAPI.Controllers
{
    //Create a controller class for the TodoItems

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly Repository _repository;

        public TodoItemController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return Ok(_repository.GetTodoItems());
        }

        //Read
        //[HttpGet(Name = "GetTodoItem")]
        //public IEnumerable<TodoItem> Get()
        //{
        //    var todoItem = _todoItemRepository.GetAll();
        //    return todoItem;
        //}

        [HttpPost]
        public ActionResult<TodoItem> AddTodoItem(TodoItem todoItem)
        {
            return Ok(_repository.AddTodoItem(todoItem));
        }

        //Create
        //[HttpPost("/create-customer-using-params")]
        //public IActionResult CreateTodo(int id, string task, object todoItemRepository)
        //{
        //    var myTodoItem = new TodoItem
        //    {
        //        Id = 0,
        //        Task = "",
        //    };

        //    //_todoItemRepository.Add(myTodoItem);
        //    return Ok(myTodoItem.Id);
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _repository.UpdateTodoItem(todoItem);

            return NoContent();
        }

        //Update
        //[HttpPut("/update-first-name")]
        //public IActionResult UpdateCustomerDetails(int id, string task)
        //{
        //    var todoitem = _todoItemRepository.GetById(id);
        //    if (todoitem == null)
        //    {
        //        return BadRequest();
        //    }

        //    //todoitem.Id = 0;
        //    //todoitem.Task = "";

        //    _todoItemRepository.Update(todoitem);
        //    return Ok(todoitem);
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(int id)
        {
            var todoItem = _repository.GetTodoItem(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _repository.DeleteTodoItem(todoItem);

            return NoContent();
        }

        //Delete
        //[HttpDelete("/delete-user")]
        //public IActionResult DeleteUserById(int id)
        //{
        //    var todoItem = _todoItemRepository.GetById(id);
        //    if (todoItem == null)
        //    {
        //        return BadRequest();
        //    }

        //    _todoItemRepository.DeleteById(id);
        //    return Ok(todoItem);
        //}

        //private readonly TodoItemRepository _todoItemRepository;
    }

}