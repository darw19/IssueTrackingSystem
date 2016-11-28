using System.Collections.Generic;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Domain.Concrete
{
    public class EFUserRepository: IUserRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<ApplicationUser> Users
        {
            get { return context.Users; }
        }
    }
}
