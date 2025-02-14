using People.Domain.Entities;

namespace People.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task AddAsync(Person person);
    }
}
