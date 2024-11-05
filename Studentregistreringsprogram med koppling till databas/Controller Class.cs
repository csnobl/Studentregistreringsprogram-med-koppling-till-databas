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
        private StudentDbContext _dbCtxObject;
        
        public Controller_Class(StudentDbContext dbCtxObject)
        {
            _dbCtxObject = dbCtxObject;
        }
        
        public void CreateNewStudent(string firstName, string lastName, string city)
        {
            _dbCtxObject.Students.Add(new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                City = city
            });
            _dbCtxObject.SaveChanges();
        }
        
        public void UpdateStudent(int idChoice, string updatedFirstName, string updatedLastName, string updatedCity)
        {
            Student updateStudent = _dbCtxObject.Students.Where(x => x.StudentId == idChoice).FirstOrDefault();
            
            if (updateStudent != null)
            {
                updateStudent.FirstName = updatedFirstName;
                updateStudent.LastName = updatedLastName;
                updateStudent.City = updatedCity;
            }

            _dbCtxObject.SaveChanges();
        }
        
        public List<Student> GetStudents()
        {
            return _dbCtxObject.Students.ToList();
        }

        public bool StudentExist(int idChoice)
        {
            Student studentExist = _dbCtxObject.Students.Where(x => x.StudentId == idChoice).FirstOrDefault();
            if (studentExist != null)
            {
                return true;
            }
            return false;
        }

        public void Run()
        {
            Menu menu = new Menu(this);
        }
    }
}
