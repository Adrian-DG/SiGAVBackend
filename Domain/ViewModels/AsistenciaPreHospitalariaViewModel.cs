using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class AsistenciaPreHospitalariaViewModel
	{
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string Ficha { get; set; }
        public string Denominacion { get; set; }
    }
}
