<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_powRecordTypes.aspx.vb" Inherits="GF_powRecordTypes" title="Maintain List: Record Types" %>
<asp:Content ID="CPHpowRecordTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpowRecordTypes" runat="server" Text="&nbsp;List: Record Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpowRecordTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpowRecordTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/POW_Main/App_Edit/EF_powRecordTypes.aspx"
      AddUrl = "~/POW_Main/App_Create/AF_powRecordTypes.aspx"
      ValidationGroup = "powRecordTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpowRecordTypes" runat="server" AssociatedUpdatePanelID="UPNLpowRecordTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpowRecordTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSpowRecordTypes" DataKeyNames="RecordTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Record Type ID" SortExpression="RecordTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelRecordTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RecordTypeID") %>'></asp:Label>
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
      ID = "ODSpowRecordTypes"
      runat = "server"
      DataObjectTypeName = "SIS.POW.powRecordTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "powRecordTypesSelectList"
      TypeName = "SIS.POW.powRecordTypes"
      SelectCountMethod = "powRecordTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpowRecordTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
