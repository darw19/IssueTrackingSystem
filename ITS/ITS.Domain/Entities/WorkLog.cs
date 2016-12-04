using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Domain.Entities
{
    public class WorkLog
    {
        [Key]
        public int Id { get; set; }
        public int MillisecondsLogged { get; set; }
        public DateTime TimeOfLogging { get; set; }

        public int? IssueId { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Issue Issue { get; set; }
    }
}
