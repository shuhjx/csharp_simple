using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sompo.Util
{
    class DBUtil
    {
        public static void GetDBConnection(Action<IDbConnection> action)
        {
            string connStr = ConfigUtil.GetByKey("SqlConnectionStr");
            IOrmLiteDialectProvider dialectProvider = MySqlDialectProvider.Instance;
            //#if !MYSQLCONNECTOR
            //            MySqlDialectProvider.Instance;
            //#else
            //            MySqlConnectorDialectProvider.Instance;
            //#endif
            var dbFactory = new OrmLiteConnectionFactory(connStr, dialectProvider);
            Log.Println("连接Mysql数据库...");
            using (IDbConnection db = dbFactory.Open())
            {
                Log.Println("数据库已连接。");
                action(db);//执行代码块

                db.Close();
                Log.Println("数据库连接已关闭。");
            }
        }
    }
}
