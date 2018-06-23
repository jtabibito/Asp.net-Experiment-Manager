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
    public partial class ForgetWebForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!Page.IsPostBack) {
                this.PwdSettingTB.Visible = false;
                this.ConfirmTB.Visible = false;
                this.PublishBtn.Visible = false;
            }
        }

        /// <summary>
        /// 处理用户密保问题答案
        /// </summary>
        private bool DecodeUserAnswer(string uAnswer) {
            string[] splitStr = uAnswer.Split((char)',');

            int[] index = new int[splitStr.Count()];
            for (int i = 0; i < splitStr.Count(); i++) {
                index[i] = splitStr[i].IndexOf(':');
                if(this.VerfiyQuestionList.Text.Equals(splitStr[i].Substring(0, index[i]))) {
                    if(this.VerfiyTB.Text.Equals(splitStr[i].Substring(index[i] + 1))) {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 读取用户数据
        /// </summary>
        protected void MySqlDataRead() {
            MySqlConnection myConn =  MyClassFiles.MyCommand.CreateConnectObject();

            string selectStr = null;
            if (Session["user_table_id"] != null) {
                selectStr = MyClassFiles.MyCommand.SelectCommandALL(Session["user_table_id"].ToString(), this.Account.ID, this.Account.Text);
            } else {
                selectStr = MyClassFiles.MyCommand.SelectCommandALL(Session["student"].ToString(), this.Account.ID, this.Account.Text);
            }

            MySqlCommand myComm = MyClassFiles.MyCommand.CreateCommandObject(selectStr, myConn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = myComm;
            DataSet ds = new DataSet("user_config");

            object affectRows = null;
            try {
                myConn.Open();
                affectRows = myComm.ExecuteScalar();
                if(affectRows != null) {
                    da.Fill(ds, "user_info");
                    if(this.Account.Text.Trim() == ds.Tables["user_info"].Rows[0][0].ToString()) {
                        if(DecodeUserAnswer(ds.Tables["user_info"].Rows[0][3].ToString())) {
                            this.VerfiyQuestionList.Visible = false;
                            this.VerfiyTB.Visible = false;
                            this.PwdSettingTB.Visible = true;
                            this.ConfirmTB.Visible = true;
                            this.SubmitBtn.Visible = false;
                            this.PublishBtn.Visible = true;
                        }
                    }
                }
                myConn.Close();
            } catch(Exception ex) {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script type=\"text/javascript\">" +
                    "confirm(\"You have got an error: \"" + ex.Message + ");" +
                    "</script>");
            }
        }
        
        /// <summary>
        /// 更新密码
        /// </summary>
        private bool UpdateData() {
            MySqlConnection myConn = MyCommand.CreateConnectObject();

            List<string> columns = new List<string>();
            List<string> settings = new List<string>();
            columns.Add("password");
            settings.Add(this.PwdSettingTB.Text);

            string commandStr = null;
            if (Session["user_table_id"] != null) {
                commandStr = MyCommand.UpdateCommand(Session["user_table_id"].ToString(), columns, settings, this.Account.ID, this.Account.Text);
            } else {
                commandStr = MyCommand.UpdateCommand("student", columns, settings, this.Account.ID, this.Account.Text);
            }

            MySqlCommand myComm = MyCommand.CreateCommandObject(commandStr, myConn);

            if(!this.PwdSettingTB.Text.Equals(this.ConfirmTB.Text)) {
                return false;
            }

            object affectRows = null;
            try {
                myConn.Open();
                affectRows = myComm.ExecuteNonQuery();
                myConn.Close();
            } catch(Exception ex) {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script type=\"text/javascript\">" +
                    "confirm(\"You have got an error: \"" + ex.Message + ");" +
                    "</script>");
            }

            if(affectRows != null) {
                return true;
            }

            return false;
        }

        protected void SubmitBtn_Click(object sender, EventArgs e) {
            MySqlDataRead();
        }

        protected void PublishBtn_Click(object sender, EventArgs e) {
            if(UpdateData()) {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script type=\"text/javascript\">" +
                    "confirm(\"密码修改成功\");" +
                    "</script>");
            } else {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script type=\"text/javascript\">" +
                    "confirm(\"两次密码输入不一致, 无法修改\");" +
                    "</script>");
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e) {
            this.Account.Text = null;
            this.VerfiyTB.Text = null;
            this.PwdSettingTB.Text = null;
            this.ConfirmTB.Text = null;

            Response.Redirect("~\\UserLoginWebForm.aspx");
        }

        protected void ReturnLoginWeb_Click(object sender, EventArgs e) {
            Response.Redirect("~\\UserLoginWebForm.aspx");
        }
    }
}