using TaskManager.Web.Services;

namespace TaskManager.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();
            builder.Services.AddHttpClient<ApiService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7293/"); 
            });



            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //builder.Services.AddHttpContextAccessor();

            // Register the handler
            builder.Services.AddTransient<AuthenticationDelegatingHandler>();

            // Configure your HttpClient (assuming you're using IHttpClientFactory)
            //builder.Services.AddHttpClient("API", client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:7293/");
            //})
            //.AddHttpMessageHandler<AuthenticationDelegatingHandler>();


            var app = builder.Build();
            app.UseSession();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
