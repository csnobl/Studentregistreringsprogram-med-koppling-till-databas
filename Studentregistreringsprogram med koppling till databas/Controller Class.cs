using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Studentregistreringsprogram_med_koppling_till_databas
{
    internal class Controller_Class
    {
        //Kan jag göra denna property till ett field istället?
        public StudentDbContext DbCtxObject { get; set; }
        //Skapar en konstruktor för att kunna ta emot DBobjektet och spara det. Vi ska använda det nedan.
        //men varför skapar vi inte DBobjektet i denna klass istället?
        public Controller_Class(StudentDbContext dbCtxObject)
        {
            DbCtxObject = dbCtxObject;
        }
        //en metod som tar emot värden ifrån menu klassen och användaren.
        //Vi kallar på DBStudent objektet och använder add metodend för att lägga till studentobjekt till en dbSet lista.
        //Men varför kallar vi inte på listan för att kunna göra add på den? Det känns konstigt att göra add på ett objekt..
        //Propertiesen i studentobjektet sätts av inparametrarna i metoden.
        public void CreateNewStudent(string firstName, string lastName, string city)
        {
            DbCtxObject.Add(new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                City = city
            });
            //Vi sparar, men vart sparar vi? Jag menar, vi sparar väl inte till db, för det görs väl i package manager consolen?
            DbCtxObject.SaveChanges();
        }
        //Vi har en metod som tar ett par inparametrar ifrån menu klassen och användaren.
        public void UpdateStudent(int idChoice, string updatedFirstName, string updatedLastName, string updatedCity)
        {//Vi skapar en variabel som heter updateStudent. Sen kallar vi på DBStudent objektet och dess lista. Listan sorterar jag ut på vilket ID som kommer som inparameter.
            //Jag kör First metoden för att köra sorteringen, annars körs den inte.
            Student updateStudent = DbCtxObject.Students.Where(x => x.StudentId == idChoice).First();
            // Vi ser till att inte uppdatera studentobjektets properies till null. Men varför är detta med null och inte så viktigt?
            if (updateStudent != null)
            {//Vi uppdaterar studentobjekten med inparametrarna till metoden)
                updateStudent.FirstName = updatedFirstName;
                updateStudent.LastName = updatedLastName;
                updateStudent.City = updatedCity;
            }

            DbCtxObject.SaveChanges();
        }
        //Vi skapar en returmetod av datatypen Lista av typen Student.
        public List<Student> GetStudents()
        {
            //Returnerar DBStudent objektets dbSet lista, fast vi gör om den till en vanig lista med ToList metoden först.
            return DbCtxObject.Students.ToList();
        }
        //En metod som skapar ett menyobjekt och skickar med controller klassens objekt.
        //Varför skapar vi menu objektet? Vi använder ju det aldrig till något?
        public void Run()
        {
            Menu menu = new Menu(this);
        }
    }
}
