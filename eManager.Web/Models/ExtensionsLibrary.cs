using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Models
{
    public static class ExtensionsLibrary
    {
        public static string Test(this Event e)
        {
            return "testing..";
        }
    }
}