using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.ParseExact("F579F2A3-0573-49F0-B0B5-EFA8F52BBBF9","D"),
                    Type = "Funny"
                },
                new Category()
                {
                    Id = Guid.ParseExact("52BF3597-B6D0-4959-B922-CE3F1D6D2E94","D"),
                    Type = "Gaming"
                },
                new Category()
                {
                    Id = Guid.ParseExact("F4863175-B536-4D9C-8FCD-9230C9A48CF1","D"),
                    Type = "Music"
                },
                new Category()
                {
                    Id = Guid.ParseExact("B1BF132F-A3F7-4ABD-9433-FD82768A2BC7","D"),
                    Type = "Random"
                }
            };

            return categories;
        }
    }
}
