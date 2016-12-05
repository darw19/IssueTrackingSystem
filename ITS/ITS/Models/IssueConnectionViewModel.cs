using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Models
{
    public class IssueConnectionViewModel
    {
        private IIssueRepository m_Repository;

        public IssueConnectionViewModel(IIssueRepository rep)
        {
            this.m_Repository = rep;
        }

        public Issue FirstIssue { get; set; }
        public Issue SecondIssue { get; set; }
        public IEnumerable<Issue> AllIssues { get { return m_Repository.Issues; } }
    }
}