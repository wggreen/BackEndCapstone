#pragma checksum "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Address\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddb85bce1e8b783233d3a12be9ae869cdcbaa31a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Address_Index), @"mvc.1.0.view", @"/Views/Address/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddb85bce1e8b783233d3a12be9ae869cdcbaa31a", @"/Views/Address/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2feacc088a3409d5e84c509ff993e91017d9183", @"/Views/_ViewImports.cshtml")]
    public class Views_Address_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BackEndCapstone.Models.Address>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Address\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Index</h1>

<style>
    /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
    #map {
        height: 400px;
        width: 400px;
    }
</style>


<div class=""row"">
    <div id=""map""></div>
    <script>
        var map;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: 39.5, lng: -98.35 },
                zoom: 3
            });
");
#nullable restore
#line 28 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Address\Index.cshtml"
             foreach(var item in Model){
                 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    var marker = new google.maps.Marker({\r\n                      map: map,\r\n                      position: { lat: ");
#nullable restore
#line 32 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Address\Index.cshtml"
                                  Write(item.Lat);

#line default
#line hidden
#nullable disable
            WriteLiteral(", lng: ");
#nullable restore
#line 32 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Address\Index.cshtml"
                                                  Write(item.Lng);

#line default
#line hidden
#nullable disable
            WriteLiteral(" },\r\n                      title: \'");
#nullable restore
#line 33 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Address\Index.cshtml"
                         Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'\r\n                    });\r\n                ");
#nullable restore
#line 35 "C:\Users\William\workspace\BackEndCapstone\BackEndCapstone\Views\Address\Index.cshtml"
                       
}

#line default
#line hidden
#nullable disable
            WriteLiteral("        }\r\n    </script>\r\n    <script src=\"https://maps.googleapis.com/maps/api/js?key=AIzaSyBedz54CszWCt94vm9gZGAYJdQC5v487nI&callback=initMap\"\r\n            async defer></script>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BackEndCapstone.Models.Address>> Html { get; private set; }
    }
}
#pragma warning restore 1591
