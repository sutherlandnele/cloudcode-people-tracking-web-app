using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using CRPApp.Data.ViewModels;

namespace CRPApp.Web.Hubs
{
    class DailyOnsiteStatusHubRepository
    {
        readonly string onlineStatusConnString = ConfigurationManager.ConnectionStrings["OnlineStatusConn"].ConnectionString;

        public IEnumerable<OnsiteStatusViewModel> GetAllDailyOnsiteStatus()
        {
            var dailyOnsiteStatuses = new List<OnsiteStatusViewModel>();
            using (var connection = new SqlConnection(onlineStatusConnString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [EmpId]
                          ,[FirstName]
                          ,[LastName]
                          ,[PositionTitle]
                          ,[Department]
                          ,[Company]
                          ,[IsOnsite]
                          ,[LastCRPDoorAccessed]
                          ,[LastCRPDoorAccessedDateTime]
                          ,[Message]
                      FROM [dbo].[CRPOnsiteStatus] order by [LastCRPDoorAccessedDateTime] desc", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dailyOnsiteStatuses.Add(item: new OnsiteStatusViewModel
                        {
                            EmpId = (string)reader["EmpId"],
                            FullName = (reader["FirstName"] != DBNull.Value ? (string)reader["FirstName"] : "") //first name
                                +" "+ (reader["LastName"] != DBNull.Value ? (string)reader["LastName"] : ""), //last name
                            PositionTitle = reader["PositionTitle"] != DBNull.Value ? (string)reader["PositionTitle"] : "",
                            Company = reader["Company"] != DBNull.Value ? (string)reader["Company"] : "",
                            Department = reader["Department"] != DBNull.Value ? (string)reader["Department"] : "",
                            OnsiteStatus = (bool)reader["IsOnsite"] ? "Onsite" : "Offsite",
                            LastCRPDoorAccessed = reader["LastCRPDoorAccessed"] != DBNull.Value ? (string)reader["LastCRPDoorAccessed"] : "",
                            LastCRPDoorAccessedDateTime = reader["LastCRPDoorAccessedDateTime"] != DBNull.Value ? ((DateTime)(reader["LastCRPDoorAccessedDateTime"])).ToString("dd/MM/yyyy HH:mm:ss tt") : "",
                            Message = reader["Message"] != DBNull.Value ? (string)reader["Message"] : ""

                        });
                    }
                }
            }
            return dailyOnsiteStatuses;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                DailyOnsiteStatusHub.UpdateOnsiteStatuses();
            }
        }
    }
}
