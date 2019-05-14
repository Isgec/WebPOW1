<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powTSIndents.ascx.vb" Inherits="LC_powTSIndents" %>
<asp:DropDownList 
  ID = "DDLpowTSIndents"
  DataSourceID = "OdsDdlpowTSIndents"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowTSIndents"
  Runat = "server" 
  ControlToValidate = "DDLpowTSIndents"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowTSIndents"
  TypeName = "SIS.POW.powTSIndents"
  SortParameterName = "OrderBy"
  SelectMethod = "powTSIndentsSelectList"
  Runat="server" />
