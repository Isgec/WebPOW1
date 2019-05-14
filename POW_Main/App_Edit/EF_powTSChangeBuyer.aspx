<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powTSChangeBuyer.aspx.vb" Inherits="EF_powTSChangeBuyer" title="Edit: Change Buyer" %>
<asp:Content ID="CPHpowTSChangeBuyer" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowTSChangeBuyer" runat="server" Text="&nbsp;Edit: Change Buyer"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowTSChangeBuyer" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowTSChangeBuyer"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnableDelete="False"
            ValidationGroup="powTSChangeBuyer"
            runat="server" />
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12">
          <asp:FormView ID="FVpowTSChangeBuyer"
            runat="server"
            Width="100%"
            DataKeyNames="TSID"
            DataSourceID="ODSpowTSChangeBuyer"
            DefaultMode="Edit">
            <EditItemTemplate>
              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_TSID" runat="server" ForeColor="#CC6633" Text="TSID :" /><span style="color: red">*</span></b>
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
                  <asp:Label ID="L_TSTypeID" runat="server" Text="TS Type :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_TSTypeID"
                    Width="88px"
                    Text='<%# Bind("TSTypeID") %>'
                    Enabled="False"
                    ToolTip="Value of TS Type."
                    CssClass="dmyfktxt"
                    runat="Server" />
                  <asp:Label
                    ID="F_TSTypeID_Display"
                    Text='<%# Eval("POW_TSTypes3_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_TSDescription" runat="server" Text="TS Description :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_TSDescription"
                    Text='<%# Bind("TSDescription") %>'
                    ToolTip="Value of TS Description."
                    Enabled="False"
                    Width="300px"
                    CssClass="dmytxt"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_AdditionalEMailIDs" runat="server" Text="Additional E-MailIDs :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_AdditionalEMailIDs"
                    Text='<%# Bind("AdditionalEMailIDs") %>'
                    ToolTip="Value of Additional E-MailIDs."
                    Enabled="False"
                    Width="300px"
                    CssClass="dmytxt"
                    runat="server" />
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
                  <asp:Label ID="L_CreatedBy" runat="server" Text="Buyer :" /><span style="color: red">*</span>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_CreatedBy"
                    CssClass="myfktxt"
                    Text='<%# Bind("CreatedBy") %>'
                    AutoCompleteType="None"
                    Width="72px"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Buyer."
                    ValidationGroup="powTSChangeBuyer"
                    onblur="script_powTSChangeBuyer.validate_CreatedBy(this);"
                    runat="Server" />
                  <asp:RequiredFieldValidator
                    ID="RFVCreatedBy"
                    runat="server"
                    ControlToValidate="F_CreatedBy"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="powTSChangeBuyer"
                    SetFocusOnError="true" />
                  <asp:Label
                    ID="F_CreatedBy_Display"
                    Text='<%# Eval("aspnet_users1_UserFullName") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACECreatedBy"
                    BehaviorID="B_ACECreatedBy"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="CreatedByCompletionList"
                    TargetControlID="F_CreatedBy"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_powTSChangeBuyer.ACECreatedBy_Selected"
                    OnClientPopulating="script_powTSChangeBuyer.ACECreatedBy_Populating"
                    OnClientPopulated="script_powTSChangeBuyer.ACECreatedBy_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
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
    ID="ODSpowTSChangeBuyer"
    DataObjectTypeName="SIS.POW.powTSChangeBuyer"
    SelectMethod="powTSChangeBuyerGetByID"
    UpdateMethod="powTSChangeBuyerUpdate"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powTSChangeBuyer"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="TSID" Name="TSID" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>
