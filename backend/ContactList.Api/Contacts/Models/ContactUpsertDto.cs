using System;

namespace ContactList.Api.Contacts.Models;

public class ContactUpsertDto
{
    //Id property should be disabled for PUT request - not to map empty id in case not provided in request body
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}
