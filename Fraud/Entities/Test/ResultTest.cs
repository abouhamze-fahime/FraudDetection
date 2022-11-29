using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Entities.Test
{
    [Keyless]
    public class ResultTest
    {
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int StatusCnt { get; set; }
    }
}
