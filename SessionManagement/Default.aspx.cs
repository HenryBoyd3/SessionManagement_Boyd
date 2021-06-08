using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace SessionManagement
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnLogIn_Click(object sender, EventArgs e)
		{
			if (txtUser.Text=="bgates" && txtPassword.Text=="billions")
			{
				
				string user = txtUser.Text;
				string pass = txtPassword.Text;
				Response.Redirect("WebForm1.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
			}
			else if (txtUser.Text == "rsawnson" && txtPassword.Text == "bacon")
				{
					string user = txtUser.Text;
					string pass = txtPassword.Text;
					Response.Redirect("WebForm1.aspx?u=" + txtUser.Text+ "&p=" + txtPassword.Text);
				}
			else
			{
				lblMessage.Text = "Account not recognized";
			}
	
		}
	}
}