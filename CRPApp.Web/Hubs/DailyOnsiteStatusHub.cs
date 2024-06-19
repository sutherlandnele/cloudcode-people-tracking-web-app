using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRPApp.Service;
using CRPApp.Data;
using CRPApp.Data.ViewModels;
using AutoMapper;
using System.Configuration;
using Microsoft.AspNet.SignalR.Hubs;

namespace CRPApp.Web.Hubs
{
    public class DailyOnsiteStatusHub : Hub
    {
    
        private static string onlineStatusConnString = ConfigurationManager.ConnectionStrings["OnlineStatusConn"].ToString();
        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("updateOnsiteStatuses")]
        public static void UpdateOnsiteStatuses()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<DailyOnsiteStatusHub>();
            context.Clients.All.updateOnsiteStatuses();
        }

    }
}