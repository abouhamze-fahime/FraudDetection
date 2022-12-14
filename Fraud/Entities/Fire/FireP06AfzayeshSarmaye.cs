// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fraud.Entities
{
    [Table("FireP06_AfzayeshSarmaye", Schema = "fr")]
    public partial class FireP06AfzayeshSarmaye
    {
        public int Id { get; set; }
        public int PolicyVerId { get; set; }
        public int PolicyId { get; set; }
        public int Bno { get; set; }
        public int Ro { get; set; }
        public int ElhNo { get; set; }
        public int PolicyTypeId { get; set; }
        public decimal Sarmaye { get; set; }
        public string BnSodurDate { get; set; }
        public DateTime BnSodurDateMiladi { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Nationalcode { get; set; }
        public int AgentCode { get; set; }
        public string AgentName { get; set; }
        public int SodurId { get; set; }
        public string SodurName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? DiffRate { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}