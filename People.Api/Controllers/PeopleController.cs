using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using People.Api.Utils;
using People.Application.UseCases;
using People.Domain.Entities;

namespace People.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IRegisterPersonUseCase _registerPersonUseCase;
        private readonly IGetPersonByIdUseCase _getPersonByIdUseCase;
        private readonly IGetAllPeopleUseCase _getAllPeopleUseCase;
        private readonly IValidator<Person> _personValidator;
        private readonly ValidationResultFormatter _validationResultFormatter;

        public PeopleController(
            IRegisterPersonUseCase registerPersonUseCase,
            IGetPersonByIdUseCase getPersonByIdUseCase,
            IGetAllPeopleUseCase getAllPeopleUseCase,
            IValidator<Person> personValidator,
            ValidationResultFormatter validationResultFormatter
        )
        {
            _registerPersonUseCase = registerPersonUseCase;
            _getPersonByIdUseCase = getPersonByIdUseCase;
            _getAllPeopleUseCase = getAllPeopleUseCase;
            _personValidator = personValidator;
            _validationResultFormatter = validationResultFormatter;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPerson([FromBody] Person person)
        {
            try
            {
                var result = await _personValidator.ValidateAsync(person);

                if (!result.IsValid)
                {
                    return BadRequest(
                        new { Errors = _validationResultFormatter.Format(result) }
                    );
                }

                await _registerPersonUseCase.ExecuteAsync(person);
                return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            try
            {
                var person = await _getPersonByIdUseCase.GetSingleAsync(id);

                return Ok(person);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetPeople()
        {
            try
            {
                var people = await _getAllPeopleUseCase.GetAllAsync();

                return Ok(people);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
