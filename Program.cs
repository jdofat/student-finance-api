// program.cs configures and starts the entire app and connects the backend pieces together so the api can run

// first, configure: psql connection, entity framework, dependency injection, controllers, api routing, 
using Microsoft.EntityFrameworkCore; //'using' imports functionality so .NET can talk to PSQL using C# instead of raw SQL
using StudentFinanceApi.Data; //imports 'Data' folder and gives Program.cs access to AppDbContext inside Data/appdbcontext.cs

var builder = WebApplication.CreateBuilder(args); //creates the application builder(variable) that stores the object is a built-in .NET method

// IMPORTANT FOR RENDER
builder.WebHost.UseUrls("http://0.0.0.0:10000");

//connect to PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options => //registers database context as a service: something the application can automatically create and provide when needed
    options.UseNpgsql( //we're using psql: PostgreSQL provider for .NET
        builder.Configuration.GetConnectionString("DefaultConnection") // dependency injection, reads the connection string from appsettings.json
    ));

//add controller support: looks for controller classes and lets api requests use them
builder.Services.AddControllers();

// now we build and start the application:

var app = builder.Build(); //builds the application
//recognize the frontend html/js/css files:
app.UseDefaultFiles();
app.UseStaticFiles();

//configures API routing, tells .net to search for controller classes and activate their routes:
app.MapControllers(); 

app.Run(); //starts the server