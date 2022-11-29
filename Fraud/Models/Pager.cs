﻿using Fraud.Models;
using Fraud.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Fraud.Models
{
    public class Pager
    {
        public int TotalItem { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int? PageSize { get; private set; }
        public StaticPagedList<SalesD6DayDamageViewModel> PolicyLst { get; set; }
       //add two constructor 
        public Pager()
        {

        }
        //page is current page 
         public Pager(int totalItem , int page , int pageSize)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItem / (decimal )pageSize);
            int currentPage = page;
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;
            if (startPage<=0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage>totalPages)
            {
                endPage = totalPages;
                if (endPage>10)
                {
                    startPage = endPage - 9;
                }

            }

            TotalItem = totalItem;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
    }

  
}
