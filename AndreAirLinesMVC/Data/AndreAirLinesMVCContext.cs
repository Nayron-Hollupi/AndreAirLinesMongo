﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthenticationAPI.Models;
using Model;

namespace AndreAirLinesMVC.Data
{
    public class AndreAirLinesMVCContext : DbContext
    {
        public AndreAirLinesMVCContext (DbContextOptions<AndreAirLinesMVCContext> options)
            : base(options)
        {
        }

        public DbSet<AuthenticationAPI.Models.User> User { get; set; }

        public DbSet<Model.Aircraft> Aircraft { get; set; }
    }
}
