<%@ Application Language="VB" %>

<script runat="server">
  Public Class mySVars
    Public Property Key As String = ""
    Public Property Value As Object = Nothing
    Sub New(k As String, v As String)
      Key = k
      Value = v
    End Sub
    Sub New()
      'dummy
    End Sub
  End Class

  Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

  Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    ' Code that runs on application shutdown
  End Sub

  Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

  Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      Dim LastURL As String = HttpContext.Current.Request.UrlReferrer.ToString
      Dim mVars As New List(Of mySVars)
      For Each str As String In Session.Keys
        mVars.Add(New mySVars(str, Session(str)))
      Next
      SIS.SYS.Utilities.SessionManager.InitializeEnvironment(HttpContext.Current.User.Identity.Name)
      HttpContext.Current.Session("LastURL") = LastURL.Replace("mMenu.aspx", "mDefault.aspx")
      HttpContext.Current.Session("LastVars") = mVars
      'Get Redirect URL from Authorization, there It needs to create default page for role.
      Dim RedirectURL As String = "~/POW_Main/App_Forms/GF_powTechnicalSpecifications.aspx"
      Response.Redirect(RedirectURL)
    Else
      Try
        SIS.SYS.Utilities.SessionManager.CreateSessionEnvironement()
      Catch ex As Exception
      End Try
    End If
  End Sub

  Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
    Try
      SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
      'LoggedOut Destroyes all variables, must be handled there first
      'If HttpContext.Current.Session("LastURL") IsNot Nothing Then
      '  Dim RedirectURL As String = HttpContext.Current.Session("LastURL")
      '  Dim mVars As List(Of mySVars) = HttpContext.Current.Session("LastVars")
      '  For Each tmp As mySVars In mVars
      '    HttpContext.Current.Session(tmp.Key) = tmp.Value
      '  Next
      '  Server.Transfer(RedirectURL)
      'Else
      '  SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
      'End If
    Catch ex As Exception
    End Try
  End Sub

  Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs)
  End Sub
</script>