using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Parking.BLL.DTO;
using Parking.BLL.Helpers;
using Parking.BLL.Interfaces;
using Parking.BLL.Mapper;
using Parking.BLL.Options;
using Parking.BLL.Services;
using Parking.BLL.Validators;
using Parking.DAL;
using Parking.DAL.Interface;
using Parking.DAL.Models;
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
        services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
        services.AddHttpClient();
        services.AddAutoMapper(typeof(AutoMapping));
       // services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("EFConnection")));
        services.AddDbContext<DataContext>(options => options.UseSqlServer(
            Configuration.GetConnectionString("EFConnection")));
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

        #region Validators

        services.AddTransient<IValidator<Car>, CarValidator>();
        services.AddTransient<IValidator<User>, UserValidator>();
        services.AddTransient<IValidator<Arrival>, ArrivalValidator>();
        services.AddTransient<IValidator<Payment>, PaymentValidator>();
        services.AddTransient<IValidator<Tariff>, TariffValidator>();
        services.AddTransient<IValidator<Status>, StatusValidator>();

        #endregion

        #region Sorting Helpers

        services.AddTransient<ISortHelper<Payment>, SortHelper<Payment>>();
        services.AddTransient<ISortHelper<Arrival>, SortHelper<Arrival>>();
        services.AddTransient<ISortHelper<Car>, SortHelper<Car>>();
        services.AddTransient<ISortHelper<Status>, SortHelper<Status>>();
        services.AddTransient<ISortHelper<Tariff>, SortHelper<Tariff>>();
        services.AddTransient<ISortHelper<User>, SortHelper<User>>();

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