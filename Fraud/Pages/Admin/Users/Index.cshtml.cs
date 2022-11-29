using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fraud.Services;
using Fraud.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fraud.Security;

namespace Fraud.Pages.Admin.Users
{
    [PermissionChecker(3)]
    public class IndexModel : PageModel
    {
        private IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserForAdminViewModel UserForAdmin { get; set; }
        public void OnGet(int pageId =1 , string filterUserName="" , string filterEmail="")
        {
            UserForAdmin = _userService.GetUsers(pageId, filterUserName, filterEmail);
        }

     
    }
}
