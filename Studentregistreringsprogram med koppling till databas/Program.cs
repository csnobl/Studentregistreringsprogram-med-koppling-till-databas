namespace Studentregistreringsprogram_med_koppling_till_databas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller_Class(new StudentDbContext());
            
            controller.Run();
        }
    }
}
