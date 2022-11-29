using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Models.Car
{
    public class SalesD1KarbariViewModel
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int PrvNo { get; set; }
        public string PrvDate { get; set; }
        public int? Bno { get; set; }
        public string BeginDate { get; set; }
        public DateTime BeginDateMiladi { get; set; }
        public string EndDate { get; set; }
        public DateTime? EndDateMiladi { get; set; }
        public string HadeseDate { get; set; }
        public DateTime? HadeseDateMiladi { get; set; }
        public string HadeseAddress { get; set; }
        public int? ElatHadeseId { get; set; }
        public string ElatHadeseName { get; set; }
        public int? GovahiTypeId { get; set; }
        public string GovahiTypeName { get; set; }
        public int MoredEstefadeId { get; set; }
        public string MoredEstefadeName { get; set; }
        public int KhodroListId { get; set; }
        public int? KhodroKindId { get; set; }
        public string KhodroKindName { get; set; }
        public int DamageSodurId { get; set; }
        public string DamageSodurName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public decimal SumHvPayAmountAsRial { get; set; }
        public string DamageType { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
