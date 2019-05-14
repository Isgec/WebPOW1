<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_powOffers.aspx.vb" Inherits="AF_powOffers" title="Create: Offers" %>
<asp:Content ID="CPHpowOffers" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowOffers" runat="server" Text="&nbsp;Create: Message"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowOffers" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowOffers"
            ToolType="lgNMAdd"
            InsertAndStay="False"
            EnableForward="true"
            AfterInsertURL="~/POW_Main/App_Edit/EF_powOffers.aspx"
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
            DefaultMode="Insert" CssClass="sis_formview">
            <InsertItemTemplate>
              <div class="row">
                <div class="col-sm-12">
                  <asp:Label ID="L_ErrMsgpowOffers" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_TSID" ForeColor="#CC6633" runat="server" Text="TSID :" /><span style="color: red">*</span></b>
                  <asp:CheckBox ID="F_ForSupplier" runat="server" Checked='<%# Bind("ForSupplier") %>' Style="display: none;" />
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_TSID"
                    CssClass="mypktxt"
                    Width="88px"
                    Text='<%# Bind("TSID") %>'
                    AutoCompleteType="None"
                    Enabled="false"
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
                    <asp:Label ID="L_EnquiryID" ForeColor="#CC6633" runat="server" Text="Enquiry ID :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_EnquiryID"
                    CssClass="mypktxt"
                    Width="88px"
                    Text='<%# Bind("EnquiryID") %>'
                    AutoCompleteType="None"
                    Enabled="false"
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
                    <asp:Label ID="L_RecordID" ForeColor="#CC6633" runat="server" Text="Record ID :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_RecordID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
                    RequiredFieldErrorMessage=""
                    runat="Server" />
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
                    ValidationGroup="powOffers"
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
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powOffers"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for E-Mail Body."
                    MaxLength="4000"
                    Width="300px"
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
    ID="ODSpowOffers"
    DataObjectTypeName="SIS.POW.powOffers"
    InsertMethod="UZ_powOffersInsert"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powOffers"
    SelectMethod="GetNewRecord"
    runat="server"></asp:ObjectDataSource>
</asp:Content>
