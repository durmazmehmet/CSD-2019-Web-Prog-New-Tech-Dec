#pragma checksum "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b5026dfe4ca3536f89bbe7fdcea8aaef4e2ec9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\_ViewImports.cshtml"
using CSD.CarInfoApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\_ViewImports.cshtml"
using static CSD.CarInfoApp.Globals.Global;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\_ViewImports.cshtml"
using static CSD.CarInfoApp.Globals.HomeControllerView;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b5026dfe4ca3536f89bbe7fdcea8aaef4e2ec9f", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6df806234a39c508857732d0b877ed0494820769", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSD.CarInfoApp.Models.CarInfo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>CarInfo</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Brand));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayFor(model => model.Brand));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayFor(model => model.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EngineId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
       Write(Html.DisplayFor(model => model.EngineId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 46 "E:\Developer\CSD\WebProgNewTech-Dec-2019\src\DotnetCore\ASPDotnet\M01-CarInfoApp\CarInfoApp\Views\Home\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new {  id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b5026dfe4ca3536f89bbe7fdcea8aaef4e2ec9f8064", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSD.CarInfoApp.Models.CarInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591