using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class Userfriend
    {
        public int UserId { get; set; }
        public int FriendsId { get; set; }

        public virtual Friend Friends { get; set; }
        public virtual User User { get; set; }
    }
}
