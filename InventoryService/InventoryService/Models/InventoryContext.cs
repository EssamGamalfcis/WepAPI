using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    public class InventoryContext : DbContext
    {
        public DbSet<InventoryItems> InventoryItem { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3L6MHQI;Initial Catalog=WebAPI;User ID=sa;Password=Essam2014");
        }
    }
}
