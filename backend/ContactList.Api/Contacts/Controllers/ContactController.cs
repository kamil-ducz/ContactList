using ContactList.Api.Contacts.Models;
using ContactList.Api.Contacts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactList.Api.Contacts.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly IValidator<ContactUpsertDto> _validatorContactUpsertDto;

    public ContactController(IContactService contactService, IValidator<ContactUpsertDto> validatorContactUpsertDto)
    {
        _contactService = contactService;
        _validatorContactUpsertDto = validatorContactUpsertDto;
    }
    [HttpGet]
    public IReadOnlyCollection<ContactDto> Get()
    {
        return _contactService.GetContacts();
    }

    [HttpGet("{contactId}")]
    public ContactDto Get(int contactId)
    {
        return _contactService.GetContact(contactId);
    }

    [HttpPost]
    public IActionResult Post(ContactUpsertDto contactUpsertDto)
    {
        _validatorContactUpsertDto.ValidateAndThrow(contactUpsertDto);

        var newContactId = _contactService.InsertContact(contactUpsertDto);

        return Created(Request.GetEncodedUrl() + "/" + newContactId, _contactService.GetContact(newContactId));
    }

    [HttpPut("{contactId}")]
    public IActionResult Put(int contactId, ContactUpsertDto contactUpsertDto)
    {
        _validatorContactUpsertDto.ValidateAndThrow(contactUpsertDto);
        _contactService.UpdateContact(contactId, contactUpsertDto);

        return Ok(_contactService.GetContact(contactId));
    }

    [HttpDelete("{contactId}")]
    public IActionResult Delete(int contactId)
    {
        _contactService.DeleteContact(contactId);

        return NoContent();
    }
}
