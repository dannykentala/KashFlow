using KashFlow.Application.Mappers;
using KashFlow.Domain.DTOs;
using KashFlow.Domain.Interfaces.Services;
using OfficeOpenXml;

public class ExcelService: IExcelService
  {
    // private readonly string _assetsDir = "../../../";
    private string _excelDir = $"../../../assets/data.xlsx";
    private ExcelWorksheet _excelSheet;
    private readonly ExcelMapper _excelMapper;


    public ExcelService(ExcelMapper excelMapper)
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
      _excelMapper = excelMapper;
    }

    public void UploadExcelToDb()
    {
        ConvertExcelToDbObject();
    }

    private List<ExcelDTO> ConvertExcelToDbObject()
    {
      List<ExcelDTO> ExcelEntries = new();

      using(ExcelPackage excelPackage = new ExcelPackage(_excelDir))
      {
        _excelSheet = excelPackage.Workbook.Worksheets[0];

        for(int i = FirstRow(); i < LastRow(); i++)
        {
          List<string> rowData = GetRowInfo(i);
          ExcelDTO excelDTO = _excelMapper.ExcelRegisterToExcelDTO(rowData);
        }

        excelPackage.Save();
      }

      return ExcelEntries;
    }

    private int FirstRow()
    {
      /*
        | ID | Name |
        | 1  | Jose |

        we have to begin in the next row
      */
      return HeaderRow() + 1;
    }

    private List<string> GetRowInfo(int rowNumber)
    {
      List<string> rowValues = new();

      int firstColum = _excelSheet.Dimension.Start.Column;

      for(int i = firstColum; i <= LastColunm(); i++)
      {
        string cell = _excelSheet.Cells[rowNumber,i].Value.ToString();
        rowValues.Add(cell);
      }

      return rowValues;
    }

    private int HeaderRow()
    {
      return _excelSheet.Dimension.Start.Row;
    }

    private int LastColunm()
    {
      return _excelSheet.Dimension.End.Column;
    }

    private int LastRow()
    {
      return _excelSheet.Dimension.End.Row;
    }
  }