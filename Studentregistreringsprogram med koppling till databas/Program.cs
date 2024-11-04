namespace Studentregistreringsprogram_med_koppling_till_databas
{
    internal class Program
    {//
        static void Main(string[] args)
        {
            //skapar ett objekt av controller klassen samt skickar med ett DBobjekt som vi skapar som argument.
            var controller = new Controller_Class(new StudentDbContext());
            //använder controller objektet och kallar på Run metoden.
            controller.Run();
        }
    }
}
