using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_med_koppling_till_databas
{
    internal class Menu
    {//Kan jag göra denna property till ett field istället?
        public Controller_Class ControllerObject { get; set; }
        //Vi har en konstruktor för att ta emot controllklassens objekt.
        public Menu(Controller_Class controllerObject)
        {//I konstruktorn så sätter vi våra lokala property till controller objektet.
            ControllerObject = controllerObject;
            //Jag skapar en loop som loopar tills användaren stänger av programmet.
            bool loop = true;
            while (loop)
            {
                //Inne i konstruktorn har jag en meny. Varför gör vi så? Den skulle aldrig köras annars eller hur?
                Console.WriteLine("1 - Would you like to register a new student?\n" +
                    "2 - Would you like to update an existing student?\n" +
                    "3 - Would you like to see all students?\n" +
                    "4 - Would you like to exit the program?");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Please enter the first name!\n");
                        string firstName = Console.ReadLine();

                        Console.WriteLine("Please enter the last name!\n");
                        string lastName = Console.ReadLine();

                        Console.WriteLine("Please enter the city!");
                        string city = Console.ReadLine();
                        //Vi anropar skapa ny student metoden i controller objektet och skickar med de sparade inmatningar som argument.
                        ControllerObject.CreateNewStudent(firstName, lastName, city);
                        break;

                    case 2:
                        Console.WriteLine("Please enter the id of the student!\n");
                        int idChoice = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Please update first name!\n");
                        string updatedFirstName = Console.ReadLine();

                        Console.WriteLine("Please update last name!\n");
                        string updatedLastName = Console.ReadLine();

                        Console.WriteLine("Please update city!");
                        string updatedCity = Console.ReadLine();
                        //Vi anropar uppdatera studentmetoden och skickar med de sparade inmatningarna som argument.
                        ControllerObject.UpdateStudent(idChoice, updatedFirstName, updatedLastName, updatedCity);
                        break;

                    case 3://Vi skapar en lista, studentLista och anropar getstudentsmetoden i controller objektet.
                        List<Student> studentList = ControllerObject.GetStudents();
                        //För varje studentobjekt i studentlistan så skriver vi ut alla dess egenskaper genom att kalla på dess properties.
                        foreach (Student student in studentList)
                        {
                            Console.WriteLine(student.StudentId + "\n" +
                                student.FirstName + "\n" +
                                student.LastName + "\n" +
                                student.City + "\n");
                        }

                        break;
                        //Om användaren väljer 4 så avslutar vi programmet.
                    case 4:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Please choose a number between 1 and 4!");
                        break;
                }
            }
        }


    }
}
