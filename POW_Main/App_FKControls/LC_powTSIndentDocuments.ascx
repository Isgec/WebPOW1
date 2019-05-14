<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powTSIndentDocuments.ascx.vb" Inherits="LC_powTSIndentDocuments" %>
<asp:DropDownList 
  ID = "DDLpowTSIndentDocuments"
  DataSourceID = "OdsDdlpowTSIndentDocuments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowTSIndentDocuments"
  Runat = "server" 
  ControlToValidate = "DDLpowTSIndentDocuments"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowTSIndentDocuments"
  TypeName = "SIS.POW.powTSIndentDocuments"
  SortParameterName = "OrderBy"
  SelectMethod = "powTSIndentDocumentsSelectList"
  Runat="server" />
