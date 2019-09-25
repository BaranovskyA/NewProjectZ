﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public partial class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
