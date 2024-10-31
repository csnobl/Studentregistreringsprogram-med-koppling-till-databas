namespace Studentregistreringsprogram_med_koppling_till_databas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDatabas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

            var controller = new Controller_Class(new StudentDbContext());

            controller.Run();
        }
    }
}
