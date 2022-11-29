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
    [PermissionChecker(5)]
    public class CreateUserModel : PageModel
    {
       
        private IPermissionService _permissionService;
        private IUserService _userService;

        public CreateUserModel(IUserService userService ,IPermissionService permissionService)
        {
            _userService = userService;
             _permissionService = permissionService;
        }
        [BindProperty]
        public CreateUserViewModel CreateUser { get; set; }

        /// <summary>
        ///  „«„ —Ê·Â« 
        /// </summary>
        public void OnGet()
        {
          
          
            ViewData["Roles"] = _permissionService.GetRoles();
        }


        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
                return Page();
            int userId = _userService.AddUserFromAdmin(CreateUser);
            //Add Roles
            _permissionService.AddRolesToUser(SelectedRoles, userId);
            return Redirect("/Admin/Users");
        }
    }
}
