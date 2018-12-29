using MyDoktor.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDoktor.WebApp.Filters
{
    
        public class AuthAdminOrDoctor : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                if (CurrentSession.User != null )
                {
                    if (CurrentSession.User.IsAdmin == false && CurrentSession.User.IsDoctor == false)
                    {
                    filterContext.Result = new RedirectResult("/Home/AccessDenied");
                    }
                }
            }
        }
    
}