using Microsoft.AspNetCore.Mvc;
using SD_725_Final.Models;

namespace SD_725_Final.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Races = Enum.GetValues(typeof(Race));
            ViewBag.Classes = Enum.GetValues(typeof(Class));
            return View(new Character());
        }
        [HttpPost]
        public IActionResult GenerateCharacter(Character character)
        {
            character.RollAbilities();
            return View("CharacterDetails", character);
        }
    }
}
