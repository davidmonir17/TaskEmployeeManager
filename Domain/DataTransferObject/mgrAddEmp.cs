﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObject
{
    public class mgrAddEmp
    {
        public string Name { get; set; }

        public int Phone { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }
    }
}