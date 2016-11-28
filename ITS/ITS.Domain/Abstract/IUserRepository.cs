using System.Collections.Generic;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> Users { get; }
    }
}