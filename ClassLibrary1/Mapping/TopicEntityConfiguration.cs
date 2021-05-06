using GenericForum.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericForum.Persistence.Mapping
{
    internal class TopicEntityConfiguration : IEntityTypeConfiguration<TopicEntity>
    {
        public void Configure(EntityTypeBuilder<TopicEntity> builder)
        {



            builder.ToTable("Topic");

            builder.HasKey(t => t.ID);

            builder.Property(t => t.Title)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(t => t.Subtitle)
                .HasColumnType("varchar(765)");

            builder.Property(t => t.CreationDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(t => t.ClientID)
                    .HasColumnName("UserID")
                    .IsRequired();

            builder.HasOne(t => t.Client)
                .WithMany(c => c.Topics)
                .HasForeignKey(t => t.ClientID)
                .OnDelete(DeleteBehavior.ClientSetNull);


           
        }
    }
}
