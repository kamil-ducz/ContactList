using System.Collections.Generic;

namespace ContactList.Domain.Repositories;
public interface IDictionaryRepository
{
    IReadOnlyCollection<T> GetAll<T>() where T : class;
}
