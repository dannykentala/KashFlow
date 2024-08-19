using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using KashFlow.Application.Generators;
using KashFlow.Application.Managers;
using KashFlow.Application.Mappers;
using KashFlow.Application.Validations.Fluent;
using KashFlow.Application.Validations.Interators;
using KashFlow.Domain.DTOs.Setters;
using KashFlow.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace KashFlow.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication (this IServiceCollection services)
    {
      //----- Automapers
      services.AddAutoMapper(typeof(BillProfile));
      services.AddAutoMapper(typeof(CustomerProfile));
      services.AddAutoMapper(typeof(DocumentTypeProfile));
      services.AddAutoMapper(typeof(EmployeeProfile));
      services.AddAutoMapper(typeof(PaymentProfile));
      services.AddAutoMapper(typeof(PaymentTypeProfile));
      services.AddAutoMapper(typeof(PlatformProfile));

      services.AddScoped<ExcelMapper>();

      //----- Validators
      //Enables integration between FluentValidation and ASP.NET MVC's automatic validation pipeline.
      services.AddFluentValidationAutoValidation();
      //Enables integration between FluentValidation and ASP.NET client-side validation.
      services.AddFluentValidationClientsideAdapters();
      services.AddTransient<IValidator<PaymentCreateDTO>, PaymentFluent>();

      //----- Generators singlenton
      services.AddScoped<PaymentGenerator>();

      //----- Interators
      services.AddScoped<PaymentInterator>();

      //----- Managers
      services.AddScoped<AuthManager>();
      services.AddScoped<PaymentManager>();

      return services;
    }
  }
}