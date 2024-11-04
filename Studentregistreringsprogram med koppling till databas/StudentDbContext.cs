using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_med_koppling_till_databas
{
    internal class StudentDbContext:DbContext
    {//Sparar connectionstringen till databasen och servern, väl?
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDatabas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //Skapar en property av datatypen databaslista av typen Student.
        public DbSet<Student> Students { get; set; }
        //Optionsbuilder vet jag inte vad det är? Vi kallar på UseSqlServer metoden som gör vadå? 
        //och skickar med connectionstringen som argument.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
