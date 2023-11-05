using harmadik_backend_app.Models;
using harmadik_backend_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace harmadik_backend_app.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    public PostController()
    {
    }

    [HttpGet]
public ActionResult<List<Post>> GetAll() =>
    PostService.GetAll();

    [HttpGet("{id}")]
public ActionResult<Post> Get(int id)
{
    var post = PostService.Get(id);

    if(post == null)
        return NotFound();

    return post;
}

 
 [HttpPost]
public IActionResult Create(Post post)
{            
    PostService.Add(post);
    return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
}

 [HttpPut("{id}")]
public IActionResult Update(int id, Post post)
{
    if (id != post.Id)
        return BadRequest();
           
    var existingPost = PostService.Get(id);
    if(existingPost is null)
        return NotFound();
   
    PostService.Update(post);           
   
    return NoContent();
}

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var post = PostService.Get(id);
   
    if (post is null)
        return NotFound();
       
    PostService.Delete(id);
   
    return NoContent();
}
}