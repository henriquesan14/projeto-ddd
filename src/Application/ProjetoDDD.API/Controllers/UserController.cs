using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Service.Validators;
using ProjetoDDD.Domain.Interfaces;

namespace ProjetoDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService baseUserService)
        {
            _userService = baseUserService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _userService.Add<UserValidator>(user).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _userService.Update<UserValidator>(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _userService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _userService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _userService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
