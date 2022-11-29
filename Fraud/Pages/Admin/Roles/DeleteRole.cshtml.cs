using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Fraud.Services;
using Fraud.Entities.Acount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fraud.Security;

namespace Fraud.Pages.Admin.Roles
{
    [PermissionChecker(15)]
    public class DeleteRoleModel : PageModel
    {
       private IPermissionService _permission;
        public DeleteRoleModel(IPermissionService permission)
        {
            _permission = permission;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permission.GetRoleById(id);
        }
        public IActionResult OnPost()
        {
            _permission.DeleteRole(Role);
            return RedirectToPage("Index");
        }
    }
}
