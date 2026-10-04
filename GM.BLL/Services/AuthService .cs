using GM.BLL.DTOs.Authdto;
using GM.BLL.Interfaces;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _users;
        private readonly ITokenService _tokens;

        public AuthService(IUserRepository users, ITokenService tokens)
        {
            _users = users;
            _tokens = tokens;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var email = dto.Email.Trim().ToLowerInvariant();
            var user = await _users.GetByEmailAsync(email);

            // نفس النتيجة (null) سواء البريد خطأ أو كلمة المرور خطأ أو الحساب غير مفعّل
            if (user is null || user.IsActive != 1 || !PasswordMatches(dto.Password, user.Password))
                return null;
            if (user.ClubId is null)
                return null;
            var (token, expires) = _tokens.Create(user);

            return new LoginResponseDto
            {
                Token = token,
                ExpiresAt = expires,
                FullName = $"{user.FirstName} {user.LastName}",
            };
        }

        private static bool PasswordMatches(string plain, string stored)
        {
            // كلمة مرور مخزّنة كنص عادي: نرفض بدل أن ينهار BCrypt بخطأ 500
            if (!stored.StartsWith("$2")) return false;
            return BCrypt.Net.BCrypt.Verify(plain, stored);
        }
    }
}
