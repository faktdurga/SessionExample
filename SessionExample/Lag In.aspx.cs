using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionExample
{
    
    public partial class Lag_In : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SutdentInfo _objSutdentInfo = new SutdentInfo(txtUserName.Text, txtPwd.Text);
            Session["objSutdentInfo"] = _objSutdentInfo;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd;
            SqlDataReader sdr;
            cmd = new SqlCommand("Select UserName, Pwd From UserDetails", con);
            sdr = cmd.ExecuteReader();

            while(sdr.Read())
            {
                if(sdr["UserName"].ToString()==txtUserName.Text && sdr["Pwd"].ToString() == txtPwd.Text)
                {
                    string sKey = txtUserName.Text + txtPwd.Text;
                    string sUser = Convert.ToString(Cache[sKey]);

                    if (sUser == null || sUser == string.Empty)
                    {
                        TimeSpan SessTimeOut = new TimeSpan(0, 0, HttpContext.Current.Session.Timeout, 0, 0);
                        HttpContext.Current.Cache.Insert(sKey, sKey, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                        Session["User"] = txtUserName.Text + txtPwd.Text;
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        lblDisplay.Text = "<Marquee><h1><font color=red>Already Logged IN</font></h1></marquee>";
                        return;
                    }
                }
                else
                {
                    lblDisplay.Text = "Invalid Credentials try again !!";
                }

            }

        }

        [Serializable]
        public class SutdentInfo
        {
            public SutdentInfo()
            { 
            
            }

            public SutdentInfo(string UserName, string Password)
            {
                this.Uname = UserName;
                this.Pwd = Password;
            }

            private string UserName;
            private string Password;
            public string Uname
            {
                get { return UserName; }
                set { UserName = value; }
            }
            public string Pwd
            {
                get { return Password; }
                set { Password = value; }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPwd.Text = "";
        }
    }
}