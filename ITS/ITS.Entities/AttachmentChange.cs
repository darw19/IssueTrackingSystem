//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttachmentChange : BaseChange
    {
        public int AttachmentId { get; set; }
    
        public virtual Attachment Attachment { get; set; }
    }
}
