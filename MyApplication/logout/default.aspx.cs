using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mykraf
{
    public partial class LogoutMykraf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Session["pwd"] = null;
            Session.Abandon();
            string backURL = Server.HtmlEncode(HttpContext.Current.Request.ServerVariables["HTTP_REFERER"]);
            Response.Redirect(backURL);
        }
    }
}