<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powTSTypes.ascx.vb" Inherits="LC_powTSTypes" %>
<asp:DropDownList 
  ID = "DDLpowTSTypes"
  DataSourceID = "OdsDdlpowTSTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  CssClass = "form-control"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowTSTypes"
  Runat = "server" 
  ControlToValidate = "DDLpowTSTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowTSTypes"
  TypeName = "SIS.POW.powTSTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "powTSTypesSelectList"
  Runat="server" />
