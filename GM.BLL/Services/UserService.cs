using GM.BLL.DTOs.UserDto;
using GM.BLL.Interfaces;
using GM.DAL.Domain;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace GM.BLL.Services
{
    public class UserService: IUserService
    {

       readonly private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
          _userRepository = userRepository;
        }
      public  async Task<bool> Register(UserDto userDto)
        {

            var passwordHasher = new PasswordHasher<User>();
            var user = new User
            {
                Email = userDto.Email,
                Adress = userDto.Adress,

                // الخصائص الإضافية المطلوبة لتجنب أخطاء Validation و Null Reference
                FirstName = userDto.FirstName ?? "DefaultFirstName",
                LastName = userDto.LastName ?? "DefaultLastName",
                PhoneNumaer = userDto.PhoneNumaer ?? "0000000000",
                Password  = passwordHasher.HashPassword(null!, userDto.Password),
                Age = userDto.Age,
                IsActive = 1 // 1 للحيوي/النشط أو 0 للغير نشط
            };


            return await _userRepository.RegisterAsync(user);
                }

    }
}
