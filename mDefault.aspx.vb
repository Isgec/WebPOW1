Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Security.Principal
Imports System.Security
Partial Class mLGDefault
  Inherits System.Web.UI.Page
  Protected Sub AuthenticateAndRedirect(ByVal UserID As String, ByVal URL As String)
    HttpContext.Current.Session("LoginID") = UserID
    Try
      Dim pw As String = SIS.SYS.Utilities.SessionManager.GetPassword(UserID)
      If Membership.ValidateUser(UserID, pw) Then
      End If
      HttpContext.Current.Session("IsAuthenticated") = True
      Dim isPersistent As Boolean = True
      Dim userData As String = "ApplicationSpecific data for this user."
      Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1,
        UserID,
        DateTime.Now,
        DateTime.Now.AddMinutes(1),
        isPersistent,
        userData,
        FormsAuthentication.FormsCookiePath)
      ' Encrypt the ticket.
      Dim encTicket As String = FormsAuthentication.Encrypt(ticket)
      ' Create the cookie. 
      HttpContext.Current.Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, encTicket))
      SIS.SYS.Utilities.SessionManager.InitializeEnvironment(UserID)
      Me.msg.Visible = True
      msg.InnerHtml = "<a id='lnk' href='" & URL & "'></a><script type='text/javascript'> $get('lnk').click();</script>"

      'Response.Redirect(URL)
    Catch ex As Exception
    End Try
  End Sub
  Private Sub mLGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If Not Page.User.Identity.IsAuthenticated Then
      If Request.QueryString("EnqKey") IsNot Nothing Then
        Dim Key As String = Request.QueryString("EnqKey")
        Dim enq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.GetByEnquiryKey(Key)
        Dim UserID As String = enq.SupplierLoginID
        Dim RedirectURL As String = "POW_Main/App_Create/AF_powVendorOffers.aspx?TSID=" & enq.TSID & "&EnquiryID=" & enq.EnquiryID
        AuthenticateAndRedirect(UserID, RedirectURL)
      Else
        Me.msg.Visible = True
        msg.InnerHtml = "<div class='btn btn-danger'>Invalid Link</div>"
      End If
    End If
  End Sub

End Class
