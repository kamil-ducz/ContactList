using AutoMapper;
using ContactList.Api.Contacts.Models;
using ContactList.Domain.Entities;
using ContactList.Domain.Repositories;
using System.Collections.Generic;

namespace ContactList.Api.Contacts.Services;

public interface IContactService
{
    IReadOnlyCollection<ContactDto> GetContacts();
    ContactDto GetContact(int contactId);
    int InsertContact(ContactUpsertDto contact);
    void UpdateContact(int contactId, ContactUpsertDto contact);
    void DeleteContact(int contactId);
}

public class ContactService : IContactService
{
    private readonly IMapper _mapper;
    private readonly IContactRepository _contactRepository;

    public ContactService(IMapper mapper, IContactRepository contactRepository)
    {
        _mapper = mapper;
        _contactRepository = contactRepository;
    }
    public IReadOnlyCollection<ContactDto> GetContacts()
    {
        return _mapper.Map<IReadOnlyCollection<ContactDto>>(_contactRepository.GetContacts());
    }

    public ContactDto GetContact(int contactId)
    {
        return _mapper.Map<ContactDto>(_contactRepository.GetContact(contactId));
    }

    public int InsertContact(ContactUpsertDto contact)
    {
        var contactToInsert = _mapper.Map<Contact>(contact);
        _contactRepository.InsertContact(contactToInsert);
        return contactToInsert.Id;
    }

    public void UpdateContact(int contactId, ContactUpsertDto contact)
    {
        var contactToUpdate = _mapper.Map<Contact>(GetContact(contactId));
        _contactRepository.UpdateContact(contactToUpdate);
    }

    public void DeleteContact(int contactId)
    {
        _contactRepository.DeleteContact(_mapper.Map<Contact>(GetContact(contactId)));
    }
}
