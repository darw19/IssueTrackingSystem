using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITS.Domain.Entities;

namespace ITS.Models
{
    public class AttachmentViewModel
    {
        virtual public IEnumerable<HttpPostedFileBase> Files { get; set; }
        virtual public Attachment Attachment { get; set; }
    }
}