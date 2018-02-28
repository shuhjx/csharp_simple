using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sompo.Util
{
    class ConfigUtil
    {
        public static string GetByKey(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch (NullReferenceException e)
            {
                Log.Println("没有找到相应的配置！");
                Log.Println(e.StackTrace);
                throw e;
            }
        }
    }
}
