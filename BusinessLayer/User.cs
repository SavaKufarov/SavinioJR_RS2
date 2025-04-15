using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class User
    {
        public User()
        {
            Userfriends = new HashSet<Userfriend>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? FriendsId { get; set; }
        public int? DistrictId { get; set; }

        public virtual ICollection<Userfriend> Userfriends { get; set; }
    }
}
