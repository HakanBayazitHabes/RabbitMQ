#pragma checksum "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a9a5cbae9094384bbb2935c57a62a9f48c0aebf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Files), @"mvc.1.0.view", @"/Views/Products/Files.cshtml")]
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
#line 1 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\_ViewImports.cshtml"
using RabbitMQWeb.ExcelCreate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\_ViewImports.cshtml"
using RabbitMQWeb.ExcelCreate.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a9a5cbae9094384bbb2935c57a62a9f48c0aebf", @"/Views/Products/Files.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7504ab609e4a87826331d156c04c64d991740fe", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Files : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<UserFile>>
    {
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
#nullable restore
#line 2 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
  
    ViewData["Title"] = "Files";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(" \r\n    <script>\r\n        $(document).ready(function () {\r\n            var hasStartCreatingExcel = \'");
#nullable restore
#line 10 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
                                    Write(TempData["StartCreatingExcel"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';

            if (hasStartCreatingExcel) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Excel oluşturma işlemi başlamıltır. Bittiğinde bildiri alacaksınız',
                    showConfirmButton: false,
                    timer:2500
                })
            }
        })
    </script>
");
            }
            );
            WriteLiteral("\r\n<h1>Files</h1>\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th>File Name</th>\r\n            <th>Created Date</th>\r\n            <th>File Status</th>\r\n            <th>Donwload</th>\r\n        </tr>\r\n    </thead>\r\n");
#nullable restore
#line 35 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
           Write(item.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 39 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
           Write(item.GetCreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 40 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
           Write(item.FileStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a9a5cbae9094384bbb2935c57a62a9f48c0aebf5864", async() => {
                WriteLiteral("Download");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1073, "~/files/", 1073, 8, true);
#nullable restore
#line 42 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
AddHtmlAttributeValue("", 1081, item.FilePath, 1081, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1104, "btn", 1104, 3, true);
            AddHtmlAttributeValue(" ", 1107, "btn-primary", 1108, 12, true);
#nullable restore
#line 42 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
AddHtmlAttributeValue(" ", 1119, item.FileStatus==FileStatus.Creating ? "disable":"", 1120, 54, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\user\Desktop\Software\Fatih Çakıroğlu Core\RabbitMQ\RabbitMQWeb.ExcelCreate\Views\Products\Files.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<UserFile>> Html { get; private set; }
    }
}
#pragma warning restore 1591
