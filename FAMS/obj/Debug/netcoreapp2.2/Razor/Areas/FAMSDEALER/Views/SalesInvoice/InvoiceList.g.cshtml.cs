#pragma checksum "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4c52751fce80ed99714dd3b40bd6024986d0115"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_FAMSDEALER_Views_SalesInvoice_InvoiceList), @"mvc.1.0.view", @"/Areas/FAMSDEALER/Views/SalesInvoice/InvoiceList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/FAMSDEALER/Views/SalesInvoice/InvoiceList.cshtml", typeof(AspNetCore.Areas_FAMSDEALER_Views_SalesInvoice_InvoiceList))]
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
#line 1 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\_ViewImports.cshtml"
using FADMS;

#line default
#line hidden
#line 2 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\_ViewImports.cshtml"
using FADMS.Models;

#line default
#line hidden
#line 3 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\_ViewImports.cshtml"
using FADMS.Areas.FAMSDEALER;

#line default
#line hidden
#line 7 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4c52751fce80ed99714dd3b40bd6024986d0115", @"/Areas/FAMSDEALER/Views/SalesInvoice/InvoiceList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d6da59ad1f56a285e9f316e27282c43cacd5d73", @"/Areas/FAMSDEALER/Views/_ViewImports.cshtml")]
    public class Areas_FAMSDEALER_Views_SalesInvoice_InvoiceList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FADMS.Areas.FAMSDEALER.Models.SalesInvoiceViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
  
    ViewData["Title"] = "InvoiceList";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(240, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Style", async() => {
                BeginContext(257, 164, true);
                WriteLiteral("\r\n    <style>\r\n        .redStar {\r\n            color: red;\r\n        }\r\n\r\n        #tblInvoiceList tbody tr {\r\n            cursor: pointer;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(424, 2051, true);
            WriteLiteral(@"
    <div class=""col-12"">
        <div class=""card"" style=""width: 100%;"">
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-9"">
                        <h5 class=""card-title"" style=""color: black"">বিক্রয় চালানের তালিকা </h5>
                    </div>
                    <div class=""col-2"">
                        <a href=""/FAMSDEALER/SalesInvoice/DealerSales?id=0"" style=""background-color:#024972;float:right;"" class=""btn btn-info btn-sm mr-0"">নতুন যোগ করুন </a>
                    </div>
                    <div class=""col-1"">
                        <a class='btn btn-outline-info btn-sm mb-0' style="""" data-toggle='tooltip' title='Go Back' href=""javascript: history.go(-1)""><i class=""fas fa-backward""></i></a>
                    </div>
                </div>
                <hr>
                <div class=""container"">
                    <div class=""row"">
                        <input type=""hidden"" id=""rowCount"" name=""rowCount"" value=""0""");
            WriteLiteral(@" />
                        <div class=""col-12"">
                            <table class=""table table-bordered table-striped""  id=""tblInvoiceList"" data-parsley-required=""true"">
                                <thead style=""width:100%;"">
                                    <tr>
                                        <th>সিরিয়াল নং </th>
                                        <th>চালান নং </th>
                                        <th>আগ্নেয়াস্ত্রের নাম</th>
                                        <th>চালানের তারিখ</th>
                                        <th>লাইসেন্স নাম্বার</th>
                                        <th>মোট </th>
                                        <th>ভ্যাট</th>
                                        <th>ট্যাক্স </th>
                                        <th> সর্বমোট </th>
                                        <th>সম্পাদনা করুন </th>
                                    </tr>
                                </thead>
                                <tbody");
            WriteLiteral(">\r\n");
            EndContext();
#line 57 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                      

                                        int i = 1;

                                        

#line default
#line hidden
#line 61 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                         foreach (var item in Model.salesInvoiceMastersDetails)
                                        {


#line default
#line hidden
            BeginContext(2713, 113, true);
            WriteLiteral("                                            <tr>\r\n                                                <td width=\"2%\">");
            EndContext();
            BeginContext(2827, 1, false);
#line 65 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                          Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(2828, 99, true);
            WriteLiteral("</td>\r\n                                                <td width=\"25%\"><span style=\"display:none\">-");
            EndContext();
            BeginContext(2928, 7, false);
#line 66 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                                                       Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2935, 8, true);
            WriteLiteral("-</span>");
            EndContext();
            BeginContext(2944, 38, false);
#line 66 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                                                                       Write(item.salesInvoiceMaster?.invoiceNumber);

#line default
#line hidden
            EndContext();
            BeginContext(2982, 70, true);
            WriteLiteral("</td>\r\n                                                <td width=\"2%\">");
            EndContext();
            BeginContext(3053, 38, false);
#line 67 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                          Write(item.itemSpecification?.Item?.itemName);

#line default
#line hidden
            EndContext();
            BeginContext(3091, 71, true);
            WriteLiteral("</td>\r\n                                                <td width=\"10%\">");
            EndContext();
            BeginContext(3163, 60, false);
#line 68 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                           Write(item.salesInvoiceMaster?.invoiceDate?.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(3223, 71, true);
            WriteLiteral("</td>\r\n                                                <td width=\"13%\">");
            EndContext();
            BeginContext(3295, 51, false);
#line 69 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                           Write(item.salesInvoiceMaster?.licenseInfo?.licenseNumber);

#line default
#line hidden
            EndContext();
            BeginContext(3346, 96, true);
            WriteLiteral("</td>\r\n                                                <td width=\"10%\" style=\"text-align:right\">");
            EndContext();
            BeginContext(3443, 56, false);
#line 70 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                                                    Write(item.salesInvoiceMaster?.totalAmount?.ToString("0,0.00"));

#line default
#line hidden
            EndContext();
            BeginContext(3499, 95, true);
            WriteLiteral("</td>\r\n                                                <td width=\"8%\" style=\"text-align:right\">");
            EndContext();
            BeginContext(3595, 55, false);
#line 71 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                                                   Write(item.salesInvoiceMaster?.VATOnTotal?.ToString("0,0.00"));

#line default
#line hidden
            EndContext();
            BeginContext(3650, 95, true);
            WriteLiteral("</td>\r\n                                                <td width=\"8%\" style=\"text-align:right\">");
            EndContext();
            BeginContext(3746, 55, false);
#line 72 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                                                   Write(item.salesInvoiceMaster?.TAXOnTotal?.ToString("0,0.00"));

#line default
#line hidden
            EndContext();
            BeginContext(3801, 96, true);
            WriteLiteral("</td>\r\n                                                <td width=\"10%\" style=\"text-align:right\">");
            EndContext();
            BeginContext(3898, 53, false);
#line 73 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                                                                    Write(item.salesInvoiceMaster?.NetTotal?.ToString("0,0.00"));

#line default
#line hidden
            EndContext();
            BeginContext(3951, 148, true);
            WriteLiteral("</td>\r\n                                                <td width=\"15%\">\r\n                                                    <a class=\"btn btn-info\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4099, "\"", 4174, 2);
            WriteAttributeValue("", 4106, "/FAMSDEALER/SalesInvoice/DealerSales?id=", 4106, 40, true);
#line 75 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
WriteAttributeValue("", 4146, item.salesInvoiceMaster?.Id, 4146, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4175, 133, true);
            WriteLiteral(" title=\"Invoice Edit\" ><i class=\"fa fa-edit\"></i></a>\r\n                                                    <a class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4308, "\"", 4386, 2);
            WriteAttributeValue("", 4315, "/FAMSDEALER/SalesInvoice/InvoiceDetails?id=", 4315, 43, true);
#line 76 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
WriteAttributeValue("", 4358, item.salesInvoiceMaster?.Id, 4358, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4387, 151, true);
            WriteLiteral(" target=\"_blank\" title=\"Details\"><i class=\"fas fa-info-circle\"></i></a>\r\n                                                    <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4538, "\"", 4618, 2);
            WriteAttributeValue("", 4545, "/FAMSDEALER/SalesInvoice/InvoicePDFAction?id=", 4545, 45, true);
#line 77 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
WriteAttributeValue("", 4590, item.salesInvoiceMaster?.Id, 4590, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4619, 171, true);
            WriteLiteral(" target=\"_blank\" title=\"Report\"><i class=\"fa fa-print\"></i></a>\r\n                                                </td>\r\n                                            </tr>\r\n");
            EndContext();
#line 80 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\SalesInvoice\InvoiceList.cshtml"
                                            i++;
                                        }

#line default
#line hidden
            BeginContext(4922, 214, true);
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5153, 758, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#tblInvoiceList').DataTable();
            var table = $('#tblInvoiceList').DataTable();

            $('#tblInvoiceList tbody').on('click', 'tr', function () {
                var data = table.row(this).data();
                var iddata = data[1];
                let id = iddata.replace('<span style=""display:none"">', """").replace(""</span>"", """");
                var vid = parseInt(id.split('-')[1]);
                window.location.href = ""/Sales/SalesInvoice/InvoiceDetails/?id="" + vid;
            });
            $('#tblInvoiceList tbody').on('click', 'td:last-child', function (e) {
                e.stopPropagation();
            });
        });

    </script>
");
                EndContext();
            }
            );
            BeginContext(5914, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FADMS.Areas.FAMSDEALER.Models.SalesInvoiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
