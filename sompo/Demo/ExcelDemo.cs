using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using sompo.Util;

namespace sompo.Demo
{
    class ExcelDemo
    {

        public static void TestCallMacro()
        {
            //string strFileName = @"D:/BaiduNetdiskDownload/#137959/20180125_1つの具体例を作る/02_XXX_ABC株式会社（定量計算）.xlsm";
            string strFileName = @"D:/BaiduNetdiskDownload/#137959/20180125_1つの具体例を作る/test.xlsm";
            Action<Excel.Application, Excel.Workbook> action = (Excel.Application app, Excel.Workbook wb) => {
                //app.Run("'02_XXX_ABC株式会社（定量計算）.xlsm'!AccumlationGet");
                app.Run("test.xlsm!btnClick");
                Log.Println("执行宏。");

                Excel.Sheets sheets = wb.Worksheets;
                Excel.Worksheet worksheet = sheets[1];
                Log.Println(worksheet.Name);
                wb.Save(); //保存执行宏后的结果
            };
            ExcelUtil.GetExcelWorkbook(strFileName, action);
        }

        public static void TestToPDF() {
            string strFileName = @"D:/BaiduNetdiskDownload/#137959/20180125_1つの具体例を作る/03_XXX_ABC株式会社（レポート）.xls";
            Action<Excel.Application, Excel.Workbook> action = (Excel.Application app, Excel.Workbook wb) =>
            {
                //wb.Worksheets.Select();//导出全部sheet
                //wb.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF,
                //    @"D:/BaiduNetdiskDownload/#137959/20180125_1つの具体例を作る/20180227_01.pdf",
                //    Excel.XlFixedFormatQuality.xlQualityStandard);

                Excel.Workbook tmpWb = app.Workbooks.Add();
                for (int i = 3;i <= 25; i++)
                {
                    Excel.Worksheet copysheet = (Excel.Worksheet) wb.Sheets[i];
                    copysheet.Copy(tmpWb.Worksheets[tmpWb.Worksheets.Count]);
                }
                Excel.Worksheet lastsheet = (Excel.Worksheet)tmpWb.Worksheets[tmpWb.Worksheets.Count];
                Log.Println("最后一个sheet名： "+ lastsheet.Name);
                if (lastsheet.Name.Equals("Sheet1")) {
                    lastsheet.Delete(); //删除最后一个名字是Sheet1的sheet
                }
                tmpWb.Worksheets.Select();
                tmpWb.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF,
                    @"D:/BaiduNetdiskDownload/#137959/20180125_1つの具体例を作る/20180227_01.pdf",
                    Excel.XlFixedFormatQuality.xlQualityStandard);

                Log.Println("PDF文件导出成功。");
                //tmpWb.SaveAs(@"D:/BaiduNetdiskDownload/#137959/20180125_1つの具体例を作る/tmp20180227_01.xls");
                //tmpWb.Close();
                tmpWb.Close(false, Type.Missing, Type.Missing);
            };
            ExcelUtil.GetExcelWorkbook(strFileName, action);
        }
        
    }
}
