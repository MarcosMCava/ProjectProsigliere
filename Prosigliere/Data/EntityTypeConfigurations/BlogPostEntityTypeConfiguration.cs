using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prosigliere.Entities;

namespace Prosigliere.Data.EntityTypeConfigurations
{
    public class BlogPostEntityTypeConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        private const string TableName = "BlogPost";
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(bp => new { bp.Id });

            builder.Property(ac => ac.Id);

            builder.Property(ac => ac.Title);

            builder.Property(ac => ac.Content);

            builder
                .HasMany(ac => ac.Comments)
                .WithOne("BlogPost")
                .HasForeignKey("Id");
        }
    }
}
