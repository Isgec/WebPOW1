Partial Class bsLogin
  Inherits System.Web.UI.Page
  Public Property RedirectURL As String
    Get
      If ViewState("RedirectURL") IsNot Nothing Then
        Return CType(ViewState("RedirectURL"), String)
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("RedirectURL", value)
    End Set
  End Property
  Public Property UserID As String
    Get
      If ViewState("UserID") IsNot Nothing Then
        Return CType(ViewState("UserID"), String)
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("UserID", value)
    End Set
  End Property
  Public Sub LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim oLogin As System.Web.UI.WebControls.Login = CType(sender, System.Web.UI.WebControls.Login)
    UserID = oLogin.UserName
    SIS.SYS.Utilities.SessionManager.InitializeEnvironment(UserID)
    If RedirectURL = "" Then RedirectURL = "~/Default.aspx"
    Response.Redirect(RedirectURL)
    'If RedirectURL <> "" Then
    '  msg.InnerHtml = "<a id='lnk' href='" & RedirectURL & "'></a><script type='text/javascript'> $get('lnk').click();</script>"
    'End If
  End Sub

  Private Sub bsLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
    'msg.InnerText = Session("LoginID")
  End Sub

  Private Sub Login0_PreRender(sender As Object, e As EventArgs) Handles Login0.PreRender
    If Not Page.User.Identity.IsAuthenticated Then
      If Not Page.IsPostBack Then
        If Request.QueryString("EnqKey") IsNot Nothing Then
          Dim Key As String = Request.QueryString("EnqKey")

          Dim enq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.GetByEnquiryKey(Key)
          If enq IsNot Nothing Then
            UserID = enq.SupplierLoginID
            Dim pw As String = SIS.SYS.Utilities.SessionManager.GetPassword(UserID)
            RedirectURL = "~/POW_Main/App_Create/AF_powVendorOffers.aspx?TSID=" & enq.TSID & "&EnquiryID=" & enq.EnquiryID
            CType(Login0.FindControl("UserName"), TextBox).Text = UserID
            'CType(Login0.FindControl("Password"), TextBox).Text = pw
            msg.InnerHtml = "<script type='text/javascript'>$get('Password').value='" & pw & "'; $get('cmdLogin').click();</script>"
          End If
          CType(Login0.FindControl("pnlLogin"), Panel).Attributes.Add("style", "display:none;")
          'Else
          '  'Temporary arrange, otherwise use Device ID to validate
          '  SIS.SYS.Utilities.SessionManager.InitializeEnvironment(UserID)
          '  If RedirectURL = "" Then RedirectURL = "~/Default.aspx"
          '  Response.Redirect(RedirectURL)
        End If
      End If
    End If
  End Sub
End Class
