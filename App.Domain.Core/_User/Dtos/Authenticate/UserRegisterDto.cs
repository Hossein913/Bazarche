using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core._User.Dtos.Authenticate
{
    public class UserRegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
