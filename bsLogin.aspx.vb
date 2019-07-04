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
    '1. Called From Vendor E-Mail Link
    If Request.QueryString("EnqKey") IsNot Nothing Then
      Dim Key As String = Request.QueryString("EnqKey")
      Dim enq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.GetByEnquiryKey(Key)
      If enq IsNot Nothing Then
        UserID = enq.SupplierLoginID
        If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
          SIS.SYS.Utilities.ApplicationSpacific.GenerateSupplierAuthorization(UserID)
          RedirectURL = "~/POW_Main/App_Edit/EF_powVendorEnquiries.aspx?TSID=" & enq.TSID & "&EnquiryID=" & enq.EnquiryID
          Response.Redirect(RedirectURL)
        End If
      End If
    End If
    '2. Called From RFQ Generation, After Indent selection from ERP
    If Request.QueryString("zaq12wsx") IsNot Nothing Then
      UserID = Request.QueryString("UserID")
      Dim TSID As String = Request.QueryString("TSID")
      HttpContext.Current.Session("BrowserWidth") = 1001
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        RedirectURL = "~/POW_Main/App_Edit/EF_powTechnicalSpecifications.aspx?TSID=" & TSID
        Response.Redirect(RedirectURL)
      End If
    End If
    '3. Called From ERP Menu
    If Request.QueryString("UserID") IsNot Nothing Then
      UserID = Request.QueryString("UserID")
      HttpContext.Current.Session("BrowserWidth") = 1001
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        RedirectURL = "~/POW_Main/App_Forms/GF_powTechnicalSpecifications.aspx"
        Response.Redirect(RedirectURL)
      End If
    End If
    '4. From Mobile App
    If Request.QueryString("LoginID") IsNot Nothing Then
      UserID = Request.QueryString("LoginID")
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        HttpContext.Current.Session("BrowserWidth") = 1001
        RedirectURL = "~/POW_Main/App_Forms/GF_powTechnicalSpecifications.aspx"
        Response.Redirect(RedirectURL)
      End If
    End If
  End Sub
End Class
