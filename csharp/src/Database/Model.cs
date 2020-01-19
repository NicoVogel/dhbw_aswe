using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mvvm.Model;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {
        //public DbSet<ClassBook> ClassBooks { get; set; }
        //public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }
}