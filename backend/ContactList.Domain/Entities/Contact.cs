using System;

namespace ContactList.Domain.Entities;
public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ContactCategory? Category { get; set; }
    public int CategoryId { get; set; }
    public ContactSubCategory? SubCategory { get; set; }
    public int? SubCategoryId { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}
