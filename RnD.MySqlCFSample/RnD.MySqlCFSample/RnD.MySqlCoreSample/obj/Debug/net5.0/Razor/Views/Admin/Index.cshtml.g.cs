#pragma checksum "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "594db65f6f0b073e55cf70c34c686d57d88a2290"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\_ViewImports.cshtml"
using RnD.MySqlCoreSample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\_ViewImports.cshtml"
using RnD.MySqlCoreSample.EntityModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\_ViewImports.cshtml"
using RnD.MySqlCoreSample.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\_ViewImports.cshtml"
using RnD.MySqlCoreSample.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"594db65f6f0b073e55cf70c34c686d57d88a2290", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ee6253e5d8803fba817190d052cd5e56136d25b", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Student>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Admin Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-12\">\r\n        <div class=\"text-center\">\r\n            <h1 class=\"display-4\">Welcome</h1>\r\n            <p>MySql Core Web</p>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 16 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\Admin\Index.cshtml"
     if (Model.Any())
    {
        foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-4\">\r\n                ");
#nullable restore
#line 21 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\Admin\Index.cshtml"
           Write(item.StudentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-4\">\r\n                ");
#nullable restore
#line 24 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\Admin\Index.cshtml"
           Write(item.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-4\">\r\n                ");
#nullable restore
#line 27 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\Admin\Index.cshtml"
           Write(item.DateOfBirth.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 29 "C:\Users\placo\OneDrive\Documents\GitHub\asp.net-mvc-mysql-sample\RnD.MySqlCFSample\RnD.MySqlCFSample\RnD.MySqlCoreSample\Views\Admin\Index.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Student>> Html { get; private set; }
    }
}
#pragma warning restore 1591