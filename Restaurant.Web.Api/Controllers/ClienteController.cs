using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Domain.Models.Cliente;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Models.Cliente;
using Restaurant.Infraestructure.Repositories;


namespace Restaurant.Web.Api.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public ClienteController(IClienteRepository clienteRepository, ApplicationDbContext applicationDbContext)
        {
            _clienteRepository = clienteRepository;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(SaveClienteModel model)
        {
            Cliente cliente = new()
            {
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Email = model.Email
            };

            await _clienteRepository.AddAsync(cliente);

            var result = await _applicationDbContext.SaveChangesAsync() > 0;

            if (!result) return BadRequest("No se agregó el cliente");

            return Ok(cliente);
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
            if (id <= 0) return BadRequest("El ID debe ser un valor positivo");

            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound("Cliente no encontrado");

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente(int id, UpdateClienteModel model)
        {
            if (id <= 0) return BadRequest("El ID debe ser un valor positivo");

            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound("Cliente no encontrado");

            cliente.Nombre = model.Nombre;
            cliente.Telefono = model.Telefono;
            cliente.Email = model.Email;

            await _clienteRepository.UpdateAsync(cliente);

            var result = await _applicationDbContext.SaveChangesAsync() > 0;

            if (!result) return BadRequest("No se pudo actualizar el cliente");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            if (id <= 0) return BadRequest("El ID debe ser un valor positivo");

            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound("Cliente no encontrado");

            await _clienteRepository.DeleteAsync(id);

            var result = await _applicationDbContext.SaveChangesAsync() > 0;

            if (!result) return BadRequest("No se pudo eliminar el cliente");

            return NoContent();
        }
    }
}
