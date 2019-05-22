#pragma checksum "/Users/Guest/Desktop/TakeAHike/TakeAHike/Views/Trails/New.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57590b1f8c42f81bdb0132f29f33f166bb4a12d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trails_New), @"mvc.1.0.view", @"/Views/Trails/New.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Trails/New.cshtml", typeof(AspNetCore.Views_Trails_New))]
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
#line 4 "/Users/Guest/Desktop/TakeAHike/TakeAHike/Views/Trails/New.cshtml"
using TakeAHike.Models;

#line default
#line hidden
#line 5 "/Users/Guest/Desktop/TakeAHike/TakeAHike/Views/Trails/New.cshtml"
using TakeAHike;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57590b1f8c42f81bdb0132f29f33f166bb4a12d3", @"/Views/Trails/New.cshtml")]
    public class Views_Trails_New : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/Guest/Desktop/TakeAHike/TakeAHike/Views/Trails/New.cshtml"
  
  Layout = "_Layout";

#line default
#line hidden
            BeginContext(70, 2245, true);
            WriteLiteral(@"
<div class=""container"">
  <div class=""box"">
  <div class=""title-bar"">
    <h4>Find a Trail</h4>
  </div>


  <form action=""/trails/create"" method=""post"">
    <div class=""form-group"">
      <label for=""name"">Trail Name: </label>
      <input class=""form-control"" type=""text"" name=""name"" required>
    </div>
    <div class=""form-group"">
      <label for=""difficulty"">Trail Difficulty: </label>
      <select class=""form-control"" name=""difficulty"" required>
        <option value=""1"">Level 1</option>
        <option value=""2"">Level 2</option>
        <option value=""3"">Level 3</option>
        <option value=""4"">Level 4</option>
        <option value=""5"">Level 5</option>
      </select>
    </div>
    <div>
      <label for=""distance"">Distance (in miles): </label>
      <input class=""form-control"" type=""float"" name=""distance"" required>
    </div>
    <div>
      <label for=""waterfalls"">Waterfalls: </label>
      <select class=""form-control"" name=""waterfalls"" required>
        <option value=""1"">Yes</option>
        <o");
            WriteLiteral(@"ption value=""0"">No</option>
      </select>
    </div>
    <div>
      <label for=""summits"">View Points</label>
      <select class=""form-control"" name=""summits"" required>
        <option value=""1"">Summit Only</option>
        <option value=""2"">Two View Points</option>
        <option value=""3"">Three or more View Points</option>
      </select>
    </div>
    <div class=""form-group"">
      <h5>Wildlife/Scenery (select all that apply): </h5>
        <input type=""checkbox"" name=""streams"" value=""true"">
        <label for=""streams"">Streams/Rivers</label>
        <input type=""checkbox"" name=""mountainViews"" value=""true"">
        <label for=""mountainViews"">Mountain Views</label>
        <input type=""checkbox"" name=""meadows"" value=""true"">
        <label for=""meadows"">Meadows</label>
        <input type=""checkbox"" name=""lakes"" value=""true"">
        <label for=""lakes"">Lakes</label>
    </div>
    <div class=""form-group"">
      <label for=""dogs"">Dogs Allowed?</label>
      <select class=""form-control"" name=""dogs"">
     ");
            WriteLiteral("   <option value=\"true\">Yes</option>\n        <option value=\"false\">No</option>\n      </select>\n    </div>\n    <button type=\"submit\" class=\"btn btn-info\">Add Trail</button>\n\n  </form>\n</div>\n</div>\n");
            EndContext();
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
