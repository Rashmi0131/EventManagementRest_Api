using System.ComponentModel.DataAnnotations;

namespace EventManagementAPICRUD.DTO_s
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
