<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="True" EnableEventValidation="false" CodeFile="bsLogin.aspx.vb" Inherits="bsLogin" title="Login Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" ClientIDMode="Static" runat="Server">
  <div class="container">
    <div style="max-width: 400px; margin: 15px auto auto auto;" class="myborder">

      <div class="row text-center">
        <div class="col">
          <img alt="ISGEC" src="App_Themes/Default/Images/Isgec2.JPG" />
        </div>
      </div>
      <asp:Login ID="Login0" OnLoggedIn="LoggedIn" Width="100%" runat="server">
        <LayoutTemplate>
          <asp:Panel ID="pnlLogin" runat="server" DefaultButton="cmdLogin">
          <div class="form-group" >
            <label for="UserName">Login ID:</label>
            <asp:TextBox CssClass="form-control" id="UserName" ClientIDMode="Static" runat="server" required="required" maxlength="8" ValidationGroup="login" />
          </div>
          <div class="form-group">
            <label for="Password">Password:</label>
            <asp:TextBox TextMode="Password" class="form-control" id="Password" ClientIDMode="Static" runat="server" required="required" maxlength="20"  ValidationGroup="login" />
          </div>
          <div class="row text-center">
            <div class="col">
              <asp:Button ID="cmdLogin" CommandName="Login" ClientIDMode="Static" CssClass="btn btn-sm btn-primary" runat="server" Text="Sign In"  ValidationGroup="login" />
            </div>
          </div>
          </asp:Panel>
        </LayoutTemplate>
      </asp:Login>
      <div id="msg" runat="server"></div>
    </div>
  </div>
</asp:Content>

