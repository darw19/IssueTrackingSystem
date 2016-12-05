﻿using System.Collections.Generic;
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
                Issue dbEntry = context.Issues.Find(issue.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = issue.Title;
                    dbEntry.Description = issue.Description;
                    dbEntry.AssignedTo = context.Users.Find(issue.AssignedTo.Id);
                    dbEntry.Comments = issue.Comments;
                    dbEntry.Status = issue.Status;
                }
                else
                {
                    issue.CreatedOn = System.DateTime.Now;
                    issue.AssignedTo = context.Users.Find(issue.AssignedTo.Id);
                    context.Issues.Add(issue);
                }
                context.SaveChanges();
        }
    }
}
