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
    [PermissionChecker(6)]
    public class EditUserModel : PageModel
    {
        IUserService _userService;
        IPermissionService _permissionService;
        public EditUserModel(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }
        [BindProperty]
        public EditUserViewModel EditUser { get; set; }
        public void OnGet(int id)
        {
            EditUser = _userService.GetUserForShowInEditMode(id);
            var a=  _permissionService.GetRoles();
            ViewData["Roles1"] = a;



        }
        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
            { return Page(); }
               
            _userService.EditUserFromAdmin(EditUser);
            //Add Roles
            _permissionService.EditRolesUser(SelectedRoles, EditUser.UserId );
            return RedirectToPage("Index");
        }
    }
}
