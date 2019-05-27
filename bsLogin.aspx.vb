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
    If UserID = "" Then
      If oLogin.UserName <> "" Then
        UserID = oLogin.UserName
      Else
        UserID = CType(oLogin.FindControl("UserName"), TextBox).Text
      End If
    End If
    SIS.SYS.Utilities.SessionManager.InitializeEnvironment(UserID)
    If RedirectURL = "" Then RedirectURL = "~/Default.aspx"
    Response.Redirect(RedirectURL)
  End Sub
  Private Sub Login0_PreRender(sender As Object, e As EventArgs) Handles Login0.PreRender
    If Not Page.User.Identity.IsAuthenticated Then
      If Not Page.IsPostBack Then
        If Request.QueryString("EnqKey") IsNot Nothing Then
          'Called From Vendor E-Mail Link
          Dim Key As String = Request.QueryString("EnqKey")
          Dim enq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.GetByEnquiryKey(Key)
          If enq IsNot Nothing Then
            UserID = enq.SupplierLoginID
            Dim pw As String = SIS.SYS.Utilities.SessionManager.GetPassword(UserID)
            RedirectURL = "~/POW_Main/App_Create/AF_powVendorOffers.aspx?TSID=" & enq.TSID & "&EnquiryID=" & enq.EnquiryID
            CType(Login0.FindControl("UserName"), TextBox).Text = UserID
            msg.InnerHtml = "<script type='text/javascript'>$get('Password').value='" & pw & "';$get('UserName').value='" & UserID & "';$get('cmdLogin').click();</script>"
            CType(Login0.FindControl("pnlLogin"), Panel).Attributes.Add("style", "display:none;")
          End If
        ElseIf Request.QueryString("zaq12wsx") IsNot Nothing Then
          'Called From RFQ Generation, After Indent selection from ERP
          UserID = Request.QueryString("UserID")
          Dim TSID As String = Request.QueryString("TSID")
          Dim pw As String = SIS.SYS.Utilities.SessionManager.GetPassword(UserID)
          RedirectURL = "~/POW_Main/App_Edit/EF_powTechnicalSpecifications.aspx?TSID=" & TSID
          CType(Login0.FindControl("UserName"), TextBox).Text = UserID
          msg.InnerHtml = "<script type='text/javascript'>$get('Password').value='" & pw & "';$get('UserName').value='" & UserID & "';$get('cmdLogin').click();</script>"
          CType(Login0.FindControl("pnlLogin"), Panel).Attributes.Add("style", "display:none;")
          HttpContext.Current.Session("BrowserWidth") = 1001
        ElseIf Request.QueryString("UserID") IsNot Nothing Then
          'Called From ERP Menu
          UserID = Request.QueryString("UserID")
          Dim pw As String = SIS.SYS.Utilities.SessionManager.GetPassword(UserID)
          RedirectURL = "~/POW_Main/App_Forms/GF_powTechnicalSpecifications.aspx"
          CType(Login0.FindControl("UserName"), TextBox).Text = UserID
          msg.InnerHtml = "<script type='text/javascript'>$get('Password').value='" & pw & "';$get('UserName').value='" & UserID & "';$get('cmdLogin').click();</script>"
          CType(Login0.FindControl("pnlLogin"), Panel).Attributes.Add("style", "display:none;")
          HttpContext.Current.Session("BrowserWidth") = 1001
        End If
      End If
    End If
    'First Time Mobile App Users are handled in global.aspx 
    'Second Time in same loop From Here as global file is not executed
    If Request.Item("LoginID") IsNot Nothing Then
      'Called From Mobile App
      UserID = Request.QueryString("LoginID")
      Dim LastURL As String = HttpContext.Current.Request.UrlReferrer.ToString
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        HttpContext.Current.Session("LastURL") = LastURL
        HttpContext.Current.Session("BrowserWidth") = 1001
        RedirectURL = "~/POW_Main/App_Forms/GF_powTechnicalSpecifications.aspx"
        Response.Redirect(RedirectURL)
      End If
    End If
  End Sub
End Class
