using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SecureWebApp
{
    public class SecurityManager
    {
        public static void CreateRoles()
        {
            Roles.CreateRole("manager");
            Roles.AddUserToRole("a", "manager");

            var users = Membership.GetAllUsers();
        }
    }
}