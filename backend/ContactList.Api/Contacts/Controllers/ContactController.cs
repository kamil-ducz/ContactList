using ContactList.Api.Auth.Attributes;
using ContactList.Api.Auth.Models;
using ContactList.Api.Contacts.Models;
using ContactList.Api.Contacts.Services;
using ContactList.Api.Users.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactList.Api.Contacts.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly IValidator<ContactUpsertDto> _validatorContactUpsertDto;
    private readonly IUserService _userService;

    public ContactController(IContactService contactService, IValidator<ContactUpsertDto> validatorContactUpsertDto
        , IUserService userService)
    {
        _contactService = contactService;
        _validatorContactUpsertDto = validatorContactUpsertDto;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpGet]
    public IReadOnlyCollection<ContactDto> Get()
    {
        return _contactService.GetContacts();
    }

    [AllowAnonymous]
    [HttpGet("{contactId}")]
    public ContactDto Get(int contactId)
    {
        return _contactService.GetContact(contactId);
    }

    [HttpPost]
    public IActionResult Post(ContactUpsertDto contactUpsertDto)
    {
        _validatorContactUpsertDto.ValidateAndThrow(contactUpsertDto);

        int? newContactId = _contactService.InsertContact(contactUpsertDto);
        if (newContactId == null)
        {
            return Conflict();
        }

        return Created(Request.GetEncodedUrl() + "/" + newContactId, _contactService.GetContact((int)newContactId));
    }

    [HttpPut("{contactId}")]
    public IActionResult Put(ContactUpsertDto contactUpsertDto, int contactId)
    {
        _validatorContactUpsertDto.ValidateAndThrow(contactUpsertDto);
        _contactService.UpdateContact(contactUpsertDto, contactId);

        return Ok(_contactService.GetContact(contactId));
    }

    [HttpDelete("{contactId}")]
    public IActionResult Delete(int contactId)
    {
        _contactService.DeleteContact(contactId);

        return NoContent();
    }

    // auth section
    // contact == user
    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }
}
