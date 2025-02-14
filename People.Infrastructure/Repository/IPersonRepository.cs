using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Domain.Entities;

namespace People.Infrastructure.Repository
{
    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        Task<List<Person>> GetAllAsync();
    }
}
