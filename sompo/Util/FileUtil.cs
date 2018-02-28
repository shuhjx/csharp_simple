using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sompo.Util
{
    class FileUtil
    {
        public static DirectoryInfo CreateDir(string baseDirName)
        {
            if (!Directory.Exists(baseDirName))
            {
                throw new FileNotFoundException("指定目录不存在！", baseDirName);
            }
            //https://www.cnblogs.com/polk6/p/5465088.html#Menu3-Custom  C# DateTime日期格式化
            string newDirName = new DirectoryInfo(baseDirName).Parent.FullName + "/" + System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
            DirectoryInfo dir = new DirectoryInfo(newDirName);
            if (dir.Exists)
            {
                dir.Delete(true);
                dir.Create();
            }
            else
            {
                dir.Create();
            }

            return dir;
        }

        public static void FilesCopy(string sourceDirName, string destDirName)
        {
            if (!Directory.Exists(sourceDirName))
            {
                
                throw new FileNotFoundException("指定要复制的目录不存在！", sourceDirName);
            }
            if (!Directory.Exists(destDirName))
            {
                throw new FileNotFoundException("指定目标目录不存在！", destDirName);
            }

            IEnumerable<string> files = Directory.EnumerateFiles(sourceDirName);
            foreach (var file in files)
            {
                //Log.Println(f);
                FileInfo info = new FileInfo(file);
                File.Copy(file, destDirName + "/" + info.Name);
            }
        }
    }
}
