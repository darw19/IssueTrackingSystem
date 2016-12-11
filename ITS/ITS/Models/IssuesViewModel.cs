using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Models
{
    public class IssuesViewModel
    {
        private IEnumerable<Issue> m_IssuesRepository;
        private IEnumerable<ApplicationUser> m_UserRepository;
        public IssuesViewModel(IEnumerable<ApplicationUser> userRepository,
                               IEnumerable<Issue> issuesRepository)
        {
            this.m_UserRepository = userRepository;
            this.m_IssuesRepository = issuesRepository;
        }

        public IEnumerable<ApplicationUser> Users { get { return m_UserRepository; } }
        public IEnumerable<Issue> Issues { get { return m_IssuesRepository; } }
        public static IEnumerable<string> Statuses()
        {
            IEnumerable<string> statuses = new List<string>() { "Not started", "In progress", "Done" };
            return statuses;
        }
    }
}