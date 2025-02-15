using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Domain.Entities;

namespace People.Application.UseCases
{
    public interface IGetPersonByIdUseCase
    {
        Task<Person> GetSingleAsync(Guid Id);
    }
}
