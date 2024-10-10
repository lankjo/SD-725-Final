using Microsoft.AspNetCore.Mvc;
namespace SD_725_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiceController : ControllerBase

    {
        [HttpGet("roll/{dice}")]

        public IActionResult RollDice(string dice)
        {
            try
            {
                var parts = dice.Split('d');

                if (parts.Length != 2 || !int.TryParse(parts[0], out int count) || !int.TryParse(parts[1], out int sides))
                {
                    return BadRequest("Invalid dice format. Use the format 'XdY' (e.g., '3d6').");
                }

                int total = 0;

                Random rand = new Random();
                for (int i = 0; i < count; i++)
                {
                    total += rand.Next(1, sides + 1);
                }

                return Ok(new { Rolls = count, Sides = sides, Total = total });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}