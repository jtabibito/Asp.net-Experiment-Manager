using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using ExerprimentManager.MyClassFiles;

namespace ExerprimentManager.SourceFiles {
    public partial class UserLoginWebForm : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            if(!Page.IsPostBack) {
                Session["user_table_id"] = this.IDSelectList.Text;
            }
        }
        
        /// <summary>
        /// 此代码检查用户登录信息
        /// </summary>
        /// <returns></returns>
        private bool PersureUserInfo(string uIDSelected) {
            MySqlConnection myConn = MyCommand.CreateConnectObject();
            
            string selectCommandStr = MyCommand.SelectCommandALL(uIDSelected, this.Account.ID, this.Account.Text);
            MySqlCommand myComm = new MySqlCommand(selectCommandStr, myConn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = myComm;
            DataSet ds = new DataSet("user_config");

            object affectRows = null;
            try {
                myConn.Open();
                affectRows = myComm.ExecuteScalar();
                if(affectRows != null) {
                    da.Fill(ds, "user_info");
                    if (this.Account.Text.Trim() == ds.Tables["user_info"].Rows[0][0].ToString() &&
                        this.uPwdTB.Text.Trim() == ds.Tables["user_info"].Rows[0][1].ToString()) {
                        return true;
                    }
                }
                myConn.Close();
            } catch (Exception ex) {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "IDInfoError", "<script type=\"text/javascript\">" +
                    "confirm(\"You have got an error: \"" + ex.Message + ");" +
                    "</script>");
            }

            return false;
        }

        /// <summary>
        /// 确认事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SubmitBtn_Click(object sender, EventArgs e) {
            // 默认账号身份
            string accountID = "student";

            // 选择身份
            if (this.IDSelectList.SelectedIndex == 0) {
                accountID = "student";
            } else if( this.IDSelectList.SelectedIndex == 1) {
                accountID = "teacher";
            }

            Session["user_table_id"] = accountID;
            if (PersureUserInfo(accountID)) {
                Response.Redirect("SourceFiles/SysMainWebForm.aspx");
            } else {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "IDInfoError", "<script type=\"text/javascript\">"
                    + "confirm(\"账户信息错误，请检查\");"
                    + "</script>");
            }
        }

        protected void ForgetBtn_Click(object sender, EventArgs e) {
            // 默认账号身份
            string accountID = "student";

            // 选择身份
            if (this.IDSelectList.SelectedIndex == 0) {
                accountID = "student";
            } else if (this.IDSelectList.SelectedIndex == 1) {
                accountID = "teacher";
            }

            Session["user_table_id"] = accountID;
            Response.Redirect("SourceFiles/ForgetWebForm.aspx");
        }
    }
}