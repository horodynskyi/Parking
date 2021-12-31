using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Parking.BLL.DTO;
using Parking.BLL.Interfaces;
using Parking.BLL.Mapper;
using Parking.BLL.Options;
using Parking.BLL.Services;
using Parking.DAL;
using Parking.DAL.Interface;
using Parking.DAL.Repositories;

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
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddDbContext<DataContext>(options => options.UseSqlServer(
            Configuration.GetConnectionString("EFConnection"),
            b => b.MigrationsAssembly("Parking.WEB"))
                
        );
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "Parking.WEB", Version = "v1"});
        });

        #region Twilio

        services.Configure<TwilioOptions>(Configuration.GetSection(TwilioOptions.Twilio));
        services.AddTransient<ITwilioService, TwilioService>();

        #endregion
        #region BLL
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ITariffService, TariffService>();
        services.AddTransient<ICarService, CarService>();
        services.AddTransient<IPaymentService, PaymentService>();
        services.AddTransient<IStatusService, StatusService>();
        services.AddTransient<IArrivalService, ArrivalService>();
        #endregion

        #region Repositories

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITariffRepository, TariffRepository>();
        services.AddTransient<ICarRepository, CarRepository>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();
        services.AddTransient<IStatusRepository, StatusRepository>();
        services.AddTransient<IArrivalRepository, ArrivalRepository>();

        #endregion
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