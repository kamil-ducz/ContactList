using ContactList.Domain.Entities;
using ContactList.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ContactList.Infrastructure.Repositories;
public class ContactRepository : IContactRepository
{
    private readonly ContactListDbContext _contactListDbContext;

    public ContactRepository(ContactListDbContext contactListDbContext)
    {
        _contactListDbContext = contactListDbContext;
    }
    public IReadOnlyCollection<Contact> GetContacts()
    {
        return _contactListDbContext.Contacts.ToList();
    }
    public Contact GetContact(int contactId)
    {
        return _contactListDbContext.Contacts.First(c => c.Id == contactId);
    }

    public void InsertContact(Contact contact)
    {
        _contactListDbContext.Contacts.Add(contact);
        _contactListDbContext.SaveChanges();
    }

    public void UpdateContact(Contact contact)
    {
        _contactListDbContext.Contacts.Update(contact);
        _contactListDbContext.SaveChanges();
    }

    public void DeleteContact(Contact contact)
    {
        _contactListDbContext.Contacts.Remove(contact);
        _contactListDbContext.SaveChanges();
    }
}
