using Microsoft.Extensions.DependencyInjection;

namespace BadashkoNew;

public void ConfigureServices(IServiceCollection services)
{  
  
    services.AddControllers();
    services.AddSwaggerGen(c =>
    {  
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnionArchitecture", Version = "v1" });
    });  
 
    #region Connection String  
    services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
    #endregion  
 
}