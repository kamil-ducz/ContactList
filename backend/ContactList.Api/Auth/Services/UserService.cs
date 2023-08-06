using ContactList.Api.Auth.Models;
using ContactList.Api.Contacts.Models;
using ContactList.Api.Contacts.Services;
using ContactList.Api.Users.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace ContactList.Api.Users.Services;

public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
}

public class UserService : IUserService
{
    private readonly IContactService _contactService;
    private readonly IJwtUtils _jwtUtils;
    private IEnumerable<ContactDto> _users = new List<ContactDto>();

    public UserService(IContactService contactService, IJwtUtils jwtUtils)
    {
        _contactService = contactService;
        _jwtUtils = jwtUtils;
    }

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        _users = _contactService.GetContacts();
        var user = _users.SingleOrDefault(x => x.Email == model.Username);

        // return null if user not found
        if (user == null)
        {
            return null;
        }

        // Verify the user-typed password with the hashed password stored in the database
        if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
        {
            // Passwords do not match
            return null;
        }

        // authentication successful so generate jwt token
        var token = _jwtUtils.GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }
}