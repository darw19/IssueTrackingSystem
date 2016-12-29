using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITS.Domain.Abstract;
using ITS.Domain.Entities;
using ITS.Models;

namespace ITS.Controllers
{
    public class CompletedIssuesController : Controller
    {
        private IUserRepository m_UserRepository;
        private IIssueRepository m_IssueRepository;

        public CompletedIssuesController(IUserRepository _userRepository,
                                         IIssueRepository _issuesRepository)
        {
            this.m_UserRepository = _userRepository;
            this.m_IssueRepository = _issuesRepository;
        }

        [HttpGet]
        public ViewResult Index(string userName)
        {
            ApplicationUser curUser = m_UserRepository.Users.First(x => x.Email == userName);
            var issuesCompletedByUser = m_IssueRepository.Issues;
            List<Issue> desiredIssues = new List<Issue>();
            foreach (var x in issuesCompletedByUser.ToList())
            {
                if (x.CompletedBy != null && x.CompletedBy.Email == userName)
                {
                    desiredIssues.Add(x);
                }
            }

            
            IEnumerable<ApplicationUser> users = m_UserRepository.Users;
            return View(new CompletedIssuesViewModel(users, desiredIssues, curUser));
        }

        [HttpPost]
        public ActionResult RequestData(CompletedIssuesViewModel vm)
        {
            return RedirectToAction("Index", new { userName = vm.CurrentUser.Email });
        }
    }
}