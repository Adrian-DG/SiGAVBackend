using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : PersonaModelMetadata
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool EsAdministrador { get; set; }
        public RolUsuario RolUsuario { get; set; }
        public ICollection<UsuarioPermiso> Permisos { get; set; }
    }
}