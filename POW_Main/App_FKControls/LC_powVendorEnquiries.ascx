<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powVendorEnquiries.ascx.vb" Inherits="LC_powVendorEnquiries" %>
<asp:DropDownList 
  ID = "DDLpowVendorEnquiries"
  DataSourceID = "OdsDdlpowVendorEnquiries"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowVendorEnquiries"
  Runat = "server" 
  ControlToValidate = "DDLpowVendorEnquiries"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowVendorEnquiries"
  TypeName = "SIS.POW.powVendorEnquiries"
  SortParameterName = "OrderBy"
  SelectMethod = "powVendorEnquiriesSelectList"
  Runat="server" />
