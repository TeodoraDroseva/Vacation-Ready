using Microsoft.EntityFrameworkCore;
using Vacation_Ready.Models;
using Vacation_Ready.Models.AdditionalTables;
using Vacation_Ready.Models.JoinTables;
using Vacation_Ready.Models.Projects;
using Vacation_Ready.Models.Requests;
using Vacation_Ready.Models.Roles;
using Vacation_Ready.Models.Teams;

namespace Vacation_Ready
{
    public class VacationReadyContext : DbContext
    {
        public VacationReadyContext(DbContextOptions<VacationReadyContext> options)
        {
        }

        public DbSet<LeaveTypesModel> LeaveTypes { get; set; }
        public DbSet<RequestsModel> Requests { get; set; }
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<RolesModel> Roles { get; set; }
        public DbSet<TeamsModel> Teams { get; set; }
        public DbSet<ProjectsModel> Projects { get; set; }
        public DbSet<UsersRolesModel> UsersRoles { get; set; }
        public DbSet<UsersTeamsModel> UsersTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveTypesModel>().ToTable("LeaveTypes");
            modelBuilder.Entity<RequestsModel>().ToTable("Requests");
            modelBuilder.Entity<UsersModel>().ToTable("Users");
            modelBuilder.Entity<RolesModel>().ToTable("Roles");
            modelBuilder.Entity<TeamsModel>().ToTable("Teams");
            modelBuilder.Entity<ProjectsModel>().ToTable("Projects");
            modelBuilder.Entity<UsersRolesModel>().ToTable("UsersRoles");
            modelBuilder.Entity<UsersTeamsModel>().ToTable("UsersTeams");
        }
    }
}