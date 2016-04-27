using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Login.dbopt;

namespace Login.dao
{
    class DaoUser
    {
        private Dao dao = null;

        public DaoUser(Dao daoOpt)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			//传入数据库链接
			this.dao = daoOpt;
		}

        public DataSet querybyUserNameandPwd(DataTable dtUser, string sTable)
        {
            DataSet dsUser = null;
            try
            {
                string sUserName = dtUser.Rows[0]["username"].ToString().Trim();
                string sPassword = dtUser.Rows[0]["password"].ToString().Trim();

                string sSql = "select * from " + "["+sTable +"]"+ " where username = '" + sUserName + "' and password = '" + sPassword + "'";
                dsUser = dao.Exc_Select(sSql, sTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsUser;
        }
    }
}
