using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace escolauc10a.Class
{//
    public static class Banco
    {
        static string strConn = @"server=127.0.0.1;database=uc1088adb; user id=root; password=";
        public static MySqlCommand Abrir()
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection cn = new MySqlConnection(strConn);
            try
            {
                cn.Open();
                cmd.Connection = cn;
            }
            catch (Exception e)
            {

                throw e;
            }

            return cmd;
        }
    }
}
