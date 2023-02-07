using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    //DTO: data transfer object
    //auto bind: same property name(case unsensitive) is required.
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}