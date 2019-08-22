using System.ComponentModel.DataAnnotations;

namespace Nina.WebSite.Model
{
    public class AccountModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;

        public string Error { get; set; }
    }
}
