using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace iTOS3D.Tool
{
    class ConnHelper
    {
        public const string CONNECTIONSTRING = "server=127.0.0.1;port=3306;database=itos3d;userid=root;pwd=123456;";

        public static MySqlConnection Connect()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(CONNECTIONSTRING);
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                MessageBox.Show("链接数据库时出错" + e);
                //Console.WriteLine("链接数据库时出错" + e);
                return null;
            }

        }

        public static void CloseConnection(MySqlConnection conn)
        {
            try
            {
                if (conn != null)
                    conn.Close();
                else
                {
                    MessageBox.Show("conn为空");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("关闭数据库时出错" + e);
            }
        }
    }
}
