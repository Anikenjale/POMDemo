using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public  class TestSource
    {
        public static IEnumerable<object[]> ReadLoginData()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(new FileInfo(@"C:\C#\.NetSeleniumFinal\Source\LoginData.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;
                for (int i = 1; i <= rowCount; i++)
                {
                    yield return new object[]
                    {
                        worksheet.Cells[i,1].Value?.ToString(),
                        worksheet.Cells[i,2].Value?.ToString(),



                    };
                }
            }
        }
        public static IEnumerable<object[]> ReadErrorLoginData()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(@"C:\C#\.NetSeleniumFinal\Source\ErrorData.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;
                for (int i = 1; i <= rowCount; i++)
                {
                    yield return new object[]
                    {
                        worksheet.Cells[i,1].Value?.ToString(),
                        worksheet.Cells[i,2].Value?.ToString(),
                         worksheet.Cells[i,3].Value?.ToString()
                    };
                }
            }
        }

        public static IEnumerable<object[]> ExcelResData()
        {
            using (ExcelPackage package =
                   new ExcelPackage(new FileInfo(@"C:\C#\.NetSeleniumFinal\Source\Patientdata.xlsx")))
            {
                //Get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowcount = worksheet.Dimension.End.Row;
                int colcount = worksheet.Dimension.End.Column;


                List<TestCaseData> list = new List<TestCaseData>();
                for (int i = 1; i <= rowcount; i++)
                {
                    yield return new object[] {
                     worksheet.Cells[i, 1].Value?.ToString(),
                    worksheet.Cells[i, 2].Value?.ToString(),
                    worksheet.Cells[i, 3].Value?.ToString(),
                    worksheet.Cells[i, 4].Value?.ToString(),
                    worksheet.Cells[i, 5].Value?.ToString(),
                    worksheet.Cells[i, 6].Value?.ToString(),
                    worksheet.Cells[i, 7].Value?.ToString(),
                    worksheet.Cells[i, 8].Value?.ToString(),
                    worksheet.Cells[i, 9].Value?.ToString(),
                    worksheet.Cells[i, 10].Value?.ToString(),
                    worksheet.Cells[i, 11].Value?.ToString(),
                    worksheet.Cells[i, 12].Value?.ToString(),
                    worksheet.Cells[i, 13].Value?.ToString(),
                    worksheet.Cells[i, 14].Value?.ToString(),
                    worksheet.Cells[i, 15].Value?.ToString(),
                    worksheet.Cells[i, 16].Value?.ToString(),
                    worksheet.Cells[i, 17].Value?.ToString(),
                    worksheet.Cells[i, 18].Value?.ToString()
                };



                }


            }
        }

        public static IEnumerable<object[]> ReadName()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(@"C:\C#\.NetSeleniumFinal\Source\PatientName.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;
                for (int i = 1; i <= rowCount; i++)
                {
                    yield return new object[]
                    {
                        worksheet.Cells[i,1].Value?.ToString(),
                        worksheet.Cells[i,2].Value?.ToString(),
                        worksheet.Cells[i,3].Value?.ToString()
                    };
                }
            }
        }


        public static IEnumerable<object[]> ReadId()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(@"C:\C#\.NetSeleniumFinal\Source\PatientId.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;
                for (int i = 1; i <= rowCount; i++)
                {
                    yield return new object[]
                    {
                        worksheet.Cells[i,1].Value?.ToString(),
                        worksheet.Cells[i,2].Value?.ToString(),
                        worksheet.Cells[i,3].Value?.ToString()
                    };
                }
            }
        }


}
}
