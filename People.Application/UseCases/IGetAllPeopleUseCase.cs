using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Domain.Entities;

namespace People.Application.UseCases
{
    public interface IGetAllPeopleUseCase
    {
        Task<IEnumerable<Person>> GetAllAsync();
    }
}
