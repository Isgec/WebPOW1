<%@ Control Language="VB" AutoEventWireup="false" CodeFile="lgAttachments.ascx.vb" Inherits="lgAttachments" %>
<div id="outerDiv" runat="server">
  <script type="text/javascript">
    function show_submit() {
      showProcessingMPV();
      return true;
    }
  </script>
<asp:UpdatePanel ID="UPNLediAFile" runat="server">
  <ContentTemplate>
    <table style="display:none;">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_hndl" runat="server" Text="Handle :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_t_hndl"
            Text='<%# Handle %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="200"
            Width="100px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_indx" runat="server" Text="Index :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_t_indx"
            Text='<%# Index %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="50"
            Width="100px"
            runat="server" />
        </td>
      </tr>
    </table>
    <asp:LinkButton ID="cmdDownloadZip" runat="server" CssClass="btn btn-sm btn-success" OnClientClick='<%# GetSDownloadAllLink %>'>Download Zip &nbsp;<i class="fa fa-file-zip-o" style="font-size:16px; color:chartreuse;"></i></asp:LinkButton>
    <asp:GridView 
      ID="GVediAFile" 
      runat="server" 
      DataSourceID="ODSediAFile" 
      ShowHeader="false" 
      AutoGenerateColumns="false" 
      PageSize="99"
      PageIndex="0"
      GridLines="None"
      AlternatingRowStyle-BackColor="#ccffcc"
      AlternatingRowStyle-BorderColor="#ffccff"
      AlternatingRowStyle-BorderStyle="Solid"
      AlternatingRowStyle-BorderWidth="1pt"
      HeaderStyle-BackColor="#009999"
      HeaderStyle-ForeColor="#99ffcc"
      BorderColor="LightGray"
      BorderWidth="1pt"
      BorderStyle="Solid"
      DataKeyNames="t_drid">
      <Columns>
        <asp:TemplateField HeaderText="File">
          <ItemTemplate>
            <asp:LinkButton ID="Labelt_fnam" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("t_fnam") %>' OnClientClick='<%# EVal("GetDownloadLink") %>'></asp:LinkButton>
          </ItemTemplate>
        <HeaderStyle CssClass="alignCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DEL">
          <ItemTemplate>
            <asp:LinkButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>'><i class="fa fa-trash" style="font-size:18px;color:red"></i></asp:LinkButton>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <%--        <asp:TemplateField>
                  <ItemTemplate>
                    <asp:ImageButton ID="cmdDownload" ValidationGroup='<%# "Download" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DownloadWFVisible") %>' Enabled='<%# EVal("DownloadWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download" SkinID="Download" OnClientClick='<%# "return Page_ClientValidate(""Download" & Container.DataItemIndex & """) && confirm(""Download record ?"");" %>' CommandName="DownloadWF" CommandArgument='<%# Container.DataItemIndex %>' />
                  </ItemTemplate>
                  <ItemStyle CssClass="alignCenter" />
                  <HeaderStyle CssClass="alignCenter" Width="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Forward">
                  <ItemTemplate>
                    <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                  </ItemTemplate>
                  <ItemStyle CssClass="alignCenter" />
                  <HeaderStyle CssClass="alignCenter" Width="30px" />
                </asp:TemplateField>--%>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="*** No Attachment ***"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSediAFile"
      runat = "server"
      DataObjectTypeName = "SIS.EDI.ediAFile"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "ediAFileSelectList"
      TypeName = "SIS.EDI.ediAFile"
      SelectCountMethod = "ediAFileSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_t_hndl" PropertyName="Text" Name="t_hndl" Type="String" Size="200" />
        <asp:ControlParameter ControlID="F_t_indx" PropertyName="Text" Name="t_indx" Type="String" Size="50" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <div id="UploadDiv" runat="server">
      <%--One File Upload Hidden--%>
      <div style="display:none">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
            <asp:FileUpload ID="F_FileUpload" runat="server" />
            <asp:Button ID="cmdFileUpload" Text="Upload" runat="server" ToolTip="Click to upload." CommandName="tmplUpload" CommandArgument="" />
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdFileUpload" />
          </Triggers>
        </asp:UpdatePanel>
      </div>
      <%--Multifile upload Used--%>
      <div>
        <asp:UpdatePanel ID="UpdatePanelBulk" runat="server">
          <ContentTemplate>
            <input type="file" id="F_FileUploadBulk" class="btn btn-sm btn-success" runat="server" name="files[]" multiple="multiple" style="width: 150px" title="Browse Document Files" />
            <asp:LinkButton ID="cmdFileUploadBulk" runat="server" CssClass="btn btn-sm btn-success" ToolTip="Click to upload selected files." CommandName="filesUpload" CommandArgument='<%# PrimaryKey %>' ValidationGroup='<%# ValidationGroup %>'  CausesValidation='<%# ValidateClient %>' >Upload &nbsp;<i class="fa fa-upload" style="font-size:16px;color:chartreuse;"></i></asp:LinkButton>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdFileUploadBulk" />
          </Triggers>
        </asp:UpdatePanel>
      </div>
    </div>
  </ContentTemplate>
</asp:UpdatePanel>
  
</div>