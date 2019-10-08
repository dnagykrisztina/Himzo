using System;
using System.Collections.Generic;
using System.Text;

using Himzo.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Himzo.Dal
{
    public class HimzoDbContext : DbContext
    {
        public HimzoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
