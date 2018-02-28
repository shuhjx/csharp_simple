using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using sompo.Model;
using sompo.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sompo.Demo
{
    class OrmLiteDemo
    {
        public static void TestOrmLiteSelect()
        {
            Console.Out.WriteLine("OrmLiteSimple#TestOrmLiteSelect");
            Action<IDbConnection> action = (IDbConnection db) => {
                var builder = new SqlBuilder();
                //var justId = builder.AddTemplate("SELECT /**select**/ FROM admins");
                var all = builder.AddTemplate("SELECT /**select**/ FROM admins /**join**/ /**where**/ /**orderby**/;");
                builder.Select("admins.*");
                builder.Join(" companies on companies.id=admins.company_id and companies.deleted=0");
                builder.Where("admins.deleted =@a and admins.id < @b", new { a = 0, b = 100 });
                //builder.Where("admins.email like @a", new { a = "shuh@%" });
                builder.OrderBy("admins.id desc");
                Log.Println(all.RawSql);
                //var ids = db.Select<int>(justId.RawSql, justId.Parameters);
                var admins = db.Select<Admin>(all.RawSql, all.Parameters);

                foreach (var admin in admins)
                {
                    Log.Println(admin.ToS());
                }
            };
            DBUtil.GetDBConnection(action);

        }

        public static void TestOrmLiteInsert()
        {
            Log.Println("OrmLiteSimple#TestOrmLiteInsert");
            Action<IDbConnection> action = (IDbConnection db) =>
            {
                using (IDbTransaction dbTrans = db.OpenTransaction())//开启事务
                {
                    Company company = new Company();
                    company.Ctype = 1;
                    company.Name = "会社888";
                    company.Unit_price = 8000;
                    company.Currency_unit = "RMB";
                    company.Email = "shuh+888@alpha-it-system.com";
                    company.Status = 1;
                    db.Insert(company); //返回成功件数
                    company.Id = db.LastInsertId(); //返回保存后的id
                    Log.Println(company.ToS());

                    dbTrans.Commit();//提交事务
                    //dbTrans.Rollback();
                }
            };
            DBUtil.GetDBConnection(action);
        }
        
        public static void TestOrmLiteUpdate()
        {
            Log.Println("OrmLiteSimple#TestOrmLiteUpdate");
            Action<IDbConnection> action = (IDbConnection db) =>
            {
                Company company = db.LoadSingleById<Company>(6);
                company.Name = "会社100";
                using (IDbTransaction dbTrans = db.OpenTransaction())//开启事务
                {
                    db.Update(company);
                    dbTrans.Commit();//提交事务
                }

                Log.Println(company.ToS());
            };
            DBUtil.GetDBConnection(action);

        }
        
    }
}
