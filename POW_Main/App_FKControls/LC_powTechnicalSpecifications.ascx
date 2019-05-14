<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_powTechnicalSpecifications.ascx.vb" Inherits="LC_powTechnicalSpecifications" %>
<asp:DropDownList 
  ID = "DDLpowTechnicalSpecifications"
  DataSourceID = "OdsDdlpowTechnicalSpecifications"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpowTechnicalSpecifications"
  Runat = "server" 
  ControlToValidate = "DDLpowTechnicalSpecifications"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpowTechnicalSpecifications"
  TypeName = "SIS.POW.powTechnicalSpecifications"
  SortParameterName = "OrderBy"
  SelectMethod = "powTechnicalSpecificationsSelectList"
  Runat="server" />
