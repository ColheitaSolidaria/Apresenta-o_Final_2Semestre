using ColheitaSolidaria.Data;
using ColheitaSolidaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace ColheitaSolidaria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar o DbContext com a string de conexão
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configurar sessão (necessário para armazenar dados do usuário)
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Duração da sessão
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Adicionar suporte a controladores e views
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Ativar o middleware de sessão
            app.UseSession();

            app.UseRouting();
#pragma warning disable ASP0014 // Suggest using top level route registrations
            _ = app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
#pragma warning restore ASP0014 // Suggest using top level route registrations

            app.Run();

            var builderr = WebApplication.CreateBuilder(args);
            builderr.Services.AddDbContext<ColheitaSolidariaContext>(options =>
                options.UseSqlServer(builderr.Configuration.GetConnectionString("ColheitaSolidariaContext") ?? throw new InvalidOperationException("Connection string 'ColheitaSolidariaContext' not found.")));

            // Add services to the container.
            builderr.Services.AddControllersWithViews();

            var appp = builderr.Build();

            // Configure the HTTP request pipeline.
            if (!appp.Environment.IsDevelopment())
            {
                appp.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                appp.UseHsts();
            }

            appp.UseHttpsRedirection();
            appp.UseStaticFiles();

            appp.UseRouting();

            appp.UseAuthorization();

            appp.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            appp.Run();

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(static options =>
                options.UseSqlServer(GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
        }

        private static Action<SqlServerDbContextOptionsBuilder>? GetConnectionString(string v)
        {
            throw new NotImplementedException();
        }
    }
}
