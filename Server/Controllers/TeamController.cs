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
    public class TeamController : Controller
    {
        private ITeamRepository _teamRepository;
        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        [Route("GetAllTeams")]
        public async Task<IActionResult> getAllTeams()
        {

            try
            {
                return Ok(await _teamRepository.getAllTeams());
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

        [HttpGet]
        [Route("GetSingleTeam")]
        public async Task<IActionResult> getTeam(string id)
        {
            try
            {
                return Ok(await _teamRepository.getTeam(id));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }


        [HttpPost]
        [Route("AddTeam")]
        public async Task<IActionResult> AddTeam(Team team)
        {

            try
            {
                await _teamRepository.addTeam(team);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }


        [HttpPut]
        [Route("UpdateTeam")]
        public async Task<IActionResult> UpdateTeam(Team team)
        {

            try
            {
                await _teamRepository.updateTeam(team);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

        [HttpDelete]
        [Route("RemoveTeam")]
        public async Task<IActionResult> RemoveTeam(string id)
        {

            try
            {
                await _teamRepository.removeTeam(id);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

    }
}
