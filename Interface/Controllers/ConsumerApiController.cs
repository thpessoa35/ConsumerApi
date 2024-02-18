
using Microsoft.AspNetCore.Mvc;
using consumerApiUseCase;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeController : ControllerBase
    {
        private readonly ConsumerApiUseCase _consumerApiUseCase;
        private readonly ConsumerApiGetIdUseCase _consumerApiIdUseCase;

      


        public EmployeeController(
            ConsumerApiUseCase consumerApiUseCase,
            ConsumerApiGetIdUseCase consumerApiGetIdUseCase
           
            )
        {
            _consumerApiUseCase = consumerApiUseCase;
            _consumerApiIdUseCase = consumerApiGetIdUseCase;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _consumerApiUseCase.FindAll();

                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Erro ao conectar com a Api" });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeUnique([FromRoute] string id)
        {
            try
            {
                var employee = await _consumerApiIdUseCase.FindById(id);

                if (employee != null)
                {
                    return Ok(employee);
                }
                else
                {
                    return NotFound(new { Message = "Funcionário não encontrado" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter funcionário por ID: {ex.Message}");
                return BadRequest(new { Message = "Erro ao conectar com a API" });
            }

        }
        
    }
}
