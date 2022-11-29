
using Fraud.Models.Car;
using Fraud.Entities.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fraud.Entities.Test;
using Fraud.Entities.Common;
using Fraud.Models.Common;

namespace Fraud.Services
{
    public interface IServices
    {
        //int GetListCount();

        #region Third Party 

        #region Policy 

        /// <summary>
        /// شاخص یک صدور ثالث: مبلغ پیش پرداخت بیمه نامه  کل حق بیمه
        /// </summary>
        /// <returns></returns>
        
        IQueryable<SalesP1LessPishPardakhtViewModel> GetSalesP1LessPishPardakht();
        SalesP1LessPishPardakhtViewModel OpenRecordSalesP1LessPishPardakht(int? id);
        SalesP1LessPishPardakht UpdateSalesP1LessPishPardakht(string comment, int id, int statusId);

        /// <summary>
        /// شاخص دو صدور ثالث: شرایط اعلام بدهکار 
        /// </summary>
        /// <returns></returns>
        
        IQueryable<SalesP2AghsatGreater6ViewModel> GetSalesP2AghsatGreater6();
        SalesP2AghsatGreater6ViewModel OpenRecordSalesP2AghsatGreater6(int? id);
        SalesP2AghsatGreater6 UpdateSalesP2AghsatGreater6(string comment, int id, int statusId);

        /// <summary>
        ///شاخص سه ثالث: تخفیفات بیمه نامه - تاریخ شماره گذاری - تاریخ شروع بیمه نامه 
        /// </summary>
        /// <returns></returns>
      
        IQueryable<SalesP3PelakSodurDateDiscountViewModel> GetSalesP3PelakSodurDateDiscount();
        SalesP3PelakSodurDateDiscountViewModel OpenRecordSalesP3PelakSodurDateDiscount(int? id);
        SalesP3PelakSodurDateDiscount UpdateSalesP3PelakSodurDateDiscount(string comment, int id, int statusId);

        /// <summary>
        /// شاخص شماره چهار صدور ثالث: نام مالک - نام بیمه گذار
        /// </summary>
        /// <returns></returns>

        IQueryable<SalesP4MalekCustomerViewModel> GetSalesP4MalekCustomer();
        SalesP4MalekCustomerViewModel OpenRecordSalesP4MalekCustomer(int? id);
        SalesP4MalekCustomer UpdateSalesP4MalekCustomer(string comment, int id, int statusId);

       
        /// <summary>
        /// شاخص شماره 5 ثالث : اشخاص با اطلاعات ناقص   
        /// </summary>
        /// <returns></returns>

        IQueryable<SalesP5TroubledCustomerViewModel> GetSalesP5TroubledCustomer();
        SalesP5TroubledCustomerViewModel OpenRecordSalesP5TroubledCustomer(int? id);
        SalesP5TroubledCustomer UpdateSalesP5TroubledCustomer(string comment, int id, int statusId);


        /// <summary>
        /// شاخص شش ثالث : خودرو با اطلاعات ناقص   
        /// </summary>
        /// <returns></returns>

        IQueryable<SalesP6TroubledKhodroViewModel> GetSalesP6TroubledKhodro();
        SalesP6TroubledKhodroViewModel OpenRecordSalesP6TroubledKhodro(int? id);
        SalesP6TroubledKhodro UpdateSalesP6TroubledKhodro(string comment, int id, int statusId);
       
        /// <summary>
        /// شاخص شماره هفت صدور ثالث:سال ساخت خودرو - سال تخفیف سنواتی اعمال شده
        /// </summary>
        /// <returns></returns>      

        IQueryable<SalesP7SalSahkhtSanavatDiscountViewModel> GetSalesP7SalSahkhtSanavatDiscount();
        SalesP7SalSahkhtSanavatDiscountViewModel OpenRecordSalesP7SalSahkhtSanavatDiscount(int? id);
        SalesP7SalSahkhtSanavatDiscount UpdateSalesP7SalSahkhtSanavatDiscount(string comment, int id, int statusId);
        #endregion

        #region Damage  
        /// <summary>
        /// شاخص یک : کاربری وسیله نقلیه 
        /// </summary>
        /// <returns></returns>

        IQueryable<SalesD1KarbariViewModel> GetSalesD1Karbari();
        SalesD1KarbariViewModel OpenRecordSalesD1Karbari(int? id);
        SalesD1Karbari UpdateSalesD1Karbari(string comment, int id , int statusId);

