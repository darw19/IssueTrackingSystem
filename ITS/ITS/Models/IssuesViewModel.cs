using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITS.Domain.Entities;
using ITS.Domain.Concrete;

namespace ITS.Models
{
    public class IssuesViewModel
    {
        public IEnumerable<ApplicationUser> Users() { 
        var users = new ITS.Domain.Concrete.EFUserRepository();
        return users.Users;
        }
        public IEnumerable<string> Statuses()
        {
            IEnumerable<string> statuses = new List<string>() { "Not started", "In progress", "Done" };
            return statuses;
        }
    }
}