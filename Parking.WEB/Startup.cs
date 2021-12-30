using Microsoft.OpenApi.Models;
using Parking.BLL.Interfaces;
using Parking.BLL.Options;
using Parking.BLL.Services;

namespace Parking.WEB;

public class Startup
{
    public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    public IConfiguration Configuration { get; }
 
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "Parking.WEB", Version = "v1"});
        });
        services.Configure<TwilioOptions>(Configuration.GetSection(TwilioOptions.Twilio));
        services.AddTransient<ITwilioService, TwilioService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parking v1"));
        }
        
        
       // app.UseHttpsRedirection();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}