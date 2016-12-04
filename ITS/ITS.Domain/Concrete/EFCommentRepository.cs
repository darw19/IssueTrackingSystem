using System.Collections.Generic;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Domain.Concrete
{
    public class EFCommentRepository : ICommentRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Comment> Comments
        {
            get { return context.Comments; }
        }

        public void SaveIssue(Comment comment)
        {
            if (comment.Id == 0)
            {
                context.Comments.Add(comment);
            }
            else
            {
                Comment dbEntry = context.Comments.Find(comment.Id);
                if (dbEntry != null)
                {
                    dbEntry.Text = comment.Text;
                    dbEntry.CommentChanges = comment.CommentChanges;
                    context.SaveChanges();
                }
            }
        }
    }
}
