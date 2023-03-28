using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Database;
using MyApplication.DTOs;
using System.Data.SqlClient;
using System.Data;


namespace MyApplication.Provider
{
    public class CustomerProvider
    {
        private const string provider = "MyApplication.Provider.CustomerProvider";
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using(var cn = UtilityDB.GetConnection())
            {
                
                using(SqlCommand cmd = new SqlCommand("Select * from Customers",cn))
                {
                    using(var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            customers.Add(new Customer
                                {
                                    
                                  Country = dr[1].ToString().Trim(),
                                  Name = dr[2].ToString().Trim(),
                                }
                                );
                        }
                    }
                }
                cn.Close();
            }
            return customers;
        }

        public static List<Customer> GetCustomer(int id)
        {
            List<Customer> customers = new List<Customer>();
            using (var cn = UtilityDB.GetConnection())
            {

                using (SqlCommand cmd = new SqlCommand("Select * from Customers where CustomerID="+id, cn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            customers.Add(new Customer
                            {

                                Country = dr[1].ToString().Trim(),
                                Name = dr[2].ToString().Trim(),
                            }
                                );
                        }
                    }
                }
                cn.Close();
            }
            return customers;
        }
        public static void InsertCustomer(Customer customer)
        {
       
         
            using(var cn = UtilityDB.GetConnection())
            {
                //cn.Open();
                
                using (SqlCommand cmd = new SqlCommand("p_customers_i",cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                
                    cmd.ExecuteNonQuery();
                   
 

                }
                cn.Close();
            }

        }

        public static void Insert(Customer customer)
        {
            int customerId;

            using (var cn = UtilityDB.GetConnection())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("p_customers_i", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = customer.Name;
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.ExecuteNonQuery();
                    int.TryParse(cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value.ToString(), out customerId);
                    DBHelper.IsValidReturn(Convert.ToInt32(cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value), provider);
                }               

                cn.Close();
            }
            customer.Id = customerId;

        }
    }
}