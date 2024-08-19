using KashFlow.Domain.Entities;
using KashFlow.Domain.Interfaces.Repositories;
using KashFlow.Domain.Interfaces.Services;
using KashFlow.Infrastructure.Data;
using KashFlow.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Andela.Infrastructure
{

  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence (this IServiceCollection services, IConfiguration configuration)
    {
      var data = configuration.GetConnectionString("MySqlConnection"); 
      //----- MySQL connection
      services.AddDbContext<BaseContext>(options =>
        options.UseMySql(
          configuration.GetConnectionString("MySqlConnection"),
          Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));
      
      //----- Repositories
      services.AddScoped<IBillsRepository, BillsRepository>();
      services.AddScoped<ICustomersRepository, CustomersRepository>();
      services.AddScoped<IDocumentsTypesRepository, DocumentsTypesRepository>();
      services.AddScoped<IEmployeesRepository, EmployeesRepository>();
      services.AddScoped<IPaymentsRepository, PaymentsRepository>();
      services.AddScoped<IPaymentTypesRepository, PaymentTypesRepository>();
      services.AddScoped<IPlatformsRepository, PlatformsRepository>();

      //----- Services
      services.AddScoped<IExcelService, ExcelService>();

    return services;
    }
  }
}