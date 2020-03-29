using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Links
{
    public static partial class Bundles
    {
        public static partial class Scripts
        {
            public static readonly string jquery = "~/bundles/jquery";
            public static readonly string jqueryval = "~/bundles/jqueryval";
            public static readonly string modernizr = "~/bundles/modernizr";
            public static readonly string bootstrap = "~/bundles/bootstrap";

            public static readonly string lib = "~/bundles/lib";
        }
        public static partial class Styles
        {
            public static readonly string contentCss = "~/Content/css";
        }
    }
}