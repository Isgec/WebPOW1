<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powEnquiryStates.ascx.vb" Inherits="LC_powEnquiryStates" %>
<asp:DropDownList 
  ID = "DDLpowEnquiryStates"
  DataSourceID = "OdsDdlpowEnquiryStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowEnquiryStates"
  Runat = "server" 
  ControlToValidate = "DDLpowEnquiryStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowEnquiryStates"
  TypeName = "SIS.POW.powEnquiryStates"
  SortParameterName = "OrderBy"
  SelectMethod = "powEnquiryStatesSelectList"
  Runat="server" />
