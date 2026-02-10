namespace Backend.Models;
public class Post
{
    public int Id {get; set;}
    public string Content {get; set;} = null!;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

    public string UserId {get; set;} = null!;
    public ApplicationUser User {get; set;} = null!;
    public ICollection<Comment> Comments {get; set;} = new List<Comment>();
    public ICollection<Like> Likes {get; set;} = new List<Like>();
}