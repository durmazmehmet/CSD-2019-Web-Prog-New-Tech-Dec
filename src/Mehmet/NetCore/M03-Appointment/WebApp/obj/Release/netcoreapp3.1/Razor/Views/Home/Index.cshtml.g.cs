#pragma checksum "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M03-Appointment\WebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c8c7c9f46fd1f14e41fd5f566178a5a7f32a686"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 2 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M03-Appointment\WebApp\Views\_ViewImports.cshtml"
using CSD.AppointmentApp.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c8c7c9f46fd1f14e41fd5f566178a5a7f32a686", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0e051e95b56751efdf89fa3accea5a9afad3abe", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M03-Appointment\WebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "C ve Sistem Programcıları Derneği";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Appointment Project</h1>\r\n\r\n<h2>");
#nullable restore
#line 8 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M03-Appointment\WebApp\Views\Home\Index.cshtml"
Write(ViewBag.Today.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<div><a href=\"/Home/BookAppointment\">Create a new appointment</a></div>\r\n<div><a href=\"/Home/ListClients\">List of Clients</a></div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
