
using Fraud.Entities;
using Fraud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Services
{
  public  interface IFireServices
    {
        /// <summary>
        /// درج کامل آدرس مورد بیمه و یکسان بودن آن با کد پستی در فناوران
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP01TroubledCodePostiViewModel> GetFireP01TroubledCodePosti();
        FireP01TroubledCodePostiViewModel OpenRecordFireP01TroubledCodePosti(int? id);
        FireP01TroubledCodePosti UpdateFireP01TroubledCodePosti(string comment, int id, int statusId);

        /// <summary>
        /// کنترل ثبت کد رایانه بیمه نامه قبلی در فناوران در خصوص صدور بیمه نامه های تمدیدی
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP03BnNoLastPolicyIdViewModel> GetFireP03BnNoLastPolicyId();
        FireP03BnNoLastPolicyIdViewModel OpenRecordFireP03BnNoLastPolicyId(int? id);
        FireP03BnNoLastPolicyId UpdateFireP03BnNoLastPolicyId(string comment, int id, int statusId);


        /// <summary>
        /// کنترل درج لیست تفکیکی
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP04TafkikListViewModel> GetFireP04TafkikList();
        FireP04TafkikListViewModel OpenRecordFireP04TafkikList(int? id);
        FireP04TafkikList UpdateFireP04TafkikList(string comment, int id, int statusId);


        /// <summary>
        /// الزام بازدید از موارد بیمه صنعتی، غیرصنعتی و انبارها با درخواست افزایش ...
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP06AfzayeshSarmayeViewModel> GetFireP06AfzayeshSarmaye();
        FireP06AfzayeshSarmayeViewModel OpenRecordFireP06AfzayeshSarmaye(int? id);
        FireP06AfzayeshSarmaye UpdateFireP06AfzayeshSarmaye(string comment, int id, int statusId);

        /// <summary>
        /// الزام به بازدید از انبارهای عمومی بدون در نظر گرفتن ارزش سرمایه مورد بیمه
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP07AnbarBazdidViewModel> GetFireP07AnbarBazdid();
        FireP07AnbarBazdidViewModel OpenRecordFireP07AnbarBazdid(int? id);
        FireP07AnbarBazdid UpdateFireP07AnbarBazdid(string comment, int id, int statusId);


        /// <summary>
        /// کنترل اعتبار زمان بازدید اولیه تا صدور بیمه نامه برای خطر آصا و سایر خطراتی که بازدید برای آنها الزامی است
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP08AsaBazdidViewModel> GetFireP08AsaBazdid();
        FireP08AsaBazdidViewModel OpenRecordFireP08AsaBazdid(int? id);
        FireP08AsaBazdid UpdateFireP08AsaBazdid(string comment, int id, int statusId);


        /// <summary>
        /// کنترل بازدید آتش سوزی مسکونی بیش از 400 میلیارد ریال
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP09MaskanBazdidViewModel> GetFireP09MaskanBazdid();
        FireP09MaskanBazdidViewModel OpenRecordFireP09MaskanBazdid(int? id);
        FireP09MaskanBazdid UpdateFireP09MaskanBazdid(string comment, int id, int statusId);


        /// <summary>
        ///کنترل بازدید آتش سوزی غیر صنعتی بیش از 10 میلیارد ریال
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP10GheirSanatiBazdidOver10ViewModel> GetFireP10GheirSanatiBazdidOver10();
        FireP10GheirSanatiBazdidOver10ViewModel OpenRecordFireP10GheirSanatiBazdidOver10(int? id);
        FireP10GheirSanatiBazdidOver10 UpdateFireP10GheirSanatiBazdidOver10(string comment, int id, int statusId);



        /// <summary>
        ///کنترل بازدید آتش سوزی غیرصنعتی بیش از 80 میلیارد ریال
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP11GheirSanatiBazdidOver80ViewModel> GetFireP11GheirSanatiBazdidOver80();
        FireP11GheirSanatiBazdidOver80ViewModel OpenRecordFireP11GheirSanatiBazdidOver80(int? id);
        FireP11GheirSanatiBazdidOver80 UpdateFireP11GheirSanatiBazdidOver80(string comment, int id, int statusId);


        /// <summary>
        ///کنترل بازدید آتش سوزی انبار بیش از 10 میلیارد ریال
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP12AnbarBazdidOver10ViewModel> GetFireP12AnbarBazdidOver10();
        FireP12AnbarBazdidOver10ViewModel OpenRecordFireP12AnbarBazdidOver10(int? id);
        FireP12AnbarBazdidOver10 UpdateFireP12AnbarBazdidOver10(string comment, int id, int statusId);


        /// <summary>
        ///کنترل بازدید آتش سوزی صنعتی بیش از 20 میلیارد ریال
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP13SanatiBazdidOver20ViewModel> GetFireP13SanatiBazdidOver20();
        FireP13SanatiBazdidOver20ViewModel OpenRecordFireP13SanatiBazdidOver20(int? id);
        FireP13SanatiBazdidOver20 UpdateFireP13SanatiBazdidOver20(string comment, int id, int statusId);



        /// <summary>
        ///کنترل بازدید آتش سوزی صنعتی و انبارهای عمومی تمامی فعالیتهای گروه 9-10-11-12 
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP14SanatiAnbarBazdidSpecialGroupViewModel> GetFireP14SanatiAnbarBazdidSpecialGroup();
        FireP14SanatiAnbarBazdidSpecialGroupViewModel OpenRecordFireP14SanatiAnbarBazdidSpecialGroup(int? id);
        FireP14SanatiAnbarBazdidSpecialGroup UpdateFireP14SanatiAnbarBazdidSpecialGroup(string comment, int id, int statusId);



        /// <summary>
        ///کنترل بازدید ترکیدگی لوله آب ، ضایعات ناشی از آب باران و ذوب برف بیش از30 میلیون ریال
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP15BazdidSpecialGroupOver30ViewModel> GetFireP15BazdidSpecialGroupOver30();
        FireP15BazdidSpecialGroupOver30ViewModel OpenRecordFireP15BazdidSpecialGroupOver30(int? id);
        FireP15BazdidSpecialGroupOver30 UpdateFireP15BazdidSpecialGroupOver30(string comment, int id, int statusId);


        /// <summary>
        ///کنترل بازدید ترکیدگی لوله آب ، ضایعات ناشی از آب باران و ذوب برف بیش از30 میلیون ریال
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP16SerghatBazdidOver700ViewModel> GetFireP16SerghatBazdidOver700();
        FireP16SerghatBazdidOver700ViewModel OpenRecordFireP16SerghatBazdidOver700(int? id);
        FireP16SerghatBazdidOver700 UpdateFireP16SerghatBazdidOver700(string comment, int id, int statusId);


        /// <summary>
        ///کنترل بازدید رانش زمین ، شرایط جایگزینی یا بازسازی 
        ///، حوادث ، تعریق ، سنگینی برف ، خود سوزی ، نوسانات برق ، فساد کالا درسردخانه
        ///، نشت گاز آمونیاک ، فروکش چاه آب و فاضلاب ، دفرمگی ظروف تحت فشار صنعتی
        ///، ریزش پودر مواد خام داغ ، تگرگ ، ریزش کوه و بهمن ، برخورد وسایل نقلیه داخل
        ///سایت مورد بیمه ، سقوط قطعات منفصله از ماشین آلات ، تمام خطر اموال و شکست ماشین آلاتل
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP17SpecialGroupBazdidViewModel> GetFireP17SpecialGroupBazdid();
        FireP17SpecialGroupBazdidViewModel OpenRecordFireP17SpecialGroupBazdid(int? id);
        FireP17SpecialGroupBazdid UpdateFireP17SpecialGroupBazdid(string comment, int id, int statusId);



        /// <summary>
        ///الزام بازدید از مورد بیمه ای که دارای سابقه خسارت بوده اند بدون در نظر گرفتن سرمایه بیمه نامه
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP18DamagedBazdidViewModel> GetFireP18DamagedBazdid();
        FireP18DamagedBazdidViewModel OpenRecordFireP18DamagedBazdid(int? id);
        FireP18DamagedBazdid UpdateFireP18DamagedBazdid(string comment, int id, int statusId);


        /// <summary>
        ///حداقل حق بیمه دریافتی برای صدور تمام بیمه نامه های آتش سوزی )به جز طرح جامع منازل مسکونی(218,000) ریال می باشد
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP19MinPrmViewModel> GetFireP19MinPrm();
        FireP19MinPrmViewModel OpenRecordFireP19MinPrm(int? id);
        FireP19MinPrm UpdateFireP19MinPrm(string comment, int id, int statusId);

        /// <summary>
        ///درصورتیکه حق بیمه کمتر از 2.000.000 ریال در رشته آتش سوزی مسکونی و کمتر از 2.000.000 ریال در رشته غیرصنعتی 
        ///و کمتر از 5.000.000 ریال در رشته صنعتی و انبارها باشد . حق بیمه باید همزمان با صدور بیمه نامه به حساب شرکت واریز شود.
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP21CashPrmBnViewModel> GetFireP21CashPrmBn();
        FireP21CashPrmBnViewModel OpenRecordFireP21CashPrmBn(int? id);
        FireP21CashPrmBn UpdateFireP21CashPrmBn(string comment, int id, int statusId);



        /// <summary>
        ///حق بیمه الحاقیه های که منجر به افزایش تعهد مالی برای بیمه گذار می شود در تمامی رشته ها به صورت نقد می باشد.
        ///خارج از موارد فوق با تأیید و نظر کتبی مدیر فنی مربوطه حداکثر تا زمان اعتبار بیمه نامه امکان پذیر است
        /// </summary>
        /// <returns></returns>

        IQueryable<FireP23CashPrmElhViewModel> GetFireP23CashPrmElh();
        FireP23CashPrmElhViewModel OpenRecordFireP23CashPrmElh(int? id);
        FireP23CashPrmElh UpdateFireP23CashPrmElh(string comment, int id, int statusId);





    }
}
