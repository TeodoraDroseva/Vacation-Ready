using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Vacation_Ready.Models.JoinTables;

namespace Vacation_Ready.Models
{
    public class UsersModel : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<UsersTeamsModel> UserTeams { get; set; }
    }
}