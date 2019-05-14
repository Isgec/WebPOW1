<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powEnquiries.aspx.vb" Inherits="EF_powEnquiries" title="Edit: Enquiries" %>
<asp:Content ID="CPHpowEnquiries" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowEnquiries" runat="server" Text="&nbsp;Edit: Enquiries"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowEnquiries" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowEnquiries"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
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
            DefaultMode="Edit">
            <EditItemTemplate>
  <div id="accordion">
    <div class="card">
      <div class="card-header">
        <a class="card-link" data-toggle="collapse" href="#collapseOne">
          Click to Show or Hide Enquiry Details
        </a>
      </div>
      <div id="collapseOne" class="collapse" data-parent="#accordion">
        <div class="card-body">

              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_TSID" runat="server" ForeColor="#CC6633" Text="TSID :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_TSID"
                    Width="88px"
                    Text='<%# Bind("TSID") %>'
                    CssClass="mypktxt"
                    Enabled="False"
                    ToolTip="Value of TSID."
                    runat="Server" />
                  <asp:Label
                    ID="F_TSID_Display"
                    Text='<%# Eval("POW_TechnicalSpecifications2_TSDescription") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_EnquiryID" runat="server" ForeColor="#CC6633" Text="Enquiry ID :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_EnquiryID"
                    Text='<%# Bind("EnquiryID") %>'
                    ToolTip="Value of Enquiry ID."
                    Enabled="False"
                    CssClass="mypktxt"
                    Width="88px"
                    Style="text-align: right"
                    runat="server" />
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
                    Text='<%# Bind("SupplierID") %>'
                    AutoCompleteType="None"
                    Width="80px"
                    onfocus="return this.select();"
                    ToolTip="Enter Supplier."
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
                    Width="300px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Supplier Name."
                    MaxLength="100"
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
                    Width="300px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powEnquiries"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Supplier's E-Mail ID."
                    MaxLength="100"
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
                    Width="300px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powEnquiries"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter E-Mail Subject."
                    MaxLength="100"
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
                    Width="300px"
                    TextMode="MultiLine"
                    Height="150px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powEnquiries"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter E Mail Body."
                    MaxLength="4000"
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
                    Width="300px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Additional E-Mail IDs."
                    MaxLength="500"
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
                    Text='<%# Bind("SupplierLoginID") %>'
                    AutoCompleteType="None"
                    Width="72px"
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
                  <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_StatusID"
                    Width="88px"
                    Text='<%# Bind("StatusID") %>'
                    Enabled="False"
                    ToolTip="Value of Status."
                    CssClass="dmyfktxt"
                    runat="Server" />
                  <asp:Label
                    ID="F_StatusID_Display"
                    Text='<%# Eval("POW_EnquiryStates1_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_SentOn" runat="server" Text="Sent On :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_SentOn"
                    Text='<%# Bind("SentOn") %>'
                    ToolTip="Value of Sent On."
                    Enabled="False"
                    Width="168px"
                    CssClass="dmytxt"
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
                    Editable='<%# AthEditable %>'
                    OnFilesUploaded="F_TSAttachments_FilesUploaded"
                    runat="server" />
                </div>
              </div>

          </div>
        </div>
      </div>
    </div>


              <div class="row">
                <div class="col-sm-12">
                  <legend>
                    <asp:Label ID="LabelpowOffers" runat="server" Text="&nbsp;List: Messages"></asp:Label>
                  </legend>
                  <asp:UpdatePanel ID="UPNLpowOffers" runat="server">
                    <ContentTemplate>
                      <LGM:ToolBar0
                        ID="TBLpowOffers"
                        ToolType="lgNMGrid"
                        EditUrl="~/POW_Main/App_Edit/EF_powOffers.aspx"
                        AddUrl="~/POW_Main/App_Create/AF_powOffers.aspx"
                        AddPostBack="True"
                        EnableExit="false"
                        ValidationGroup="powOffers"
                        runat="server" />
                      <asp:UpdateProgress ID="UPGSpowOffers" runat="server" AssociatedUpdatePanelID="UPNLpowOffers" DisplayAfter="100">
                        <ProgressTemplate>
                          <span style="color: #ff0033">Loading...</span>
                        </ProgressTemplate>
                      </asp:UpdateProgress>
                      <asp:GridView ID="GVpowOffers" SkinID="gv_silver" runat="server" DataSourceID="ODSpowOffers" DataKeyNames="TSID,EnquiryID,RecordID">
                        <Columns>
                          <asp:TemplateField HeaderText="DETAILS">
                            <ItemTemplate>
                              <%# Eval("M_Details") %>
                            </ItemTemplate>
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="ACTION">
                            <ItemTemplate>
                              <asp:Button Text="EDIT" CssClass="btn btn-sm btn-primary" ID="xcmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                              <asp:Button Text="FWD" CssClass="btn btn-sm btn-warning" ID="xcmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' ToolTip="Forward offer/information" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward Offer/Information ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                              <asp:Button Text="DTE" CssClass="btn btn-sm btn-success" ID="xcmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' ToolTip="Distribute for Technical Evaluation" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Distribute for technical evaluation ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="EDIT">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <%--                                <asp:TemplateField HeaderText="Record ID" SortExpression="RecordID">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelRecordID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RecordID") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Record Type" SortExpression="POW_RecordTypes5_Description">
                                  <ItemTemplate>
                                    <asp:Label ID="L_RecordTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RecordTypeID") %>' Text='<%# Eval("POW_RecordTypes5_Description") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revision" SortExpression="RecordRevision">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelRecordRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RecordRevision") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="From" SortExpression="aspnet_users2_UserFullName">
                            <ItemTemplate>
                              <asp:Label ID="L_SubmittedBy" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("SubmittedBy") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="" Width="200px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Submitted On" SortExpression="SubmittedOn">
                            <ItemTemplate>
                              <asp:Label ID="LabelSubmittedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SubmittedOn") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="90px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Subject" SortExpression="EMailSubject">
                            <ItemTemplate>
                              <asp:Label ID="LabelEMailSubject" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EMailSubject") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignleft" />
                            <HeaderStyle CssClass="alignleft" Width="600px" />
                          </asp:TemplateField>
                          <%--                                <asp:TemplateField HeaderText="Status" SortExpression="POW_OfferStates4_Description">
                                  <ItemTemplate>
                                    <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("POW_OfferStates4_Description") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="DEL">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="FWD">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward offer/information" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward Offer/Information ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <%--                                <asp:TemplateField HeaderText="ACK">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Acknowledge Vendor Offer" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Acknowledge Vendor Offer ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="30px" />
                                </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="DTE">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Distribute for Technical Evaluation" SkinID="Distribute" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Distribute for technical evaluation ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <%--                                <asp:TemplateField HeaderText="CLOSE">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdClose" ValidationGroup='<%# "Close" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CloseWFVisible") %>' Enabled='<%# EVal("CloseWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Close the record" SkinID="lock" OnClientClick='<%# "return Page_ClientValidate(""Close" & Container.DataItemIndex & """) && confirm(""Close the record ?"");" %>' CommandName="CloseWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                        ID="ODSpowOffers"
                        runat="server"
                        DataObjectTypeName="SIS.POW.powOffers"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="UZ_powOffersSelectList"
                        TypeName="SIS.POW.powOffers"
                        SelectCountMethod="powOffersSelectCount"
                        SortParameterName="OrderBy" EnablePaging="True">
                        <SelectParameters>
                          <asp:ControlParameter ControlID="F_EnquiryID" PropertyName="Text" Name="EnquiryID" Type="Int32" Size="10" />
                          <asp:ControlParameter ControlID="F_TSID" PropertyName="Text" Name="TSID" Type="Int32" Size="10" />
                          <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                          <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                        </SelectParameters>
                      </asp:ObjectDataSource>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVpowOffers" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </div>
            </EditItemTemplate>
          </asp:FormView>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  <asp:ObjectDataSource
    ID="ODSpowEnquiries"
    DataObjectTypeName="SIS.POW.powEnquiries"
    SelectMethod="powEnquiriesGetByID"
    UpdateMethod="UZ_powEnquiriesUpdate"
    DeleteMethod="UZ_powEnquiriesDelete"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powEnquiries"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="TSID" Name="TSID" Type="Int32" />
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="EnquiryID" Name="EnquiryID" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>
