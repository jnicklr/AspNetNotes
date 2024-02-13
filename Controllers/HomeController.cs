using AspNetNotes.Data;
using AspNetNotes.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetNotes.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] DataContext context) 
            => Ok(context.Todos.ToList());

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromServices] DataContext context, [FromRoute] int id)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

        [HttpPost("/")]
        public IActionResult Post([FromServices] DataContext context, [FromBody] Todo todo)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return Created($"/{todo.Id}", todo);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put([FromServices] DataContext context, [FromBody] Todo todo, [FromRoute] int id)
        {
            var updatedTodo = context.Todos.FirstOrDefault(x => x.Id == id);

            if (updatedTodo == null)
                return NotFound();

            updatedTodo.Title = todo.Title;
            updatedTodo.Done = todo.Done;

            context.Todos.Update(updatedTodo);
            context.SaveChanges();

            return Ok(updatedTodo);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromServices] DataContext context, [FromRoute] int id)
        {
            var deletedTodo = context.Todos.FirstOrDefault(x => x.Id == id);

            if (deletedTodo == null)
                return NotFound();

            context.Todos.Update(deletedTodo);
            context.SaveChanges();
            return Ok(deletedTodo);
        }
    }
}
