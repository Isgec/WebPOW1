<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powTechnicalSpecifications.aspx.vb" Inherits="EF_powTechnicalSpecifications" title="Edit: Technical Specifications" %>
<asp:Content ID="CPHpowTechnicalSpecifications" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowTechnicalSpecifications" runat="server" Text="&nbsp;Edit: Technical Specifications"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowTechnicalSpecifications" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowTechnicalSpecifications"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnablePrint="True"
            PrintUrl="../App_Print/RP_powTechnicalSpecifications.aspx?pk="
            ValidationGroup="powTechnicalSpecifications"
            runat="server" />
          <script type="text/javascript">
            var pcnt = 0;
            function print_report(o) {
              pcnt = pcnt + 1;
              var nam = 'wTask' + pcnt;
              var url = self.location.href.replace('App_Forms/GF_', 'App_Print/RP_');
              url = url + '?pk=' + o.alt;
              url = o.alt;
              window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
          </script>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12">
          <asp:FormView ID="FVpowTechnicalSpecifications"
            runat="server"
            Width="100%"
            DataKeyNames="TSID"
            DataSourceID="ODSpowTechnicalSpecifications"
            DefaultMode="Edit">
            <EditItemTemplate>
  <div id="accordion">
    <div class="card">
      <div class="card-header">
        <a class="card-link" data-toggle="collapse" href="#collapseOne">
          Click to Show or Hide Technical Specification Details
        </a>
      </div>
      <div id="collapseOne" class="collapse" data-parent="#accordion">
        <div class="card-body">

              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_TSID" runat="server" Font-Bold="True" ForeColor="#CC6633" Text="TSID :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_TSID"
                    Text='<%# Bind("TSID") %>'
                    ToolTip="Value of TSID."
                    Enabled="False"
                    CssClass="mypktxt"
                    Width="88px"
                    Style="text-align: right"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_TSTypeID" runat="server" Text="TS Type :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <LGM:LC_powTSTypes
                    ID="F_TSTypeID"
                    SelectedValue='<%# Bind("TSTypeID") %>'
                    OrderBy="DisplayField"
                    DataTextField="DisplayField"
                    DataValueField="PrimaryKey"
                    IncludeDefault="true"
                    DefaultText="-- Select --"
                    Width="200px"
                    CssClass="myddl"
                    ValidationGroup="powTechnicalSpecifications"
                    RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_TSDescription" runat="server" Text="TS Description :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_TSDescription"
                    Text='<%# Bind("TSDescription") %>'
                    Width="300px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powTechnicalSpecifications"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Technical Specification Description."
                    MaxLength="100"
                    runat="server" />
                  <asp:RequiredFieldValidator
                    ID="RFVTSDescription"
                    runat="server"
                    ControlToValidate="F_TSDescription"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="powTechnicalSpecifications"
                    SetFocusOnError="true" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_AdditionalEMailIDs" runat="server" Text="Additional E-MailIDs :" />
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_AdditionalEMailIDs"
                    Text='<%# Bind("AdditionalEMailIDs") %>'
                    Width="300px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powTechnicalSpecifications"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Additional E-MailIDs."
                    MaxLength="500"
                    runat="server" />
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
                    Text='<%# Eval("POW_TSStates2_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_CreatedBy"
                    Width="72px"
                    Text='<%# Bind("CreatedBy") %>'
                    Enabled="False"
                    ToolTip="Value of Created By."
                    CssClass="dmyfktxt"
                    runat="Server" />
                  <asp:Label
                    ID="F_CreatedBy_Display"
                    Text='<%# Eval("aspnet_users1_UserFullName") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_CreatedOn"
                    Text='<%# Bind("CreatedOn") %>'
                    ToolTip="Value of Created On."
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
                    Handle='<%# Eval("AthHandle") %>'
                    Index='<%# Eval("AthIndex") %>'
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
                    <asp:Label ID="LabelpowEnquiries" runat="server" Text="&nbsp;List: Enquiries"></asp:Label>
                  </legend>
                  <asp:UpdatePanel ID="UPNLpowEnquiries" runat="server">
                    <ContentTemplate>
                      <LGM:ToolBar0
                        ID="TBLpowEnquiries"
                        ToolType="lgNMGrid"
                        EditUrl="~/POW_Main/App_Edit/EF_powEnquiries.aspx"
                        AddUrl="~/POW_Main/App_Create/AF_powEnquiries.aspx?skip=1"
                        AddPostBack="True"
                        EnableExit="false"
                        ValidationGroup="powEnquiries"
                        runat="server" />
                      <asp:UpdateProgress ID="UPGSpowEnquiries" runat="server" AssociatedUpdatePanelID="UPNLpowEnquiries" DisplayAfter="100">
                        <ProgressTemplate>
                          <span style="color: #ff0033">Loading...</span>
                        </ProgressTemplate>
                      </asp:UpdateProgress>
                      <asp:GridView ID="GVpowEnquiries" SkinID="gv_silver" runat="server" DataSourceID="ODSpowEnquiries" DataKeyNames="TSID,EnquiryID">
                        <Columns>
                          <asp:TemplateField HeaderText="DETAILS">
                            <ItemTemplate>
                              <%# Eval("M_Details") %>
                            </ItemTemplate>
                            <HeaderStyle Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="ACTION">
                            <ItemTemplate>
                              <asp:Button Text="EDIT" CssClass="btn btn-sm btn-success" ID="xcmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                              <%--<asp:Button Text="SEND" CssClass="btn btn-sm btn-warning" ID="xcmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Send / Re-Send Enquiry Alert and Login Details to Vendor" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Raise Enquiry and send E-Mail to Vendor ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />--%>
                              <asp:Button Text="UVO" CssClass="btn btn-sm btn-warning" ID="xcmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Click to upload vendor Offer" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Upload Vendor Offer ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
                              <asp:Button Text="CNC" CssClass="btn btn-sm btn-danger" ID="xcmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Commercial Negotiation Completed" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Update Commericial Negotiation Completed ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="EDIT">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Enquiry ID" SortExpression="EnquiryID">
                            <ItemTemplate>
                              <asp:Label ID="LabelEnquiryID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("EnquiryID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="40px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Supplier">
                            <ItemTemplate>
                              <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("GetSupplier") %>' Text='<%# Eval("GetSupplier") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Subject" SortExpression="EMailSubject">
                            <ItemTemplate>
                              <asp:Label ID="LabelEMailSubject" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("EMailSubject") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="400px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Sent On" SortExpression="SentOn">
                            <ItemTemplate>
                              <asp:Label ID="LabelSentOn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SentOn") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="90px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Status" SortExpression="POW_EnquiryStates1_Description">
                            <ItemTemplate>
                              <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("POW_EnquiryStates1_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="DEL">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="SEND">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Send / Re-Send Enquiry Alert and Login Details to Vendor" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Raise Enquiry and send E-Mail to Vendor ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="UVO">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Click to upload vendor Offer" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Upload vendor offer ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="REP">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdReplyWF" ValidationGroup='<%# "Reply" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Click to communicate to vendor" SkinID="reply" OnClientClick='<%# "return Page_ClientValidate(""Reply" & Container.DataItemIndex & """) && confirm(""Create Reply ?"");" %>' CommandName="ReplyWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="OR">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdRequestCommercialOfferUVO" ValidationGroup='<%# "RequestCommercialOfferUVO" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RequestCommercialOfferUVOWFVisible") %>' Enabled='<%# EVal("RequestCommercialOfferUVOWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Click to Update Offer Received." SkinID="received" OnClientClick='<%# "return Page_ClientValidate(""RequestCommercialOfferUVO" & Container.DataItemIndex & """) && confirm(""Update Offer Received ?"");" %>' CommandName="RequestCommercialOfferUVOWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="CNC">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Commercial Negotiation Completed" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Update Commericial Negotiation Completed ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                        ID="ODSpowEnquiries"
                        runat="server"
                        DataObjectTypeName="SIS.POW.powEnquiries"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="UZ_powEnquiriesSelectList"
                        TypeName="SIS.POW.powEnquiries"
                        SelectCountMethod="powEnquiriesSelectCount"
                        SortParameterName="OrderBy" EnablePaging="True">
                        <SelectParameters>
                          <asp:ControlParameter ControlID="F_TSID" PropertyName="Text" Name="TSID" Type="Int32" Size="10" />
                          <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                          <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                        </SelectParameters>
                      </asp:ObjectDataSource>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVpowEnquiries" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </div>
              <div class="row">
                <div class="col-sm-12">
                  <legend>
                    <asp:Label ID="LabelpowTSIndents" runat="server" Text="&nbsp;List: Indents Included in Technical Specification"></asp:Label>
                  </legend>
                  <asp:UpdatePanel ID="UPNLpowTSIndents" runat="server">
                    <ContentTemplate>
                      <LGM:ToolBar0
                        ID="TBLpowTSIndents"
                        ToolType="lgNMGrid"
                        EditUrl="~/POW_Main/App_Edit/EF_powTSIndents.aspx"
                        EnableAdd="False"
                        EnableExit="false"
                        ValidationGroup="powTSIndents"
                        runat="server" />
                      <asp:UpdateProgress ID="UPGSpowTSIndents" runat="server" AssociatedUpdatePanelID="UPNLpowTSIndents" DisplayAfter="100">
                        <ProgressTemplate>
                          <span style="color: #ff0033">Loading...</span>
                        </ProgressTemplate>
                      </asp:UpdateProgress>
                      <asp:GridView ID="GVpowTSIndents" SkinID="gv_silver" runat="server" DataSourceID="ODSpowTSIndents" DataKeyNames="TSID,SerialNo">
                        <Columns>
                          <asp:TemplateField HeaderText="DETAILS">
                            <ItemTemplate>
                              <%# Eval("M_Details") %>
                            </ItemTemplate>
                            <HeaderStyle Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="ACTION">
                            <ItemTemplate>
                              <asp:Button Text="EDIT" CssClass="btn btn-sm btn-primary" ID="xcmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="EDIT">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
                            <ItemTemplate>
                              <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="40px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Indent No" SortExpression="IndentNo">
                            <ItemTemplate>
                              <asp:Label ID="LabelIndentNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("IndentNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="50px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Indent Line" SortExpression="IndentLine">
                            <ItemTemplate>
                              <asp:Label ID="LabelIndentLine" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("IndentLine") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="80px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="LotItem" SortExpression="LotItem">
                            <ItemTemplate>
                              <asp:Label ID="LabelLotItem" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("LotItem") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="100px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects2_Description">
                            <ItemTemplate>
                              <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects2_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Element" SortExpression="IDM_WBS3_Description">
                            <ItemTemplate>
                              <asp:Label ID="L_ElementID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ElementID") %>' Text='<%# Eval("IDM_WBS3_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                          </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                          <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                        </EmptyDataTemplate>
                      </asp:GridView>
                      <asp:ObjectDataSource
                        ID="ODSpowTSIndents"
                        runat="server"
                        DataObjectTypeName="SIS.POW.powTSIndents"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="UZ_powTSIndentsSelectList"
                        TypeName="SIS.POW.powTSIndents"
                        SelectCountMethod="powTSIndentsSelectCount"
                        SortParameterName="OrderBy" EnablePaging="True">
                        <SelectParameters>
                          <asp:ControlParameter ControlID="F_TSID" PropertyName="Text" Name="TSID" Type="Int32" Size="10" />
                          <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                          <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                        </SelectParameters>
                      </asp:ObjectDataSource>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVpowTSIndents" EventName="PageIndexChanged" />
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
    ID="ODSpowTechnicalSpecifications"
    DataObjectTypeName="SIS.POW.powTechnicalSpecifications"
    SelectMethod="powTechnicalSpecificationsGetByID"
    UpdateMethod="powTechnicalSpecificationsUpdate"
    DeleteMethod="powTechnicalSpecificationsDelete"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powTechnicalSpecifications"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="TSID" Name="TSID" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>
