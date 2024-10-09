using System.Collections.Generic;
using System;

namespace Technical_Test_DHB.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<Seguros> Seguros { get; set; }
    }
}
