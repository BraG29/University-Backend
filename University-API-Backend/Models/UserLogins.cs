using Microsoft.Build.Framework;

namespace University_API_Backend.Models
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
