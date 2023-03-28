using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyApplication.ServiceReferenceCustomer;

namespace MyApplication.Module
{
    public partial class customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ServiceReferenceCustomer.Service1Client obj = new Service1Client();
                obj.SaveCustomer();

            }
        }
    }
}