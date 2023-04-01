using RadiowaveDesigner.Infrastructure;
using RadiowaveDesigner.Settings;

namespace RadiowaveDesigner;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRadiowaveDesignerModule();
        services.RegisterSettings<YandexApiSettings>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");
        });
    }
}