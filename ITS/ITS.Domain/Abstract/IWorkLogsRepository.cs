using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITS.Domain.Entities;

namespace ITS.Domain.Abstract
{
    public interface IWorkLogsRepository
    {
        IEnumerable<WorkLog> WorkLogs { get; }
    }
}
