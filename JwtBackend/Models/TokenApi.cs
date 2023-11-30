using System;
using Microsoft.EntityFrameworkCore;
namespace JwtBackend.Models;

public class TokenApiDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }