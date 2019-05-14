<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_powTSTypes.aspx.vb" Inherits="GF_powTSTypes" title="Maintain List: TS Types" %>
<asp:Content ID="CPHpowTSTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpowTSTypes" runat="server" Text="&nbsp;List: TS Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpowTSTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpowTSTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/POW_Main/App_Edit/EF_powTSTypes.aspx"
      AddUrl = "~/POW_Main/App_Create/AF_powTSTypes.aspx"
      ValidationGroup = "powTSTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpowTSTypes" runat="server" AssociatedUpdatePanelID="UPNLpowTSTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpowTSTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSpowTSTypes" DataKeyNames="TSTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TS TypeID" SortExpression="TSTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelTSTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TSTypeID") %>'></asp:Label>
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
      ID = "ODSpowTSTypes"
      runat = "server"
      DataObjectTypeName = "SIS.POW.powTSTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "powTSTypesSelectList"
      TypeName = "SIS.POW.powTSTypes"
      SelectCountMethod = "powTSTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpowTSTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
