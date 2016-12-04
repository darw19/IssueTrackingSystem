using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITS.Domain.Entities;
using ITS.Domain.Abstract;

namespace ITS.Domain.Concrete
{
    public class EFWorkLogRepository: IWorkLogsRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<WorkLog> WorkLogs
        {
            get { return context.WorkLogs; }
        }
    }
}
