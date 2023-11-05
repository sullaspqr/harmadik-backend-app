namespace harmadik_backend_app.Models;

public class Comment
{
    public int postId { get; set; }
    public int Id { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }
    public string? body { get; set; }
}