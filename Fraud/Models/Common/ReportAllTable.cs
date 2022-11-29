using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Models.Common
{
    public class ReportAllTable
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string ReshteName { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int cnt { get; set; }
    }
}
