using System.Security.Claims;
using AutoMapper;
using KashFlow.Application.Utils;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Interfaces.Repositories;

namespace KashFlow.Infrastructure.Repository;

public class AuthManager
{
    // private readonly BaseContext _context;
    // private readonly IMapper _mapper;
    private readonly IEmployeesRepository _employeesRepository;

    public AuthManager(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
        // _context = context;
        // _mapper = mapper;
    }

    public ClaimsPrincipal LoginMVC(string email, string password)
    {
        if(!ValidInputFields(email, password))
            return InvalidDataClaims();

        EmployeeDTO userInfo = _employeesRepository.GetByEmail(email);

        if(userInfo == null)
            return InvalidDataClaims();

        if(!ValidUserPassword(userInfo.Password, password))
            return InvalidDataClaims();

        return NewClaimsIdentity(userInfo);
    }

    private ClaimsPrincipal InvalidDataClaims()
    {
        return new ClaimsPrincipal();
    }

    private ClaimsPrincipal NewClaimsIdentity(EmployeeDTO userInfo)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, userInfo.Email),
            new Claim(ClaimTypes.Role, userInfo.Role)
        };

        var identity = new ClaimsIdentity(claims, "MyAuthenticationScheme");
        var principal = new ClaimsPrincipal(identity);

        return principal;
    }

    private bool ValidInputFields(string email, string password)
    {
        if(email == null || password == null)
            return false;

        return true;
    }

    private bool ValidUserPassword(string dbPassword, string comparePassword)
    {
        // Validate if the password from the database is equal of input given password
        if(!PasswordHashing.VerifyPassword(comparePassword, dbPassword))
            return false;

        return true;
    }
}
