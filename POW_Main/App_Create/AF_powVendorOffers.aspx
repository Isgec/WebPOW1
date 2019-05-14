<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_powVendorOffers.aspx.vb" Inherits="AF_powVendorOffers" title="Supplier: Communications" %>
<asp:Content ID="CPHpowVendorOffers" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowVendorOffers" runat="server" Text="&nbsp;Supplier: Create & Send Mail"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowVendorOffers" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowVendorOffers"
            ToolType="lgNMAdd"
            InsertAndStay="False"
            AfterInsertURL="~/POW_Main/App_Edit/EF_powVendorOffers.aspx"
            ValidationGroup="powVendorOffers"
            EnableForward="true"
            runat="server" />
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12">
          <asp:FormView ID="FVpowVendorOffers"
            runat="server"
            Width="100%"
            DataKeyNames="TSID,EnquiryID,RecordID"
            DataSourceID="ODSpowVendorOffers"
            DefaultMode="Insert">
            <InsertItemTemplate>
              <div class="row">
                <div class="col-sm-12">
                  <asp:Label ID="L_ErrMsgpowVendorOffers" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                </div>
              </div>
              <div class="row" style="display: none;">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_TSID" ForeColor="#CC6633" runat="server" Text="TSID :" /></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_TSID"
                    CssClass="mypktxt"
                    Width="88px"
                    Text='<%# Bind("TSID") %>'
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
                      <asp:Label ID="L_EnquiryID" ForeColor="#CC6633" runat="server" Text="Enquiry ID :" /></b>
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox
                      ID="F_EnquiryID"
                      CssClass="mypktxt"
                      Width="88px"
                      Text='<%# Bind("EnquiryID") %>'
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
                      <asp:Label ID="Label2" ForeColor="#CC6633" runat="server" Text="Pl. select FROM E-Mail ID :" /></b>
                  </div>
                  <div class="col-sm-8">
                    <asp:RadioButtonList
                      ID="F_OptionsFromEMailID"
                      DataSource='<%# seDS %>'
                      SelectedValue='<%# Bind("SelectedFromEMailID") %>'
                      CssClass="mychk"
                      runat="server">
                    </asp:RadioButtonList>
                    <asp:TextBox
                      ID="F_FromEMailID"
                      Text='<%# Bind("FromEMailID") %>'
                      CssClass="mytxt"
                      Width="200px"
                      runat="Server" />
                  </div>
                </div>
                <div class="row" style="display: none;">
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
                      ValidationGroup="powVendorOffers"
                      onblur="this.value=this.value.replace(/\'/g,'');"
                      ToolTip="Enter E-Mail Subject."
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
                      ValidationGroup="powVendorOffers"
                      SetFocusOnError="true" />
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-4">
                    <asp:Label ID="L_EMailBody" runat="server" Text="E-Mail Message :" /><span style="color: red">*</span>
                  </div>
                  <div class="col-sm-8">
                    <asp:TextBox ID="F_EMailBody"
                      Text='<%# Bind("EMailBody") %>'
                      CssClass="mytxt"
                      onfocus="return this.select();"
                      ValidationGroup="powVendorOffers"
                      onblur="this.value=this.value.replace(/\'/g,'');"
                      ToolTip="Enter E-Mail Message."
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
                      ValidationGroup="powVendorOffers"
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
                    ValidationGroup="powVendorOffers"
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
    ID="ODSpowVendorOffers"
    DataObjectTypeName="SIS.POW.powVendorOffers"
    InsertMethod="UZ_powVendorOffersInsert"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powVendorOffers"
    SelectMethod="GetNewRecord"
    runat="server"></asp:ObjectDataSource>
</asp:Content>
