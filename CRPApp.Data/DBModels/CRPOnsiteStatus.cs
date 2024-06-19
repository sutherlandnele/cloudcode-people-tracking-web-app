using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPApp.Data.DBModels
{
    [Table("CRPOnsiteStatus")]
    public class CRPOnsiteStatus
    {
        [Key]
        public string EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionTitle { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public bool? IsOnsite { get; set; }       
        public string LastCRPDoorAccessed { get; set; }
        public DateTime? LastCRPDoorAccessedDateTime { get; set; }
        public string Message { get; set; }

    }
}
