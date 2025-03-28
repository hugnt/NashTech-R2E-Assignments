
using Assignment03.API.Middlewares;
using Assignment03.API.Services;

namespace Assignment03.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //add DI service
            //builder.Services.AddSingleton<ILoggingService, SeriLogService>();
            builder.Services.AddSingleton<ILoggingService, LoggingService>();
            builder.Services.AddSingleton<IStudentService, StudentService>();

            var app = builder.Build();
            // Middleware
            app.UseMiddleware<LoggingRequestMiddleware>();
            app.UseMiddleware<LoggingResponseMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
