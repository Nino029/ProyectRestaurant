using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Domain.Models.Empleado;
using AutoMapper;
using Restaurant.Infraestructure.Models.Empleado;

namespace Restaurant.Web.Api.Controllers
{
    [ApiController]
    [Route("api/empleado")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public EmpleadoController(IEmpleadoRepository empleadoRepository, IMapper mapper)
        {
            _empleadoRepository = empleadoRepository ?? throw new ArgumentNullException(nameof(empleadoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetAll()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetById(int id)
        {
            try
            {
                var empleado = await _empleadoRepository.GetByIdAsync(id);
                return Ok(empleado);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Empleado no encontrado");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> Create(SaveEmpleadoModel model)
        {
            var empleado = _mapper.Map<Empleado>(model);

            try
            {
                await _empleadoRepository.AddAsync(empleado);
                return CreatedAtAction(nameof(GetById), new { id = empleado.IdEmpleado }, empleado);
            }
            catch (Exception)
            {
                return BadRequest("No se pudo crear el empleado");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmpleadoModel model) 
        {
   

            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado == null)
            {
                return NotFound("Empleado no encontrado");
            }

            model.IdEmpleado = id; 

            try
            {
                await _empleadoRepository.UpdateAsync(_mapper.Map<Empleado>(model));
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Empleado no encontrado");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo actualizar el empleado");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _empleadoRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Empleado no encontrado");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo eliminar el empleado");
            }
        }
    }
}