        /// <summary>
        /// شاخص دو:
        /// نوع حادثه - تخلف ساز 
        /// </summary>
        /// <returns></returns>
        /// 
        IQueryable<SalesD2TakhalofHadeseSazViewModel> GetSalesD2TakhalofHadeseSaz(); 
        SalesD2TakhalofHadeseSazViewModel OpenRecordSalesD2TakhalofHadeseSaz(int? id);
        SalesD2TakhalofHadeseSaz UpdateSalesD2TakhalofHadeseSaz(string comment, int id, int statusId);

        /// <summary>
        /// شاخص دو:
        /// تخلف حادث ساز که تسویه نشده اند  
        /// </summary>
        /// <returns></returns>
        /// 

        IQueryable<SalesD2BazyaftNotTasvieViewModel> GetSalesD2BazyaftNotTasvie();
        SalesD2BazyaftNotTasvieViewModel OpenRecordSalesD2BazyaftNotTasvie(int? id);
        SalesD2BazyaftNotTasvie UpdateSalesD2BazyaftNotTasvie(string comment, int id, int statusId);

        /// <summary>
        /// شاخص سه:
        /// نوع خودرو - نوع گواهی نامه  
        /// </summary>
        /// <returns></returns>
        /// 

        IQueryable<SalesD3GovahiCarTypeViewModel> GetSalesD3GovahiCarType();
        SalesD3GovahiCarTypeViewModel OpenRecordSalesD3GovahiCarType(int? id);
        SalesD3GovahiCarType UpdateSalesD3GovahiCarType(string comment, int id, int statusId);

        /// <summary>
        /// شاخص شش:
        ///تاریخ صدور بیمه نامه - تاریخ وقوع حادثه
        /// </summary>
        /// <returns></returns>
        /// 

        IQueryable<SalesD6DayDamageViewModel> GetSalesD6DayDamage(); 
        SalesD6DayDamageViewModel OpenRecordSalesD6DayDamage(int? id);
        SalesD6DayDamage UpdateSalesD6DayDamage(string comment, int id, int statusId);

        /// <summary>
        /// جزییات شاخص شش : تفاوت تاریخ صدور بیمه نامه و تاریخ وقوع حادثه
        /// </summary>
        /// <param name="policyId"></param>
        /// <returns></returns>
        IQueryable<SalesD6DayDamageDetailViewModel> GetSalesD6DayDamageDetail(int policyId); 

        /// <summary>
        /// شاخص شماره هفت خسارت ثالث: تاریخ اقساط - تاریخ واریزهای - تاریخ وقوع حادثه  -  
        /// </summary>
        /// <returns></returns>
        IQueryable<SalesD7InstallmentWithHvViewModel> GetSalesD7InstallmentWithHv();//تاریخ اقساط - و واریزیها 
        SalesD7InstallmentWithHvViewModel OpenRecordSalesD7InstallmentWithHv(int? id);
        SalesD7InstallmentWithHv UpdateSalesD7InstallmentWithHv(string comment, int id, int statusId);

        #endregion

        #endregion

        #region   Car Body 

        #region Policy 
        
        /// <summary>
        /// شاخص شماره یک بدنه : نوع خودرو - سال ساخت خودرو  
        /// </summary>
        /// <returns></returns>
         
        IQueryable<BdP1206pusheshViewModel> GetBdP1206pushesh();
        BdP1206pusheshViewModel OpenRecordBdP1206pushesh(int? id);
        BdP1206pushesh UpdateBdP1206pushesh(string comment, int id, int statusId);

        /// <summary>
        /// شاخص شماره سه بدنه : تاریخ شماره گذاری - تاریخ آغاز بیمه نامه - تخفیف اعطا شده  
        /// </summary>
        /// <returns></returns>
        

        IQueryable<BdP3NewCarDiscountViewModel> GetBdP3NewCarDiscount();
        BdP3NewCarDiscountViewModel OpenRecordBdP3NewCarDiscount(int? id);
        BdP3NewCarDiscount UpdateBdP3NewCarDiscount(string comment, int id, int statusId);
     
        
        /// <summary>
        /// شاخص شماره 4 بدنه : اشخاص با اطلاعات ناقص   
        /// </summary>
        /// <returns></returns>

