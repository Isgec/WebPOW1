<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powVendorEnquiries.aspx.vb" Inherits="EF_powVendorEnquiries" title="Edit: Vendor Enquiries" %>
<asp:Content ID="CPHpowVendorEnquiries" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowVendorEnquiries" runat="server" Text="&nbsp;Enquiry Detail"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowVendorEnquiries" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowVendorEnquiries"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnableDelete="False"
            EnablePrint="True"
            PrintUrl="../App_Print/RP_powVendorEnquiries.aspx?pk="
            ValidationGroup="powVendorEnquiries"
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
          <asp:FormView ID="FVpowVendorEnquiries"
            runat="server"
            Width="100%"
            DataKeyNames="TSID,EnquiryID"
            DataSourceID="ODSpowVendorEnquiries"
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
                  <asp:Label
                    ID="F_SupplierID"
                    CssClass="dmytxt"
                    Text='<%# Eval("GetSupplier") %>'
                    Width="300px"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_EMailSubject" runat="server" Text="E-Mail Subject :" />
                </div>
                <div class="col-sm-8">
                  <asp:Label
                    ID="F_EMailSubject"
                    Text='<%# Eval("EMailSubject") %>'
                    Width="300px"
                    CssClass="dmytxt"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_EMailBody" runat="server" Text="E Mail Body :" />
                </div>
                <div class="col-sm-8">
                  <asp:Label
                    ID="F_EMailBody"
                    Text='<%# Eval("EMailBody") %>'
                    Width="300px"
                    CssClass="dmytxt"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_SupplierEMailID" runat="server" Text="CC E-Mail IDs :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_SupplierEMailID"
                    Text='<%# Bind("SupplierEMailID") %>'
                    Width="300px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powVendorEnquiries"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Supplier's E-Mail ID."
                    MaxLength="100"
                    runat="server" />
                  <asp:RequiredFieldValidator
                    ID="RFVSupplierEMailID"
                    runat="server"
                    ControlToValidate="F_SupplierEMailID"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="powVendorEnquiries"
                    SetFocusOnError="true" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_SupplierFromEMailID" runat="server" Text="Reply From E-Mail ID [Only One] :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_SupplierFromEMailID"
                    Text='<%# Bind("SupplierFromEMailID") %>'
                    Width="300px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Mail ID to be used as FROM address in E-Mail communication."
                    MaxLength="100"
                    runat="server" />
                  <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ControlToValidate="F_SupplierFromEMailID"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="powVendorEnquiries"
                    SetFocusOnError="true" />
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
                    ValidationGroup="powVendorEnquiries"
                    ValidateClient="true"
                    Editable="false"
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

          </div>
        </div>
      </div>
    </div>

              <div class="row">
                <div class="col-sm-12">
                  <legend>
                    <asp:Label ID="LabelpowVendorOffers" runat="server" Text="&nbsp;List: Offers / Communications"></asp:Label>
                  </legend>
                  <asp:UpdatePanel ID="UPNLpowVendorOffers" runat="server">
                    <ContentTemplate>
                      <LGM:ToolBar0
                        ID="TBLpowVendorOffers"
                        ToolType="lgNMGrid"
                        EditUrl="~/POW_Main/App_Edit/EF_powVendorOffers.aspx"
                        AddUrl="~/POW_Main/App_Create/AF_powVendorOffers.aspx"
                        AddPostBack="True"
                        EnableExit="false"
                        ValidationGroup="powVendorOffers"
                        runat="server" />
                      <asp:UpdateProgress ID="UPGSpowVendorOffers" runat="server" AssociatedUpdatePanelID="UPNLpowVendorOffers" DisplayAfter="100">
                        <ProgressTemplate>
                          <span style="color: #ff0033">Loading...</span>
                        </ProgressTemplate>
                      </asp:UpdateProgress>
                      <asp:GridView ID="GVpowVendorOffers" SkinID="gv_silver" runat="server" DataSourceID="ODSpowVendorOffers" DataKeyNames="TSID,EnquiryID,RecordID">
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
                              <asp:Button Text="FWD" CssClass="btn btn-sm btn-warning" ID="xcmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' ToolTip="Forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                          <%--        <asp:TemplateField HeaderText="Record ID" SortExpression="RecordID">
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
                            <HeaderStyle Width="100px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Date" SortExpression="SubmittedOn">
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
                            <HeaderStyle CssClass="alignCenter" Width="500px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Status" SortExpression="POW_OfferStates4_Description">
                            <ItemTemplate>
                              <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("POW_OfferStates4_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="30px" />
                          </asp:TemplateField>
                          <%--        <asp:TemplateField HeaderText="Revise">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRevise" ValidationGroup='<%# "Revise" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ReviseWFVisible") %>' Enabled='<%# EVal("ReviseWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Revise" SkinID="Revise" OnClientClick='<%# "return Page_ClientValidate(""Revise" & Container.DataItemIndex & """) && confirm(""Revise record ?"");" %>' CommandName="ReviseWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="Forward">
                            <ItemTemplate>
                              <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                        ID="ODSpowVendorOffers"
                        runat="server"
                        DataObjectTypeName="SIS.POW.powVendorOffers"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="UZ_powVendorOffersSelectList"
                        TypeName="SIS.POW.powVendorOffers"
                        SelectCountMethod="powVendorOffersSelectCount"
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
                      <asp:AsyncPostBackTrigger ControlID="GVpowVendorOffers" EventName="PageIndexChanged" />
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
    ID="ODSpowVendorEnquiries"
    DataObjectTypeName="SIS.POW.powVendorEnquiries"
    SelectMethod="powVendorEnquiriesGetByID"
    UpdateMethod="UZ_powVendorEnquiriesUpdate"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powVendorEnquiries"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="TSID" Name="TSID" Type="Int32" />
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="EnquiryID" Name="EnquiryID" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>
