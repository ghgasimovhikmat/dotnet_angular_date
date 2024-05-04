using System.ComponentModel.DataAnnotations;

namespace DateVoyage.DTOs
{
    public class LoginDto
    {
        public string UserName { get; set; }
      
        public string Password { get; set; }
    }
}
