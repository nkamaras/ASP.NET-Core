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
    public class StadiumController : Controller
    {

        private IStadiumRepository _stadiumRepository;

        public StadiumController(IStadiumRepository stadiumRepository)
        {
            _stadiumRepository = stadiumRepository;
        }

        [HttpGet]
        [Route("GetAllStadiums")]
        public async Task<IActionResult> getAllStadiums() {

            try {
                return Ok(await _stadiumRepository.getAllStadiums());
            }
            catch (Exception ex) {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

        [HttpGet]
        [Route("GetStadium")]
        public async Task<IActionResult> getStadium(string id)
        {
            try
            {
                return Ok(await _stadiumRepository.getStadium(id));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }


        [HttpPost]
        [Route("AddStadium")]
        public async Task<IActionResult> AddStadium(Stadium stadium)
        {

            try
            {
               await  _stadiumRepository.addStadium(stadium);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }


        [HttpPut]
        [Route("UpdateStadium")]
        public async Task<IActionResult> UpdateStadium(Stadium stadium)
        {

            try
            {
                await _stadiumRepository.updateStadium(stadium);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }

        [HttpDelete]
        [Route("RemoveStadium")]
        public async Task<IActionResult> RemoveStadium(string id)
        {

            try
            {
                await _stadiumRepository.removeStadium(id);
                return StatusCode(((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }

        }


    }
}
