using BillyUserApi.Models;
using BillyUserApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillyUserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _userService;

    public UsersController(UsersService usersService) => _userService = usersService;

    [HttpGet]
    public async Task<List<User>> Get() => await _userService.Get();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _userService.Get(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }
    [HttpGet("{email}")]
    public async Task<ActionResult<User>> GetByEmail(string email)
    {
        var user = await _userService.GetByEmail(email);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _userService.Create(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    [HttpPut]
    public async Task<IActionResult> Update(User updatedUser)
    {
        await _userService.Update(updatedUser);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _userService.Remove(id);

        return NoContent();
    }

}