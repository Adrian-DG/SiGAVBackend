using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class LoginResponse : ServerResponse
    {
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }
        public bool EsAdministrador { get; set; }
        public List<int> Permisos { get; set; }
    }
}