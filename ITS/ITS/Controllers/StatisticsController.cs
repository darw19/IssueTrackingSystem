using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITS.Models;
using ITS.Domain.Abstract;

namespace ITS.Controllers
{
    public class StatisticsController : Controller
    {
        private IIssueRepository m_IssuesRepository;
        private IUserRepository m_UsersRepository;

        public StatisticsController(IIssueRepository issuesRepository,
                                    IUserRepository usersRepository)
        {
            this.m_IssuesRepository = issuesRepository;
            this.m_UsersRepository = usersRepository;
        }

        [HttpGet]
        public ViewResult Statistics()
        {
            return View(new IssuesViewModel(m_UsersRepository.Users, m_IssuesRepository.Issues));
        }
    }
}