using EFRelations.Data;
using EFRelations.Dto;
using EFRelations.Dto.Character;
using EFRelations.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters
                .Where(c => c.UserId == userId)
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .ToListAsync();

            return characters;
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacterDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null) { return(NotFound()); }

            var newCharacter = new Character
            {
                name = request.Name,
                RPGClass = request.RpgClass,
                User = user,
            };
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            return await Get(newCharacter.UserId);
        }

        [HttpPost("weapon")]
        public async Task<ActionResult<Character>> AddWeapon(CreateWeaponDto request)
        {
            var character = await _context.Characters.FindAsync(request.ChracterId);
            if (character == null) { return NotFound(); }

            var newWeapon = new Weapon
            {
                Name = request.Name,
                Damage = request.Damage,
                character = character,
            };
            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();
            return character;
        }

        [HttpPost("skill")]
        public async Task<ActionResult<Character>> AddSkill(CreateSkillDto request)
        {
            var character = await _context.Characters.Where(c => c.id == request.CharacterId)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync();
            if (character == null) { return NotFound(); }

            var skill = await _context.Skills.FindAsync(request.SkillId);
            if(skill == null) { return NotFound(); }

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}
