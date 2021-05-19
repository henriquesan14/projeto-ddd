using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDD.Application.DTOs
{
    public class UserDTO : BaseDTO
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
