using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using People.Domain.Entities;
using People.Domain.Interfaces;
using People.Infrastructure.Persistence;

namespace People.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleDbContext _context;

        public PersonRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<Person>> IPersonRepository.GetAllAsync()
        {
            return await _context.People.Include(x => x.Company).ToListAsync();
        }

        public async Task<Person> GetSingleByIdAsync(Guid Id)
        {
            return await _context
                .People.Include(x => x.Company)
                .FirstAsync<Person>(x => x.Id == Id);
        }
    }
}
