// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fraud.Entities.Car
{
    [Table("SalesD3_GovahiCarType", Schema = "cr")]
    public partial class SalesD3GovahiCarType
    {
        [Key]
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int? Bno { get; set; }
        public string BnSodurDate { get; set; }
        public DateTime? BnSodurDateMiladi { get; set; }
        public int? GovahiType { get; set; }
        public int GovahiTypeId { get; set; }
        public string GovahiTypeName { get; set; }
        public int KhodroGoruhId { get; set; }
        public string KhodroGoruhName { get; set; }
        public int KhodroId { get; set; }
        public string KhodroKindCaption { get; set; }
        public int? SarneshinCount { get; set; }
        public decimal? Tonaje { get; set; }
        public int PrvId { get; set; }
        public int? PrvNo { get; set; }
        public string PrvDate { get; set; }
        public DateTime? PrvDateMiladi { get; set; }
        public string HadeseDate { get; set; }
        public DateTime? HadeseDateMiladi { get; set; }
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
        public DateTime CreateDate { get; set; }
    }
}