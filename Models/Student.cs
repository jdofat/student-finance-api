//a class is a blueprint that defines what something looks like and what it can do

//defines what a student object looks like in c#

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentFinanceApi.Models
{
    [Table("students")] //the actual table name is "s"tudents
    public class Student //create student class which will define the following properties:
    {
        [Key] //tells EF Core this is the primary key
        
        public int student_id { get; set; } //public can be accessed from anywhere

        public string? student_name { get; set; } //get = read value, set = change value

        public string? student_email { get; set; } //C# is allowed to read and write this value

        public string? firebase_uid { get; set; } //name matches SQL column
    }
}