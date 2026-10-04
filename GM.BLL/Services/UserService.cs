using GM.BLL.DTOs.Authdto;
using GM.BLL.DTOs.UserDto;
using GM.BLL.Interfaces;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GM.BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _users;
        public UserService(IUserRepository users) => _users = users;

        public async Task<string?> RegisterAsync(CreateUserDto dto)
        {
            var email = dto.Email.Trim().ToLowerInvariant();

            if (await _users.EmailExistsAsync(email))
                return "EMAIL_EXISTS";

            var user = new User
            {
                FirstName = dto.FirstName.Trim(),
                LastName = dto.LastName.Trim(),
                PhoneNumaer = dto.PhoneNumber.Trim(),
                Age = dto.Age,
                Adress = dto.Address?.Trim(),
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),   // التشفير هنا
                IsActive = 0,   // ينتظر موافقة الأدمن
            };

            await _users.AddAsync(user);
            return null;
        }
    }
}
