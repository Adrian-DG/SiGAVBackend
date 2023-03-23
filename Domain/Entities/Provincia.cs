using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provincia : NombreModelMetadata
    {
        public RegionMacro RegionMacro { get; set; }
    }
}