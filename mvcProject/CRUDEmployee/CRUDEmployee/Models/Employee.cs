﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDEmployee.Models
{
    public class Employee
    {
        
        public int Empid { get; set; }
        
       
        public string Name { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

    }
}