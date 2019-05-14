<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="True" CodeFile="AF_powEnquiries.aspx.vb" Inherits="AF_powEnquiries" title="Add: Enquiries" %>
<asp:Content ID="CPHpowEnquiries" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowEnquiries" runat="server" Text="&nbsp;Add: Enquiries"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowEnquiries" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowEnquiries"
            ToolType="lgNMAdd"
            InsertAndStay="False"
            AfterInsertURL="~/POW_Main/App_Edit/EF_powEnquiries.aspx"
            EnableForward="true"
            ValidationGroup="powEnquiries"
            runat="server" />
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12">
          <asp:FormView ID="FVpowEnquiries"
            runat="server"
            Width="100%"
            DataKeyNames="TSID,EnquiryID"
            DataSourceID="ODSpowEnquiries"
            DefaultMode="Insert">
            <InsertItemTemplate>
              <div class="row">
                <div class="col-sm-12">
                  <asp:Label ID="L_ErrMsgpowEnquiries" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_TSID" ForeColor="#CC6633" runat="server" Text="TSID :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_TSID"
                    CssClass="mypktxt"
                    Width="88px"
                    Text='<%# Bind("TSID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for TSID."
                    ValidationGroup="powEnquiries"
                    onblur="script_powEnquiries.validate_TSID(this);"
                    runat="Server" />
                  <asp:RequiredFieldValidator
                    ID="RFVTSID"
                    runat="server"
                    ControlToValidate="F_TSID"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="powEnquiries"
                    SetFocusOnError="true" />
                  <asp:Label
                    ID="F_TSID_Display"
                    Text='<%# Eval("POW_TechnicalSpecifications2_TSDescription") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACETSID"
                    BehaviorID="B_ACETSID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="TSIDCompletionList"
                    TargetControlID="F_TSID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_powEnquiries.ACETSID_Selected"
                    OnClientPopulating="script_powEnquiries.ACETSID_Populating"
                    OnClientPopulated="script_powEnquiries.ACETSID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_EnquiryID" ForeColor="#CC6633" runat="server" Text="Enquiry ID :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_EnquiryID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_SupplierID"
                    CssClass="myfktxt"
                    Width="80px"
                    Text='<%# Bind("SupplierID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Supplier."
                    onblur="script_powEnquiries.validate_SupplierID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_SupplierID_Display"
                    Text='<%# Eval("VR_BusinessPartner3_BPName") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACESupplierID"
                    BehaviorID="B_ACESupplierID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="SupplierIDCompletionList"
                    TargetControlID="F_SupplierID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_powEnquiries.ACESupplierID_Selected"
                    OnClientPopulating="script_powEnquiries.ACESupplierID_Populating"
                    OnClientPopulated="script_powEnquiries.ACESupplierID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_SupplierName" runat="server" Text="Name [If Supplier is NON-Registered] :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_SupplierName"
                    Text='<%# Bind("SupplierName") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Supplier Name."
                    MaxLength="100"
                    Width="300px"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_SupplierEMailID" runat="server" Text="Supplier's E-Mail ID :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_SupplierEMailID"
                    Text='<%# Bind("SupplierEMailID") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powEnquiries"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Supplier's E-Mail ID."
                    MaxLength="100"
                    Width="300px"
                    runat="server" />
                  <asp:RequiredFieldValidator
                    ID="RFVSupplierEMailID"
                    runat="server"
                    ControlToValidate="F_SupplierEMailID"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="powEnquiries"
                    SetFocusOnError="true" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_EMailSubject" runat="server" Text="E-Mail Subject :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_EMailSubject"
                    Text='<%# Bind("EMailSubject") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powEnquiries"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for E-Mail Subject."
                    MaxLength="100"
                    Width="300px"
                    runat="server" />
                  <asp:RequiredFieldValidator
                    ID="RFVEMailSubject"
                    runat="server"
                    ControlToValidate="F_EMailSubject"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="powEnquiries"
                    SetFocusOnError="true" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_EMailBody" runat="server" Text="E Mail Body :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_EMailBody"
                    Text='<%# Bind("EMailBody") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powEnquiries"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for E Mail Body."
                    MaxLength="4000"
                    Width="300px"
                    TextMode="MultiLine"
                    Height="150px"
                    runat="server" />
                  <asp:RequiredFieldValidator
                    ID="RFVEMailBody"
                    runat="server"
                    ControlToValidate="F_EMailBody"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="powEnquiries"
                    SetFocusOnError="true" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_AdditionalEMailIDs" runat="server" Text="Additional E-Mail IDs :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_AdditionalEMailIDs"
                    Text='<%# Bind("AdditionalEMailIDs") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Additional E-Mail IDs."
                    MaxLength="500"
                    Width="300px"
                    runat="server" />
                </div>
              </div>
              <div class="row" style="display:none;">
                <div class="col-sm-4">
                  <asp:Label ID="L_SupplierLoginID" runat="server" Text="Supplier Login :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_SupplierLoginID"
                    CssClass="myfktxt"
                    Width="72px"
                    Text='<%# Bind("SupplierLoginID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Supplier Login."
                    onblur="script_powEnquiries.validate_SupplierLoginID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_SupplierLoginID_Display"
                    Text='<%# Eval("aspnet_users4_UserFullName") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACESupplierLoginID"
                    BehaviorID="B_ACESupplierLoginID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="SupplierLoginIDCompletionList"
                    TargetControlID="F_SupplierLoginID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_powEnquiries.ACESupplierLoginID_Selected"
                    OnClientPopulating="script_powEnquiries.ACESupplierLoginID_Populating"
                    OnClientPopulated="script_powEnquiries.ACESupplierLoginID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="Label2" runat="server" Text="Attachments For RFQ :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <LGM:LGAttachments
                    ID="LGAttachments1"
                    Process=""
                    Handle="J_PREORDER_TECHSPEC"
                    Index='<%# TSID %>'
                    ValidationGroup="powEnquiries"
                    ValidateClient="true"
                    Editable="false"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="Label1" runat="server" Text="Attachments :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <LGM:LGAttachments
                    ID="F_TSAttachments"
                    Process='<%# Eval("AthProcess") %>'
                    Handle='<%# Eval("AthHandle") %>'
                    Index='<%# Eval("AthIndex") %>'
                    ValidationGroup="powEnquiries"
                    ValidateClient="true"
                    Editable="true"
                    OnFilesUploaded="F_TSAttachments_FilesUploaded"
                    runat="server" />
                </div>
              </div>


            </InsertItemTemplate>
          </asp:FormView>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  <asp:ObjectDataSource
    ID="ODSpowEnquiries"
    DataObjectTypeName="SIS.POW.powEnquiries"
    InsertMethod="UZ_powEnquiriesInsert"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powEnquiries"
    SelectMethod="GetNewRecord"
    runat="server"></asp:ObjectDataSource>
</asp:Content>
