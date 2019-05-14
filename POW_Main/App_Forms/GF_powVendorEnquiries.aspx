<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_powVendorEnquiries.aspx.vb" Inherits="GF_powVendorEnquiries" title="Maintain List: Vendor Enquiries" %>
<asp:Content ID="CPHpowVendorEnquiries" ContentPlaceHolderID="cph1" Runat="Server">
<div class="page">
<div class="caption">
    <asp:Label ID="LabelpowVendorEnquiries" runat="server" Text="&nbsp;List: Enquiries From ISGEC"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpowVendorEnquiries" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "TBLpowVendorEnquiries"
      ToolType = "lgNMGrid"
      EditUrl = "~/POW_Main/App_Edit/EF_powVendorEnquiries.aspx"
      EnableAdd = "False"
      ValidationGroup = "powVendorEnquiries"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpowVendorEnquiries" runat="server" AssociatedUpdatePanelID="UPNLpowVendorEnquiries" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVpowVendorEnquiries" SkinID="gv_silver" runat="server" DataSourceID="ODSpowVendorEnquiries" DataKeyNames="TSID,EnquiryID">
      <Columns>
        <asp:TemplateField HeaderText="DETAILS">
          <ItemTemplate>
            <%# Eval("M_Details") %>
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ACTION">
          <ItemTemplate>
            <asp:Button Text="VIEW" CssClass="btn btn-sm btn-primary" ID="xcmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="View Enquiry details."  CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Button Text="Submit Offer" CssClass="btn btn-sm btn-success" ID="xcmdSelect" ValidationGroup='<%# "Select" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("SelectWFVisible") %>' Enabled='<%# EVal("SelectWFEnable") %>' ToolTip="Create and submit offer" SkinID="link" OnClientClick='<%# "return Page_ClientValidate(""Select" & Container.DataItemIndex & """) && confirm(""Create and submit offer ?"");" %>' CommandName="SelectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VIEW">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Enq.ID" SortExpression="EnquiryID">
          <ItemTemplate>
            <asp:Label ID="LabelEnquiryID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("EnquiryID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From">
          <ItemTemplate>
             <asp:Label ID="L_From" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("FK_POW_Enquiries_TSID.CreatedBy") %>' Text='<%# Eval("FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Subject" SortExpression="EMailSubject">
          <ItemTemplate>
             <asp:Label ID="L_Subject" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("EMailSubject") %>' Text='<%# Eval("EMailSubject") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="600px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="SentOn">
          <ItemTemplate>
            <asp:Label ID="LabelSentOn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SentOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Status" SortExpression="POW_EnquiryStates1_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("POW_EnquiryStates1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Submit Offer">
          <ItemTemplate>
            <asp:ImageButton ID="cmdSelect" ValidationGroup='<%# "Select" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("SelectWFVisible") %>' Enabled='<%# EVal("SelectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Create and submit offer" SkinID="link" OnClientClick='<%# "return Page_ClientValidate(""Select" & Container.DataItemIndex & """) && confirm(""Create and submit offer ?"");" %>' CommandName="SelectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Send Technical Offer">
          <ItemTemplate>
            <asp:ImageButton ID="cmdSendTechnicalOffer" ValidationGroup='<%# "SendTechnicalOffer" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("SendTechnicalOfferWFVisible") %>' Enabled='<%# EVal("SendTechnicalOfferWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Send Technical Offer" SkinID="SendTechnicalOffer" OnClientClick='<%# "return Page_ClientValidate(""SendTechnicalOffer" & Container.DataItemIndex & """) && confirm(""Send Technical Offer record ?"");" %>' CommandName="SendTechnicalOfferWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send Commercial Offer">
          <ItemTemplate>
            <asp:ImageButton ID="cmdSendCommercialOffer" ValidationGroup='<%# "SendCommercialOffer" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("SendCommercialOfferWFVisible") %>' Enabled='<%# EVal("SendCommercialOfferWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Send Commercial Offer" SkinID="SendCommercialOffer" OnClientClick='<%# "return Page_ClientValidate(""SendCommercialOffer" & Container.DataItemIndex & """) && confirm(""Send Commercial Offer record ?"");" %>' CommandName="SendCommercialOfferWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send Other Information">
          <ItemTemplate>
            <asp:ImageButton ID="cmdSendOtherInformation" ValidationGroup='<%# "SendOtherInformation" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("SendOtherInformationWFVisible") %>' Enabled='<%# EVal("SendOtherInformationWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Send Other Information" SkinID="SendOtherInformation" OnClientClick='<%# "return Page_ClientValidate(""SendOtherInformation" & Container.DataItemIndex & """) && confirm(""Send Other Information record ?"");" %>' CommandName="SendOtherInformationWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>--%>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpowVendorEnquiries"
      runat = "server"
      DataObjectTypeName = "SIS.POW.powVendorEnquiries"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_powVendorEnquiriesSelectList"
      TypeName = "SIS.POW.powVendorEnquiries"
      SelectCountMethod = "powVendorEnquiriesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpowVendorEnquiries" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
