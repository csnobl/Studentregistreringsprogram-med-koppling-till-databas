using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_med_koppling_till_databas
{
    internal class Menu
    {
        public Controller_Class ControllerObject { get; set; }
        public Menu(Controller_Class controllerObject)
        {
            ControllerObject = controllerObject;

            Console.WriteLine("1 - Would you like to register a new student?\n" +
                "2 - Would you like to update an existing student?\n" +
                "3 - Would you like to see all students?");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Please enter the first name!\n");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Please enter the last name!\n");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Please enter the city!");
                    string city = Console.ReadLine();

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

                    ControllerObject.UpdateStudent(idChoice, updatedFirstName, updatedLastName, updatedCity);
                    break;

                case 3:
                    List<Student> studentList = ControllerObject.GetStudents();

                    foreach(Student student in studentList)
                    {
                        Console.WriteLine(student.StudentId + "\n" +
                            student.FirstName + "\n" +
                            student.LastName + "\n" +
                            student.City + "\n");
                    }

                    break;

                default:
                    Console.WriteLine("Choose a number between 1 and 3!");
                    break;
            }
        }


    }
}
