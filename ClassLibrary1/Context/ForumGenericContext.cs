using GenericForum.Model.Entity;
using GenericForum.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GenericForum.Model.Interfaces.Repositories
{
    public class ForumGenericContext : DbContext
    {

        public ForumGenericContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }


        public DbSet<ClientEntity> ClientTable { get; set; }
        public DbSet<ProfileEntity> ProfileTable { get; set; }
        public DbSet<TopicEntity> TopicTable { get; set; }
        public DbSet<CommentEntity> CommentTable { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TopicEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());

        }

        

    }
}
