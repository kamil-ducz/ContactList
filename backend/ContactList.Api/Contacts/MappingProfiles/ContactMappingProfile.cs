using AutoMapper;
using ContactList.Api.Contacts.Models;
using ContactList.Domain.Entities;

namespace ContactList.Api.Contacts.MappingProfiles;

public class ContactMappingProfile : Profile
{
    public ContactMappingProfile()
    {
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<Contact, ContactUpsertDto>().ReverseMap();
    }
}
