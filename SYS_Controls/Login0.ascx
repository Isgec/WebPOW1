<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Login0.ascx.vb" Inherits="Login0" %>
  <asp:LoginView ID="LoginFormView1" runat="server">
    <AnonymousTemplate>
      <asp:Login ID="Login0" OnLoggedIn="LoggedIn" OnLoginError="LoginError" OnLoggingIn="LoggingIn" runat="server">
        <LayoutTemplate>
          <asp:Panel ID="panel1" runat="server" DefaultButton="LoginButton">
            <table >
              <tr>
                <td>
                  <asp:Label runat="server" Font-Size="12px" Text="Login ID:"></asp:Label>
                </td>
                <td>
                  <asp:TextBox ID="UserName" runat="server" CssClass="form-control" Font-Size="12px" MaxLength="8" Width="60px"></asp:TextBox>
                </td>
                <td>
                  <asp:Label ID="Label1" runat="server" Font-Size="12px" Text="Password:"></asp:Label>
                </td>
                <td>
                  <asp:TextBox ID="Password" runat="server" CssClass="form-control" MaxLength="20" Font-Size="12px" TextMode="Password" Width="60px"></asp:TextBox>
                </td>
                <td>
                  <asp:Button ID="LoginButton" CssClass="btn btn-sm btn-primary"  runat="server" CommandName="Login" ValidationGroup="ctl00$ctl00$Login0" Text="Sign In" />
                </td>
              </tr>
              <tr>
                <td colspan="5" style="color:#66FF66; font-weight: bold; background-color: Black">
                  <asp:Label ID="FailureText" runat="server"></asp:Label>
                </td>
              </tr>
            </table>
          </asp:Panel>
        </LayoutTemplate>
      </asp:Login>
    </AnonymousTemplate>
    <LoggedInTemplate>
      <table>
        <tr>
          <td>
            <LGM:Informations ID="Informations1" Visible="false" runat="server" />
          </td>
          <td style="vertical-align: top; text-align: right;">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sm btn-outline-warning" PostBackUrl="~/ChangePassword.aspx" Text="Change Password" /><br />
              <asp:LoginStatus ID="LoginStatus1" runat="server" Width="86px" CssClass="btn btn-sm btn-outline-primary" OnLoggedOut="LoggedOut" LoginText="Sign In" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" LogoutText="  Sign Out  " />
          </td>
        </tr>
      </table>
    </LoggedInTemplate>
  </asp:LoginView>
