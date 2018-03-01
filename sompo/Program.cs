using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sompo.Demo;
using sompo.Util;

namespace sompo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Println("1：执行OrmLiteDemo.TestOrmLiteSelect()");
            Log.Println("2：执行OrmLiteDemo.TestOrmLiteInsert()");
            Log.Println("3：执行OrmLiteDemo.TestOrmLiteUpdate()"); 
            Log.Println("4：执行ExcelDemo.TestCallMacro()");
            Log.Println("5：执行ExcelDemo.TestToPDF()"); 
                Log.Println("6：执行ExcelDemo.TestEditExcel()"); 
            Log.Println("7：执行FileDemo.TestCopyDir()");
            Log.Println("exit：退出");

            while (true)
            {
                Log.Print("\n请输入命令：");
                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        OrmLiteDemo.TestOrmLiteSelect();
                        break;
                    case "2":
                        OrmLiteDemo.TestOrmLiteInsert();
                        break;
                    case "3":
                        OrmLiteDemo.TestOrmLiteUpdate();
                        break;
                    case "4":
                        ExcelDemo.TestCallMacro();
                        break; 
                    case "5":
                        ExcelDemo.TestToPDF();
                        break;
                    case "6":
                        ExcelDemo.TestEditExcel();
                        break;
                    case "7":
                        FileDemo.TestCopyDir();
                        break;
                    case "exit":
                        return;
                    default:
                        Log.Println("命令不存在，请重新输入。");
                        break;
                }
            }
            
            

        }
    }
}
