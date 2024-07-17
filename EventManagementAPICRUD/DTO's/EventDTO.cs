using System.Text.Json.Serialization;

namespace EventManagementAPICRUD.DTO_s
{
    public class EventDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Location { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Organizer { get; set; } = null!;

        [JsonIgnore]
        public int? Created_By { get; set; }
        [JsonIgnore]
        public DateTime? Created_Date { get; set; }

        [JsonIgnore]
        public int? Update_By { get; set; }

        [JsonIgnore]
        public DateTime? Update_Date { get; set; }
    }
}
