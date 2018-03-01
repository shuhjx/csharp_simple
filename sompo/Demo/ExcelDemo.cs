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
        
        public static void TestEditExcel()
        {
            string excelFile = @"D:\BaiduNetdiskDownload\#137959\20180125_1つの具体例を作る\test.xlsm";
            Action<Excel.Application, Excel.Workbook> action = (Excel.Application app, Excel.Workbook wb) =>
            {
                Excel.Sheets sheets = wb.Worksheets;
                Excel.Worksheet sheet = sheets[1];
                sheet.Cells[1, 1] = "WWWWWWWWWWWWW";
                Excel.Range r = sheet.Cells[1, 1];
                
                Log.Println("(1,1)的值是： "+ r.Value);
                Log.Println("(1,1)的值2是： " + r.Value2);

                sheet.Cells[2, 2] = "2018/01/01";
                r = sheet.Cells[2, 2];

                Log.Println("(2,2)的值是： " + r.Value);
                Log.Println("(2,2)的值2是： " + r.Value2);

                r = sheet.get_Range("c3");//选取单元格
                r.Merge(true);//合并单元格   
                r.Value2 = 99999999.9999999; //设置单元格内文本   
                r.Font.Name = "宋体";//设置字体   
                r.Font.Size = 18;//字体大小   
                r.Font.Bold = true;//加粗显示   
                r.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//水平居中   
                r.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;//垂直居中   
                r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;//设置边框   
                r.Borders.Weight = Excel.XlBorderWeight.xlMedium;//边框常规粗细  
                //r.Interior.Color = Color.FromArgb(224, 224, 224);//
                //r.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FF34B3");

                Log.Println("(3,3)的值是： " + r.Value);
                Log.Println("(3,3)的值2是： " + r.Value2);
                wb.Save();
            };
            ExcelUtil.GetExcelWorkbook(excelFile, action);
        }
    }
}
