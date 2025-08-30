using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebWorker.Data;
using WebWorker.Data.Entities.Identity;
using WebWorker.Models.Users;

namespace WebWorker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(AppWorkerDbContext appDbContext,
    UserManager<UserEntity> userManager) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> GetUsers()
    {
        var users = appDbContext.Users
            .Select(x => new UserItemModel
            {
                Id = x.Id,
                FullName = $"{x.FirstName ?? string.Empty} {x.LastName ?? string.Empty}",
                Email = x.Email ?? string.Empty,
                Image = x.Image,
                Roles = x.UserRoles!
                        .Select(r => r.Role!.Name ?? string.Empty)
                        .ToArray()
            })
            .ToList();
        return Ok(users);
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostUser([FromForm] UserCreateModel model)
    {
        var user = new UserEntity
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        var result = await userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        return Ok(user.Id);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return NotFound();
        }
        var result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        return NoContent();
    }
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromForm] UserUpdateModel model)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return NotFound();
        }
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        return NoContent();
    }

}
