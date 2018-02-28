using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace sompo.Util
{
    class ExcelUtil
    {
        public static void GetExcelWorkbook(string fileName, Action<Excel.Application, Excel.Workbook> action)
        {
            Excel.Application app = null;
            Excel.Workbooks wbs = null;
            Excel.Workbook wb = null;
            try
            {
                app = new Excel.Application();
                app.DisplayAlerts = false;//DisplayAlerts 属性设置成 False，就不会出现警告
                app.Visible = false; //后台打开，不显示excel窗口
                app.UserControl = false;

                wbs = app.Workbooks;
                wb = wbs.Open(fileName);
                Log.Println("打开Excel文件。");

                action(app, wb);
            }
            finally
            {
                if (wb != null)
                {
                    wb.Close();
                }
                if (wbs != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wbs);

                }
                if (app != null)
                {
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                }
                Log.Println("关闭Excel。");
            }


        }
    }
}
