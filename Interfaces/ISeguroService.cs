using System.Threading.Tasks;
using System;
using Technical_Test_DHB.Models;

namespace Technical_Test_DHB.Interfaces
{
    public interface ISeguroService
    {
        Task<Seguros> RegistrarSeguro(Seguros seguro);
        Task<Seguros> ConsultarSeguro(string cedula);

    }
}
