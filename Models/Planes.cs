namespace Technical_Test_DHB.Models
{
    public class Planes
    {
        public int Id { get; set; }
        public string CodigoPlan { get; set; }
        public string NombrePlan { get; set; }
        public decimal Cuota { get; set; }
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public string TipoSeguro { get; set; }
    }
}
