using AppController;
using AppModels;
using Utilities;

namespace UiPatientApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IEventDispatcher, EmptyEventDispatcher>();
            services.AddScoped<IModel, Model>();
            services.AddScoped<IController, Controller>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            /* AT
            app.UseHttpsRedirection( );
            */
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
           {
               endpoints.MapBlazorHub();
               endpoints.MapFallbackToPage("/_Host");
           });
        }
    }
}
