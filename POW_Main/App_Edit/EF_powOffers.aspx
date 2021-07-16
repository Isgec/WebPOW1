<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powOffers.aspx.vb" Inherits="EF_powOffers" title="Edit: Offers" %>
<asp:Content ID="CPHpowOffers" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowOffers" runat="server" Text="&nbsp;Edit: Offers"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowOffers" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowOffers"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnableForward="true"
            ValidationGroup="powOffers"
            runat="server" />
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12">
          <asp:FormView ID="FVpowOffers"
            runat="server"
            Width="100%"
            DataKeyNames="TSID,EnquiryID,RecordID"
            DataSourceID="ODSpowOffers"
            DefaultMode="Edit">
            <EditItemTemplate>
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
                    Text='<%# Eval("POW_TechnicalSpecifications6_TSDescription") %>'
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
                    <asp:TextBox
                      ID="F_EnquiryID"
                      Width="88px"
                      Text='<%# Bind("EnquiryID") %>'
                      CssClass="mypktxt"
                      Enabled="False"
                      ToolTip="Value of Enquiry ID."
                      runat="Server" />
                    <asp:Label
                      ID="F_EnquiryID_Display"
                      Text='<%# Eval("POW_Enquiries3_EMailSubject") %>'
                      CssClass="myLbl"
                      runat="Server" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-4">
                    <b>
                      <asp:Label ID="L_RecordID" runat="server" ForeColor="#CC6633" Text="Record ID :" /><span style="color: red">*</span></b>
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_RecordID"
                      Text='<%# Bind("RecordID") %>'
                      ToolTip="Value of Record ID."
                      Enabled="False"
                      CssClass="mypktxt"
                      Width="88px"
                      Style="text-align: right"
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
                      Text='<%# Eval("POW_OfferStates4_Description") %>'
                      CssClass="myLbl"
                      runat="Server" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-4">
                    <asp:Label ID="Label2" runat="server" Text="ERP Status :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox
                      ID="F_ERPStatusID"
                      Width="88px"
                      Text='<%# Bind("ERPStatusID") %>'
                      Enabled="False"
                      ToolTip="Value of ERP Status."
                      CssClass="dmyfktxt"
                      runat="Server" />
                    <asp:Label
                      ID="Label3"
                      Text='<%# Eval("ERPStatusNM") %>'
                      CssClass="myLbl"
                      runat="Server" />
                  </div>
                </div>
                <div class="row" style="display: none;">
                  <div class="col-sm-4">
                    <asp:Label ID="L_RecordTypeID" runat="server" Text="Record Type :" /><span style="color: red">*</span>
                  </div>
                  <div class="col-sm-8">
                    <LGM:LC_powRecordTypes
                      ID="F_RecordTypeID"
                      SelectedValue='<%# Bind("RecordTypeID") %>'
                      OrderBy="DisplayField"
                      DataTextField="DisplayField"
                      DataValueField="PrimaryKey"
                      IncludeDefault="true"
                      DefaultText="-- Select --"
                      Width="200px"
                      CssClass="myddl"
                      ValidationGroup="powOffers"
                      RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                      runat="Server" />
                  </div>
                </div>
                <div class="row" style="display: none;">
                  <div class="col-sm-4">
                    <asp:Label ID="L_RecordRevision" runat="server" Text="Revision :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_RecordRevision"
                      Text='<%# Bind("RecordRevision") %>'
                      ToolTip="Value of Revision."
                      Enabled="False"
                      Width="48px"
                      CssClass="dmytxt"
                      runat="server" />
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
                      ValidationGroup="powOffers"
                      onblur="this.value=this.value.replace(/\'/g,'');"
                      ToolTip="Enter value for E-Mail Subject."
                      MaxLength="100"
                      runat="server" />
                    <asp:RequiredFieldValidator
                      ID="RFVEMailSubject"
                      runat="server"
                      ControlToValidate="F_EMailSubject"
                      ErrorMessage="<div class='errorLG'>Required!</div>"
                      Display="Dynamic"
                      EnableClientScript="true"
                      ValidationGroup="powOffers"
                      SetFocusOnError="true" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-4">
                    <asp:Label ID="L_EMailBody" runat="server" Text="E-Mail Body :" /><span style="color: red">*</span>
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_EMailBody"
                      Text='<%# Bind("EMailBody") %>'
                      Width="300px"
                      CssClass="mytxt"
                      onfocus="return this.select();"
                      ValidationGroup="powOffers"
                      onblur="this.value=this.value.replace(/\'/g,'');"
                      ToolTip="Enter value for E-Mail Body."
                      MaxLength="4000"
                      TextMode="MultiLine"
                      Height="200px"
                      runat="server" />
                    <asp:RequiredFieldValidator
                      ID="RFVEMailBody"
                      runat="server"
                      ControlToValidate="F_EMailBody"
                      ErrorMessage="<div class='errorLG'>Required!</div>"
                      Display="Dynamic"
                      EnableClientScript="true"
                      ValidationGroup="powOffers"
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
                      ValidationGroup="powOffers"
                      ValidateClient="true"
                      Editable='<%# AthEditable %>'
                      OnFilesUploaded="F_TSAttachments_FilesUploaded"
                      runat="server" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-4">
                    <asp:Label ID="L_SubmittedBy" runat="server" Text="Submitted By :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox
                      ID="F_SubmittedBy"
                      Width="72px"
                      Text='<%# Bind("SubmittedBy") %>'
                      Enabled="False"
                      ToolTip="Value of Submitted By."
                      CssClass="dmyfktxt"
                      runat="Server" />
                    <asp:Label
                      ID="F_SubmittedBy_Display"
                      Text='<%# Eval("aspnet_users2_UserFullName") %>'
                      CssClass="myLbl"
                      runat="Server" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-4">
                    <asp:Label ID="L_SubmittedOn" runat="server" Text="Submitted On :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_SubmittedOn"
                      Text='<%# Bind("SubmittedOn") %>'
                      ToolTip="Value of Submitted On."
                      Enabled="False"
                      Width="168px"
                      CssClass="dmytxt"
                      runat="server" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-4">
                    <asp:Label ID="L_ReceiptID" runat="server" Text="IDMS Receipt :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_ReceiptID"
                      Text='<%# Bind("ReceiptID") %>'
                      ToolTip="Value of IDMS Receipt."
                      Enabled="False"
                      Width="80px"
                      CssClass="dmytxt"
                      runat="server" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-4">
                    <asp:Label ID="L_ReceiptRevision" runat="server" Text="IDMS Revision :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_ReceiptRevision"
                      Text='<%# Bind("ReceiptRevision") %>'
                      ToolTip="Value of IDMS Revision."
                      Enabled="False"
                      Width="48px"
                      CssClass="dmytxt"
                      runat="server" />
                  </div>
                </div>
                <div class="row" style="display: none;">
                  <div class="col-sm-4">
                    <asp:Label ID="L_AcknowledgedOn" runat="server" Text="Acknowledged On :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_AcknowledgedOn"
                      Text='<%# Bind("AcknowledgedOn") %>'
                      ToolTip="Value of Acknowledged On."
                      Enabled="False"
                      Width="168px"
                      CssClass="dmytxt"
                      runat="server" />
                  </div>
                </div>
                <div class="row" style="display: none;">
                  <div class="col-sm-4">
                    <asp:Label ID="L_DistributedOn" runat="server" Text="Distributed On :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_DistributedOn"
                      Text='<%# Bind("DistributedOn") %>'
                      ToolTip="Value of Distributed On."
                      Enabled="False"
                      Width="168px"
                      CssClass="dmytxt"
                      runat="server" />
                  </div>
                </div>
                <div class="row" style="display: none;">
                  <div class="col-sm-4">
                    <asp:Label ID="L_EValuatedOn" runat="server" Text="Evaluated On :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_EValuatedOn"
                      Text='<%# Bind("EValuatedOn") %>'
                      ToolTip="Value of Evaluated On."
                      Enabled="False"
                      Width="168px"
                      CssClass="dmytxt"
                      runat="server" />
                  </div>
                </div>
                <div class="row" style="display: none;">
                  <div class="col-sm-4">
                    <asp:Label ID="L_EvaluatedBy" runat="server" Text="Evaluated By :" />&nbsp;
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox
                      ID="F_EvaluatedBy"
                      Width="72px"
                      Text='<%# Bind("EvaluatedBy") %>'
                      Enabled="False"
                      ToolTip="Value of Evaluated By."
                      CssClass="dmyfktxt"
                      runat="Server" />
                    <asp:Label
                      ID="F_EvaluatedBy_Display"
                      Text='<%# Eval("aspnet_users1_UserFullName") %>'
                      CssClass="myLbl"
                      runat="Server" />
                  </div>
                </div>
            </EditItemTemplate>
          </asp:FormView>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  <asp:ObjectDataSource
    ID="ODSpowOffers"
    DataObjectTypeName="SIS.POW.powOffers"
    SelectMethod="powOffersGetByID"
    UpdateMethod="UZ_powOffersUpdate"
    DeleteMethod="UZ_powOffersDelete"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powOffers"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="TSID" Name="TSID" Type="Int32" />
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="EnquiryID" Name="EnquiryID" Type="Int32" />
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecordID" Name="RecordID" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>
