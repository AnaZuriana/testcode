using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Database;
using dto = MyApplication.DTOs;
using System.Data.SqlClient;
using System.Data;


namespace MyApplication.Provider
{
    public class ServiceProvider
    {
        private const string provider = "MyApplication.Provider.ServiceProvider";

        #region Services

        public  static List<dto.Service> GetAllServices()
        {
            //List<dto.Service> services = new List<dto.Service>();
            List<MyApplication.DTOs.Service> services = new List<MyApplication.DTOs.Service>();
            using (var cn = UtilityDB.GetConnectionDB())
            {
                cn.Open();

                using (var cmd = new SqlCommand("p_Services_sa",cn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            services.Add(new MyApplication.DTOs.Service
                            {
                                Id = Conversion.DBNullToInt32(dr[1].ToString()),
                                ServiceName = Conversion.DBNullToString(dr[2].ToString()),
                                ProductNumber = Conversion.DBNullToString(dr[3].ToString()),
                                Description = Conversion.DBNullToString(dr[4].ToString()),
                                ScopeOfWork = Conversion.DBNullToString(dr[5].ToString()),
                                UnitPrice = Conversion.DBNullToDecimal(dr[6].ToString()),
                                CreatedById = Conversion.DBNullToInt32(dr[7].ToString()),
                                CreatedBy = Conversion.DBNullToString(dr[8].ToString()),
                                CreatedDate = Conversion.DBNullToDateTime(dr[9].ToString()),
                                ModifiedById = Conversion.DBNullToInt32(dr[10].ToString()),
                                ModifiedBy = Conversion.DBNullToString(dr[11].ToString()),
                                ModifiedDate = Conversion.DBNullToDateTime(dr[12].ToString()),

                                IsDirty = false
                            });
                        }
                    }
                }

                cn.Close();
            }

            return services;
        }

        //public static Service GetService(int serviceId)
        //{
        //    Service service = null;

        //    if (serviceId == 0)
        //    {
        //        return service;
        //    }

        //    using (var cn = Connections.GetSqlConnection(ConnectionAliases.DBCustomCodes))
        //    {
        //        cn.Open();

        //        using (var cmd = DBCUSTOMCODES.p_Services_s(cn, serviceId))
        //        {
        //            using (var dr = cmd.ExecuteReader())
        //            {
        //                if (dr != null && dr.Read())
        //                {
        //                    return new Service()
        //                    {
        //                        Id = Conversion.DBNullToInt32(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_ID]),
        //ServiceName = Conversion.DBNullToString(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_ServiceName]),
        //ProductNumber = Conversion.DBNullToString(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_ProductNumber]),
        //Description = Conversion.DBNullToString(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_Description]),
        //ScopeOfWork = Conversion.DBNullToString(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_ScopeOfWork]),
        //UnitPrice = Conversion.DBNullToDecimal(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_UnitPrice]),
        //CreatedById = Conversion.DBNullToInt32(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_CreatedByID]),
        //CreatedBy = Conversion.DBNullToString(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_CreatedBy]),
        //CreatedDate = Conversion.DBNullToDateTime(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_CreatedDate]),
        //ModifiedById = Conversion.DBNullToInt32(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_ModifiedByID]),
        //ModifiedBy = Conversion.DBNullToString(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_ModifiedBy]),
        //ModifiedDate = Conversion.DBNullToDateTime(dr[(int)DBCUSTOMCODES.p_Service_s_Columns.col_ModifiedDate]),

        //                        IsDirty = false
        //                    };
        //                }
        //            }
        //        }

        //        cn.Close();
        //    }

        //    return service;
        //}

        //public static void InsertService(Service service)
        //{
        //    int serviceId;

        //    using (var cn = Connections.GetSqlConnection(ConnectionAliases.DBCustomCodes))
        //    {
        //        cn.Open();

        //        using (var cmd = DBCUSTOMCODES.p_Services_i(cn, service.ServiceName, service.ProductNumber, service.Description, service.ScopeOfWork, service.UnitPrice, service.CreatedById, service.CreatedBy, service.ModifiedById, service.ModifiedBy))
        //        {
        //            cmd.ExecuteNonQuery();

        //            int.TryParse(cmd.Parameters[(int)DBCUSTOMCODES.p_Services_i_Parameters.out_ServiceID].Value.ToString(), out serviceId);

        //            DBHelper.IsValidReturn(Convert.ToInt32(cmd.Parameters[(int)DBCUSTOMCODES.p_Services_i_Parameters.rv_RETURN_VALUE].Value), provider);
        //        }

        //        cn.Close();
        //    }

        //    service.Id = serviceId;
        //}

        //public static void UpdateService(Service service)
        //{
        //    using (var cn = Connections.GetSqlConnection(ConnectionAliases.DBCustomCodes))
        //    {
        //        cn.Open();

        //        using (var cmd = DBCUSTOMCODES.p_Services_u(cn, service.Id, service.ServiceName, service.ProductNumber, service.Description, service.ScopeOfWork, service.UnitPrice, service.CreatedById, service.CreatedBy, service.ModifiedById, service.ModifiedBy))
        //        {
        //            cmd.ExecuteNonQuery();

        //            DBHelper.IsValidReturn(Convert.ToInt32(cmd.Parameters[(int)DBCUSTOMCODES.p_Services_u_Parameters.rv_RETURN_VALUE].Value), provider);
        //        }

        //        cn.Close();
        //    }
        //}

        //public static void DeleteService(int serviceId)
        //{
        //    using (var cn = Connections.GetSqlConnection(ConnectionAliases.DBCustomCodes))
        //    {
        //        cn.Open();

        //        using (var cmd = DBCUSTOMCODES.p_Services_d(cn, serviceId))
        //        {
        //            cmd.ExecuteNonQuery();

        //            DBHelper.IsValidReturn(Convert.ToInt32(cmd.Parameters[(int)DBCUSTOMCODES.p_Services_d_Parameters.rv_RETURN_VALUE].Value), provider);
        //        }

        //        cn.Close();
        //    }
        //}

        #endregion

    }
}


