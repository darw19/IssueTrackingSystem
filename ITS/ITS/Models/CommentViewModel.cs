using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITS.Domain.Entities;

namespace ITS.Models
{
    public class CommentViewModel
    {
        public string UserEmail { get; set; }
        public Comment Comment { get; set; }
    }
}