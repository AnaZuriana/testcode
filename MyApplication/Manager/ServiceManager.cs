using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Provider;
using dto = MyApplication.DTOs;

namespace MyApplication.Manager
{
    public class ServiceManager
    {
        public static ServiceManager Current = new ServiceManager();
      

        public List<dto.Service> GetAllServices()
        {
            List<dto.Service> AllServices = new List<dto.Service>();
            try
            {
                AllServices = ServiceProvider.GetAllServices();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return AllServices;
        }
    }
}