using System;
using System.ComponentModel.DataAnnotations;

namespace CRPApp.Data.ViewModels
{
    public class OnsiteStatusViewModel
    {
        [Display(Name = "Emp #")]
        public string EmpId { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "Position")]
        public string PositionTitle { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        [Display(Name = "Status")]
        public string OnsiteStatus { get; set; }
        [Display(Name = "Last Door Accessed")]
        public string LastCRPDoorAccessed { get; set; }
        [Display(Name = "Last Door Accessed Time")]
        public string LastCRPDoorAccessedDateTime { get; set; }
        public string Message { get; set; }
    }
}
