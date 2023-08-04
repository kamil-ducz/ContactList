using ContactList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactCategoryList.Infrastructure.DbContextConfigurations;
public class ContactCategoryConfiguration : IEntityTypeConfiguration<ContactCategory>
{
    public void Configure(EntityTypeBuilder<ContactCategory> builder)
    {
        builder.HasData(
            new ContactCategory { Id = (int)ContactList.Domain.Enums.ContactCategory.Private, Name = "Private" },
            new ContactCategory { Id = (int)ContactList.Domain.Enums.ContactCategory.Work, Name = "Work" },
            new ContactCategory { Id = (int)ContactList.Domain.Enums.ContactCategory.Other, Name = "Other" }
            );
    }
}
