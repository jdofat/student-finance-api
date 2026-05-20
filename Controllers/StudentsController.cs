//

// this file


//'using' imports the namespaces so the app can use their classes
using Microsoft.AspNetCore.Mvc; //imports .net's built in tools
using StudentFinanceApi.Data; //imports StudentFinanceApi.Data namespace whih contains AppDbCOntext class so we can use it in this file without writing the full namespace path
using StudentFinanceApi.Models; //imports the Student model class

[ApiController] //activates "API mode" which enables behaviors like automatic request handling and validation
[Route("students")] ///sets the base url route for all. endpoints as /students
public class StudentsController : ControllerBase //creates the controller and gives it API functionality
{
    private readonly AppDbContext _context; //creates a private variable to store the database context

    public StudentsController(AppDbContext context) //constructor that runs automatically and receives the database context
    {
        _context = context; //stores the passed-in database context so we can use it in all endpoints
    }

    [HttpGet] //When a GET (read) request comes to this controller’s route, run this method
    public IActionResult GetStudents() //Create a method called GetStudents that returns an HTTP response
    {
        var students = _context.Students.ToList(); //queries the database and retrieves all students as a list
        return Ok(students); //returns the data as a 200 OK response in JSON format
    }

    [HttpGet("{id}")] //routes to GET /students/{id} , runs when the URL includes a student ID.
    public IActionResult GetStudentById(int id) //takes the integer id from the URL and stores it in a variable
    {
        var student = _context.Students.Find(id); //finds a student by primary key and stores the returned object in the student variable

        if (student == null)
        {
            return NotFound();
        }

        return Ok(student); //sends a successful HTTP response back to the client with status code 200 OK
    }

    [HttpPost] //routing: tells ASP.NET Core to run this when given a POST request to /students (POST creates data)
    public IActionResult CreateStudent([FromBody] Student student) //so ASP.NET Core can receive JSON and convert it into a C# Student object
    // ^^ Student is the class, and 'student' is the variable that holds the created Student object from the JSON request
    {
        _context.Students.Add(student); //tells EF Core to track this new student and prepare it for insertion
        _context.SaveChanges(); //executes the SQL INSERT and writes it to PostgreSQL

        return Ok(student); //returns the created student back to the client as JSON
    }

}