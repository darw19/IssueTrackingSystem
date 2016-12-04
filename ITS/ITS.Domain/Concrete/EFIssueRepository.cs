using System.Collections.Generic;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Domain.Concrete
{
    public class EFIssueRepository : IIssueRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Issue> Issues
        {
            get { return context.Issues; }
        }

        public void SaveIssue(Issue issue)
        {
            if (issue.Id == 0)
            {
                context.Issues.Add(issue);
            } else
            {
                Issue dbEntry = context.Issues.Find(issue.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = issue.Title;
                    dbEntry.Description = issue.Description;
                    dbEntry.AssignedTo = issue.AssignedTo;
                    dbEntry.Comments = issue.Comments;
                    context.SaveChanges();
                }
            }
        }
    }
}
