using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CreateUserDTO : PersonaModelMetadata
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EsAdministrador { get; set; }
        public RolUsuario RolUsuario { get; set; }
    }
}