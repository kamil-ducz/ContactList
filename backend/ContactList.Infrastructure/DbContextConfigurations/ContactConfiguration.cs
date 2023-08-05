using ContactList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactList.Infrastructure.DbContextConfigurations;
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasData(
            new Contact { Id = 1, FirstName = "John", LastName = "Smith", Email = "john.smith@gmail.com", Password = "Ex@mpleP@$$sowrd", CategoryId = (int)Domain.Enums.ContactCategory.Private, SubCategoryId = null, PhoneNumber = "700-800-900" },
            new Contact { Id = 2, FirstName = "Jack", LastName = "Dean", Email = "jack.dean@gmail.com", Password = "Ex@mpleP@$$sowrd1", CategoryId = (int)Domain.Enums.ContactCategory.Work, SubCategoryId = (int)Domain.Enums.ContactSubCategory.Client, PhoneNumber = "777-888-999" },
            new Contact { Id = 3, FirstName = "Edgar", LastName = "Gold", Email = "eg@gmail.com", Password = "Ex@mpleP@$$sowrd2", CategoryId = (int)Domain.Enums.ContactCategory.Work, SubCategoryId = (int)Domain.Enums.ContactSubCategory.Boss, PhoneNumber = "500-600-700" },
            new Contact { Id = 4, FirstName = "Roger", LastName = "Sapphire", Email = "rsapphire@gmail.com", Password = "Ex@mpleP@$$sowrd3", CategoryId = (int)Domain.Enums.ContactCategory.Other, SubCategoryId = null, PhoneNumber = "555-666-777" }
            );
    }
}
