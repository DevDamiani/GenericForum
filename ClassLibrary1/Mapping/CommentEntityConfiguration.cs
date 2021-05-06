using GenericForum.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericForum.Persistence.Mapping
{
    internal class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.ToTable("Comment");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.CommentText)
                .HasColumnType("varchar(510)")
                .IsRequired();

            builder.Property(c => c.CreationDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.ClientId)
               .HasColumnName("UserID");



            builder.HasOne(c => c.Topic)
               .WithMany(t => t.Comments)
               .HasForeignKey(c => c.TopicId);

            builder.HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
