using System;
using System.Collections.Generic;
using System.Linq;
using GreenReward.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenReward.Server.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Historico> Historico { get; set; }
        
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    }
}