﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fraud.Entities.Car
{
    [Table("SalesD6_DayDamageDetail", Schema = "cr")]
    public partial class SalesD6DayDamageDetail
    {
        [Key]
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int? PrvId { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public int? HvId { get; set; }
        public int? HvNo { get; set; }
        public string ElamDate { get; set; }
        public string HvDate { get; set; }
        public int? SalAdamKhesaratSarneshin { get; set; }
        public int? SalAdamKhesaratJani { get; set; }
        public int? SalAdamKhesaratMali { get; set; }
        public decimal? PrmAmount { get; set; }
        public decimal? HvAmount { get; set; }
        public string DamagedType { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? DriverId { get; set; }
        public string DriverName { get; set; }
        public int? DriverTypeId { get; set; }
        public string DriverTypeName { get; set; }
        public string GovahiTypeName { get; set; }
        public int? HvGirandeId { get; set; }
        public string HvGirandeName { get; set; }
        public string HvGirandeNationalcode { get; set; }
        public decimal? HvGirandeHvAmount { get; set; }
        public int? MoredEstefadeId { get; set; }
        public string MoredEstefadeName { get; set; }
        public int? CarGroupId { get; set; }
        public string CarGroupName { get; set; }
        public int? CarKindId { get; set; }
        public string CarKindName { get; set; }
        public int? CarModel { get; set; }
        public string Pelak { get; set; }
        public int? PelakKindId { get; set; }
        public string PelakKindName { get; set; }
        public int? DmgMored { get; set; }
        public string Comment { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}