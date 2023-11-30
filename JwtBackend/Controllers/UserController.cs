using AngularAuthYtAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Text;
using AngularAuthYtAPI.Context;
using Microsoft.EntityFrameworkCore;
using AngularAuthYtAPI.Helpers;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using JwtBackend.Models;

namespace JwtBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;
        public UserController(AppDbContext _context){
            context = _context;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj){
             if (userObj == null)
                return BadRequest();

            var user = await context.Users
                .FirstOrDefaultAsync(x => x.Username == userObj.Username);

            if (user == null)
                return NotFound(new { Message = "User not found!" });

            user.Token = CreateJwt(user);
            var newAccessToken = user.Token;
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(5);
            await _authContext.SaveChangesAsync();
        }
    }
}