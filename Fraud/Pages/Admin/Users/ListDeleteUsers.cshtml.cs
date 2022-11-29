using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fraud.Services;
using Fraud.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fraud.Pages.Admin.Users
{
    public class ListDeleteUsersModel : PageModel
    {
        private IUserService _userService;
        public ListDeleteUsersModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserForAdminViewModel UserForAdmin { get; set; }
        public void OnGet(int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            UserForAdmin = _userService.GetDeleteUsers(pageId, filterUserName, filterEmail);
        }

    }
}
