using KashFlow.Application.Enums;
using KashFlow.Domain.DTOs;

namespace KashFlow.Application.Mappers
{
    public class ExcelMapper
    {
        private List<string> _excelRegister;

        public ExcelDTO ExcelRegisterToExcelDTO(List<string> excelRegister)
        {
            SetExcelRegister(excelRegister);

            ExcelDTO excelDTO = new ExcelDTO()
            {
                Payment = new PaymentDTO()
                {
                    TransactionCode = GetRegister(ExcelEnum.PaymentCode),
                    Date = DateTime.Parse(GetRegister(ExcelEnum.PaymentDate)),
                    Amount = double.Parse(GetRegister(ExcelEnum.PaymentAmount)),
                    Status = GetRegister(ExcelEnum.PaymentStatus),
                },
                PaymentType = new PaymentTypeDTO()
                {
                    Name = GetRegister(ExcelEnum.PaymentType)
                },
                Customer = new CustomerDTO()
                {
                    Name = GetRegister(ExcelEnum.ClientName),
                    Document = long.Parse(GetRegister(ExcelEnum.ClientDocument)),
                    Address = GetRegister(ExcelEnum.ClientAddress),
                    Phone = GetRegister(ExcelEnum.ClientPhone),
                    Email = GetRegister(ExcelEnum.ClientEmail)
                },
                Platform = new PlatformDTO()
                {
                    Name = GetRegister(ExcelEnum.PlatformName)
                },
                Bill = new BillDTO()
                {
                    Code = GetRegister(ExcelEnum.BillCode),
                    Amount = double.Parse(GetRegister(ExcelEnum.BillAmount)),
                    EndPaimentDate = DateTime.Parse(GetRegister(ExcelEnum.BillEndPaymentDate))
                }
            };

            return excelDTO;
        }

        private string GetRegister(ExcelEnum excelEnum)
        {
            return _excelRegister[(int)excelEnum];
        }

        private void SetExcelRegister(List<string> excelRegister)
        {
            _excelRegister = excelRegister;
        }
    }
}