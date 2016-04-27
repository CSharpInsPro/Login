using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.logicbean;

namespace Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sTable = "user";  //数据库的表名，此处暂用user

            DataSet dsUserQueryInfo = querybyusernameandpwd(sTable);
            DataTable dtUserQueryInfo = dsUserQueryInfo.Tables[sTable];

            if (dtUserQueryInfo != null && dtUserQueryInfo.Rows.Count == 1)
            {
                //登录成功
                MessageBox.Show("SUCC");
            }
            else
            {
                //用户名或密码错误
                MessageBox.Show("Fail");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private DataSet querybyusernameandpwd(string sTable)
        {
            DataSet dsUser = new DataSet();
            DataTable dtUser = dsUser.Tables.Add(sTable);
            dtUser.Columns.Add("operflag", typeof(string));
            dtUser.Columns.Add("sTable", typeof(string));
            dtUser.Columns.Add("username", typeof(string));
            dtUser.Columns.Add("password", typeof(string));

            DataRow drUser = dtUser.NewRow();
            drUser["operflag"] = "querybyusernameandpwd";
            drUser["sTable"] = sTable;
            drUser["username"] = txtUserName.Text.Trim().ToString();
            drUser["password"] = txtPassword.Text.Trim().ToString();
            dtUser.Rows.Add(drUser);

            LbUser lbUser = new LbUser();
            DataSet dsUserQueryInfo = lbUser.execute(dsUser);
            return dsUserQueryInfo;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
