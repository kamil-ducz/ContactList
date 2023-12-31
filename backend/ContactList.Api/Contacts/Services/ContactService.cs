﻿using AutoMapper;
using ContactList.Api.Contacts.Models;
using ContactList.Domain.Entities;
using ContactList.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ContactList.Api.Contacts.Services;

public interface IContactService
{
    IReadOnlyCollection<ContactDto> GetContacts();
    ContactDto GetContact(int contactId);
    int? InsertContact(ContactUpsertDto contact);
    void UpdateContact(ContactUpsertDto contact, int contactId);
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

    public int? InsertContact(ContactUpsertDto contact)
    {
        var contactToInsert = _mapper.Map<Contact>(contact);
        if (_contactRepository.GetContacts().Any(c => c.Email == contact.Email))
        {
            return null;
        }
        contactToInsert.Password = BCrypt.Net.BCrypt.HashPassword(contact.Password);
        _contactRepository.InsertContact(contactToInsert);
        return contactToInsert.Id;
    }

    public void UpdateContact(ContactUpsertDto contactDto, int contactId)
    {
        var contact = _contactRepository.GetContact(contactId);
        _mapper.Map(contactDto, contact);
        contact.Password = BCrypt.Net.BCrypt.HashPassword(contact.Password);
        _contactRepository.UpdateContact(contact);
    }

    public void DeleteContact(int contactId)
    {
        var contactToDelete = _contactRepository.GetContact(contactId);
        _contactRepository.DeleteContact(contactToDelete);
    }
}
