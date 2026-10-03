using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GM.BLL.DTOs.Authdto
{
    public class CreateUserDto
    {
        [Required, StringLength(50)] public string FirstName { get; set; } = null!;
        [Required, StringLength(50)] public string LastName { get; set; } = null!;
        [Required, StringLength(20)] public string PhoneNumber { get; set; } = null!;
        [Range(16, 100)] public int Age { get; set; }
        [StringLength(255)] public string? Address { get; set; }
        [Required, EmailAddress, StringLength(100)] public string Email { get; set; } = null!;
        [Required, StringLength(72, MinimumLength = 8)] public string Password { get; set; } = null!;
    }
}
