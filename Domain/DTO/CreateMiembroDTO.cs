﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class CreateMiembroDTO : PersonaModelMetadata
	{
		public int RangoId { get; set; }
		public Institucion Institucion { get; set; }
		public PerteneceA PerteneceA { get; set; }
		public bool AccesoTotal { get; set; } = false;
	}
}
