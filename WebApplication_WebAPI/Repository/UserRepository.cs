﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication_WebAPI.Data;
using WebApplication_WebAPI.Models;
using WebApplication_WebAPI.Repository.IRepository;

namespace WebApplication_WebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbcontext _context;
        private readonly AppSettings _appSettings;
        public UserRepository(ApplicationDbcontext context,IOptions<AppSettings> appSettings)
        {
            _context = context;   
            _appSettings = appSettings.Value;
        }
        public User Authenticate(string username, string password)
        {
            var userInDb = _context.Users.FirstOrDefault(u=> u.UserName == username && u.Password ==password);
            if (userInDb ==null) return null;

            //JWT Authentication         
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name,userInDb.Id.ToString()),
                        new Claim(ClaimTypes.Role,userInDb.Role)
                        
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            userInDb.Token = tokenHandler.WriteToken(token);
            //**
            userInDb.Password = "";
            return userInDb;

         }

        public bool IsUniqueUser(string username)
        {
            var user = _context.Users.FirstOrDefault(u=>u.UserName == username);
            if (user == null)
                return true;
            else
                return false;
        }

        public User Register(string username, string password)
        {
            User user = new User()
            {
                UserName = username,
                Password = password,
                Role = "Admin"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
