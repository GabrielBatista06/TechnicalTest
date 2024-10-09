using System;

namespace Technical_Test_DHB.Models
{
    public class Seguros
    {
        public int Id { get; set; }
        public string CodigoSeguro { get; set; }
        public string TipoSeguro { get; set; }
        public string Plan { get; set; }
        public string TipoCuentaFinanciera { get; set; }
        public string NumeroCuentaFinanciera { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal ValorCuota { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
    }
}
