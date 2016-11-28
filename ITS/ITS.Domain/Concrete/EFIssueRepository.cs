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
    }
}
