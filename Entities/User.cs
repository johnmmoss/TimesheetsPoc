﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TimesheetPoc.Domain
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }
    }
}
