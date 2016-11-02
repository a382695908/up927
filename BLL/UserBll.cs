using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using WebBasic;
using System.Data;
using System.Net;
using System.IO;
using System.Configuration;
using System.Collections;

namespace BLL
{
    public class UserBll
    {
        private SqlDataBase database = new SqlDataBase("Up927Con", false);

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="email"></param>
        /// <param name="sex"></param>
        /// <param name="baby"></param>
        /// <param name="baby_date"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public int Add_User(string username, string pwd, string email, int sex, int baby, DateTime baby_date, string remark)
        {
            SqlParameter[] spInfo = new SqlParameter[7];
            spInfo[0] = new SqlParameter("@username", username);
            spInfo[1] = new SqlParameter("@pwd", pwd);
            spInfo[2] = new SqlParameter("@email", email);
            spInfo[3] = new SqlParameter("@sex", sex);
            spInfo[4] = new SqlParameter("@baby", baby);
            spInfo[5] = new SqlParameter("@baby_date", baby_date);
            spInfo[6] = new SqlParameter("@remark", remark);

            return Convert.ToInt32(database.ExecuteScalar("Add_User", true, spInfo));
        }

        /// <summary>
        /// 查询用户名是否已存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int SelectUsernameExist(string username)
        {
            string sql = "select count(uid) from t_user where username='"+username+"'";
            return Convert.ToInt32(database.ExecuteScalar(sql,false,null));
        }

        /// <summary>
        /// 查询邮箱是否已存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int SelectEmailExist(string email)
        {
            string sql = "select count(uid) from t_user where email='" + email + "'";
            return Convert.ToInt32(database.ExecuteScalar(sql, false, null));
        }

        /// <summary>
        /// 判断用户名或密码是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int SelectUsernameEmailExist(string username)
        {
            string sql = "select count(uid) from up927_f.t_user where username='" + username + "' or email='" + username + "'";
            return Convert.ToInt32(database.ExecuteScalar(sql, false, null));
        }

        /// <summary>
        /// 根据用户名、邮箱判断密码是否正确
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="valid_type"></param>
        /// <returns></returns>
        public int SelectUserPwdIsTrue(string username, string password, int valid_type)
        {
            string sql = "";
            if (valid_type == 1)//根据用户名判断
            {
                sql = "select count(uid) from up927_f.t_user where username='" + username + "' and pwd='" + password + "'";
            }
            else //根据邮箱判断
            {
                sql = "select count(uid) from up927_f.t_user where email='" + username + "' and pwd='" + password + "'";
            }
            return Convert.ToInt32(database.ExecuteScalar(sql,false,null));
        }

        /// <summary>
        /// 根据用户名、邮箱查询用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable SelectUserInfo(string username)
        {
            return database.ExecDataTable("select * from up927_f.t_user where email='" + username + "' or username='" + username + "'", false, null);
        }

    }
}
