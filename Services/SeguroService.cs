using System.Threading.Tasks;
using System;
using Technical_Test_DHB.Interfaces;
using Technical_Test_DHB.Models;
using Technical_Test_DHB.Utils;

namespace Technical_Test_DHB.Services
{
    public class SeguroService : ISeguroService
    {
        private readonly ISeguroRepository _seguroRepository;
        public SeguroService(ISeguroRepository seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }

        public async Task<Seguros> RegistrarSeguro(Seguros seguro)
        {
            if (await _seguroRepository.ValidaPoliza(seguro.ClienteId, seguro.TipoSeguro))
            {
                throw new InvalidOperationException(Constantes.TienePoliza);
            }

            var plan = await _seguroRepository.ObtenerPlan(seguro.Plan);
            if (plan == null)
            {
                throw new InvalidOperationException(Constantes.Plan);
            }

            int edadCliente = DateTime.Now.Year - seguro.Cliente.FechaNacimiento.Year;
            if (edadCliente < plan.EdadMinima || edadCliente > plan.EdadMaxima)
            {
                throw new InvalidOperationException($" {Constantes.Edad} {plan.EdadMinima} y {plan.EdadMaxima} años.");
            }

            seguro.ValorCuota = plan.Cuota;
            seguro.CodigoSeguro = await GenerarCodigoSeguro(seguro.TipoSeguro, seguro.Plan);

            return await _seguroRepository.CrearSeguro(seguro);
        }

        public async Task<Seguros> ConsultarSeguro(string cedula)
        {
            return await _seguroRepository.ObtenerSeguro(cedula);
        }

        private async Task<string> GenerarCodigoSeguro(string tipoSeguro, string codigoPlan)
        {
            int secuencia = await _seguroRepository.ObtenerUltimoSeguro() + 1;

            return $"{tipoSeguro}-{codigoPlan}-{secuencia.ToString("D5")}";
        }
    }
}
