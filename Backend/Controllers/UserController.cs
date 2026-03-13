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
    
public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfile dto)
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
        user.DateOfBirth = dto.DateOfBirth;
        user.ProfilePictureUrl = dto.ProfilePictureUrl;

            await _userManeger.UpdateAsync(user);

            return Ok ("Perfil Criado com sucesso");
    }  

}
