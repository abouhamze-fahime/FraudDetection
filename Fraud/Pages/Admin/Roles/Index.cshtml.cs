using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fraud.Services;
using Fraud.Entities.Acount;
using Fraud.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fraud.Security;

namespace Fraud.Pages.Admin.Roles

{
    [PermissionChecker(12)]
    public class IndexModel : PageModel
    {
        private IPermissionService _permissionService;
        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public List<Role> RoleList { get; set; }
        public void OnGet()
        {
            RoleList = _permissionService.GetRoles();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("Index");
        }

     
    }
}
