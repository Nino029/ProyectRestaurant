using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Domain.Models.DetallePedido;
using Restaurant.Infraestructure.Models.DetallePedido;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Web.Api.Controllers
{
    [ApiController]
    [Route("api/detallePedido")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoRepository _detallePedidoRepository;

        public DetallePedidoController(IDetallePedidoRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetAll()
        {
            var detalles = await _detallePedidoRepository.GetAllAsync();
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetById(int id)
        {
            try
            {
                var detalle = await _detallePedidoRepository.GetByIdAsync(id);
                return Ok(detalle);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Detalle de pedido no encontrado");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> Create(SaveDetallePedidoModel model)
        {
            var detalle = new DetallePedido
            {
                IdPedido = model.IdPedido,
                IdPlato = model.IdPlato,
                Cantidad = model.Cantidad,
                Subtotal = model.Subtotal
            };

            try
            {
                await _detallePedidoRepository.AddAsync(detalle);
                return CreatedAtAction(nameof(GetById), new { id = detalle.IdDetallePedido }, detalle);
            }
            catch (Exception)
            {
                return BadRequest("No se pudo crear el detalle de pedido");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDetallePedido model)
        {
 

            var detalle = await _detallePedidoRepository.GetByIdAsync(id);
            if (detalle == null)
            {
                return NotFound("Detalle de pedido no encontrado");
            }

            detalle.IdPedido = id;
            detalle.IdPlato = model.IdPlato;
            detalle.Cantidad = model.Cantidad;
            detalle.Subtotal = model.Subtotal;

            try
            {
                await _detallePedidoRepository.UpdateAsync(detalle);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Detalle de pedido no encontrado");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo actualizar el detalle de pedido");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _detallePedidoRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Detalle de pedido no encontrado");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo eliminar el detalle de pedido");
            }
        }
    }
}
