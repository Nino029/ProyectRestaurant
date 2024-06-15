using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Domain.Models.Factura;
using AutoMapper;
using Restaurant.Infraestructure.Models.Factura;

namespace Restaurant.Web.Api.Controllers
{
    [ApiController]
    [Route("api/factura")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IMapper _mapper;

        public FacturaController(IFacturaRepository facturaRepository, IMapper mapper)
        {
            _facturaRepository = facturaRepository ?? throw new ArgumentNullException(nameof(facturaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetAll()
            => Ok(await _facturaRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetById(int id)
        {
            try
            {
                var factura = await _facturaRepository.GetByIdAsync(id);
                return Ok(factura);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Factura no encontrada");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Factura>> Create(SaveFacturaModel model)
        {
            var factura = _mapper.Map<Factura>(model);

            try
            {
                await _facturaRepository.AddAsync(factura);
                return CreatedAtAction(nameof(GetById), new { id = factura.IdFactura }, factura);
            }
            catch (Exception)
            {
                return BadRequest("No se pudo crear la factura");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFacturaModel model)
        {
            var factura = await _facturaRepository.GetByIdAsync(id);
            if (factura == null)
            {
                return NotFound("Factura no encontrada");
            }

            model.IdFactura = id;

            try
            {
                await _facturaRepository.UpdateAsync(_mapper.Map<Factura>(model));
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Factura no encontrada");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo actualizar la factura");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _facturaRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Factura no encontrada");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo eliminar la factura");
            }
        }
    }
}
