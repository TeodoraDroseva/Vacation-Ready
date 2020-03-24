using System.Collections.Generic;
using Vacation_Ready.Models.Roles;
using Vacation_Ready.Models.Teams;

namespace Vacation_Ready.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<RolesModel> Roles { get; set; }
        public ICollection<TeamsModel> Teams { get; set; }
    }
}