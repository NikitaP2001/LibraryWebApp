#pragma checksum "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "188a45721a21ffc3d912722a842ab74044c5d9f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Details), @"mvc.1.0.view", @"/Views/Books/Details.cshtml")]
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
#line 1 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\_ViewImports.cshtml"
using LibraryWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\_ViewImports.cshtml"
using LibraryWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"188a45721a21ffc3d912722a842ab74044c5d9f8", @"/Views/Books/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90e93c59d968b59b56c26f21090a31cb846cc108", @"/Views/_ViewImports.cshtml")]
    public class Views_Books_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LibraryWebApp.Book>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Comments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
  
    ViewData["Title"] = "Детально";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Детально про книгу ");
#nullable restore
#line 7 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                  Write(ViewBag.BookName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<p>\r\n    <div>\r\n        ");
#nullable restore
#line 10 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
   Write(Html.ActionLink("Видання", "Index", "Publisheds", new { id = ViewBag.BookId, name = ViewBag.BookName }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 13 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
   Write(Html.ActionLink("Автори", "Index", "Wrotes", new { id = ViewBag.BookId, name = ViewBag.bookName }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 16 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
   Write(Html.ActionLink("Теги", "Index", "Descriptions", new { id = ViewBag.BookId, name = ViewBag.bookName }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</p>\r\n");
#nullable restore
#line 19 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <hr />\r\n        <dl class=\"row\">\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 25 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
           Write(Html.DisplayNameFor(model => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 28 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
           Write(Html.DisplayFor(model => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 31 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
           Write(Html.DisplayNameFor(model => item.YearWritten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 34 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
           Write(Html.DisplayFor(model => item.YearWritten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 37 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
           Write(Html.DisplayNameFor(model => item.Isbn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 40 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
           Write(Html.DisplayFor(model => item.Isbn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 43 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
           Write(Html.DisplayNameFor(model => item.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 46 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
           Write(Html.DisplayFor(model => item.Genre.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "188a45721a21ffc3d912722a842ab74044c5d9f88915", async() => {
                WriteLiteral("Редагувати");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "188a45721a21ffc3d912722a842ab74044c5d9f811074", async() => {
                WriteLiteral("Назад до списку");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 54 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Перші 10 коментарів</h4>\r\n");
#nullable restore
#line 58 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
     foreach (var comment in item.Comments.Take(10))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <table>\r\n                <tr>\r\n                    <td>\r\n                        <div class=\"ava-column bl-img\">\r\n");
#nullable restore
#line 65 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                             if (comment.Reader.img == null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span style=\"display: block; width: 64px; height: 64px; background: #ccc);\"></span>\r\n");
#nullable restore
#line 68 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img style=\'width:80px; height:60px;\'");
            BeginWriteAttribute("src", " src=\"", 2365, "\"", 2390, 1);
#nullable restore
#line 71 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
WriteAttributeValue("", 2371, comment.Reader.img, 2371, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 72 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                             }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                    </td>\r\n                    <td class=\"right-td\">\r\n                        <div class=\"comment-entry\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 78 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                           Write(Html.ActionLink(comment.Reader.Login, "Details", "Readers", new { id = comment.ReaderId, BookId = ViewBag.BookId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <span>");
#nullable restore
#line 79 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                                 Write(comment.DateWritten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </p>\r\n                            <p>\r\n                                ");
#nullable restore
#line 82 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                           Write(comment.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n            <div></div>\r\n        </div>\r\n");
#nullable restore
#line 90 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 94 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "188a45721a21ffc3d912722a842ab74044c5d9f816504", async() => {
                WriteLiteral("\r\n    <input type=\"submit\" value=\"Всі коментарі\" class=\"btn-info\" /> \r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 99 "C:\Users\Nikita\source\repos\LibraryWebApp\LibraryWebApp\Views\Books\Details.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LibraryWebApp.Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591
