using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPApp.Data
{
    public class CRPOnsiteStatus
    {
        [Key]
        public string EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionTitle { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public Boolean IsOnsite { get; set; }
        public string LastCRPDoorAccessed { get; set; }
        public DateTime LastCRPDoorAccessedDateTime { get; set; }
        public string Message { get; set; }

    }
}
