using System.Collections.Generic;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Domain.Concrete
{
    public class EFBaseChangeRepository : IBaseChangeRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<BaseChange> BaseChanges
        {
            get { return context.BaseChanges; }
        }
    }
}
