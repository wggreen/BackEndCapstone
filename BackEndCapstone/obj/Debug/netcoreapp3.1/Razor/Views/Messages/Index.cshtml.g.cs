#pragma checksum "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70eb6dbaa70a6b126ae8e3d6c2328fd3e6de9042"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Messages_Index), @"mvc.1.0.view", @"/Views/Messages/Index.cshtml")]
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
#nullable restore
#line 2 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70eb6dbaa70a6b126ae8e3d6c2328fd3e6de9042", @"/Views/Messages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2feacc088a3409d5e84c509ff993e91017d9183", @"/Views/_ViewImports.cshtml")]
    public class Views_Messages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BackEndCapstone.Models.Messages>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Messages.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .messages {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        justify-content: space-evenly;
    }

    .hidden {
        display: none;
    }

    .card {
        padding-bottom: 10px;
    }

    .card-body {
        display: flex;
        flex-direction: column;
    }
</style>

<section class=""messages"">
    <section class=""recievedMessages"">
        <h2>Inbox</h2>
        <div class=""row"">
            <div class=""col-sm-6"">
");
#nullable restore
#line 37 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                 foreach (var item in Model)
                {
                    if (item.RecipientId == UserManager.GetUserAsync(User).Result.Id)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card border-primary mb-3\" style=\"max-width: 20rem; min-width: 20rem; min-height: 10rem; max-height: 30rem;\">\r\n                            <div class=\"card-body\">\r\n                                <h5 class=\"card-title\">");
#nullable restore
#line 43 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                                                  Write(item.Sender.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 class=\"card-subtitle\">");
#nullable restore
#line 44 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                                                     Write(item.Timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <p class=\"card-text\">Dates: ");
#nullable restore
#line 45 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                                                       Write(item.Dates);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p class=\"card-text\">");
#nullable restore
#line 46 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                                                Write(item.MessageText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <button id=\"messageReply\">Reply</button>\r\n                            </div>\r\n                        </div>\r\n                        <input id=\"senderId\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1631, "\"", 1680, 1);
#nullable restore
#line 50 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
WriteAttributeValue("", 1639, UserManager.GetUserAsync(User).Result.Id, 1639, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n                        <input id=\"recipientId\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1746, "\"", 1769, 1);
#nullable restore
#line 51 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
WriteAttributeValue("", 1754, item.Sender.Id, 1754, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <input id=\"messageDates\" type=\"hidden\"");
            BeginWriteAttribute("value", " value=", 1837, "", 1855, 1);
#nullable restore
#line 52 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
WriteAttributeValue("", 1844, item.Dates, 1844, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n");
#nullable restore
#line 53 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </section>\r\n\r\n    <section class=\"sentMessages\">\r\n        <h2>Sent</h2>\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-6\">\r\n");
#nullable restore
#line 63 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                 foreach (var item in Model)
                {
                    if (item.SenderId == UserManager.GetUserAsync(User).Result.Id)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card border-primary mb-3\" style=\"max-width: 20rem; min-width: 20rem; min-height: 10rem; max-height: 10rem;\">\r\n                            <div class=\"card-body\">\r\n                                <h5 class=\"card-title\">");
#nullable restore
#line 69 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                                                  Write(item.Recipient.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 class=\"card-subtitle\">");
#nullable restore
#line 70 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                                                     Write(item.Timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <p class=\"card-text\">Dates: ");
#nullable restore
#line 71 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                                                       Write(item.Dates);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p class=\"card-text\">");
#nullable restore
#line 72 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                                                Write(item.MessageText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 75 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Messages\Index.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </section>\r\n</section>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70eb6dbaa70a6b126ae8e3d6c2328fd3e6de904210711", async() => {
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
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BackEndCapstone.Models.Messages>> Html { get; private set; }
    }
}
#pragma warning restore 1591
