using GenericForum.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericForum.Persistence.Mapping
{
    internal class ProfileEntityConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {



            builder.ToTable("Profile");

            builder.HasKey(p => p.ID);

            builder.Property(p => p.ID)
                .HasColumnName("UserID");

            builder.Property(p => p.Biografia)
                .HasColumnType("varchar(510)");

            builder.HasOne(p => p.Client)
                .WithOne(c => c.Profile)
                .HasForeignKey<ProfileEntity>(c => c.ID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
