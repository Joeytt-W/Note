using log4net;
using System;
using System.Data.SqlClient;

namespace _01_SimpleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger("Main");

            try
            {               
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-FFG55EG;initial catalog=Test;integrated security=false;persist security info=True;User ID=sa;Password=wang0705"))
                {
                    conn.Open();
                    log.Info("数据库连接成功");
                    string sql = string.Format(@"
INSERT INTO Log 
(Date,Thread,Level,Logger,Message,Exception) 
VALUES 
('{0}', 'thread', 'log_level', 'logger', 'message', 'exception')", DateTime.Now);
                    log.Info($"执行Sql语句：{sql}");
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int i = cmd.ExecuteNonQuery();
                    if (i <= 0)
                        log.Error("执行失败");
                    else
                        log.Info("执行成功");
                    conn.Close();
                    log.Info("数据库连接关闭");
                }
            }catch(SqlException ex)
            {
                log.Error("SqlException", ex);//$"SqlClient:【ExceptionStackTrace:{ex.StackTrace};ExceptionMessage:{ex.Message}】"
            }
            Console.ReadKey();
        }
    }
}
