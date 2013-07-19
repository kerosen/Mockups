using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureWebApp
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var identity = HttpContext.Current.User.Identity;
            var aPermission = new PrincipalPermission("a", "Manager");
            aPermission.Demand();
        }
    }
}