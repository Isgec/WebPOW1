<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_powTSIndents.aspx.vb" Inherits="EF_powTSIndents" title="Edit: TS Indents" %>
<asp:Content ID="CPHpowTSIndents" ContentPlaceHolderID="cph1" runat="Server">
  <div class="row">
    <div class="col-sm-12 caption">
      <asp:Label ID="LabelpowTSIndents" runat="server" Text="&nbsp;Edit: TS Indents"></asp:Label>
    </div>
  </div>
  <asp:UpdatePanel ID="UPNLpowTSIndents" runat="server">
    <ContentTemplate>
      <div class="row">
        <div class="col-sm-12">
          <LGM:ToolBar0
            ID="TBLpowTSIndents"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnableDelete="False"
            ValidationGroup="powTSIndents"
            runat="server" />
        </div>
      </div>
      <div class="row">
        <div class="col-sm-12">
          <asp:FormView ID="FVpowTSIndents"
            runat="server"
            Width="100%"
            DataKeyNames="TSID,SerialNo"
            DataSourceID="ODSpowTSIndents"
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
                    Text='<%# Eval("POW_TechnicalSpecifications4_TSDescription") %>'
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
                  <asp:TextBox ID="F_SerialNo"
                    Text='<%# Bind("SerialNo") %>'
                    ToolTip="Value of Serial No."
                    Enabled="False"
                    CssClass="mypktxt"
                    Width="88px"
                    Style="text-align: right"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_IndentNo" runat="server" Text="Indent No :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_IndentNo"
                    Text='<%# Bind("IndentNo") %>'
                    ToolTip="Value of Indent No."
                    Enabled="False"
                    Width="80px"
                    CssClass="dmytxt"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_IndentLine" runat="server" Text="Indent Line :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_IndentLine"
                    Text='<%# Bind("IndentLine") %>'
                    ToolTip="Value of Indent Line."
                    Enabled="False"
                    Width="88px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_LotItem" runat="server" Text="LotItem :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox ID="F_LotItem"
                    Text='<%# Bind("LotItem") %>'
                    ToolTip="Value of LotItem."
                    Enabled="False"
                    Width="384px"
                    CssClass="dmytxt"
                    runat="server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_IndenterID" runat="server" Text="Indenter :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_IndenterID"
                    Width="72px"
                    Text='<%# Bind("IndenterID") %>'
                    Enabled="False"
                    ToolTip="Value of Indenter."
                    CssClass="dmyfktxt"
                    runat="Server" />
                  <asp:Label
                    ID="F_IndenterID_Display"
                    Text='<%# Eval("aspnet_users1_UserFullName") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_ProjectID"
                    Width="56px"
                    Text='<%# Bind("ProjectID") %>'
                    Enabled="False"
                    ToolTip="Value of Project."
                    CssClass="dmyfktxt"
                    runat="Server" />
                  <asp:Label
                    ID="F_ProjectID_Display"
                    Text='<%# Eval("IDM_Projects2_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-4">
                  <asp:Label ID="L_ElementID" runat="server" Text="Element :" />&nbsp;
                </div>
                <div class="col-sm-8">
                  <asp:TextBox
                    ID="F_ElementID"
                    Width="72px"
                    Text='<%# Bind("ElementID") %>'
                    Enabled="False"
                    ToolTip="Value of Element."
                    CssClass="dmyfktxt"
                    runat="Server" />
                  <asp:Label
                    ID="F_ElementID_Display"
                    Text='<%# Eval("IDM_WBS3_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                </div>
              </div>
              <div class="row">
                <div class="col-sm-12">
                  <legend>
                    <asp:Label ID="LabelpowTSIndentDocuments" runat="server" Text="&nbsp;List: Indent Documents"></asp:Label>
                  </legend>
                  <asp:UpdatePanel ID="UPNLpowTSIndentDocuments" runat="server">
                    <ContentTemplate>
                      <LGM:ToolBar0
                        ID="TBLpowTSIndentDocuments"
                        ToolType="lgNMGrid"
                        EditUrl="~/POW_Main/App_Edit/EF_powTSIndentDocuments.aspx"
                        EnableAdd="False"
                        EnableExit="false"
                        ValidationGroup="powTSIndentDocuments"
                        runat="server" />
                      <asp:UpdateProgress ID="UPGSpowTSIndentDocuments" runat="server" AssociatedUpdatePanelID="UPNLpowTSIndentDocuments" DisplayAfter="100">
                        <ProgressTemplate>
                          <span style="color: #ff0033">Loading...</span>
                        </ProgressTemplate>
                      </asp:UpdateProgress>
                      <asp:GridView ID="GVpowTSIndentDocuments" SkinID="gv_silver" runat="server" DataSourceID="ODSpowTSIndentDocuments" DataKeyNames="TSID,SerialNo,DocNo">
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
                          <asp:TemplateField HeaderText="Doc No" SortExpression="DocNo">
                            <ItemTemplate>
                              <asp:Label ID="LabelDocNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="40px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Document ID" SortExpression="DocumentID">
                            <ItemTemplate>
                              <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="100px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Revision" SortExpression="DocumentRevision">
                            <ItemTemplate>
                              <asp:Label ID="LabelDocumentRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentRevision") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="alignCenter" />
                            <HeaderStyle CssClass="alignCenter" Width="50px" />
                          </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                          <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                        </EmptyDataTemplate>
                      </asp:GridView>
                      <asp:ObjectDataSource
                        ID="ODSpowTSIndentDocuments"
                        runat="server"
                        DataObjectTypeName="SIS.POW.powTSIndentDocuments"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="UZ_powTSIndentDocumentsSelectList"
                        TypeName="SIS.POW.powTSIndentDocuments"
                        SelectCountMethod="powTSIndentDocumentsSelectCount"
                        SortParameterName="OrderBy" EnablePaging="True">
                        <SelectParameters>
                          <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
                          <asp:ControlParameter ControlID="F_TSID" PropertyName="Text" Name="TSID" Type="Int32" Size="10" />
                          <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                          <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                        </SelectParameters>
                      </asp:ObjectDataSource>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVpowTSIndentDocuments" EventName="PageIndexChanged" />
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
    ID="ODSpowTSIndents"
    DataObjectTypeName="SIS.POW.powTSIndents"
    SelectMethod="powTSIndentsGetByID"
    UpdateMethod="UZ_powTSIndentsUpdate"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.POW.powTSIndents"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="TSID" Name="TSID" Type="Int32" />
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>
