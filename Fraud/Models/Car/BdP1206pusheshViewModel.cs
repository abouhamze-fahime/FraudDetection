using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Models.Car
{
    public class BdP1206pusheshViewModel
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int? Bno { get; set; }
        public string KhodroName { get; set; }
        public int SalSakht { get; set; }
        public string SodurDate { get; set; }
        public DateTime? SodurDateMiladi { get; set; }
        public int ElhNo { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Nationalcode { get; set; }
        public string CompanyCode { get; set; }
        public int AgentCode { get; set; }
        public string AgentName { get; set; }
        public int BnSodurId { get; set; }
        public string BnSodurName { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
