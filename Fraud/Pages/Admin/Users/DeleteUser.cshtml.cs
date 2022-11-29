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
    [PermissionChecker(7)]
    public class DeleteUserModel : PageModel
    {
        private IUserService _userService;
        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }
        public InformationUserViewModel InformationUser { get; set; }
        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            InformationUser = _userService.GetUserInformation(id);
        }
       
        public IActionResult OnPostSend( int userId)
        {
            _userService.DeleteUser(userId);
            return RedirectToPage("Index");
        }


    }
}
