using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Controllers
{
    public class SingleIssueController : Controller
    {
        private IIssueRepository m_Repository;
        public SingleIssueController(IIssueRepository repository)
        {
            this.m_Repository = repository;
        }

        [HttpGet] 
        public ActionResult Issue(int? issueId)
        {
            issueId = 1;
            return View(m_Repository.Issues.First(x => (x.Id == issueId)));
        }

        [HttpPost]
        public ActionResult Issue(Issue issue)
        {
            m_Repository.SaveIssue(issue);
            return RedirectToAction("Index", "Issues");
        }
    }
}