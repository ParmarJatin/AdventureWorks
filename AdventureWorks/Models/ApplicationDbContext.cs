using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdventureWorks.Models
{
    public class ApplicationDbContext
    {
        public List<DatabaseLog> databaseLogs;


        public ApplicationDbContext()
        {
            databaseLogs = new List<DatabaseLog>();
            this.getDatabaseLogs();
        }

        public void getDatabaseLogs()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString.ToString();
            SqlConnection oMySqlConnection = new SqlConnection(connectionString);
            oMySqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT [DatabaseLogID],[DatabaseUser],[Event],[Schema],[Object],[TSQL]  FROM  dbo.DatabaseLog", oMySqlConnection);
            SqlDataReader oMySqlDataReader = command.ExecuteReader();
            while (oMySqlDataReader.Read())
            {
                databaseLogs.Add(new DatabaseLog
                {
                    DatabaseLogID = oMySqlDataReader["DatabaseLogID"].ToString(),
                    DatabaseUser = oMySqlDataReader["DatabaseUser"].ToString(),
                    Event = oMySqlDataReader["Event"].ToString(),
                    Schema = oMySqlDataReader["Schema"].ToString(),
                    Object = oMySqlDataReader["Object"].ToString(),
                    TSQL = oMySqlDataReader["TSQL"].ToString()
                });
            }
        }
    }
}