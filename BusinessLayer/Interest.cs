﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DistrictId { get; set; }
    }
}
