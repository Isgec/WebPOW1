<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_powTechnicalSpecifications.aspx.vb" Inherits="GF_powTechnicalSpecifications" title="Maintain List: Technical Specifications" %>
<asp:Content ID="CPHpowTechnicalSpecifications" ContentPlaceHolderID="cph1" Runat="Server">
<div class="page">
<div class="caption">
    <asp:Label ID="LabelpowTechnicalSpecifications" runat="server" Text="&nbsp;List: Technical Specifications"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpowTechnicalSpecifications" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "TBLpowTechnicalSpecifications"
      ToolType = "lgNMGrid"
      EditUrl = "~/POW_Main/App_Edit/EF_powTechnicalSpecifications.aspx"
      AddUrl = "~/POW_Main/App_Create/AF_powTechnicalSpecifications.aspx?skip=1"
      ValidationGroup = "powTechnicalSpecifications"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpowTechnicalSpecifications" runat="server" AssociatedUpdatePanelID="UPNLpowTechnicalSpecifications" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr style="display:none;">
        <td class="alignright">
          <b><asp:Label ID="L_StatusID" runat="server" Text="Status :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_StatusID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEStatusID"
            BehaviorID="B_ACEStatusID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="StatusIDCompletionList"
            TargetControlID="F_StatusID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEStatusID_Selected"
            OnClientPopulating="ACEStatusID_Populating"
            OnClientPopulated="ACEStatusID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="Label1" runat="server" Text="Indent No :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_IndentNo" runat="server" Width="110px" MaxLength="9" CssClass="mytxt"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="Label2" runat="server" Text="Indent Line :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_IndentLine" runat="server" Width="60px" MaxLength="3" CssClass="mytxt"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="alignCenter" colspan="2">
          <asp:Label ID="L_msg" runat="server" Font-Bold="true" ForeColor="Red" Text=""  />
        </td>
      </tr>
      <tr>
        <td class="alignCenter" colspan="2">
          <asp:Button ID="cmdImport" runat="server" Text="Create/Update TS"  />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
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
    <asp:GridView ID="GVpowTechnicalSpecifications" SkinID="gv_silver" runat="server" DataSourceID="ODSpowTechnicalSpecifications" DataKeyNames="TSID">
      <Columns>
        <asp:TemplateField HeaderText="DETAILS">
          <ItemTemplate>
            <%# Eval("M_Details") %>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ACTION">
          <ItemTemplate>
            <asp:Button Text="EDIT" CssClass="btn btn-sm btn-warning" ID="xcmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record."  CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Button Text="REL" CssClass="btn btn-sm btn-success" ID="xcmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Release Technical Specification." OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Release Technical Specification ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Button Text="CreateEnq" CssClass="btn btn-sm btn-success" ID="xcmdCreateEnquiry" ValidationGroup='<%# "CreateEnquiry" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CreateEnquiryWFVisible") %>' Enabled='<%# EVal("CreateEnquiryWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Create Enquiry" OnClientClick='<%# "return Page_ClientValidate(""CreateEnquiry" & Container.DataItemIndex & """) && confirm(""Create Enquiry record ?"");" %>' CommandName="CreateEnquiryWF" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Button Text="AOR" CssClass="btn btn-sm btn-primary" ID="xcmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="All Offer Received" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""All offer received ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Button Text="COF" CssClass="btn btn-sm btn-danger" ID="xcmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Commercial Offer Finalized" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Commercial Offer Finalized ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TSID" SortExpression="TSID">
          <ItemTemplate>
            <asp:Label ID="LabelTSID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TSID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TS Description" SortExpression="TSDescription">
          <ItemTemplate>
            <asp:Label ID="LabelTSDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TSDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignleft" />
        <HeaderStyle CssClass="alignleft" Width="300px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Enquiries Offers Receipts" >
          <ItemTemplate>
            <div style="display:flex; flex-direction:row;">
              <div class='btn-danger' title="Enquiries" style='font-weight:bold;padding:5px;border-radius:10px;'><%# Eval("GetEnquiries") %></div>
              <div class='btn-warning' title="Offers" style='font-weight:bold;padding:5px;border-radius:10px;'><%# Eval("GetOffers") %></div>
              <div class='btn-primary' title="IDMS Receipts" style='font-weight:bold;padding:5px;border-radius:10px;'><%# Eval("GetReceipts") %></div>
            </div>
          </ItemTemplate>
          <HeaderStyle Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Projects" >
          <ItemTemplate>
             <asp:Label ID="L_Projects" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("Projects") %>' Text='<%# Eval("Projects") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="POW_TSStates2_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("POW_TSStates2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REL">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Release Technical Specification." SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Release Technical Specification ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Create Enquiry">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCreateEnquiry" ValidationGroup='<%# "CreateEnquiry" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CreateEnquiryWFVisible") %>' Enabled='<%# EVal("CreateEnquiryWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Create Enquiry" SkinID="link" OnClientClick='<%# "return Page_ClientValidate(""CreateEnquiry" & Container.DataItemIndex & """) && confirm(""Create Enquiry record ?"");" %>' CommandName="CreateEnquiryWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
<%--
        REL= When TS is created from here by selecting Indent Line
        <asp:TemplateField HeaderText="DEL">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ARCH">
          <ItemTemplate>
            <asp:ImageButton ID="cmdArchive" ValidationGroup='<%# "Archive" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ArchiveWFVisible") %>' Enabled='<%# EVal("ArchiveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Archive" SkinID="Archive" OnClientClick='<%# "return Page_ClientValidate(""Archive" & Container.DataItemIndex & """) && confirm(""Archive record ?"");" %>' CommandName="ArchiveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
--%>

        <asp:TemplateField HeaderText="AOR">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="All Offer Received" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""All offer received ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COF">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Commercial Offer Finalized" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Commercial Offer Finalized ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpowTechnicalSpecifications"
      runat = "server"
      DataObjectTypeName = "SIS.POW.powTechnicalSpecifications"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "powTechnicalSpecificationsSelectList"
      TypeName = "SIS.POW.powTechnicalSpecifications"
      SelectCountMethod = "powTechnicalSpecificationsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpowTechnicalSpecifications" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
