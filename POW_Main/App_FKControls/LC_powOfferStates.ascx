<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powOfferStates.ascx.vb" Inherits="LC_powOfferStates" %>
<asp:DropDownList 
  ID = "DDLpowOfferStates"
  DataSourceID = "OdsDdlpowOfferStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowOfferStates"
  Runat = "server" 
  ControlToValidate = "DDLpowOfferStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowOfferStates"
  TypeName = "SIS.POW.powOfferStates"
  SortParameterName = "OrderBy"
  SelectMethod = "powOfferStatesSelectList"
  Runat="server" />
