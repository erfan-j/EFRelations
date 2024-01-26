namespace EFRelations.Dto.Character
{
    public class CreateCharacterDto
    {
        //! we dont need id here
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "knight";
        public int UserId { get; set; } = 1;
    }
}
