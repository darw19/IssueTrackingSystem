using System.Collections.Generic;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface ICommentChangeRepository
    {
        IEnumerable<CommentChange> CommentChanges { get; }
    }
}