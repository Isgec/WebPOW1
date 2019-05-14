<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powTSStates.ascx.vb" Inherits="LC_powTSStates" %>
<asp:DropDownList 
  ID = "DDLpowTSStates"
  DataSourceID = "OdsDdlpowTSStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowTSStates"
  Runat = "server" 
  ControlToValidate = "DDLpowTSStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowTSStates"
  TypeName = "SIS.POW.powTSStates"
  SortParameterName = "OrderBy"
  SelectMethod = "powTSStatesSelectList"
  Runat="server" />
