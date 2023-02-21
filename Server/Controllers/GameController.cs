using Microsoft.AspNetCore.Mvc;
using DemoApp.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using DemoApp.Shared.Models;


namespace DemoApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {

        private IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        [Route("GetAllGames")]
        public async Task<IActionResult> getAllGames()
        {

            try
            {
                return Ok(await _gameRepository.getAllGames());
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

        [HttpGet]
        [Route("GetSingleGame")]
        public async Task<IActionResult> GetSingleGame(string id)
        {

            try
            {
                return Ok(await _gameRepository.getGame(id));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }


        [HttpDelete]
        [Route("RemoveGame")]
        public async Task<IActionResult> RemoveGame(string id)
        {

            try
            {
                await _gameRepository.removeGame(id);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

        [HttpPost]
        [Route("AddGame")]
        public async Task<IActionResult> AddGame(Game game)
        {

            try
            {
                await _gameRepository.addGame(game);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

        [HttpPut]
        [Route("UpdateGame")]
        public async Task<IActionResult> UpdateGame(Game game)
        {

            try
            {
                await _gameRepository.updateGame(game);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

    }
}
