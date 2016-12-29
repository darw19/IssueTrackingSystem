using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Models
{
    public class CompletedIssuesViewModel
    {
        private IEnumerable<Issue> m_IssuesRepository;
        private IEnumerable<ApplicationUser> m_UserRepository;
        private ApplicationUser m_CurrentUser;

        public CompletedIssuesViewModel()
        {
            this.m_IssuesRepository = null;
            this.m_UserRepository = null;
            this.m_CurrentUser = null; 
        }

        public CompletedIssuesViewModel(IEnumerable<ApplicationUser> userRepository,
                                        IEnumerable<Issue> issuesRepository,
                                        ApplicationUser currentUser)
        {
            this.m_UserRepository = userRepository;
            this.m_IssuesRepository = issuesRepository;
            this.m_CurrentUser = currentUser;
        }

        public IEnumerable<ApplicationUser> Users { get { return m_UserRepository; } }
        public IEnumerable<Issue> Issues { get { return m_IssuesRepository; } }
        public ApplicationUser CurrentUser { get { return m_CurrentUser; } set { m_CurrentUser = value; } }
    }
}