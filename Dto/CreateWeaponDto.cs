namespace EFRelations.Dto
{
    public class CreateWeaponDto
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;
        public int ChracterId { get; set; } = 1;
    }
}
