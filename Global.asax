<%@ Application Language="VB" %>

<script runat="server">
  Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

  Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    ' Code that runs on application shutdown
  End Sub

  Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

  Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      'Authenticated User will come only from Mobile App
      'Store LastURL, If it is allready stored then do nothing
      If HttpContext.Current.Session("LastURL") Is Nothing Then
        Dim LastURL As String = HttpContext.Current.Request.UrlReferrer.ToString
        Dim mVars As New List(Of SIS.SYS.Utilities.mySVars)
        For Each str As String In Session.Keys
          mVars.Add(New SIS.SYS.Utilities.mySVars(str, Session(str)))
        Next
        Dim UserID As String = HttpContext.Current.User.Identity.Name
        If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
          HttpContext.Current.Session("LastURL") = LastURL
          HttpContext.Current.Session("LastVars") = mVars
          HttpContext.Current.Session("BrowserWidth") = 1001
          Dim RedirectURL As String = "~/POW_Main/App_Forms/GF_powTechnicalSpecifications.aspx"
          Response.Redirect(RedirectURL)
        End If
      End If
    End If
  End Sub

  Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
    Try
      SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
    Catch ex As Exception
    End Try
  End Sub

  Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs)
  End Sub
</script>