/* AT
using Microsoft.AspNetCore.Authentication.Certificate;
*/
using Microsoft.OpenApi.Models;

namespace PatientApplicationMicroservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /* AT
            services.AddAuthentication( CertificateAuthenticationDefaults.AuthenticationScheme ).AddCertificate( );
            */
            services.AddControllers();

            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo { Title = "PatientApplicationMicroservice", Version = "v1" }); });

            services.AddHttpClient();
            services.AddTransient<IDoctorApplicationHandler, DoctorApplicationHandler>();
            services.AddTransient<IDoctorDataServiceClient, DoctorDataServiceClient>();
            services.AddTransient<IPatientApplicationHandler, PatientApplicationHandler>();
            services.AddTransient<IPatientDataServiceClient, PatientDataServiceClient>();
            services.AddTransient<IDrugApplicationHandler, DrugApplicationHandler>();
            services.AddTransient<IDrugDataServiceClient, DrugDataServiceClient>();
            services.AddTransient<IPrescriptionApplicationHandler, PrescriptionApplicationHandler>();
            services.AddTransient<IPrescriptionDataServiceClient, PrescriptionDataServiceClient>();

            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientApplicationMicroservice v1"));
            }
            
            app.UseHttpsRedirection( );
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}