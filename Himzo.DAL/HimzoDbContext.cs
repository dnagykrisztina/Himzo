using System;
using System.Collections.Generic;
using System.Text;

using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Himzo.Dal
{
    public class HimzoDbContext : IdentityDbContext<User, Role, int>
    {
		public HimzoDbContext() : base(new DbContextOptionsBuilder().Options) { }
		public HimzoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Comment);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments);

            modelBuilder.Entity<Role>().ToTable("Roles");

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User);

        }

    }
}
