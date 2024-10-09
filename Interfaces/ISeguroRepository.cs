using System.Numerics;
using System.Threading.Tasks;
using Technical_Test_DHB.Models;

namespace Technical_Test_DHB.Interfaces
{
    public interface ISeguroRepository
    {
        Task<Seguros> CrearSeguro(Seguros seguro);
        Task<Seguros> ObtenerSeguro(string cedula);
        Task<bool> ValidaPoliza(int clienteId, string tipoSeguro);
        Task<Planes> ObtenerPlan(string codigoPlan);
        Task<int> ObtenerUltimoSeguro();
    }
}
