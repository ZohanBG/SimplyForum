using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Infrastructure.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>()
            {
                UserId = "648a1ea7-a0d3-4aba-8316-cd702f2be4d9",
                RoleId = "dcc4e7c6-341d-485f-9aac-3de4b724b178"
            });
        }
    }
}
