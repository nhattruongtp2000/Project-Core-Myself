#pragma checksum "D:\Visual project\Iden2\Web\Views\Products\GetProductPerCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2732146d4aaff7ebfbb46dcd88feb1ae1d03e467"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_GetProductPerCategory), @"mvc.1.0.view", @"/Views/Products/GetProductPerCategory.cshtml")]
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
#line 1 "D:\Visual project\Iden2\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Visual project\Iden2\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2732146d4aaff7ebfbb46dcd88feb1ae1d03e467", @"/Views/Products/GetProductPerCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_GetProductPerCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViewModel.ViewModels.ProductVm>>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<!--\r\n    ustora by freshdesignweb.com\r\n    Twitter: https://twitter.com/freshdesignweb\r\n    URL: https://www.freshdesignweb.com/ustora/\r\n-->\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2732146d4aaff7ebfbb46dcd88feb1ae1d03e4673451", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <title>Shop Page- Ustora Demo</title>

    <!-- Google Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Titillium+Web:400,200,300,700,600' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Roboto+Condensed:400,700,300' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Raleway:400,100' rel='stylesheet' type='text/css'>

    <!-- Bootstrap -->
    <link rel=""stylesheet"" href=""css/bootstrap.min.css"">

    <!-- Font Awesome -->
    <link rel=""stylesheet"" href=""css/font-awesome.min.css"">

    <!-- Custom CSS -->
    <link rel=""stylesheet"" href=""/css/owl.carousel.css"">
    <link rel=""stylesheet"" href=""/style.css"">
    <link rel=""stylesheet"" href=""/css/responsive.css"">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements a");
                WriteLiteral(@"nd media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src=""https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js""></script>
      <script src=""https://oss.maxcdn.com/respond/1.4.2/respond.min.js""></script>
    <![endif]-->
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2732146d4aaff7ebfbb46dcd88feb1ae1d03e4675821", async() => {
                WriteLiteral(@"

 



    <div class=""product-big-title-area"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""product-bit-title text-center"">
                        <h2>Shop</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class=""single-product-area"">
        <div class=""zigzag-bottom""></div>
        <div class=""container"">
            <div class=""row"">
                <!---->
");
#nullable restore
#line 64 "D:\Visual project\Iden2\Web\Views\Products\GetProductPerCategory.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"col-md-3 col-sm-6\">\r\n                        <div class=\"single-shop-product\">\r\n                            <div class=\"product-upper\">\r\n                                <img");
                BeginWriteAttribute("src", " src=\"", 2401, "\"", 2447, 2);
                WriteAttributeValue("", 2407, "https://localhost:5001\\", 2407, 23, true);
#nullable restore
#line 69 "D:\Visual project\Iden2\Web\Views\Products\GetProductPerCategory.cshtml"
WriteAttributeValue("", 2430, item.PhotoReview, 2430, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 2448, "\"", 2454, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </div>\r\n                            <h2><a");
                BeginWriteAttribute("href", " href=\"", 2528, "\"", 2535, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 71 "D:\Visual project\Iden2\Web\Views\Products\GetProductPerCategory.cshtml"
                                      Write(item.IdProduct);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></h2>\r\n                            <div class=\"product-carousel-price\">\r\n                                <ins>");
#nullable restore
#line 73 "D:\Visual project\Iden2\Web\Views\Products\GetProductPerCategory.cshtml"
                                Write(item.IdCategory);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</ins> <del>$999.00</del>
                            </div>

                            <div class=""product-option-shop"">
                                <a class=""add_to_cart_button"" data-quantity=""1"" data-product_sku="""" data-product_id=""70"" rel=""nofollow"" href=""/canvas/shop/?add-to-cart=70"">Add to cart</a>
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 81 "D:\Visual project\Iden2\Web\Views\Products\GetProductPerCategory.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"


            </div>


            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""product-pagination text-center"">
                        <nav>
                            <ul class=""pagination"">
                                <li>
                                    <a href=""#"" aria-label=""Previous"">
                                        <span aria-hidden=""true"">&laquo;</span>
                                    </a>
                                </li>
                                <li><a href=""#"">1</a></li>
                                <li><a href=""#"">2</a></li>
                                <li><a href=""#"">3</a></li>
                                <li><a href=""#"">4</a></li>
                                <li><a href=""#"">5</a></li>
                                <li>
                                    <a href=""#"" aria-label=""Next"">
                                        <span aria-hidden=""true"">&raquo;</span>
             ");
                WriteLiteral(@"                       </a>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>


   

    <!-- Latest jQuery form server -->
    <script src=""https://code.jquery.com/jquery.min.js""></script>

    <!-- Bootstrap JS form CDN -->
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js""></script>

    <!-- jQuery sticky menu -->
    <script src=""/js/owl.carousel.min.js""></script>
    <script src=""/js/jquery.sticky.js""></script>

    <!-- jQuery easing -->
    <script src=""/js/jquery.easing.1.3.min.js""></script>

    <!-- Main Script -->
    <script src=""/js/main.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ViewModel.ViewModels.ProductVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
