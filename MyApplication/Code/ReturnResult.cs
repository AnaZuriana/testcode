using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplication.Code
{
    public class ReturnResult
    {
        private int _errorCode = 0;

        public string MethodName { get; set; }

        public int ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        public string ErrorMessage { get; set; }

        public object Data { get; set; }
    }
}