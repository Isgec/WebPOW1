<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powTSTypes.aspx.vb" Inherits="EF_powTSTypes" title="Edit: TS Types" %>
<asp:Content ID="CPHpowTSTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpowTSTypes" runat="server" Text="&nbsp;Edit: TS Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpowTSTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpowTSTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "powTSTypes"
    runat = "server" />
<asp:FormView ID="FVpowTSTypes"
  runat = "server"
  DataKeyNames = "TSTypeID"
  DataSourceID = "ODSpowTSTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TSTypeID" runat="server" ForeColor="#CC6633" Text="TS TypeID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TSTypeID"
            Text='<%# Bind("TSTypeID") %>'
            ToolTip="Value of TS TypeID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="powTSTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpowTSTypes"
  DataObjectTypeName = "SIS.POW.powTSTypes"
  SelectMethod = "powTSTypesGetByID"
  UpdateMethod="powTSTypesUpdate"
  DeleteMethod="powTSTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.POW.powTSTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TSTypeID" Name="TSTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
