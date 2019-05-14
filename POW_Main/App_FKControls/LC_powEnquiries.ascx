<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powEnquiries.ascx.vb" Inherits="LC_powEnquiries" %>
<asp:DropDownList 
  ID = "DDLpowEnquiries"
  DataSourceID = "OdsDdlpowEnquiries"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowEnquiries"
  Runat = "server" 
  ControlToValidate = "DDLpowEnquiries"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowEnquiries"
  TypeName = "SIS.POW.powEnquiries"
  SortParameterName = "OrderBy"
  SelectMethod = "powEnquiriesSelectList"
  Runat="server" />