        IQueryable<BdP4TroubledCustomerViewModel> GetBdP4TroubledCustomer();
        BdP4TroubledCustomerViewModel OpenRecordBdP4TroubledCustomer(int? id);
        BdP4TroubledCustomer UpdateBdP4TroubledCustomer(string comment, int id, int statusId);

        /// <summary>
        /// شاخص پنج بدنه : خودرو با اطلاعات ناقص   
        /// </summary>
        /// <returns></returns>

        IQueryable<BdP5TroubledKhodroViewModel> GetBdP5TroubledKhodro();
        BdP5TroubledKhodroViewModel OpenRecordBdP5TroubledKhodro(int? id);
        BdP5TroubledKhodro UpdateBdP5TroubledKhodro(string comment, int id, int statusId);
        #endregion

        #region Damage 

        /// <summary>
        /// شاخص شماره یک بدنه : کاربری وسیله نقلیه 
        /// </summary>
        /// <returns></returns>
        /// 

        IQueryable<BdD1KarbariViewModel> GetBdD1Karbari();
        BdD1KarbariViewModel OpenRecordBdD1Karbari(int? id);
        BdD1Karbari UpdateBdD1Karbari(string comment, int id, int statusId);

        /// <summary>
        /// شاخص دو بدنه :
        /// تاریخ صدور گواهینامه -فرانشیز مندرج در فرم محاسبه
        /// </summary>
        /// <returns></returns>
       
        IQueryable<BdD2FranshizViewModel> GetBdD2Franshiz(); 
        BdD2FranshizViewModel OpenRecordBdD2Franshiz(int? id);
        BdD2Franshiz UpdateBdD2Franshiz(string comment, int id, int statusId);

        /// <summary>
        /// شاخص سه بدنه :
        /// نوع خودرو در بیمه نامه - نوع گواهینامه
        /// </summary>
        /// <returns></returns>

        IQueryable<BdD3GovahiCarTypeViewModel> GetBdD3GovahiCarType();  
        BdD3GovahiCarTypeViewModel OpenRecordBdD3GovahiCarType(int? id);
        BdD3GovahiCarType UpdateBdD3GovahiCarType(string comment, int id, int statusId);

        /// <summary>
        /// شاخص چهار بدنه :
        /// سال ساخت خودرو - سال وقوع حادثه
        /// </summary>
        /// <returns></returns>

        IQueryable<BdD4EstehlakViewModel> GetBdD4Estehlak(); 
        BdD4EstehlakViewModel OpenRecordBdD4Estehlak(int? id);
        BdD4Estehlak UpdateBdD4Estehlak(string comment, int id, int statusId);

        /// <summary>
        /// شاخص پنج بدنه :
        /// ارزش خودرو مندرج در بیمه نامه - ارزش کارشناسی خودرو در زمان وقوع حادثه 
        /// </summary>
        /// <returns></returns>

        IQueryable<BdD5CarAmountViewModel> GetBdD5CarAmount();
        BdD5CarAmountViewModel OpenRecordBdD5CarAmount(int? id);
        BdD5CarAmount UpdateBdD5CarAmount(string comment, int id, int statusId);

        /// <summary>
        /// شاخص شش بدنه :
        /// تاریخ صدور - تاریخ وقوع حادثه
        /// </summary>
        /// <returns></returns>

        IQueryable<BdD6DayDamageViewModel> GetBdD6DayDamage(); 
        BdD6DayDamageViewModel OpenRecordBdD6DayDamage(int? id);
        BdD6DayDamage UpdateBdD6DayDamage(string comment, int id, int statusId);

        /// <summary>
        /// شاخص هفت بدنه :
        /// تاریخ اقساط - تاریخ واریزیها - تاریخ وقوع حادثه 
        /// </summary>
        /// <returns></returns>

        IQueryable<BdD7InstallmentWithHvViewModel> GetBdD7InstallmentWithHv();
        BdD7InstallmentWithHvViewModel OpenRecordBdD7InstallmentWithHv(int? id);
        BdD7InstallmentWithHv UpdateBdD7InstallmentWithHv(string comment, int id, int statusId);

        #endregion
        #endregion








        List<MiniRepoByBranchViewModel> GetBnFileByBranch();
        List<RevenueChartViewModel> GetChartInfo();

        List<ResultTest> GetResultTestData(int id );

    }
}
