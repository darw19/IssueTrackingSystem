using System.Collections.Generic;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface IIssueChangeRepository
    {

        IEnumerable<IssueChange> IssueChanges { get; }
    }
}