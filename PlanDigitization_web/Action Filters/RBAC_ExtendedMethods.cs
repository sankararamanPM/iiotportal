using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

//Get requesting user's roles/permissions from database tables...      
public static class RBAC_ExtendedMethods
{
    public static bool HasRole(this ControllerBase controller, string role)
    {
        bool bFound = false;
        try
        {
            //Check if the requesting user has the specified role...
            bFound = new RBACUser(controller.ControllerContext.HttpContext.Request.LogonUserIdentity.Name).HasRole(role);            
        }
        catch { }
        return bFound;
    }

    public static bool HasRoles(this ControllerBase controller, string roles)
    {
        bool bFound = false;
        try
        {
            //Check if the requesting user has any of the specified roles...
            //Make sure you separate the roles using ; (ie "Sales Manager;Sales Operator"
            bFound = new RBACUser(controller.ControllerContext.HttpContext.Request.LogonUserIdentity.Name).HasRoles(roles);
        }
        catch { }
        return bFound;
    }

    public static bool HasPermission(this ControllerBase controller, string permission)
    {
        bool bFound = false;
        try
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserID"];
            //Check if the requesting user has the specified application permission...
            bFound = new RBACUser(cookie.Value).HasPermission(permission);
        }
        catch(Exception ex) { }
        return bFound;
    }

    public static bool IsSuperAdmin(this ControllerBase controller)
    {        
        bool IsSuperAdmin = false;
        try
        {
            //Check if the requesting user has the System Administrator privilege...
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserID"];
            IsSuperAdmin = new RBACUser(cookie.Value).IsSuperAdmin;
        }
        catch { }
        return IsSuperAdmin;
    }

    public static bool IsAdmin(this ControllerBase controller)
    {
        bool bIsAdmin = false;
        try
        {
            //Check if the requesting user has the System Administrator privilege...
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserID"];
            bIsAdmin = new RBACUser(cookie.Value).IsAdmin;
        }
        catch { }
        return bIsAdmin;
    }
}
