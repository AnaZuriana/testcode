using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MyApplication.Database
{
    public class UtilityDB:IDisposable
    {
        // Data insertion and update mode
        public SqlConnection connection;
        public SqlDataAdapter dataAdapter;
        public DataSet dataSet;
        public SqlTransaction transaction;

        public void OpenConnection()
        {
            string connStr = GetConnectionString();
            connection = new SqlConnection(connStr);
            connection.Open();
        }

        public void CreateTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
                transaction.Commit();
        }

        public void Rollback()
        {
            if (transaction != null)
                transaction.Rollback();
        }

        public void Close()
        {
            if (connection == null || connection.State != ConnectionState.Open)
                return;

            connection.Close();
        }

        public static string GetConnectionString()
        {
            string output = ConfigurationManager.
                ConnectionStrings["TestConnectionString"].ConnectionString;
            return output;
        }


        public static SqlConnection GetConnection()
        {
            SqlConnection output = new SqlConnection(GetConnectionString());
            output.Open();
            return output;
        }

        #region new database db
        public static string GetConnectionStringDB()
        {
            string output = ConfigurationManager.
                ConnectionStrings["DBConnectionString"].ConnectionString;
            return output;
        }


        public static SqlConnection GetConnectionDB()
        {
            SqlConnection output = new SqlConnection(GetConnectionStringDB());
            output.Open();
            return output;
        }

        #endregion
        #region IDisposable Members

        public void Dispose()
        {
            if (transaction != null &&
                connection.State == ConnectionState.Open)
                transaction.Commit();
            Close();
        }

        #endregion
    }

}