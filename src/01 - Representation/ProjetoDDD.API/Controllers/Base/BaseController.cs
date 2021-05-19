using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDDD.API.Controllers.Base
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult CustomResponse(object obj)
        {
            if(obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
    }
}
