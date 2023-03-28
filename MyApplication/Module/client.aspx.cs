using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyApplication.DTOs;
using MyApplication.Provider;


namespace MyApplication.Module
{
    public partial class client : System.Web.UI.Page
    {
        JSONHelper js = new JSONHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Name = "ana";
            cus.Country = "Malaysia";
            //List<Customer> x = new List<Customer>();
            

            string jsondata = js.JSONSerialization<Customer>(cus);
            Response.Write(jsondata);

        }
    }
}