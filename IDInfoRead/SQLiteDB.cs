using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDInfoRead
{
    public sealed class SQLiteDB
    {
        private static string idInfoPath = System.Environment.CurrentDirectory + @"\Data\IDInfo.db";
        private static string ipPath = System.Environment.CurrentDirectory + @"\Data\IP.db";
        private static string path = System.Environment.CurrentDirectory + @"\Data";

        private static SQLiteDB _instnace = new SQLiteDB();

        /// <summary>
        /// 构造函数
        /// </summary>
        private SQLiteDB()
        {
            CheckDB();
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <returns></returns>
        public static SQLiteDB Instance()
        {
            if (_instnace == null)
            {
                _instnace = new SQLiteDB();
            }
            return _instnace;
        }


        /// <summary>
        /// 检查数据库文件夹及数据库文件是否存在
        /// 不存在则创建
        /// </summary>
        public void CheckDB()
        {
            //如果Data文件夹不存在，则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //如果身份证数据库文件不存在,则创建
            if (!File.Exists(idInfoPath))
            {
                FileStream fs = File.Create(idInfoPath);
                fs.Close();
                CreateIDInfoDB(idInfoPath);
            }
            //如果服务器数据库文件不存在,则创建
            if (!File.Exists(ipPath))
            {
                FileStream fs = File.Create(ipPath);
                fs.Close();
                CreateIPDB(ipPath);
            }
        }

        /// <summary>
        /// 创建数据库文件
        /// </summary>
        /// <param name="dbPath">数据库文件路径</param>
        public static void CreateIDInfoDB(string dbPath)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + dbPath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "CREATE TABLE IDInfo( createTime nvarchar(50), Name nvarchar(31), Gender nvarchar(3),Folk nvarchar(10), Birth nvarchar(9), ID nvarchar(19), Address nvarchar(71), Agency nvarchar(31), Validity_Start nvarchar(9), Validity_End nvarchar(9) )";
                    command.ExecuteNonQuery();
                    Console.WriteLine("建表成功");
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 创建服务器数据库文件
        /// </summary>
        /// <param name="dbPath"></param>
        public static void CreateIPDB(string ipPath)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + ipPath))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "CREATE TABLE IP( Server nvarchar(16), Port nvarchar(5), updateTime nvarchar(50), createTime nvarchar(50) )";
                    command.ExecuteNonQuery();
                    Console.WriteLine("建表成功");
                }
                connection.Close();
            }
        }

        /// <summary>
        /// 获取本地保存的服务器信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIP()
        {
            string sql = "select * from IP";
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + ipPath))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }

        /// <summary>
        /// 更新或添加本地保存的服务器信息
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="Port"></param>
        /// <returns></returns>
        public int InsertOrUpdateIP(string Server, int Port )
        {
            string nowTime = DateTime.Now.ToString("G");
            DataTable dt = QueryIP();
            if (dt.Rows.Count > 0)
            {
                string sql = "update IP set Server = '" + Server + "',Port='" + Port + "',updateTime='" + nowTime + "'";
                return ExecuteNonQuery(sql, ipPath, null);
            }
            else
            {
                string sql = "insert into IP(Server,Port,updateTime,createTime) values('" + Server + "','" + Port + "','" + nowTime + "','" + nowTime + "')";
                return ExecuteNonQuery(sql, ipPath, null);
            }

        }

        /// <summary>
        /// 向数据库插入新纪录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Gender"></param>
        /// <param name="Folk"></param>
        /// <param name="Birth"></param>
        /// <param name="ID"></param>
        /// <param name="Address"></param>
        /// <param name="Agency"></param>
        /// <param name="Validity_Start"></param>
        /// <param name="Validity_End"></param>
        /// <returns></returns>
        public int InsertData(string Name, string Gender, string Folk, string Birth, string ID, string Address, string Agency, string Validity_Start, string Validity_End )
        {
            string currentTime = DateTime.Now.ToString("G");
            string sql = "insert into IDInfo(createTime, Name, Gender, Folk, Birth, ID, Address, Agency, Validity_Start, Validity_End )  values('" + currentTime + "', '" + Name + "', '" + Gender + "', '" + Folk + "', '" + Birth + "', '" + ID + "', '" + Address + "', '" + Agency + "', '" + Validity_Start + "', '" + Validity_End + "' )";

            return ExecuteNonQuery(sql, idInfoPath, null);
        }

        /// <summary> 
        /// 对SQLite数据库执行增删改操作，返回受影响的行数。 
        /// </summary> 
        /// <param name="sql">要执行的增删改的SQL语句</param> 
        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        /// <returns></returns> 
        public int ExecuteNonQuery(string sql, string dbpath, SQLiteParameter[] parameters)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + dbpath))
            {
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = sql;
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        affectedRows = command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            return affectedRows;
        }
    }
}
