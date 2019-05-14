<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_powTSTypes.aspx.vb" Inherits="AF_powTSTypes" title="Add: TS Types" %>
<asp:Content ID="CPHpowTSTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpowTSTypes" runat="server" Text="&nbsp;Add: TS Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpowTSTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpowTSTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "powTSTypes"
    runat = "server" />
<asp:FormView ID="FVpowTSTypes"
  runat = "server"
  DataKeyNames = "TSTypeID"
  DataSourceID = "ODSpowTSTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpowTSTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TSTypeID" ForeColor="#CC6633" runat="server" Text="TS TypeID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TSTypeID"
            Text='<%# Bind("TSTypeID") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="powTSTypes"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETSTypeID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TSTypeID" />
          <AJX:MaskedEditValidator 
            ID = "MEVTSTypeID"
            runat = "server"
            ControlToValidate = "F_TSTypeID"
            ControlExtender = "MEETSTypeID"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "powTSTypes"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="powTSTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "powTSTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpowTSTypes"
  DataObjectTypeName = "SIS.POW.powTSTypes"
  InsertMethod="powTSTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.POW.powTSTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
