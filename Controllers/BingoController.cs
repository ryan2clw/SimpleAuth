using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Authorize]
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

        [HttpGet("{id}")]
        public IActionResult StartGame(string gameName)
        {
            var game =  _bingoService.Start(gameName);
            return Ok(game);   
        }

        [HttpPut("{id}")]
        public IActionResult Update(string numValue, bool isPlayed)
        {
            // map dto to entity and set id
            try 
            {
                // save 
                _bingoService.Update(numValue, isPlayed);
                return Ok();
            } 
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string numValue)
        {
            _bingoService.Delete(numValue);
            return Ok();
        }
    }
}
