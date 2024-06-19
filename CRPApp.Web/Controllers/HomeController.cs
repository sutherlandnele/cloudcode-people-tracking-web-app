using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRPApp.Web.Hubs;
using OfficeOpenXml;
using System.IO;
using System.Data;
using OfficeOpenXml.Table;

namespace CRPApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Daily Onsite Statuses";
            return View();
        }

        public ActionResult GetOnsiteStatuses()
        {
            DailyOnsiteStatusHubRepository dailyOnsiteStatusHubRepository = new DailyOnsiteStatusHubRepository();
            return PartialView("_DailyOnsiteStatusList", dailyOnsiteStatusHubRepository.GetAllDailyOnsiteStatus());
        }

        public ActionResult ExportOnsiteStatusesToExcel()
        {
            DailyOnsiteStatusHubRepository dailyOnsiteStatusHubRepository = new DailyOnsiteStatusHubRepository();
            var dailyOnsiteStatuses = dailyOnsiteStatusHubRepository.GetAllDailyOnsiteStatus();
            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("EmpId", typeof(string));
                Dt.Columns.Add("FullName", typeof(string));
                Dt.Columns.Add("PositionTitle", typeof(string));
                Dt.Columns.Add("Department", typeof(string));
                Dt.Columns.Add("Company", typeof(string));
                Dt.Columns.Add("OnsiteStatus", typeof(string));
                Dt.Columns.Add("LastCRPDoorAccessed", typeof(string));
                Dt.Columns.Add("LastCRPDoorAccessedDateTime", typeof(string));
                Dt.Columns.Add("Message", typeof(string));

                foreach (var data in dailyOnsiteStatuses)
                {
                    DataRow row = Dt.NewRow();

                    row[0] = data.EmpId;
                    row[1] = data.FullName;
                    row[2] = data.PositionTitle;
                    row[3] = data.Department;
                    row[4] = data.Company;
                    row[5] = data.OnsiteStatus;
                    row[6] = data.LastCRPDoorAccessed;
                    row[7] = data.LastCRPDoorAccessedDateTime;
                    row[8] = data.Message;

                    Dt.Rows.Add(row);

                }

                var memoryStream = new MemoryStream();

                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(Dt, true, TableStyles.None);
                    //worksheet.Cells["A1:AN1"].Style.Font.Bold = true;
                    //worksheet.DefaultRowHeight = 18;
                    //worksheet.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    //worksheet.Column(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    //worksheet.Column(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    //worksheet.DefaultColWidth = 20;
                    //worksheet.Column(2).AutoFit();

                    Session["DownloadExcel_FileManager"] = excelPackage.GetAsByteArray();
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public ActionResult DownloadOnsiteStatusesExcelFile()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/octet-stream", "OnsiteStatuses.xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}
