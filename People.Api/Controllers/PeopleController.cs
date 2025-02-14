using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using People.Application.UseCases;
using People.Domain.Entities;

namespace People.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IRegisterPersonUseCase _registerPersonUseCase;

        public PeopleController(IRegisterPersonUseCase registerPersonUseCase)
        {
            _registerPersonUseCase = registerPersonUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPerson([FromBody] Person person)
        {
            try
            {
                await _registerPersonUseCase.ExecuteAsync(person);
                return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person); // Return 201 Created
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            // ... (Implementation to get a person by ID)
            return Ok();
        }
    }
}
