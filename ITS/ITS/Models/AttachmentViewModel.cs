using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITS.Domain.Entities;

namespace ITS.Models
{
    public class AttachmentViewModel
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
        public Attachment Attachment { get; set; }
    }
}