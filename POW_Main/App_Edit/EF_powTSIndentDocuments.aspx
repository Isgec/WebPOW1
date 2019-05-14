<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powTSIndentDocuments.aspx.vb" Inherits="EF_powTSIndentDocuments" title="Edit: Indent Documents" %>
<asp:Content ID="CPHpowTSIndentDocuments" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowTSIndentDocuments" runat="server" Text="&nbsp;Edit: Indent Documents"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowTSIndentDocuments" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowTSIndentDocuments"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnableDelete="False"
            ValidationGroup="powTSIndentDocuments"
            runat="server" />
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12">
          <asp:FormView ID="FVpowTSIndentDocuments"
            runat="server"
            Width="100%"
            DataKeyNames="TSID,SerialNo,DocNo"
            DataSourceID="ODSpowTSIndentDocuments"
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
                    Text='<%# Eval("POW_TechnicalSpecifications1_TSDescription") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_SerialNo"
                    Width="88px"
                    Text='<%# Bind("SerialNo") %>'
                    CssClass="mypktxt"
                    Enabled="False"
                    ToolTip="Value of Serial No."
                    runat="Server" />
                  <asp:Label
                    ID="F_SerialNo_Display"
                    Text='<%# Eval("POW_TSIndents2_IndentNo") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <b>
                    <asp:Label ID="L_DocNo" runat="server" ForeColor="#CC6633" Text="Doc No :" /><span style="color: red">*</span></b>
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_DocNo"
                    Text='<%# Bind("DocNo") %>'
                    ToolTip="Value of Doc No."
                    Enabled="False"
                    CssClass="mypktxt"
                    Width="88px"
                    Style="text-align: right"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_DocumentID"
                    Text='<%# Bind("DocumentID") %>'
                    ToolTip="Value of Document ID."
                    Enabled="False"
                    Width="408px"
                    CssClass="dmytxt"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_DocumentRevision" runat="server" Text="Revision :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_DocumentRevision"
                    Text='<%# Bind("DocumentRevision") %>'
                    ToolTip="Value of Revision."
                    Enabled="False"
                    Width="48px"
                    CssClass="dmytxt"
                    runat="server" />
                </div>
              </div>
            </EditItemTemplate>
          </asp:FormView>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  <asp:ObjectDataSource
    ID="ODSpowTSIndentDocuments"
    DataObjectTypeName="SIS.POW.powTSIndentDocuments"
    SelectMethod="powTSIndentDocumentsGetByID"
    UpdateMethod="UZ_powTSIndentDocumentsUpdate"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powTSIndentDocuments"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="TSID" Name="TSID" Type="Int32" />
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocNo" Name="DocNo" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>
