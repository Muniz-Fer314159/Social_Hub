using Microsoft.AspNetCore.Identity;

public class AplicationUser : IdentityUser
{
    public string? FullName {get; set;}
    public string? Bio {get; set;}
    public string? ProfilePictureUrl {get; set;}
    public DateTime DateOfBirth {get; set;}

    public ICollection<Post> Posts {get; set;} = new List<Post>();
    public ICollection<Comment> Comments {get; set;} = new List<Comment>();
    public ICollection<Like> Likes {get; set;} = new List<Like>();
}







