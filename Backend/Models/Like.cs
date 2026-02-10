namespace Backend.Models;
public class Like
{
    public int PostId {get; set;}
    public Post Post {get; set;} = null!;

    public string UserId {get; set;} = null!;
    public ApplicationUser User {get; set;} = null!;
}