using AspNetNotes.Data;

namespace AspNetNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}