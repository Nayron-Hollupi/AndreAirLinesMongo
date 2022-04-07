using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace AirportEntity.Data
{
    public class AirportEntityContext : DbContext
    {
        public AirportEntityContext (DbContextOptions<AirportEntityContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Model.AirportData> AirportData { get; set; }
    }
}
