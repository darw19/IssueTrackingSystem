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
                    if (issue.AssignedTo != null)
                    {
                        dbEntry.AssignedTo = context.Users.Find(issue.AssignedTo.Id);
                    }
                    else
                    {
                        dbEntry.AssignedTo = null;
                    }                    
                    dbEntry.Comments = issue.Comments;
                    dbEntry.Status = issue.Status;
                    dbEntry.IssueConnections = issue.IssueConnections;
                    if (issue.CompletedBy != null)
                    {
                        dbEntry.CompletedBy = context.Users.Find(issue.CompletedBy.Id);
                    } else
                    {
                        dbEntry.CompletedBy = null;
                    }
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
