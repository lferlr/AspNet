using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
  [ApiController]
  public class HomeController : ControllerBase
  {
    [HttpGet("/")]
    public IActionResult Get([FromServices] AppDbContext context)
    => Ok(context.Todos.ToList());

    [HttpPost("/")]
    public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {

      context.Todos.Add(todo);
      context.SaveChanges();
      return Created($"/{todo.Id}", todo);
    }

    [HttpGet("/{id}")]
    public IActionResult GetById(int id, [FromServices] AppDbContext context)
    {
      var todos = context.Todos.FirstOrDefault(x => x.Id == id);

      if (todos == null)
        return NotFound();

      return Ok(todos);
    }

    [HttpPut("/{id}")]
    public IActionResult Put(int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
      var model = context.Todos.FirstOrDefault(x => x.Id == id);
      if (model == null)
        return NotFound();

      model.Title = todo.Title;
      model.Done = todo.Done;

      context.Todos.Update(model);
      context.SaveChanges();

      return Ok(model);
    }

    [HttpDelete("/{id}")]
    public IActionResult Delete(int id, [FromServices] AppDbContext context)
    {
      var model = context.Todos.FirstOrDefault(x => x.Id == id);

      if (model == null)
        return NotFound();

      context.Todos.Remove(model);
      context.SaveChanges();

      return Ok(model);
    }
  }
}