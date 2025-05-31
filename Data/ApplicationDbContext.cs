using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

//using Microsoft.Identity.Client;
using MyMVCApplication.Models;

namespace MyMVCApplication.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {

        }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<SubjectSchedule> SubjectSchedule { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Account> Account { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.STFSTUDID);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Subject)
                .WithMany()
                .HasForeignKey(e => e.SFSUBJCODE);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.SubjectSchedule)
                .WithMany()
                .HasForeignKey(e => e.SSFEDPCODE);
        }
    }
}
