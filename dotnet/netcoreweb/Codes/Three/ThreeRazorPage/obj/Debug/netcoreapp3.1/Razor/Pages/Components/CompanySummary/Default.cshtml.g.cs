#pragma checksum "D:\Work\WorkSpaces\Note\NetCoreWeb\NetCore\Codes\Three\ThreeRazorPage\Pages\Components\CompanySummary\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7a8c3e21c21e6ef10d03c5777e8e2ecfc6c7a5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ThreeRazorPage.Pages.Components.CompanySummary.Pages_Components_CompanySummary_Default), @"mvc.1.0.view", @"/Pages/Components/CompanySummary/Default.cshtml")]
namespace ThreeRazorPage.Pages.Components.CompanySummary
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
#line 1 "D:\Work\WorkSpaces\Note\NetCoreWeb\NetCore\Codes\Three\ThreeRazorPage\Pages\_ViewImports.cshtml"
using ThreeRazorPage;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7a8c3e21c21e6ef10d03c5777e8e2ecfc6c7a5b", @"/Pages/Components/CompanySummary/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e82337f2b7dfddaebeb290ec8565af709021ca5a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Components_CompanySummary_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ThreeRazorPage.Models.CompanySummary>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"small\">\r\n    <div class=\"row h3\">");
#nullable restore
#line 4 "D:\Work\WorkSpaces\Note\NetCoreWeb\NetCore\Codes\Three\ThreeRazorPage\Pages\Components\CompanySummary\Default.cshtml"
                   Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-8 h6\">员工总数:</div>\r\n        <div class=\"col-md-4 h6\">");
#nullable restore
#line 7 "D:\Work\WorkSpaces\Note\NetCoreWeb\NetCore\Codes\Three\ThreeRazorPage\Pages\Components\CompanySummary\Default.cshtml"
                            Write(Model.EmployeeCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-8 h6\">部门平均数:</div>\r\n        <div class=\"col-md-4 h6\">");
#nullable restore
#line 11 "D:\Work\WorkSpaces\Note\NetCoreWeb\NetCore\Codes\Three\ThreeRazorPage\Pages\Components\CompanySummary\Default.cshtml"
                            Write(Model.AverageDepartmentEmployeeCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ThreeRazorPage.Models.CompanySummary> Html { get; private set; }
    }
}
#pragma warning restore 1591