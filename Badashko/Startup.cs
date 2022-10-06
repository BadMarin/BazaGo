using Microsoft.OpenApi.Models;
using RepositoryLayer;
using RepositoryLayer.RespositoryPattern;
using ServicesLayer.CustomerService;

namespace Badashko;

    public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
       
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {  
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnionArchitecture", Version = "v1" });
        });  
 
        #region Connection String  
        services.AddDbContext<ApplicationDbContext>(item => 
            item.UseSqlServer(Configuration.GetConnectionString("myconn")));
        #endregion  
        
        #region Services Injected  
        services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        services.AddTransient<ICustomerService, CustomerService>();
        #endregion
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {  
        if (env.IsDevelopment())
        {  
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnionArchitecture v1"));
        }  
  
        app.UseHttpsRedirection();
  
        app.UseRouting();
  
        app.UseAuthorization();
  
        app.UseEndpoints(endpoints =>
        {  
            endpoints.MapControllers();
        });  
    }  

   
}

