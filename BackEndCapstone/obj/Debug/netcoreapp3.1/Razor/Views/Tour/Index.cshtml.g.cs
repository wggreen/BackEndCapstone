#pragma checksum "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9ecae93acfb3d70a56b1c4b87a9e8be34e0531d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tour_Index), @"mvc.1.0.view", @"/Views/Tour/Index.cshtml")]
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
#line 1 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\_ViewImports.cshtml"
using BackEndCapstone;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\_ViewImports.cshtml"
using BackEndCapstone.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9ecae93acfb3d70a56b1c4b87a9e8be34e0531d", @"/Views/Tour/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2feacc088a3409d5e84c509ff993e91017d9183", @"/Views/_ViewImports.cshtml")]
    public class Views_Tour_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BackEndCapstone.Models.Tour>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Tours.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
  
    ViewData["Title"] = "Tours";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .tours {
        display: flex;
        flex-direction: row;
        margin-top: 30px;
    }

    .tourList {
        padding: 0;
        margin-bottom: 1px;
        margin-left: 25px;
    }

    .singleTour {
        margin-right: 50px;
        border: 1px solid black;
    }

    .tourItemName {
        text-decoration: underline;
    }

    img {
        max-width: 200px;
    }

    .singleTour {
        display: flex;
        flex-direction: column;
    }

    .tourListItem {
        margin-bottom: 30px;
    }

    .destinationHeader {
        display: flex;
        flex-direction: row;
    }

    .deleteDestination {
        margin-left: 10px;
    }

    .btn-group-xs > .btn, .btn-xs {
        padding: .25rem .4rem;
        font-size: .875rem;
        line-height: .5;
        border-radius: .2rem;
    }
</style>

<h1>Your Tours</h1>

<div class=""tours"">
");
#nullable restore
#line 62 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
     if (Model.Count() == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <p>You have no tours!</p>\r\n        </div>\r\n");
#nullable restore
#line 67 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"singleTour\">\r\n        <img src=\"..\\..\\images\\van.jpg\" />\r\n        <h2 class=\"tourItemName\">");
#nullable restore
#line 72 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
                            Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <ol class=\"tourList\">\r\n");
#nullable restore
#line 74 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
             foreach (var destination in item.Destinations)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li style=\"font-size: 1.25em !important \" class=\"tourListItem\">\r\n                    <div class=\"destinationHeader\">\r\n                        <h4>");
#nullable restore
#line 78 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
                       Write(destination.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <button");
            BeginWriteAttribute("id", " id=\"", 1634, "\"", 1665, 1);
#nullable restore
#line 79 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
WriteAttributeValue("", 1639, destination.DestinationId, 1639, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"deleteDestination btn btn-xs btn-light\" type=\"button\">Delete</button>\r\n                    </div>\r\n                    <div id=\"destinationInfo\" style=\"font-size: 0.80em !important\">\r\n                        <div>");
#nullable restore
#line 82 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
                        Write(destination.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 82 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
                                           Write(destination.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                </li>\r\n");
#nullable restore
#line 85 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ol>\r\n        ");
#nullable restore
#line 87 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
   Write(Html.ActionLink("Edit", "EditMap", new { id = item.TourId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button");
            BeginWriteAttribute("class", " class=\"", 2099, "\"", 2119, 1);
#nullable restore
#line 88 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
WriteAttributeValue("", 2107, item.TourId, 2107, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"deleteTour\">Delete tour</button>\r\n    </div>\r\n");
#nullable restore
#line 90 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Tour\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9ecae93acfb3d70a56b1c4b87a9e8be34e0531d8869", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BackEndCapstone.Models.Tour>> Html { get; private set; }
    }
}
#pragma warning restore 1591
