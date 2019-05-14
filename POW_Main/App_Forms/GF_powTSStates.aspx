<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_powTSStates.aspx.vb" Inherits="GF_powTSStates" title="Maintain List: TS States" %>
<asp:Content ID="CPHpowTSStates" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpowTSStates" runat="server" Text="&nbsp;List: TS States"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpowTSStates" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpowTSStates"
      ToolType = "lgNMGrid"
      EditUrl = "~/POW_Main/App_Edit/EF_powTSStates.aspx"
      AddUrl = "~/POW_Main/App_Create/AF_powTSStates.aspx"
      ValidationGroup = "powTSStates"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpowTSStates" runat="server" AssociatedUpdatePanelID="UPNLpowTSStates" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpowTSStates" SkinID="gv_silver" runat="server" DataSourceID="ODSpowTSStates" DataKeyNames="StatusID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status ID" SortExpression="StatusID">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpowTSStates"
      runat = "server"
      DataObjectTypeName = "SIS.POW.powTSStates"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "powTSStatesSelectList"
      TypeName = "SIS.POW.powTSStates"
      SelectCountMethod = "powTSStatesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpowTSStates" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
