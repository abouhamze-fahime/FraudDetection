using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Fraud.Services;
using Fraud.Entities.Acount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fraud.Security;

namespace Fraud.Pages.Admin.Roles
{
    [PermissionChecker(14)]
    public class EditRoleModel : PageModel
    {
        private IPermissionService _permissionService;
        public EditRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permissionService.GetRoleById(id);
            ViewData["Permissions"] = _permissionService.GetAllPermission();


            ViewData["SelectedPermissions"] = _permissionService.permissionsRole(id);
           
        }


        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _permissionService.UpdateRole(Role);
            _permissionService.UpdatePermissions(Role.RoleId, SelectedPermission);
            return RedirectToPage("Index");
        }
    }
}
