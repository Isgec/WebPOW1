<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_powTechnicalSpecifications.aspx.vb" Inherits="AF_powTechnicalSpecifications" title="Add: Technical Specifications" %>
<asp:Content ID="CPHpowTechnicalSpecifications" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowTechnicalSpecifications" runat="server" Text="&nbsp;Add: Technical Specifications"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowTechnicalSpecifications" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowTechnicalSpecifications"
            ToolType="lgNMAdd"
            InsertAndStay="False"
            AfterInsertURL="~/POW_Main/App_Edit/EF_powTechnicalSpecifications.aspx"
            ValidationGroup="powTechnicalSpecifications"
            runat="server" />
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12">
          <asp:FormView ID="FVpowTechnicalSpecifications"
            runat="server"
            Width="100%"
            DataKeyNames="TSID"
            DataSourceID="ODSpowTechnicalSpecifications"
            DefaultMode="Insert" CssClass="sis_formview">
            <InsertItemTemplate>
              <div class="row">
                <div class="col-sm-12">
                  <asp:Label ID="L_ErrMsgpowTechnicalSpecifications" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_TSID" ForeColor="#CC6633" runat="server" Text="TSID :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_TSID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powTechnicalSpecifications"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Technical Specification Description."
                    MaxLength="100"
                    Width="300px"
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
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="powTechnicalSpecifications"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter Additional E-MailIDs."
                    MaxLength="500"
                    Width="300px"
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
    ID="ODSpowTechnicalSpecifications"
    DataObjectTypeName="SIS.POW.powTechnicalSpecifications"
    InsertMethod="powTechnicalSpecificationsInsert"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powTechnicalSpecifications"
    SelectMethod="GetNewRecord"
    runat="server"></asp:ObjectDataSource>
</asp:Content>
