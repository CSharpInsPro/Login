using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.dbopt;
using Login.dao;

namespace Login.logicbean
{
    class LbUser
    {
        public DataSet execute(DataSet prm_DataSet)
        {
            string sMeg = "";
            DataSet rDataSet = new DataSet("result");
            DataTable prm_DataTable = prm_DataSet.Tables["user"];
            string operflag = prm_DataTable.Rows[0]["operflag"].ToString();
            string sTable = prm_DataTable.Rows[0]["sTable"].ToString();

            int iType = 1;

            Dao daoOpt = new Dao();
            try
            {
                daoOpt.beginTransaction();
                if (operflag.Equals("querybyusernameandpwd"))
                {
                    DaoUser mDaoUser = new DaoUser(daoOpt);
                    DataSet dsUser = mDaoUser.querybyUserNameandPwd(prm_DataTable, sTable);
                    DataTable dtUser = dsUser.Tables[sTable];
                    if (dtUser.Rows.Count == 0)
                    {
                        sMeg = "未能查到记录！";
                    }
                    else
                    {
                        rDataSet.Merge(dsUser);
                    }
                }

                if (operflag.Equals("insert"))
                {
                    //此处可写注册新用户向数据库user数据表增加记录的逻辑操作



                }

                if (operflag.Equals("update"))
                {
                    //此处可写修改用户信息的对数据库user数据表修改记录的逻辑操作


                    
                }

            }
            catch (Exception ex)
            {
                rDataSet.Clear();
                iType = 0;
            }
            finally
            {
                daoOpt.endTransaction(iType);
            }
            //将返回的消息制成Table加入到rDataSet中去
            //RtMessage.MergeMessage(rDataSet, sMeg, sMegCode);

            return rDataSet;
        }
    }
}
