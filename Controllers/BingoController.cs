using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BingoController : ControllerBase
    {
        private IBingoService _bingoService;
        public BingoController(IBingoService bingoService)
        {
            _bingoService = bingoService;
        }

        [HttpGet]
        public IActionResult GetNumbers()
        {
            var numbers =  _bingoService.GetNumbers(isPlayed: false);
            return Ok(numbers);
        }

        [HttpPost]
        public IActionResult StartGame([FromBody]string gameName)
        {
            var game =  _bingoService.Start(gameName);
            return Ok(game);   
        }

        [HttpPut("{numValue}")]
        public IActionResult Update(string numValue)
        {
            try 
            {
                // save 
                _bingoService.Update(numValue);
                return Ok();
            } 
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        // MARK TO DO: MAKE DELETE CODE TO RESET GAME
        [HttpDelete("{id}")]
        public IActionResult Delete(string numValue)
        {
            _bingoService.Delete(numValue);
            return Ok();
        }
    }
}
