using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Models.Car
{
    public class SalesD6DayDamageDetailViewModel
    {
        
        public int PolicyId { get; set; }
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
        public string CustomerName { get; set; }
        public string DriverName { get; set; }
        public string DriverTypeName { get; set; }
        public string GovahiTypeName { get; set; }
        public string HvGirandeName { get; set; }
        public string HvGirandeNationalcode { get; set; }
        public decimal? HvGirandeHvAmount { get; set; }
        public string MoredEstefadeName { get; set; }
        public string CarGroupName { get; set; }
        public string CarKindName { get; set; }
        public int? CarModel { get; set; }
        public string Pelak { get; set; }
        public string PelakKindName { get; set; }
    }
}
