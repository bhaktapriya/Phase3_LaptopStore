﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class MyIdentityDbContext : IdentityDbContext
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext>options): base(options)
        {

        }
    }
}
