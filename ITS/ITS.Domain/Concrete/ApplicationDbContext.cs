using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ITS.Domain.Entities;

namespace ITS.Domain.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AttachmentChange> AttachmentChanges { get; set; }
        public DbSet<BaseChange> BaseChanges { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueChange> IssueChanges { get; set; }
        public DbSet<CommentChange> CommentChanges { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }
        public ApplicationDbContext()
            : base("Data Source=(LocalDb)\\v11.0;Initial Catalog=aspnet-ITS;Integrated Security=True", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
