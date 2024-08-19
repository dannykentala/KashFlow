using KashFlow.Domain.Interfaces.Services;
using KashFlow.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KashFlow.Mvc.Controllers.Auth
{

  [Route("api/excel")]
  [ApiController]
  public class ExcelController : Controller
  {
    public readonly BaseContext _context;
    private readonly IExcelService _excelService;

    public ExcelController (IExcelService excelService)
    {
      // _context = context;
      _excelService = excelService;
      
    }

    // public IActionResult Index ()
    // {
    //   return View();
    // }

    [HttpGet]
    public bool ExcelToDb()
    {
      _excelService.UploadExcelToDb();
      return true;
    }
  }
}