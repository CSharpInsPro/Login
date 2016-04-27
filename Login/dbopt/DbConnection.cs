using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Login.dbopt
{
    public class DbConnection
    {
        private static OleDbConnection conn = null;

        public DbConnection()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            //initConnection();
        }

        public static void initConnection()
        {
            try
            {
                conn = new OleDbConnection(DbConfig.getConnString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static OleDbConnection getConnection()
        {
            initConnection();
            return conn;
        }

    }
}
