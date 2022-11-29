using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Entities.Common
{

    [Table("tblRevenueChart", Schema = "cmn")]
    public class RevenueChart
    {
        [Key]
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int? BnCnt { get; set; }
        public int? DmgCnt { get; set; }
    }
}
