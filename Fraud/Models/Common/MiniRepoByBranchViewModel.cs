using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Models.Common
{
    public class MiniRepoByBranchViewModel
    {

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string KpiTypeName { get; set; }
        public int? Cnt { get; set; }
    }
}
