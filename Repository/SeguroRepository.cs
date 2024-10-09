using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Threading.Tasks;
using Technical_Test_DHB.DbContext;
using Technical_Test_DHB.Interfaces;
using Technical_Test_DHB.Models;

namespace Technical_Test_DHB.Repository
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly AplicationDbContext _context;

        public SeguroRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Seguros> CrearSeguro(Seguros seguro)
        {
            _context.Seguros.Add(seguro);
            await _context.SaveChangesAsync();
            return seguro;
        }

        public async Task<Seguros> ObtenerSeguro(string cedula)
        {
            return await _context.Seguros.Include(s => s.Cliente)
                                         .FirstOrDefaultAsync(s => s.Cliente.Cedula == cedula);
        }

        public async Task<bool> ValidaPoliza(int clienteId, string tipoSeguro)
        {
            return await _context.Seguros.AnyAsync(s => s.ClienteId == clienteId && s.TipoSeguro == tipoSeguro);
        }

        public async Task<Planes> ObtenerPlan(string codigoPlan)
        {
            return await _context.Planes.FirstOrDefaultAsync(p => p.CodigoPlan == codigoPlan);
        }

        public async Task<int> ObtenerUltimoSeguro()
        {
            return await _context.Seguros.CountAsync();
        }
    }
}
