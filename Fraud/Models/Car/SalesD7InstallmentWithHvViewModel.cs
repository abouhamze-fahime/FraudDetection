﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Models.Car
{
    public class SalesD7InstallmentWithHvViewModel
    {

        public int Id { get; set; }
        public int PrmSrdId { get; set; }
        public int PolicyId { get; set; }
        public int? Bno { get; set; }
        public int ElhNo { get; set; }
        public string ReshteName { get; set; }
        public int AgentCode { get; set; }
        public string AgentName { get; set; }
        public int SodurId { get; set; }
        public string SodurName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int PayerCustomerId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BeginDate { get; set; }
        public DateTime? BeginDateMiladi { get; set; }
        public string EndDate { get; set; }
        public DateTime? EndDateMiladi { get; set; }
        public string BnSodurDate { get; set; }
        public DateTime? BnSodurDateMiladi { get; set; }
        public string SrdDate { get; set; }
        public DateTime? SrdDateMiladi { get; set; }
        public string OpDate { get; set; }
        public DateTime? OpDateMiladi { get; set; }
        public int IsActiveId { get; set; }
        public string TasvieType { get; set; }
        public decimal? SrdAmountAsRial { get; set; }
        public decimal? TasvieAmount { get; set; }
        public decimal? Mande { get; set; }
        public decimal? TasvieNashode { get; set; }
        public decimal? VosulShode { get; set; }
        public string AmaliatTasvieType { get; set; }
        public string CreditType { get; set; }
        public string PrvDate { get; set; }
        public DateTime? PrvDateMiladi { get; set; }
        public string HadeseDate { get; set; }
        public DateTime? HadeseDateMiladi { get; set; }
        public string ElamDate { get; set; }
        public DateTime? ElamDateMiladi { get; set; }
        public int? PrvNo { get; set; }
        public decimal? HvAmount { get; set; }
        public string VslStateDate { get; set; }
        public DateTime? VslStateDateMiladi { get; set; }
        public int? IsNaghdiId { get; set; }
        public string DeliverDate { get; set; }
        public DateTime? DeliverDateMiladi { get; set; }
        public int? RcvdKindId { get; set; }
        public string RcvdKindName { get; set; }
        public int? VslStateId { get; set; }
        public string VslStateName { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
