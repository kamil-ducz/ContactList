using ContactList.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ContactList.Infrastructure.Repositories;
public class DictionaryRepository : IDictionaryRepository
{
    private readonly ContactListDbContext _contactListDbContext;

    public DictionaryRepository(ContactListDbContext contactListDbContext)
    {
        _contactListDbContext = contactListDbContext;
    }
    public IReadOnlyCollection<T> GetAll<T>() where T : class
    {
        return _contactListDbContext.Set<T>().ToList();
    }
}
