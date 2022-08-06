using System;
using System.Collections.Generic;

namespace CRUDMVC.Models
{
    public partial class TblEmpleado
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Puesto { get; set; }
        public int? Salario { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
    }
}
