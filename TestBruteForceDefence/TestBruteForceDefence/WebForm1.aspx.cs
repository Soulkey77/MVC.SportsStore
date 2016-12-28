using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestBruteForceDefence
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string Login = "polikom";
        public string Password = "justnotwork";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(LoadSomeData));
        }

        private async Task LoadSomeData()
        {
            int incrementalDelay;
            if (HttpContext.Current.Application[Request.UserHostAddress] != null)
            {
                // wait for delay if there is one
                incrementalDelay = (int)HttpContext.Current.Application[Request.UserHostAddress];
                await Task.Delay(incrementalDelay * 1000);
            }

            string user = Authenticate(txtLogin.Text, txtPass.Text);
            if (string.IsNullOrEmpty(user))
            {
                // increment the delay on failed login attempts
                if (HttpContext.Current.Application[Request.UserHostAddress] == null)
                {
                    incrementalDelay = 1;
                }
                else
                {
                    incrementalDelay = (int)HttpContext.Current.Application[Request.UserHostAddress] * 2;
                }
                HttpContext.Current.Application[Request.UserHostAddress] = incrementalDelay;

                // return view with error
                lblTime.Text = "До следующего ввода пароля: " + incrementalDelay;
            }
            if (HttpContext.Current.Application[Request.UserHostAddress] != null)
            {
                HttpContext.Current.Application.Remove(Request.UserHostAddress);
            }
        }

        private string Authenticate(string login, string pass)
        {
            if (login != Login || pass != Password)
            {
                return null;
            }
            return "success";
        }
    }
}