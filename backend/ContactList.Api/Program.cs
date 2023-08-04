using ContactList.Api.Contacts.Models;
using ContactList.Api.Contacts.Services;
using ContactList.Api.Contacts.Validators;
using ContactList.Api.Dictionaries.Services;
using ContactList.Domain.Repositories;
using ContactList.Infrastructure;
using ContactList.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ContactDto>, ContactDtoValidator>();
builder.Services.AddScoped<IValidator<ContactUpsertDto>, ContactUpsertDtoValidator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IDictionaryService, DictionaryService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IDictionaryRepository, DictionaryRepository>();

builder.Services.AddDbContext<ContactListDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
