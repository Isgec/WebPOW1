Imports System.Web.Services
Imports System.IO
Partial Class lgMasterPage
  Inherits System.Web.UI.MasterPage
  Public Property Authenticated As Boolean
    Get
      If ViewState("Authenticated") IsNot Nothing Then
        Return CType(ViewState("Authenticated"), Boolean)
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("Authenticated", value)
    End Set
  End Property
  Public WriteOnly Property SetEncType As String
    Set(value As String)
      Me.form1.Attributes.Add("enctype", "multipart/form-data")
    End Set
  End Property
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not SIS.SYS.Utilities.ValidateURL.Validate(Request.AppRelativeCurrentExecutionFilePath) Then
      Response.Redirect("~/Login.aspx")
    End If
    Authenticated = False
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      Authenticated = True
      Dim mFile As String = HttpContext.Current.Server.MapPath("~/../UserRights/") & HttpContext.Current.Session("ApplicationID") & "/" & HttpContext.Current.User.Identity.Name & "_nMenu.xml"
      If IO.File.Exists(mFile) Then
        Dim tmp As IO.StreamReader = New IO.StreamReader(mFile)
        algmnu.InnerHtml = tmp.ReadToEnd().Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
        tmp.Close()
      End If
    End If
  End Sub
  Public Function GetRelativePath(ByVal mPath As String) As String
    Return VirtualPathUtility.MakeRelative(Page.AppRelativeVirtualPath, mPath)
  End Function
  Public Property Master_Form() As HtmlForm
    Get
      Return Me.form1
    End Get
    Set(ByVal value As HtmlForm)
      Me.form1 = value
    End Set
  End Property
  Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
    If (e.Exception.Data("ExtraInfo") <> Nothing) Then
      ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.Data("ExtraInfo").ToString()
    Else
      ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message
    End If
  End Sub

  Public Sub LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs)
    Authenticated = False
    SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
    'Response.Redirect("~/bsLogin.aspx")
  End Sub

  Private Sub lgMasterPage_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    cmdChangePassword.Visible = Authenticated
    myFooter.Visible = False
  End Sub
  Protected Sub cmdget_Click(sender As Object, e As EventArgs)
    wd.Text = Session("BrowserWidth")
    ht.Text = Session("BrowserHeight")

  End Sub
End Class

