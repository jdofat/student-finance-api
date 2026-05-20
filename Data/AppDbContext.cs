//this file lets API communicate with PSQL:

//EF (Entity Framework) is a “database translator layer” between C# and PostgreSQL
// ^ an EF in .NET lets you work with databases using C# objects instead of always writing raw SQL

using Microsoft.EntityFrameworkCore; //imports Entity Framework Core functionality & access to tools used to connect C# to your database
using StudentFinanceApi.Models; //imports Models folder, allows c# to recognize Student class

namespace StudentFinanceApi.Data //A namespace is just a way to organize/group related code and classes
{ //Everything until the matching closing brace belongs to the Data section of StudentFinanceApi
    public class AppDbContext : DbContext //creates public db context class that inherits functionality from DbContext class
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } //
    }
}

//A context (AppDbContext) is a type of class used by EF
// to manage the connection between the app and database
// It tracks objects, maps them to database tables, and handles reading and writing data:

// “tracks” objects when you pull data from the database:
    // EF doesn’t just return raw data, it turns each row into a C# object and remembers those objects.
    // It remembers what they looked like when they were first loaded.
    // If you change a property on one of those objects, EF detects that difference compared to its original version.