
using CWKSOCIAL.Dal;
using Microsoft.EntityFrameworkCore;

namespace CWKSOCIAL.API.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("SQLDB");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
