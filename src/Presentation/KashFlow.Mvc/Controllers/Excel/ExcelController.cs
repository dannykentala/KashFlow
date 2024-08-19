using KashFlow.Domain.Interfaces.Services;
using KashFlow.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KashFlow.Mvc.Controllers.Auth
{
  [Authorize]
  public class ExcelController : Controller
  {
    public readonly BaseContext _context;
    private readonly IExcelService _excelService;

    public ExcelController (IExcelService excelService)
    {
      // _context = context;
      _excelService = excelService;
      
    }

    public IActionResult Index ()
    {
      return View();
    }

    public IActionResult UploadExcelDb(IFormFile excelFile)
    {
      _excelService.UploadExcelToDb();
      return RedirectToAction("Index");
    }
  }
}