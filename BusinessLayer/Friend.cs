using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class Friend
    {
        public Friend()
        {
            Userfriends = new HashSet<Userfriend>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<Userfriend> Userfriends { get; set; }
    }
}
