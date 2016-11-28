using System.Collections.Generic;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Domain.Concrete
{
    public class EFAttachmentChangeRepository: IAttachmentChangeRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<AttachmentChange> AttachmentChanges {
            get { return context.AttachmentChanges; }
        }
    }
}
