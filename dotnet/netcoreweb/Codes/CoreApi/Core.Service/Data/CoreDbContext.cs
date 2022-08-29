using Core.Entity.DBEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service.Data
{
    public class CoreDbContext:DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.DepartmentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoleUser>()
                .HasKey(t => new { t.UserID, t.RoleID });

            modelBuilder.Entity<RoleMenu>()
                .HasKey(t => new { t.MenuID, t.RoleID });
        }
    }
}
