using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Entities.Common
{
    [Table("ReportFromAllTable", Schema = "cmn")]
    public class MiniRepo
    {
            [Key]
            public int Id { get; set; }
            public int BranchId { get; set; }
            public string BranchName { get; set; }
            public int Status { get; set; }
            public string StatusName { get; set; }
            public int KpiTypeId { get; set; }
            public string KpiTypeName { get; set; }
            public string Sal { get; set; }
            public int ReshteId { get; set; }
            public string ReshteName { get; set; }
            public int? Cnt { get; set; }
       
    }
}
