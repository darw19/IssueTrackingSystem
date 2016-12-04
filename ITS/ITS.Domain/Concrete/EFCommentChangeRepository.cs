using System.Collections.Generic;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Domain.Concrete
{
    public class EFCommentChangeRepository : ICommentChangeRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<CommentChange> CommentChanges
        {
            get { return context.CommentChanges; }
        }
    }
}
