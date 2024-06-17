using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Prosigliere.Entities;

namespace Prosigliere.Data.EntityTypeConfigurations
{
    public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        private const string TableName = "Comment";
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(bp => new { bp.Id });

            builder
                .Property(ac => ac.Id);

            builder.Property(ac => ac.Text);
        }
    }
}
