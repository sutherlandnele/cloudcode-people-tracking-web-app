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
    public class Old_DailyOnsiteStatusHub : Hub
    {

        private readonly OnsiteStatusService dailyOnsiteStatusService;

        public Old_DailyOnsiteStatusHub()
        {
            dailyOnsiteStatusService = new OnsiteStatusService(new CRPDbContext());
        }

        public IEnumerable<OnsiteStatusViewModel> Read()
        {

            return dailyOnsiteStatusService.Read();
        }

        public void Update(OnsiteStatusViewModel onsiteStatusViewModel)
        {
            dailyOnsiteStatusService.Update(onsiteStatusViewModel);
            Clients.Others.update(onsiteStatusViewModel);
        }



    }
}