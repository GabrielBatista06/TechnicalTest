using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Technical_Test_DHB.Interfaces;
using Technical_Test_DHB.Models;
using Technical_Test_DHB.Utils;

namespace Technical_Test_DHB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : Controller
    {
        private readonly ISeguroService _seguroService;

        public SeguroController(ISeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarSeguro([FromBody] Seguros seguro)
        {
            try
            {
                var nuevoSeguro = await _seguroService.RegistrarSeguro(seguro);
                return Ok(nuevoSeguro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{cedula}")]
        public async Task<IActionResult> ConsultarSeguro(string cedula)
        {
            var seguro = await _seguroService.ConsultarSeguro(cedula);
            if (seguro == null)
            {
                return NotFound(Constantes.NotFoundSeguro + cedula);
            }
            return Ok(seguro);
        }
    }
}
