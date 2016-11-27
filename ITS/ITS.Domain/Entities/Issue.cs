

namespace ITS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class Issue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Issue()
        {
            this.Attachments = new HashSet<Attachment>();
            this.Comments = new HashSet<Comment>();
            this.IssueChanges = new HashSet<IssueChange>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UserEmail { get; set; }
    
        public virtual ApplicationUser AssignedTo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attachment> Attachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueChange> IssueChanges { get; set; }
    }
}
