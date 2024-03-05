using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public abstract class ModelMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public bool Estatus { get; set; } = true;

        [ForeignKey("Usuario")]
        public Nullable<int> UsuarioId { get; set; } = 1; // Usuario Administrador
        public virtual Usuario Usuario { get; set; }    
    }
}