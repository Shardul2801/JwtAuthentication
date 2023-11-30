using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtBackend.Models
{
    public class User
    {
        public int? UserId {get;set;}
        public string? UserName{get;set;}
        public string? UserEmail {get;set;}
        public string? MobileNumber {get;set;}
        public string? Password {get;set;}
        public string? Role {get;set;}
        public string? Token{get;set;}
        public string? RefreshToken{get;set;}
        public DateTime? RefreshTokenExpiryTime{get;set;}
        public DateTime? Created_at{get;set;}
        public DateTime? Modified_at{get;set;}
        public string? Created_by {get;set;}
        public string? Modified_by {get;set;}
        public bool? isDeleted {get;set;}
    }
}