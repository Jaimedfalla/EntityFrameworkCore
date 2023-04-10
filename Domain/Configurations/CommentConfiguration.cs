using ef7_example.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ef7_example.Domain.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");
        builder.Property(c => c.Content).HasMaxLength(500);
    }
}
