﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Incident
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string AccountName { get; set; }

        public Account Account { get; set; }
    }
}
