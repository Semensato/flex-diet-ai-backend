using FlexDietAiDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Data
{
    public class FlexDietAiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserData> UsersData { get; set; } = null!;
        public DbSet<UserHealth> UsersHealth { get; set; } = null!;
        public DbSet<UserDiet> UsersDiets { get; set; } = null!;
        public DbSet<DietMenu> DietsMenus { get; set; } = null!;

        public FlexDietAiDbContext(DbContextOptions<FlexDietAiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRelationShips(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Configure all the tables relationships
        /// </summary>
        /// <param name="modelBuilder">DbContext modelbuilder</param>
        private void ConfigureRelationShips(ModelBuilder modelBuilder)
        {
            ConfigureUserRelationShip(modelBuilder);
            ConfigureUserHealthRelationship(modelBuilder);
            ConfigureUserDietRelationship(modelBuilder);
            ConfigureDietMenuRelationship(modelBuilder);
        }

        /// <summary>
        /// Configures User and UserData relationship.
        /// </summary>
        /// <param name="modelBuilder">DbContext modelbuilder</param>
        private void ConfigureUserRelationShip(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<UserData>(u => u.UserData)
                .WithOne(us => us.User)
                .HasForeignKey<UserData>(us => us.UserId);
        }

        /// <summary>
        /// Configures User and UserHealth relationship.
        /// </summary>
        /// <param name="modelBuilder">DbContext modelbuilder</param>
        private void ConfigureUserHealthRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<UserHealth>(u => u.UserHealth)
                .WithOne(us => us.User)
                .HasForeignKey(us => us.UserId);
        }

        /// <summary>
        /// Configures User and UserDiet relationship.
        /// </summary>
        /// <param name="modelBuilder">DbContext modelbuilder</param>
        private void ConfigureUserDietRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<UserDiet>(u => u.UserDiet)
                .WithOne(ud => ud.User)
                .HasForeignKey(ud => ud.UserId);
        }

        /// <summary>
        /// Configures DietMenu and UserMenu relationship.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void ConfigureDietMenuRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDiet>()
                .HasMany<DietMenu>(ud => ud.DietMenu)
                .WithOne(um => um.UserDiet)
                .HasForeignKey(um => um.UserDietId);
        }
    }
}
