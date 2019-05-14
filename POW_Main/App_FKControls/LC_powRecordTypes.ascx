<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powRecordTypes.ascx.vb" Inherits="LC_powRecordTypes" %>
<asp:DropDownList 
  ID = "DDLpowRecordTypes"
  DataSourceID = "OdsDdlpowRecordTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowRecordTypes"
  Runat = "server" 
  ControlToValidate = "DDLpowRecordTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowRecordTypes"
  TypeName = "SIS.POW.powRecordTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "powRecordTypesSelectList"
  Runat="server" />
