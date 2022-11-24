using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain;
using API.DTOs;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountCotroller : ControllerBase
{
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
    public AccountCotroller(UserManager<AppUser> userManager, 
        SignInManager<AppUser> signInManager)
    {
            _userManager = userManager;
            _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);    

        if (user == null) return Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if(result.Succeeded)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Image = null,
                Token = "This is a token",
                Username = user.UserName
            };
        }

        return Unauthorized();
    }
}
