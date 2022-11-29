using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Models.Car
{
    public class SalesP1LessPishPardakhtViewModel
    {
        public int Id { get; set; }
        public int MaliBid { get; set; }
        public int PolicyId { get; set; }
        public int? SodurGid { get; set; }
        public int PersonkindId { get; set; }
        public string PersonkindName { get; set; }
        public string BnSodurDate { get; set; }
        public DateTime? BnSodurDateMiladi { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Nationalcode { get; set; }
        public int AgentCode { get; set; }
        public string AgentName { get; set; }
        public int BnSodurId { get; set; }
        public string BnSodurName { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal? GhestAmount { get; set; }
        public decimal? PrmAmount { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
