using System.Collections.Generic;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface IAttachmentChangeRepository
    {

        IEnumerable<AttachmentChange> AttachmentChanges { get; }
    }
}