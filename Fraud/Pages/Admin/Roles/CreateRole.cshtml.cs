using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fraud.Services;
using Fraud.Entities.Acount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fraud.Security;

namespace Fraud.Pages.Admin.Roles
{
    [PermissionChecker(13)]
    public class CreateRoleModel : PageModel
    {
        private IPermissionService _permissionService;
        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet()
        {
            ViewData["Permissions"] = _permissionService.GetAllPermission();
        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Role.IsDelete = false;
            int roleId = _permissionService.AddRole(Role);
            _permissionService.AddPermissionsToRole(roleId, SelectedPermission);
            return RedirectToPage("Index");
        }

    }
}
