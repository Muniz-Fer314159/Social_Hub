namespace Backend.Models;
public class Comment
{
    public int Id {get; set;}
    public string Text {get; set;} = null!;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

    public int PostId {get; set;}
    public Post Post {get; set;} = null!;
    
    public string UserId {get; set;} = null!;
    public ApplicationUser User {get; set;} = null!;

}