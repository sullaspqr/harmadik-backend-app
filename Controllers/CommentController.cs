using harmadik_backend_app.Models;
using harmadik_backend_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace harmadik_backend_app.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    public CommentController()
    {
    }

    [HttpGet]
public ActionResult<List<Comment>> GetAll() =>
    CommentService.GetAll();

    [HttpGet("{id}")]
public ActionResult<Comment> Get(int id)
{
    var comment = CommentService.Get(id);

    if(comment == null)
        return NotFound();

    return comment;
}

 
 [HttpPost]
public IActionResult Create(Comment comment)
{            
    CommentService.Add(comment);
    return CreatedAtAction(nameof(Get), new { id = comment.Id }, comment);
}

 [HttpPut("{id}")]
public IActionResult Update(int id, Comment comment)
{
    if (id != comment.Id)
        return BadRequest();
           
    var existingComment = CommentService.Get(id);
    if(existingComment is null)
        return NotFound();
   
    CommentService.Update(comment);           
   
    return NoContent();
}

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var comment = CommentService.Get(id);
   
    if (comment is null)
        return NotFound();
       
    CommentService.Delete(id);
   
    return NoContent();
}
}