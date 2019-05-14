<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_powEnquiryStates.aspx.vb" Inherits="AF_powEnquiryStates" title="Add: Enquiry States" %>
<asp:Content ID="CPHpowEnquiryStates" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpowEnquiryStates" runat="server" Text="&nbsp;Add: Enquiry States"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpowEnquiryStates" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpowEnquiryStates"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "powEnquiryStates"
    runat = "server" />
<asp:FormView ID="FVpowEnquiryStates"
  runat = "server"
  DataKeyNames = "StatusID"
  DataSourceID = "ODSpowEnquiryStates"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpowEnquiryStates" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StatusID" ForeColor="#CC6633" runat="server" Text="Status ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_StatusID"
            Text='<%# Bind("StatusID") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="powEnquiryStates"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEStatusID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_StatusID" />
          <AJX:MaskedEditValidator 
            ID = "MEVStatusID"
            runat = "server"
            ControlToValidate = "F_StatusID"
            ControlExtender = "MEEStatusID"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "powEnquiryStates"
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
            ValidationGroup="powEnquiryStates"
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
            ValidationGroup = "powEnquiryStates"
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
  ID = "ODSpowEnquiryStates"
  DataObjectTypeName = "SIS.POW.powEnquiryStates"
  InsertMethod="powEnquiryStatesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.POW.powEnquiryStates"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
