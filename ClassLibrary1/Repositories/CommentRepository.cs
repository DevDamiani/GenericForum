
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Repositories;

namespace GenericForum.Persistence.Repositories
{
    public class CommentRepository : BaseRepository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(ForumGenericContext forumGenericContext) : base(forumGenericContext) { }
    }
}
