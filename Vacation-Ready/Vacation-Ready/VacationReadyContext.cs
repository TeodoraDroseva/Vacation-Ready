using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vacation_Ready.Models;
using Vacation_Ready.Models.JoinTables;
using Vacation_Ready.Models.Projects;
using Vacation_Ready.Models.Teams;

namespace Vacation_Ready
{
    public class VacationReadyContext : IdentityDbContext<UsersModel, IdentityRole<int>, int>
    {
        public VacationReadyContext(DbContextOptions<VacationReadyContext> options)
        {
        }

        public DbSet<LeaveTypesModel> LeaveTypes { get; set; }
        public DbSet<RequestsModel> Requests { get; set; }
        public DbSet<TeamsModel> Teams { get; set; }
        public DbSet<ProjectsModel> Projects { get; set; }
        public DbSet<UsersTeamsModel> UsersTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LeaveTypesModel>().ToTable("LeaveTypes");
            modelBuilder.Entity<RequestsModel>().ToTable("Requests");
            modelBuilder.Entity<RequestsModel>().HasOne(r => r.LeaveType).WithOne(l => l.Request).HasForeignKey<RequestsModel>(lti => lti.LeaveTypeId);
            modelBuilder.Entity<TeamsModel>().ToTable("Teams");
            modelBuilder.Entity<ProjectsModel>().ToTable("Projects").HasOne(t => t.Team).WithMany(p => p.Projects).HasForeignKey(ti => ti.TeamId);
            modelBuilder.Entity<UsersTeamsModel>().ToTable("UsersTeams").HasKey(ut => new { ut.UserId, ut.TeamId });
            modelBuilder.Entity<UsersTeamsModel>().HasOne(u => u.User).WithMany(ut => ut.UserTeams).HasForeignKey(ui => ui.UserId);
            modelBuilder.Entity<UsersTeamsModel>().HasOne(t => t.Team).WithMany(tu => tu.TeamUsers).HasForeignKey(ti => ti.TeamId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Vacation-Ready;Trusted_Connection=True;");
        }
    }
}