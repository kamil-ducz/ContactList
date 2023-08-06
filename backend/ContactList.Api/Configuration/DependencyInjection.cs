using ContactList.Api.Contacts.Models;
using ContactList.Api.Contacts.Services;
using ContactList.Api.Contacts.Validators;
using ContactList.Api.Dictionaries.Services;
using ContactList.Api.Users.Authorization;
using ContactList.Api.Users.Services;
using ContactList.Domain.Repositories;
using ContactList.Infrastructure;
using ContactList.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContactList.Api.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();
        services.AddCors();
        services.AddScoped<IJwtUtils, JwtUtils>();

        services.AddFluentValidationAutoValidation();
        services.AddScoped<IValidator<ContactDto>, ContactDtoValidator>();
        services.AddScoped<IValidator<ContactUpsertDto>, ContactUpsertDtoValidator>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IDictionaryService, DictionaryService>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IDictionaryRepository, DictionaryRepository>();

        services.AddDbContext<ContactListDbContext>();

        return services;
    }
}
