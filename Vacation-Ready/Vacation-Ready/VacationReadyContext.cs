using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vacation_Ready.Models;
using Vacation_Ready.Models.AdditionalTables;
using Vacation_Ready.Models.JoinTables;
using Vacation_Ready.Models.Projects;
using Vacation_Ready.Models.Requests;
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
            modelBuilder.Entity<TeamsModel>().ToTable("Teams");
            modelBuilder.Entity<ProjectsModel>().ToTable("Projects");
            modelBuilder.Entity<UsersTeamsModel>().HasNoKey().ToTable("UsersTeams");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Vacation-Ready;Trusted_Connection=True;");
        }
    }
}