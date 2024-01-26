using System.Text.Json.Serialization;

namespace EFRelations.Models;

public class Character
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string RPGClass { get; set; } = "knight";
    [JsonIgnore]
    public User User { get; set; }
    public int UserId { get; set; }
    public Weapon Weapon { get; set; }
    //public int WeaponId { get; set; }
    public List<Skill> Skills{ get; set; }

}