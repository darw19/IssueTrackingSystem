using System.Collections.Generic;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface IBaseChangeRepository
    {

        IEnumerable<BaseChange> BaseChanges { get; }
    }
}