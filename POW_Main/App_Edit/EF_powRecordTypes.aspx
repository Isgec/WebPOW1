<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powRecordTypes.aspx.vb" Inherits="EF_powRecordTypes" title="Edit: Record Types" %>
<asp:Content ID="CPHpowRecordTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpowRecordTypes" runat="server" Text="&nbsp;Edit: Record Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpowRecordTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpowRecordTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "powRecordTypes"
    runat = "server" />
<asp:FormView ID="FVpowRecordTypes"
  runat = "server"
  DataKeyNames = "RecordTypeID"
  DataSourceID = "ODSpowRecordTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecordTypeID" runat="server" ForeColor="#CC6633" Text="Record Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RecordTypeID"
            Text='<%# Bind("RecordTypeID") %>'
            ToolTip="Value of Record Type ID."
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
            ValidationGroup="powRecordTypes"
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
            ValidationGroup = "powRecordTypes"
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
  ID = "ODSpowRecordTypes"
  DataObjectTypeName = "SIS.POW.powRecordTypes"
  SelectMethod = "powRecordTypesGetByID"
  UpdateMethod="powRecordTypesUpdate"
  DeleteMethod="powRecordTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.POW.powRecordTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecordTypeID" Name="RecordTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
