using ContactList.Domain.Entities;
using System.Collections.Generic;

namespace ContactList.Domain.Repositories;
public interface IContactRepository
{
    IReadOnlyCollection<Contact> GetContacts();
    Contact GetContact(int contactId);
    void InsertContact(Contact contact);
    void UpdateContact(Contact contact);
    void DeleteContact(Contact contact);
}
