using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sompo.Util;

namespace sompo.Demo
{
    class FileDemo
    {
        public static void TestCopyDir()
        {
            string dirName = @"D:/BaiduNetdiskDownload/#137959/base_excel";
            try
            {
                FileUtil.FilesCopy(dirName, FileUtil.CreateDir(dirName).FullName);
            }
            catch (FileNotFoundException e)
            {
                Log.Println("文件不存在。");
                Log.Println(e.StackTrace);
            }
        }

    }
}
