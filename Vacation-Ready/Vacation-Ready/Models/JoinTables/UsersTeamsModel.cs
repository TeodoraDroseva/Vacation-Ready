using Vacation_Ready.Models.Teams;

namespace Vacation_Ready.Models.JoinTables
{
    public class UsersTeamsModel
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public UsersModel Users { get; set; }
        public TeamsModel Teams { get; set; }
    }
}