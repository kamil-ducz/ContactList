using ContactList.Api.Contacts.Models;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace ContactList.Api.Contacts.Validators;

public class ContactUpsertDtoValidator : AbstractValidator<ContactUpsertDto>
{
    public ContactUpsertDtoValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty")
            .MinimumLength(3).WithMessage("First name has to be at least 3 characters long")
            .MaximumLength(15).WithMessage("Last name has to be max 15 characters long")
            ;
        RuleFor(r => r.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty")
            .MinimumLength(3).WithMessage("Last name has to be at least 3 characters long")
            .MaximumLength(30).WithMessage("Last name has to be max 30 characters long")
            ;
        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email cannot be empty")
            .EmailAddress().WithMessage("Email has to be in email format")
            .MinimumLength(10).WithMessage("Email has to be at least 3 characters long")
            .MaximumLength(30).WithMessage("Email has to be max 30 characters long")
            ;
        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(8).WithMessage("Password has to be at least 8 characters long")
            .MaximumLength(100).WithMessage("Password has to be max 16 characters long")
            .Matches(@"[A-Z]+").WithMessage("Password has to contain at least one uppercase letter")
            .Matches(@"[a-z]+").WithMessage("Password has to contain at least one lowercase letter")
            .Matches(@"[0-9]+").WithMessage("Password has to contain at least one number")
            .Matches(@"[\!\?\*\.]+").WithMessage("Password has to contain at least one (!? *.)")
            ;
        RuleFor(r => r.CategoryId)
            .NotEmpty().WithMessage("CategoryId cannot be empty")
            .GreaterThanOrEqualTo(1).WithMessage("CategoryId has to be greater than or equal to 1")
            .LessThanOrEqualTo(3).WithMessage("CategoryId has to be less than or equal to 3")
            ;
        RuleFor(r => r.SubCategoryId)
            .GreaterThanOrEqualTo(1).When(s => s is not null).WithMessage("CategoryId has to be greater than or equal to 1")
            .LessThanOrEqualTo(3).When(s => s is not null).WithMessage("CategoryId has to be less than or equal to 3")
            ;
        RuleFor(r => r.PhoneNumber)
           .NotEmpty()
           .NotNull().WithMessage("Phone number cannot be empty")
           .MinimumLength(9).WithMessage("Phone number must not be less than 9 characters")
           .MaximumLength(20).WithMessage("Phone number must not exceed 50 characters")
           .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("Phone number not valid")
           ;
        RuleFor(r => r.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth cannot be empty")
            .GreaterThanOrEqualTo(DateTime.Now.AddDays(-36500)).WithMessage("You are older than 100 years, you are greater than this application master")
            ;
        ;
    }
}
