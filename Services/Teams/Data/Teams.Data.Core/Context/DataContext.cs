﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Teams.Data.Contracts.Context;
using Teams.Data.Entities;

namespace Teams.Data.Core.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringProvider.GetSqlConnection());
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}