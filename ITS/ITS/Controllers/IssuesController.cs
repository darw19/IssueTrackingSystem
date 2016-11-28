using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITS.Domain.Abstract;
using ITS.Domain.Entities;

namespace ITS.Controllers
{
    public class IssuesController : Controller
    {
        private IIssueRepository issuesRepository;

        public IssuesController(IIssueRepository arg)
        {
            this.issuesRepository = arg;
        }

        // GET: Issues
        public ActionResult Index()
        {

            return View(issuesRepository);
        }
    }
}