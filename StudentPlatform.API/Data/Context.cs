using Microsoft.EntityFrameworkCore;
using StudentPlatform.API.Models;

namespace StudentPlatform.API.Data 
{
    public class Context : DbContext 
    {
        // Our DbSet properties tells the context (which talks to the database)
        // which tables exist, DbSet is a type which comes from Entity Framework
        // and defines a tables structure from the class we specify 
        public DbSet<Student> Students {get; set;}
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public string DbPath {get;}

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        public Context(DbContextOptions<Context> options) : base(options) {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "studentplatform.db");
        }      

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}"); 
    }
}