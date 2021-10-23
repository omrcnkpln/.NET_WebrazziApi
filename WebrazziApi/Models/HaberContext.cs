using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebrazziApi.Models
{
    public class HaberContext : DbContext
    {
        public HaberContext(DbContextOptions<HaberContext> options)
            : base(options)
        {

        }

        public DbSet<HaberItem> HaberItems { get; set; }
    }
}
