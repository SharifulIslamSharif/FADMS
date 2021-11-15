#pragma checksum "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c0d22e1370557c4f37340c41a7f9027b7b3a9c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_FAMSDEALER_Views_Dealer_DealerList), @"mvc.1.0.view", @"/Areas/FAMSDEALER/Views/Dealer/DealerList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/FAMSDEALER/Views/Dealer/DealerList.cshtml", typeof(AspNetCore.Areas_FAMSDEALER_Views_Dealer_DealerList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c0d22e1370557c4f37340c41a7f9027b7b3a9c5", @"/Areas/FAMSDEALER/Views/Dealer/DealerList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d6da59ad1f56a285e9f316e27282c43cacd5d73", @"/Areas/FAMSDEALER/Views/_ViewImports.cshtml")]
    public class Areas_FAMSDEALER_Views_Dealer_DealerList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FADMS.Areas.FAMSDEALER.Models.DealerViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
  
    ViewData["Title"] = "DealerList";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(147, 1023, true);
            WriteLiteral(@"
<div class=""col-12"" style=""width:98%"">
    <div class=""row clearfix"">
        <div class=""col-12"">
            <div class=""card mb-4"">
                <!-- Card Header - Dropdown -->
                <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
                    <h5 class=""m-0 font-weight-bold"">ডিলার তথ্য তালিকা</h5>
                    <a href=""/FAMSDEALER/Dealer/AddDealer"" class=""btn btn-info btn-sm pull-right"" style=""background-color:#024972;"">নতুন যুক্ত করুন</a>
                </div>
                <!-- Card Body -->


                <div class=""card-body"">
                    <table class=""table table-striped table-bordered table-sm"" id=""educationalTable"">
                        <thead>
                            <tr>
                                <th>ক্রমিক নং</th>
                                <th>ডিলারের নাম</th>
                                <th>লাইসেন্স নম্বর</th>
                                <th>যোগাযোগের নম্বর</th>
");
            EndContext();
            BeginContext(1228, 155, true);
            WriteLiteral("                                <th>প্রক্রিয়া</th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
            EndContext();
#line 32 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
                              
                                var i = 1;
                                

#line default
#line hidden
#line 34 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
                                 foreach (var item in Model.dealers.OrderByDescending(x=>x.Id))
                                {

#line default
#line hidden
            BeginContext(1591, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(1678, 1, false);
#line 37 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
                                       Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1679, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1731, 15, false);
#line 38 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
                                       Write(item.dealerName);

#line default
#line hidden
            EndContext();
            BeginContext(1746, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1798, 18, false);
#line 39 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
                                       Write(item.LicenseNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1816, 53, true);
            WriteLiteral("</td>\r\n\r\n                                        <td>");
            EndContext();
            BeginContext(1870, 11, false);
#line 41 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
                                       Write(item.mobile);

#line default
#line hidden
            EndContext();
            BeginContext(1881, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
            BeginContext(1975, 134, true);
            WriteLiteral("                                        <td>\r\n                                            <a class=\"btn btn-success\" title=\"Edit Data\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2109, "\"", 2157, 2);
            WriteAttributeValue("", 2116, "/FAMSDEALER/Dealer/DealerMenu?id=", 2116, 33, true);
#line 44 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
WriteAttributeValue("", 2149, item.Id, 2149, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2158, 135, true);
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>&nbsp;&nbsp;\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 47 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSDEALER\Views\Dealer\DealerList.cshtml"
                                    i++;
                                }

#line default
#line hidden
            BeginContext(2401, 150, true);
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2568, 662, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $(""#education"").addClass(""active"");
            $('#educationalTable').DataTable();
        });


        var table = $('#educationalTable').DataTable();
        //$('#educationalTable tbody').on('click', 'tr', function () {
        //    var data = table.row(this).data();
        //    var iddata = data[0];
        //    let id = iddata.replace('<span style=""display:none"">', """").replace(""</span>"", """");
        //    var vid = parseInt(id.split('-')[1]);
        //    window.location.href = ""/MasterData/Customer/CustomerDetails/?id="" + vid;
        //});


    </script>
");
                EndContext();
            }
            );
            BeginContext(3233, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Style", async() => {
                BeginContext(3250, 108, true);
                WriteLiteral("\r\n    <style>\r\n        #educationalTable tbody tr {\r\n            cursor: pointer;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(3361, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FADMS.Areas.FAMSDEALER.Models.DealerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
