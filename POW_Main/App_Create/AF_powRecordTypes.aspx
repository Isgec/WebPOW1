<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_powRecordTypes.aspx.vb" Inherits="AF_powRecordTypes" title="Add: Record Types" %>
<asp:Content ID="CPHpowRecordTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpowRecordTypes" runat="server" Text="&nbsp;Add: Record Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpowRecordTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpowRecordTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "powRecordTypes"
    runat = "server" />
<asp:FormView ID="FVpowRecordTypes"
  runat = "server"
  DataKeyNames = "RecordTypeID"
  DataSourceID = "ODSpowRecordTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpowRecordTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecordTypeID" ForeColor="#CC6633" runat="server" Text="Record Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RecordTypeID"
            Text='<%# Bind("RecordTypeID") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="powRecordTypes"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEERecordTypeID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_RecordTypeID" />
          <AJX:MaskedEditValidator 
            ID = "MEVRecordTypeID"
            runat = "server"
            ControlToValidate = "F_RecordTypeID"
            ControlExtender = "MEERecordTypeID"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "powRecordTypes"
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
            ValidationGroup="powRecordTypes"
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
            ValidationGroup = "powRecordTypes"
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
  ID = "ODSpowRecordTypes"
  DataObjectTypeName = "SIS.POW.powRecordTypes"
  InsertMethod="powRecordTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.POW.powRecordTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
