#pragma checksum "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSAPP\Views\DealerInfo\LicenseInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d19197ce63cb3351abfe61e5dbb2f76c7e2dfb39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_FAMSAPP_Views_DealerInfo_LicenseInfo), @"mvc.1.0.view", @"/Areas/FAMSAPP/Views/DealerInfo/LicenseInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/FAMSAPP/Views/DealerInfo/LicenseInfo.cshtml", typeof(AspNetCore.Areas_FAMSAPP_Views_DealerInfo_LicenseInfo))]
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
#line 1 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSAPP\Views\_ViewImports.cshtml"
using FADMS;

#line default
#line hidden
#line 2 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSAPP\Views\_ViewImports.cshtml"
using FADMS.Models;

#line default
#line hidden
#line 3 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSAPP\Views\_ViewImports.cshtml"
using FADMS.Areas.FAMSAPP.Models;

#line default
#line hidden
#line 4 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSAPP\Views\_ViewImports.cshtml"
using FADMS.DAL.Organization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d19197ce63cb3351abfe61e5dbb2f76c7e2dfb39", @"/Areas/FAMSAPP/Views/DealerInfo/LicenseInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5939f267d11820a70a3d3f8888a6bb9e1beb3e0", @"/Areas/FAMSAPP/Views/_ViewImports.cshtml")]
    public class Areas_FAMSAPP_Views_DealerInfo_LicenseInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "value", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "F:\ARIF\FAMS Dealer\Project\Fire_Arms_Dealer_Management_System\FAMS\Areas\FAMSAPP\Views\DealerInfo\LicenseInfo.cshtml"
  
    ViewData["Title"] = "LicenseInfo";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(96, 1554, true);
            WriteLiteral(@"
<style>
    .fas {
        margin-top: 10px;
        font-size: 25px;
    }

    .active {
        color: darkcyan;
    }
    .btn_color {
        background-color: #30994C;
        color: #fff !important;
    }

    .nav-link {
        padding: 5px 20px !important;
        border-radius: 5px !important;
    }
</style>

<div class=""container"">
    <div class=""row"">
        <div class=""col-md-12"">
            <nav class=""navbar navbar-expand-lg navbar-light bg-light"" style=""margin-left:0!important; padding-left:0!important"">

                <div class=""collapse navbar-collapse"" id=""navbarNav"" style=""padding:5px!important; margin-left:0!important;padding-left:0!important"">
                    <ul class=""navbar-nav"" id=""navlist"">

                        <li class=""nav-item  btn btn-sm"">
                            <a class=""nav-link btn_color active"" id=""countryInfo"" href=""/FAMSAPP/DealerInfo/DealerInfo"">Dealer Info</a>
                        </li>

                        <l");
            WriteLiteral(@"i class=""nav-item  btn btn-sm"">
                            <a class=""nav-link btn_color"" id=""divisionInfo"" href=""/FAMSAPP/DealerInfo/Address"">Address</a>
                        </li>

                        <li class=""nav-item  btn btn-sm"">
                            <a class=""nav-link btn_color"" id=""districtInfo"" href=""/FAMSAPP/DealerInfo/LicenseInfo"">License</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
        <div class=""col-md-12"">

");
            EndContext();
            BeginContext(2716, 1006, true);
            WriteLiteral(@"
            <div class=""card"" style=""width: 97%;margin:0!important;"">
                <div class=""card-header"">
                    <h5 class=""card-title"" style=""color: black"">Lience Info</h5>
                </div>
            </div>
            <div class=""card mt-1"" style=""width: 97%;padding:10px"">

                <div class=""card-body"">
                    <input type=""hidden"" name=""id"" id=""id"">
                    <div class=""row"">
                        <div class=""col-6"">
                            <div class=""form-group row"">
                                <label for=""armTypeId"" class=""col-sm-4 col-form-label"">License No.</label>
                                <div class=""col-sm-8"">
                                    <input type=""text"" class=""form-control"" id=""licenseNumber"" name=""licenseNumber"" data-parsley-required=""true"" />
                                </div>

                            </div>
                            <div class=""form-group row"">
");
            EndContext();
            BeginContext(3851, 451, true);
            WriteLiteral(@"                                <label for=""armTypeId"" class=""col-sm-4 col-form-label"">License Renue</label>
                                <div class=""col-sm-8"">
                                    <input type=""text"" class=""form-control"" id=""licenseRenew"" name=""licenseRenew"" data-parsley-required=""true"" />
                                </div>

                            </div>

                            <div class=""form-group row"">
");
            EndContext();
            BeginContext(4439, 451, true);
            WriteLiteral(@"                                <label for=""manufactureId"" class=""col-sm-4 col-form-label"">License Issue</label>
                                <div class=""col-sm-8"">
                                    <input type=""text"" class=""form-control"" id=""dateOfIssue"" name=""dateOfIssue"" data-parsley-required=""true"" />
                                </div>

                            </div>
                            <div class=""form-group row"">
");
            EndContext();
            BeginContext(5026, 340, true);
            WriteLiteral(@"                                <label for=""purchaseDate"" class=""col-sm-4 col-form-label"">License Type</label>
                                <div class=""col-sm-8"">
                                    <select class=""form-control"" id=""LicenseType"" name=""LicenseType"" data-parsley-required=""true"">
                                        ");
            EndContext();
            BeginContext(5366, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d19197ce63cb3351abfe61e5dbb2f76c7e2dfb398826", async() => {
                BeginContext(5388, 4, true);
                WriteLiteral("text");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5401, 738, true);
            WriteLiteral(@"
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class=""col-6"">
                            <div class=""form-group row"">
                                <label for=""purchaseDate"" class=""col-sm-4 col-form-label"">License Issue Authority</label>
                                <div class=""col-sm-8"">
                                    <input type=""number"" class=""form-control"" id=""licenseIssueAthority"" name=""licenseIssueAthority"" data-parsley-required=""true"" />
                                </div>
                            </div>
                            <div class=""form-group row"">
");
            EndContext();
            BeginContext(6266, 465, true);
            WriteLiteral(@"                                <label for=""armModelId"" class=""col-sm-4 col-form-label"">License Renue Year</label>
                                <div class=""col-sm-8"">
                                    <input type=""number"" class=""form-control"" id=""licenseRenewYear"" name=""licenseRenewYear"" data-parsley-required=""true"" />
                                </div>
                            </div>

                            <div class=""form-group row"">
");
            EndContext();
            BeginContext(6858, 1282, true);
            WriteLiteral(@"                                <label for=""quantity"" class=""col-sm-4 col-form-label""> License Expaire </label>
                                <div class=""col-sm-8"">
                                    <input type=""number"" class=""form-control"" id=""dateOfExpair"" name=""dateOfExpair"" data-parsley-required=""true"" />
                                </div>
                            </div>

                            <button class=""btn btn-success btn-sm btnWith mt-5"" type=""submit"" id=""btnAdd"" style=""float:right;""><i class=""fa fa-save""></i> Save</button>
                        </div>
                    </div>

                </div>
                <hr />
                <br />
                <div class=""col-12"">
                    <table id=""tblDealerInfo"" class=""table table-striped table-sm table-bordered"">
                        <thead>
                            <tr>
                                <th>Organaization Name</th>
                                <th>Mobile Office</th>
   ");
            WriteLiteral(@"                             <th>Owner Name</th>
                                <th>Persona Mobile</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
            BeginContext(8262, 651, true);
            WriteLiteral(@"                            <tr>
                                <td>NameOfOrganization</td>
                                <td>ArmTypeName</td>
                                <td>modelName</td>
                                <td>ManufactureName</td>

                                <td>
                                    <a href=""javascript:void(0)"" class=""btn btn-success"" onclick=""Edit()""><i class=""fa fa-edit""></i></a>
                                    <a href=""javascript:void(0)"" class=""btn btn-danger"" onclick=""Delete()""><i class=""fa fa-trash""></i></a>
                                </td>
                            </tr>
");
            EndContext();
            BeginContext(8948, 150, true);
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
