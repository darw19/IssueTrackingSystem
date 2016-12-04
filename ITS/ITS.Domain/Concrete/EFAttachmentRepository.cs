using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Domain.Concrete
{        
    public class EFAttachmentRepository: IAttachmentRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Attachment> Attachments
        { 
            get { return context.Attachments; } 
        }

        public void AddAttachment(Attachment attachment)
        {
            context.Attachments.Add(attachment);
            context.SaveChanges();
        }

        public void RemoveAttachment(Attachment attachment)
        {
            context.Attachments.Remove(attachment);
            context.SaveChanges();
        }
    }
}
