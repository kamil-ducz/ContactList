﻿using System.ComponentModel.DataAnnotations;

namespace ContactList.Api.Auth.Models;

public class AuthenticateRequest
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
}