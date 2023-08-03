using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace MVC_Model
{
    public static class CustomHelper
    {
        public static IHtmlString Image(string src,string alt)
        {
            return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}'></img>",src,alt));
        }
    }
}