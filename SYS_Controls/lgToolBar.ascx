<%@ Control Language="VB" AutoEventWireup="True" CodeFile="lgToolBar.ascx.vb" Inherits="lgToolBar" %>
  <div class="row" id="tblDiv" runat="server">
    <div class="col-sm-4">
				<table  id="tdDefault" runat="server">
					<tr>
						<td>
							<asp:LinkButton ID="CmdExit" CssClass="btn btn-sm btn-success" ToolTip="Exit" AccessKey="X" runat="server"><i class="fa fa-1x  fa fa-long-arrow-left"></i></asp:LinkButton>
						</td>
						<td>
							<asp:LinkButton ID="CmdSave" CssClass="btn btn-sm btn-primary" ToolTip="Save" AccessKey="S" runat="server"><i class="fa fa-1x  fa fa-save"></i></asp:LinkButton>
						</td>
						<td>
							<asp:LinkButton ID="CmdAdd" CssClass="btn btn-sm btn-warning" ToolTip="Add New Record" AccessKey="A" runat="server" ><i class="fa fa-file-text-o"></i></asp:LinkButton>
						</td>
						<td>
							<asp:LinkButton ID="CmdDelete" CssClass="btn btn-sm btn-danger" ToolTip="Delete" AccessKey="D" runat="server" ><i class="fa fa-remove"></i></asp:LinkButton>
						</td>
						<td>
							<asp:LinkButton ID="CmdForward" CssClass="btn btn-sm btn-info" ToolTip="Send" AccessKey="F" runat="server" ><i class="fa fa-mail-forward"></i></asp:LinkButton>
						</td>
						<td>
							<asp:LinkButton ID="CmdReturn" CssClass="btn btn-sm btn-danger" ToolTip="Return" AccessKey="R" runat="server" ><i class="fa fa-mail-reply"></i></asp:LinkButton>
						</td>
						<td>
							<asp:LinkButton ID="CmdPrint" CssClass="btn btn-sm btn-warning" ToolTip="Print" AccessKey="O" runat="server" Enabled="false" ><i class="fa fa-print"></i></asp:LinkButton>
						</td>
					</tr>
				</table>
    </div>
    <div class="col-sm-5">
				<table  id="tdPage" runat="server">
					<tr>
						<td>
							<asp:LinkButton ID="navFirst" CssClass="btn btn-sm btn-outline-dark" ToolTip="First" AccessKey="T" runat="server"><i class="fa fa-fast-backward"></i></asp:LinkButton>
						</td>
						<td>
							<asp:LinkButton ID="navPrev" CssClass="btn btn-sm btn-outline-dark" ToolTip="Previous" AccessKey="P" runat="server"><i class="fa fa-backward"></i></asp:LinkButton>
						</td>
						<td>
							<asp:TextBox 
                ID="_CurrentPage" 
                runat="server" 
                CssClass="btn-sm btn-outline-dark form-control" 
                style="text-align:right;" 
                MaxLength="5" 
                Width="40px"                 
                Text="1" 
                ValidationGroup="currentpage" 
                AutoPostBack="True" 
                onfocus="return this.select();"  
                onblur="return dc(this,0)" />
						</td>
						<td id="abc" runat="server">
							<asp:Label ID="Label1" runat="server" class="btn-sm btn-outline-info" Text="#OF" />
						</td>
						<td>
							<asp:Label ID="_TotalPages" runat="server" class="btn-sm btn-outline-info" Width="40px" Style="text-align: right;" />
						</td>
						<td>
							<asp:Label ID="Label2" runat="server" class="btn-sm btn-outline-info" Text="Pages" />
						</td>
						<td>
							<asp:LinkButton ID="navNext" CssClass="btn btn-sm btn-outline-dark" ToolTip="Next" AccessKey="N" runat="server"><i class="fa fa-forward"></i></asp:LinkButton>
						</td>
						<td>
							<asp:LinkButton ID="navLast" CssClass="btn btn-sm btn-outline-dark" ToolTip="Last" AccessKey="L" runat="server"><i class="fa fa-fast-forward"></i></asp:LinkButton>
						</td>
						<td style="display:none;">
							<asp:TextBox 
                ID="_PageSize" 
                runat="server" 
                onfocus="return this.select();" 
                onblur="return dc(this,0);" 
                style="text-align:right;" 
                CssClass="btn-sm btn-outline-dark form-control" 
                MaxLength="5" 
                Width="60px" 
                ValidationGroup="currentpage" />
						</td> 
						<td style="display:none;">
							<asp:LinkButton ID="_PageSizeButton" runat="server" CssClass="btn btn-sm btn-outline-info" CausesValidation="False" CommandName="PageSize" ValidationGroup="currentpage">/PAGE</asp:LinkButton>
						</td>
					</tr>
				</table>
    </div>
    <div class="col-sm-3">
      <asp:Panel ID="_pnlSearch" runat="server" DefaultButton="CmdSearch">
				<table  id="tdSearch" runat="server" >
					<tr>
						<td>
							<asp:CheckBox ID="DisableSearch" runat="server" CssClass="btn-sm btn-outline-info form-control" Enabled="false" AutoPostBack="true" ToolTip="Uncheck for normal view." />
						</td>
						<td>
							<asp:TextBox 
                ID="SearchTextBox" 
                runat="server" 
                CssClass="btn-sm btn-outline-info form-control" 
                onfocus="return this.select();" 
                ToolTip="Enter keywords to search." 
                placeholder="[Search]"
                ValidationGroup="searchvalidationgroup" 
                MaxLength="250" />
							<asp:RequiredFieldValidator ID="rfvst" runat="server" ControlToValidate="SearchTextBox" Display="none" EnableClientScript="true" ValidationGroup="searchvalidationgroup" SetFocusOnError="true" />
						</td>
						<td>
							<asp:LinkButton ID="CmdSearch" CssClass="btn btn-sm btn-outline-info" runat="server" ToolTip="Click to search" ValidationGroup="searchvalidationgroup" ><i class="fa fa-1x fa-search"></i> </asp:LinkButton>
						</td>
					</tr>
				</table>
        </asp:Panel>
    </div>
  </div>
