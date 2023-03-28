using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;
using System.Runtime.Serialization;



    public class JSONHelper
    {
        public string JSONSerialization<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream m = new MemoryStream();
            ser.WriteObject(m, t);
            string jasonstring = Encoding.UTF8.GetString(m.ToArray());
            m.Close();
            return jasonstring;

        }

        public T JSONDeserialization<T>(string jsonobject)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream m = new MemoryStream(Encoding.UTF8.GetBytes(jsonobject));
            T obj = (T)ser.ReadObject(m);

            return obj;
        }
        public JSONHelper()
        {

        }
   
}