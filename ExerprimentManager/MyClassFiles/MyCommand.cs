using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace ExerprimentManager.MyClassFiles {
    public class MyCommand {
        /// <summary>
        /// 配置数据库连接字串
        /// </summary>
        /// <returns></returns>
        static public MySqlConnection CreateConnectObject() {
            string connStr = WebConfigurationManager.ConnectionStrings["MySqlConnectionStr"].ConnectionString;
            MySqlConnection my_conn = new MySqlConnection(connStr);
            return my_conn;
        }

        /// <summary>
        /// 创建命令对象
        /// </summary>
        /// <param name="command"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public MySqlCommand CreateCommandObject(string command, MySqlConnection conn) {
            MySqlCommand myCommand = new MySqlCommand(command, conn);
            return myCommand;
        }

        /// <summary>
        /// 更新命令
        /// 只更新数据表的字段的Context部分
        /// </summary>
        /// <param name="table">更新表的名称</param>
        /// <param name="columns">更新的字段</param>
        /// <param name="settings">更新的Context</param>
        /// <param name="primaryKey">搜索主键</param>
        /// <param name="primaryContext">主键的Context</param>
        /// <returns></returns>
        static public string UpdateCommand(string table, List<string> columns, List<string> settings, string primaryKey, string primaryContext) {
            string updateStr = "UPDATE " + table + " SET ";
            int index = 0;
            foreach(string IndexOfString in columns) {
                if(index < settings.Count - 1) {
                    updateStr += IndexOfString + "=\"" + settings[index] + "\", ";
                } else {
                    updateStr += IndexOfString + "=\"" + settings[index] + "\" ";
                }
                index++;
            }
            updateStr += "WHERE " + primaryKey + "=\"" + primaryContext + "\";";
            return updateStr;
        }

        /// <summary>
        /// 选择命令
        /// 查找全部
        /// </summary>
        /// <param name="table"></param>
        /// <param name="primaryKey"></param>
        /// <param name="primaryContext"></param>
        /// <returns></returns>
        static public string SelectCommandALL(string table, string primaryKey, string primaryContext) {
            string selectStr = "SELECT * FROM " + table + " WHERE " + primaryKey + "=" + primaryContext + ";";
            return selectStr;
        }

        /// <summary>
        /// 选择命令
        /// 查找部分
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        /// <param name="primaryKey"></param>
        /// <param name="primaryContext"></param>
        /// <returns></returns>
        static public string SelectCommandSection(string table, List<string> columns, string primaryKey, string primaryContext) {
            string selectStr = "SELECT ";
            int index = 0;
            foreach(string IndexOfString in columns) {
                if(index < columns.Count - 1) {
                    selectStr += IndexOfString + ", ";
                } else {
                    selectStr += IndexOfString + " ";
                }
            }
            selectStr += "WHERE " + primaryKey + "=" + primaryContext + ";";
            return selectStr;
        }
    }
}