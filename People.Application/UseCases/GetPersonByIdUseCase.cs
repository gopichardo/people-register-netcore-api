using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Domain.Entities;
using People.Domain.Interfaces;

namespace People.Application.UseCases
{
    public class GetPersonByIdUseCase : IGetPersonByIdUseCase
    {
        private readonly IPersonRepository _repository;

        public GetPersonByIdUseCase(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> GetSingleAsync(Guid Id)
        {
            var person = await _repository.GetSingleByIdAsync(Id);

            return person;
        }
    }
}
