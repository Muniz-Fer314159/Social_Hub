public class UpdateProfile
{
    public string? Bio {get; set;}
    public IFormFile? ProfilePictureUrl {get; set;}
    public DateOnly? DateOfBirth {get; set;}
}
