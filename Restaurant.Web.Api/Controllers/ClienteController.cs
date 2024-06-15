using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Domain.Models.Cliente;
using Restaurant.Infraestructure.Models.Cliente;
using Restaurant.Web.Api.DTOS;


namespace Restaurant.Web.Api.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(SaveClienteModel model)
        {
            var cliente = _mapper.Map<Cliente>(model);

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
        public async Task<ActionResult<IEnumerable<ViewClienteModel>>> GetAllClientes()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var clienteViewModels = _mapper.Map<IEnumerable<ViewClienteModel>>(clientes);
            return Ok(clienteViewModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewClienteModel>> GetClienteById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID debe ser un valor positivo");
            }

            try
            {
                var cliente = await _clienteRepository.GetByIdAsync(id);
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                var clienteViewModel = _mapper.Map<ViewClienteModel>(cliente);
                return Ok(clienteViewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cliente no encontrado");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente(int id, UpdateClienteModel model)
        {
            try
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
                model.IdCliente = id;
                
              
                await _clienteRepository.UpdateAsync(_mapper.Map<Cliente>(model));

                return NoContent();
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
