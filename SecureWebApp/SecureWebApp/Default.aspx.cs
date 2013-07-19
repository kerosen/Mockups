using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //[PrincipalPermission(SecurityAction.Demand, Name="aa")]
        protected void testRoleBtn_Click(object sender, EventArgs e)
        {
            var aPermission = new PrincipalPermission("a", null);
            var bPermission = new PrincipalPermission("b", null);
            aPermission.Union(bPermission).Demand();
            //permission.Demand();
        }

        protected void createRolesButton_Click(object sender, EventArgs e)
        {
            SecurityManager.CreateRoles();
        }

        protected void testIOButton_Click(object sender, EventArgs e)
        {
            FileIOPermission fileIOPermission =  new FileIOPermission(PermissionState.Unrestricted);
            fileIOPermission.Demand();
            Response.Redirect("~/HtmlPage1.html");
        }        
    }
}