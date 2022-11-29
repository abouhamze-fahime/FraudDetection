using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraud.Models.Car
{
  public  class SalesD6DayDamageViewModel
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int? Bno { get; set; }
        public int PrvId { get; set; }
        public int? PrvNo { get; set; }
        public string BnSodurDate { get; set; }
        public DateTime? SodurDateMiladi { get; set; }
        public string HadeseDate { get; set; }
        public DateTime? HadeseDateMiladi { get; set; }
        public int? DateDifference { get; set; }
        public string PrvDate { get; set; }
        public DateTime? PrvDateMiladi { get; set; }
        public int? DamageMoredId { get; set; }
        public string DamageMoredName { get; set; }
        public string CustomerName { get; set; }
        public string AgentName { get; set; }
        public string SodurName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string ElatHadeseName { get; set; }
        public string PrvSodurName { get; set; }
        public string BnUserName { get; set; }
        public string PrvUserName { get; set; }
        public string LastBnEndDate { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }

    }
}
