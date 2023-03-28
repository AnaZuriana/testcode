using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyApplication.ServiceReferenceCustomer;
using MyApplication.CustomerDetails;

namespace MyApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             //   ServiceReferenceCustomer.Service1Client obj = new Service1Client();
             //   obj.SaveCustomer();

              
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           Service myform = new Service();
           myform.InsertData(txtName.Text,txtCountry.Text);
            // ServiceReferenceCustomer.Service1Client obj = new Service1Client();
          //   obj.SaveCustomer();
            
        }
    }
}