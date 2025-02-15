using People.Domain.Entities;

namespace People.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task<Person> GetSingleByIdAsync(Guid Id);
    }
}
