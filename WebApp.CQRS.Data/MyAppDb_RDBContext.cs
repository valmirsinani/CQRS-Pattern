﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.CQRS.Data
{
 
    public class MyAppDb_RDBContext : DbContext
    {
        public MyAppDb_RDBContext(DbContextOptions<MyAppDb_RDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(build => {
                build.HasKey(_ => _.Id);
            });
        }
    }
}
