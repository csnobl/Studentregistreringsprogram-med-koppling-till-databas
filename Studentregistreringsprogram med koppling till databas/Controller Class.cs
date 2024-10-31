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
        public StudentDbContext DbCtxObject { get; set; }

        public Controller_Class(StudentDbContext dbCtxObject)
        {
            DbCtxObject = dbCtxObject;
        }

        public void CreateNewStudent(string firstName, string lastName, string city)
        {
            DbCtxObject.Add(new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                City = city
            });

            DbCtxObject.SaveChanges();
        }

        public void UpdateStudent(int idChoice, string updatedFirstName, string updatedLastName, string updatedCity)
        {
            Student updateStudent = DbCtxObject.Students.Where(x => x.StudentId == idChoice).First();

            if (updateStudent != null)
            {
                updateStudent.FirstName = updatedFirstName;
                updateStudent.LastName = updatedLastName;
                updateStudent.City = updatedCity;
            }

            DbCtxObject.SaveChanges();
        }

        public List<Student> GetStudents()
        {

            return DbCtxObject.Students.ToList();
        }

        public void Run()
        {
            Menu menu = new Menu(this);
        }
    }
}
