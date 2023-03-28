using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using MyApplication.DTOs;
using MyApplication.Provider;
using System.Web.Script.Serialization;
using MyApplication.Code;

namespace MyApplication                                                                                                                                                                                                    
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        private JsonSerializerSettings _jsonSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public string HelloWorld()
        {
            var result = JsonConvert.SerializeObject("Hello World", _jsonSettings);
            return result;
        }
        [WebMethod]
        public void InsertData(string Name, string Country)
        {
            Customer customer = new Customer();
            customer.Name = Name;
            customer.Country = Country;

            CustomerProvider.InsertCustomer(customer);
        }

        [WebMethod]
        public string GetAllCustomers()
        {
            string result = string.Empty;
            result = JsonConvert.SerializeObject(CustomerProvider.GetAllCustomers());
            return result;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json,UseHttpGet=false)]
        public ReturnResult ListAllCustomers()
        {
            var result = new ReturnResult { MethodName = "ListAllCustomers" };
            result.Data = CustomerProvider.GetAllCustomers();

            return result;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json,UseHttpGet=false)]
        public string ListCustomers()
        {
            return JsonConvert.SerializeObject(CustomerProvider.GetAllCustomers(), _jsonSettings);
        }
        [WebMethod]
        public void GetCustomerRecords(int id)
        {
            string result = string.Empty;
            result = JsonConvert.SerializeObject(CustomerProvider.GetCustomer(id));
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "application/json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(result);
            HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }


        [WebMethod]
        public void GetAllCustomerRecords()
        {
            string result = string.Empty;
            result = JsonConvert.SerializeObject(CustomerProvider.GetAllCustomers());
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "application/json";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(result);
            HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string insertRecord(string input)
        {
            var js = new JavaScriptSerializer();
            var msg = string.Empty;

            if (input.Length > 0)
            {
                Customer cust = js.Deserialize<Customer>(input);
                Customer customer = new Customer();
                customer.Name = cust.Name;
                customer.Country = cust.Country;
                CustomerProvider.InsertCustomer(customer);
                msg = "Your profile has been successfully updated.";

 
            }
            else
            {
                msg = "Fail.";
            }
            return msg;
        }
    }
}
