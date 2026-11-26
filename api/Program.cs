using Microsoft.EntityFrameworkCore;
using service;
using repository;
namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddFilter(
    "Microsoft.AspNetCore.StaticFiles",
    LogLevel.Debug);
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<my_shopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Transient);
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPasswordService, PasswordService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ICategoryRepositpry, CategoryRepositpry>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();


            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // חשוב: הניתוב חייב לבוא אחרי הקבצים הסטטיים
            app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "v1");
                });
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}