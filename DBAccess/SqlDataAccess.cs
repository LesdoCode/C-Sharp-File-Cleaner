using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace schedule_app_prototype.DBAccess
{
    public static class SqlDataAccess
    {
        private static string GetConnectionString(string connectionName = "ChurchBase")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static void SaveData<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    cnn.Execute(sql, data);
                    MessageBox.Show("Added to database");
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

        }

        public static void SaveMultiple<T>(string sql, List<T> data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    foreach(var row in data)
                        cnn.Execute(sql, row);                    
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public static void DeleteData<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    cnn.Execute(sql, data);
                    MessageBox.Show("Removed from database");
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

        }

        public static void UpdateData<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    cnn.Execute(sql, data);
                    MessageBox.Show("Updated to database");
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public static void Execute(string sql)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    cnn.Execute(sql);
                    MessageBox.Show("Database execution complete");
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public static List<T> Query<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, data).ToList();
            }
        } 
       
    }
}
