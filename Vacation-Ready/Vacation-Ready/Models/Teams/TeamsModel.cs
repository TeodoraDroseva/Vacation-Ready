using System.Collections.Generic;
using Vacation_Ready.Models.JoinTables;
using Vacation_Ready.Models.Projects;

namespace Vacation_Ready.Models.Teams
{
    public class TeamsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UsersTeamsModel> TeamUsers { get; set; }
        public ICollection<ProjectsModel> Projects { get; set; }
    }
}