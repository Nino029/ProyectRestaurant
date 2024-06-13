using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Domain.Models.Cliente;
using Restaurant.Infraestructure.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Web.Api.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(SaveClienteModel model)
        {
            var cliente = new Cliente
            {
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Email = model.Email
            };

            try
            {
                await _clienteRepository.AddAsync(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest("No se pudo agregar el cliente");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAllClientes()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID debe ser un valor positivo");
            }

            try
            {
                var cliente = await _clienteRepository.GetByIdAsync(id);
                return Ok(cliente);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cliente no encontrado");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente(int id, UpdateClienteModel model)
        {
            if (id <= 0)
            {
                return BadRequest("El ID debe ser un valor positivo");
            }

            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            cliente.Nombre = model.Nombre;
            cliente.Telefono = model.Telefono;
            cliente.Email = model.Email;

            try
            {
                await _clienteRepository.UpdateAsync(cliente);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cliente no encontrado");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo actualizar el cliente");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID debe ser un valor positivo");
            }

            try
            {
                await _clienteRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cliente no encontrado");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo eliminar el cliente");
            }
        }
    }
}
