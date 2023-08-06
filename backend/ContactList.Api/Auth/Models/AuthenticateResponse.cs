using ContactList.Api.Contacts.Models;

namespace ContactList.Api.Auth.Models;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(ContactDto user, string token)
    {
        Id = user.Id;
        Token = token;
    }
}