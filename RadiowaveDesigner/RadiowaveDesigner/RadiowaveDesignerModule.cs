using RadiowaveDesigner.Services;

namespace RadiowaveDesigner;

public static class RadiowaveDesignerModule
{
    internal static void AddRadiowaveDesignerModule(this IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddTransient<IHomeService, HomeService>();
    }
}