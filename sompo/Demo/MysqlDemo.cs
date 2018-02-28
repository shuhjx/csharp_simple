//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using sompo.Util;

namespace sompo.Demo
{
    class MysqlDemo
    {

        private static void TestMysql()
        {
            //string conn_str = ConfigUtil.GetByKey("SqlConnectionStr");
            //MySqlConnection conn = null;
            //MySqlCommand command = null;

            //Console.Out.WriteLine("开始连接...");
            //conn = new MySqlConnection(conn_str);
            //conn.Open();
            //Console.Out.WriteLine("连接成功。");
            //command = conn.CreateCommand();
            //command.CommandText = "select id, admin_name from admins;";
            //command.CommandType = CommandType.Text;
            //MySqlDataReader reader = command.ExecuteReader();
            //Console.Out.WriteLine("执行sql成功。");

            //while (reader.Read())
            //{
            //    Console.Out.WriteLine("admin.id = "+ reader[0].ToString() + ", admin.name = "+ reader[1].ToString());
            //}

            ////MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            ////DataSet ds = new DataSet();
            ////adapter.Fill(ds);
            ////DataView dataView = ds.Tables[0].DefaultView;

            //reader.Close();
            //conn.Close();
            //Console.Out.WriteLine("连接关闭。");

            //Thread.Sleep(3000); //3秒后关闭控制台窗口
        }
    }
}
