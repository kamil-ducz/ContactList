using ContactList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactSubCategoryList.Infrastructure.DbContextConfigurations;
public class ContactSubCategoryConfiguration : IEntityTypeConfiguration<ContactSubCategory>
{
    public void Configure(EntityTypeBuilder<ContactSubCategory> builder)
    {
        builder.HasData(
            new ContactSubCategory { Id = (int)ContactList.Domain.Enums.ContactSubCategory.Client, Name = "Client" },
            new ContactSubCategory { Id = (int)ContactList.Domain.Enums.ContactSubCategory.Boss, Name = "Boss" },
            new ContactSubCategory { Id = (int)ContactList.Domain.Enums.ContactSubCategory.Other, Name = "Other" }
            );
    }
}
