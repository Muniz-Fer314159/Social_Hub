using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

[ApiController]
[Route("api/[Controller]")]

public class UserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManeger;

    public UserController(UserManager<ApplicationUser> userManeger)
    {
        _userManeger = userManeger;
    }

    [HttpPut("Profile")]
    [Authorize]

public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfile dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
        {
            return Unauthorized();
        }

        var user = await _userManeger.FindByIdAsync(userId);
            if(user == null)
        {
            return NotFound();
        }

        user.Bio = dto.Bio;
        if (dto.DateOfBirth.HasValue)
        {
            user.DateOfBirth = dto.DateOfBirth.Value;
        }
        
        if (dto.ProfilePictureUrl != null)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(dto.ProfilePictureUrl.FileName);

        var path = Path.Combine("wwwroot/profilePictures", fileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await dto.ProfilePictureUrl.CopyToAsync(stream);
        }

        user.ProfilePictureUrl = "/profilePictures/" + fileName;
    }

            await _userManeger.UpdateAsync(user);

            return Ok ("Perfil Criado com sucesso");
    }  

}
