using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyApplication.Database
{
    public class DBHelper
    {
        public static bool IsValidReturn(int returnValue, string provider)
        {
            switch (returnValue)
            {
                case 0:
                    return true;
                case -1:
                    throw new DataException(provider + ": Stored procedure execution failed");
                default:
                    throw new DataException(provider + ": Unknown error in Stored Procedure");
            }
        }

        public static bool IsUniqueInsert(int returnValue, string provider)
        {
            switch (returnValue)
            {
                default:
                    return IsValidReturn(returnValue, provider);
            }
        }

        public static bool IsUniqueUpdate(int returnValue, string provider)
        {
            switch (returnValue)
            {
                case -2:
                    return true;
                default:
                    return IsValidReturn(returnValue, provider);
            }
        }

        public static bool IsValidDelete(int returnValue, string provider)
        {
            switch (returnValue)
            {
                default:
                    return IsValidReturn(returnValue, provider);
            }
        }
    }
}