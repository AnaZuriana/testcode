using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Database;
using System.ServiceModel;
using System.Runtime.Serialization;


namespace MyApplication.DTOs
{
    [DataContract]
    public class Customer
    {
        private int _id = 0;
        private string name = string.Empty;
        private string country = string.Empty;
        [DataMember]
        public string Name
        { get { return name; }
          set { name = value; }
        }
        [DataMember]
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

  
    }

}