using System.Text.Json.Serialization;

namespace EFRelations.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;
        [JsonIgnore]
        public Character character { get; set; }
        public int CharacterId { get; set; }
    }
}
