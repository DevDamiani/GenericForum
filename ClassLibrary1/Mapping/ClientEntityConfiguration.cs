using GenericForum.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericForum.Persistence.Mapping
{
    internal class ClientEntityConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("User");

            builder
                .HasKey(c => c.ID);

            builder
               .HasAlternateKey(c => c.UserName);
              
            builder
                .Property(c => c.UserName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
               .Property(c => c.Password)
               .HasColumnType("varchar(18)")
               .IsRequired();

            builder
               .Property(c => c.EmailAddress)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder
               .Property(c => c.CreationDate)
               .HasColumnType("datetime")
               .IsRequired();



        }
    }
}
