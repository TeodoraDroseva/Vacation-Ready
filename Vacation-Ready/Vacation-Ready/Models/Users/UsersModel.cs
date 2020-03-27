using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Vacation_Ready.Models.Teams;

namespace Vacation_Ready.Models
{
    public class UsersModel : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<TeamsModel> Teams { get; set; }
    }
}