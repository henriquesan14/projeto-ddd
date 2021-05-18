using System;
using Microsoft.AspNetCore.Mvc;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Application.DTOs;
using System.Threading.Tasks;
using ProjetoDDD.API.Controllers.Base;

namespace ProjetoDDD.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO user)
        {
            UserDTO userDto = await _userApplication.Add(user);
            return Created(new Uri($"{Request.Path}/{user.Id}", UriKind.Relative), userDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreateUserDTO user)
        {
            await _userApplication.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userApplication.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CustomResponse(await _userApplication.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CustomResponse(await _userApplication.GetById(id));
        }

    }
}
