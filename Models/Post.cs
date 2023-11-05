namespace harmadik_backend_app.Models;

public class Post
{
    public int userId { get; set; }
    public int Id { get; set; }
    public string? title { get; set; }
    public string? body { get; set; }
}