using Vacation_Ready.Models.Teams;

namespace Vacation_Ready.Models.Projects
{
    public class ProjectsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public TeamsModel Team { get; set; }
    }
}