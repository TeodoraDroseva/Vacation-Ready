using Vacation_Ready.Models.Roles;

namespace Vacation_Ready.Models.JoinTables
{
    public class UsersRolesModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public UsersModel Users { get; set; }
        public RolesModel Roles { get; set; }
    }
}