using Vacation_Ready.Models.Teams;

namespace Vacation_Ready.Models.JoinTables
{
    public class UsersTeamsModel
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public UsersModel User { get; set; }
        public TeamsModel Team { get; set; }
    }
}