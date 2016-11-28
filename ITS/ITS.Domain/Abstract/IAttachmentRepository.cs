using System.Collections.Generic;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface IAttachmentRepository
    {

        IEnumerable<Attachment> Attachments { get; }
    }
}