#pragma checksum "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9b341ab686ba2e10297831f89f298399024ec87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Index), @"mvc.1.0.view", @"/Views/Orders/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9b341ab686ba2e10297831f89f298399024ec87", @"/Views/Orders/Index.cshtml")]
    public class Views_Orders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Orders.Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Client));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Client));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1174, "\"", 1206, 1);
#nullable restore
#line 46 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
WriteAttributeValue("", 1189, item.OrderNumber, 1189, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1259, "\"", 1291, 1);
#nullable restore
#line 47 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
WriteAttributeValue("", 1274, item.OrderNumber, 1274, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1346, "\"", 1378, 1);
#nullable restore
#line 48 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
WriteAttributeValue("", 1361, item.OrderNumber, 1361, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 51 "E:\C#\FileSearchEngine\WebApplication1\WebApplication1\Views\Orders\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Orders.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
