using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventManagementAPICRUD.DTO_s
{
    public class UserDTO
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }
        [JsonIgnore]
        public int? CreatedBy { get; set; }
        [JsonIgnore]
        public int? UpdatedBy { get; set; }
        [JsonIgnore]
        public int? CreatedDate { get; set; }
        [JsonIgnore]
        public int? UpdatedDate { get; set; }
    }
}
