using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Services;


namespace ToDoListAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Habilitar CORS para permitir solicitudes de otros dominios (ej. frontend)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()  // Permite cualquier origen
                           .AllowAnyMethod()  // Permite cualquier método HTTP (GET, POST, etc.)
                           .AllowAnyHeader());  // Permite cualquier encabezado
            });


            //builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("ToDoListDB"));    

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSqlServer<ApiContext>(builder.Configuration.GetConnectionString("todolistcon"));
            builder.Services.AddScoped<IToDoList, ToDoListServices>();
            builder.Services.AddScoped<IUsuario, UsuarioServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");  // Aplicar la política de CORS

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}
