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
    {
        private Controller_Class ControllerObject;
        
        public Menu(Controller_Class controllerObject)
        {
            ControllerObject = controllerObject;
            
            PresentMenu();
        }
        public void PresentMenu()
        {
            bool loop = true;
            while (loop)
            {
                
                Console.WriteLine("1 - Would you like to register a new student?\n" +
                    "2 - Would you like to update an existing student?\n" +
                    "3 - Would you like to see all students?\n" +
                    "4 - Would you like to exit the program?");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine();

                        Console.WriteLine("Please enter the first name!");
                        string firstName = Console.ReadLine();

                        Console.WriteLine("Please enter the last name!");
                        string lastName = Console.ReadLine();

                        Console.WriteLine("Please enter the city!");
                        string city = Console.ReadLine();

                        Console.WriteLine();

                        ControllerObject.CreateNewStudent(firstName, lastName, city);
                        break;

                    case 2:
                        Console.WriteLine();

                        Console.WriteLine("Please enter the id of the student!");
                        int idChoice = Convert.ToInt32(Console.ReadLine());

                        if (!ControllerObject.StudentExist(idChoice))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a valid number, you can always look in the list!");
                            Console.WriteLine();
                            break;
                        }

                        Console.WriteLine("Please update first name!");
                        string updatedFirstName = Console.ReadLine();

                        Console.WriteLine("Please update last name!");
                        string updatedLastName = Console.ReadLine();

                        Console.WriteLine("Please update city!");
                        string updatedCity = Console.ReadLine();

                        Console.WriteLine();
                        
                        ControllerObject.UpdateStudent(idChoice, updatedFirstName, updatedLastName, updatedCity);
                        break;

                    case 3:
                        Console.WriteLine();

                        List<Student> studentList = ControllerObject.GetStudents();
                        
                        foreach (Student student in studentList)
                        {
                            Console.WriteLine(student.StudentId + "\n" +
                                student.FirstName + "\n" +
                                student.LastName + "\n" +
                                student.City + "\n");
                        }

                        break;
                    
                    case 4:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine();

                        Console.WriteLine("Please choose a number between 1 and 4!");

                        Console.WriteLine();

                        break;
                }
            }
        }
    }
}
