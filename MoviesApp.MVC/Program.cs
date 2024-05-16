using MoviesApp.DAL;
using MoviesApp.BL;
using NToastNotify;

namespace MoviesApp.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*------------------------------------------------------------------------*/
            var builder = WebApplication.CreateBuilder(args);
            /*------------------------------------------------------------------------*/
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            /*------------------------------------------------------------------------*/
            builder.Services.AddBLServices();
            builder.Services.AddDALServices(builder.Configuration);
            builder.Services.AddMvc().AddNToastNotifyToastr(new NToastNotify.ToastrOptions()
            {
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                PreventDuplicates = true,
                CloseButton = true
            });
            /*------------------------------------------------------------------------*/
            var app = builder.Build();
            /*------------------------------------------------------------------------*/
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            /*------------------------------------------------------------------------*/
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
            /*------------------------------------------------------------------------*/
        }
    }
}
