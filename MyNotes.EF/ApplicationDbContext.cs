using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyNotes.Models;
using MyNotes.Authenticate;

namespace MyNotes.EF
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<Note> Note { get; set; }
    }
}