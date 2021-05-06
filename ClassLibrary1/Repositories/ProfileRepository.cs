using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository<ProfileEntity>, IProfileRepository
    {
        public ProfileRepository(ForumGenericContext forumGenericContext) : base(forumGenericContext)
        {
        }
    }
}
