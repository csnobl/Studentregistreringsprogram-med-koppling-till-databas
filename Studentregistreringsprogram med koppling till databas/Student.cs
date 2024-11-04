using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_med_koppling_till_databas
{
    internal class Student
    {//Vi skapar 4 properties med 4 olika egenskaper. StudentID låter vi bara databasen sätta, den rör vi inte.
        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string City { get; set; } = "";
        //Vi har en tom konstruktor så att man kan skapa en student utan att direkt ange egenskaperna.
        public Student()
        {
            
        }
    }
}
