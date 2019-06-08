Imports System.Web.Services
Imports System.IO
Imports System.Xml
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
    bsmenu.Visible = False
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      Authenticated = True
      Dim mFile As String = HttpContext.Current.Server.MapPath("~/../UserRights/") & HttpContext.Current.Session("ApplicationID") & "/" & HttpContext.Current.User.Identity.Name & "_nMenu.xml"
      If IO.File.Exists(mFile) Then
        If Convert.ToInt32(Session("BrowserWidth")) < 1000 Then
          bsmenu.Visible = True
          Dim tmp As IO.StreamReader = New IO.StreamReader(mFile)
          Dim xmlStr As String = tmp.ReadToEnd
          tmp.Close()
          xmlStr = RemoveIllegalXMLCharacters(xmlStr)
          Dim doc As New System.Xml.XmlDocument
          doc.LoadXml(xmlStr)
          algmnu.InnerHtml = ConvertDoc(doc)
        Else
          Dim tmp As IO.StreamReader = New IO.StreamReader(mFile)
          algmnu.InnerHtml = tmp.ReadToEnd().Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
          tmp.Close()
        End If
      End If
    End If
  End Sub

  Private mRet As XmlDocument = Nothing
  Private mLastClass As String = "dark"
  Private Function ConvertDoc(ByVal doc As XmlDocument) As String
    mRet = Nothing
    mRet = New XmlDocument
    Dim cMenu As XmlNode = Nothing

    Dim at As XmlAttribute = Nothing

    Dim tmp As XmlNode = mRet.CreateElement("div")
    at = mRet.CreateAttribute("id")
    at.Value = "mySidenav"
    tmp.Attributes.Append(at)
    at = mRet.CreateAttribute("class")
    at.Value = "sidenav"
    tmp.Attributes.Append(at)
    at = mRet.CreateAttribute("style")
    at.Value = "overflow:hidden;"
    tmp.Attributes.Append(at)
    mRet.AppendChild(tmp)

    tmp = mRet.CreateElement("a")
    at = mRet.CreateAttribute("href")
    at.Value = "javascript:void(0)"
    tmp.Attributes.Append(at)
    at = mRet.CreateAttribute("class")
    at.Value = "closebtn"
    tmp.Attributes.Append(at)
    at = mRet.CreateAttribute("onclick")
    at.Value = "closeNav();"
    tmp.Attributes.Append(at)
    tmp.InnerXml = "&times;&nbsp;"
    mRet.ChildNodes(0).AppendChild(tmp)

    tmp = mRet.CreateElement("div")
    at = mRet.CreateAttribute("class")
    at.Value = "scrollbar scrollbar-primary"
    tmp.Attributes.Append(at)
    at = mRet.CreateAttribute("style")
    at.Value = "height:100%;width:100%"
    tmp.Attributes.Append(at)
    mRet.ChildNodes(0).AppendChild(tmp)


    For Each nd As XmlNode In doc.ChildNodes
      cMenu = GenerateMenu(cMenu, nd)
    Next

    Dim sb As New StringBuilder
    Dim os As New IO.StringWriter(sb)
    mRet.Save(os)

    Dim RetStr As String = sb.ToString.Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
    RetStr = RetStr.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")
    Return RetStr
  End Function
  Private Function GenerateMenu(ByVal cMenu As XmlNode, ByVal nd As XmlNode) As XmlNode
    If nd.Name.ToLower = "a" Then
      Dim id As String = nd.Attributes("id").Value
      Dim Name As String = id.Split("_".ToCharArray)(0)
      Dim Value As String = nd.ChildNodes(0).InnerText
      Dim at As XmlAttribute = Nothing
      Select Case Name.ToLower
        Case "role"
          Select Case mLastClass
            Case "dark"
              mLastClass = "primary"
            Case "primary"
              mLastClass = "warning"
            Case "warning"
              mLastClass = "success"
            Case "success"
              mLastClass = "danger"
            Case "danger"
              mLastClass = "dark"
          End Select
          mLastClass = "primary"
          '2.
          Dim accordian As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("id")
          at.Value = id
          accordian.Attributes.Append(at)
          mRet.ChildNodes(0).ChildNodes(1).AppendChild(accordian)
          '3.
          Dim card As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("class")
          at.Value = "card"
          card.Attributes.Append(at)
          accordian.AppendChild(card)
          '4.
          Dim cardH As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("class")
          at.Value = "card-header btn-" & mLastClass
          cardH.Attributes.Append(at)
          cardH.InnerXml = "<a class=""card-link"" data-toggle=""collapse"" href=""#c" & id & """>" & Value & "</a>"
          card.AppendChild(cardH)
          '5.
          Dim collapse As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("id")
          at.Value = "c" & id
          collapse.Attributes.Append(at)
          at = mRet.CreateAttribute("class")
          at.Value = "collapse"
          collapse.Attributes.Append(at)
          at = mRet.CreateAttribute("data-parent")
          at.Value = "#" & id
          collapse.Attributes.Append(at)
          card.AppendChild(collapse)
          '6.
          Dim cardB As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("class")
          at.Value = "card-body"
          cardB.Attributes.Append(at)
          collapse.AppendChild(cardB)
          cMenu = cardB
        Case "menup"
          Select Case mLastClass
            Case "dark"
              mLastClass = "primary"
            Case "primary"
              mLastClass = "warning"
            Case "warning"
              mLastClass = "success"
            Case "success"
              mLastClass = "danger"
            Case "danger"
              mLastClass = "dark"
          End Select
          '2.
          Dim accordian As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("id")
          at.Value = id
          accordian.Attributes.Append(at)
          cMenu.AppendChild(accordian)
          '3.
          Dim card As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("class")
          at.Value = "card"
          card.Attributes.Append(at)
          accordian.AppendChild(card)
          '4.
          Dim cardH As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("class")
          at.Value = "card-header btn btn-" & mLastClass
          cardH.Attributes.Append(at)
          cardH.InnerXml = "<a class=""card-link"" data-toggle=""collapse"" href=""#c" & id & """>" & Value & "</a>"
          card.AppendChild(cardH)
          '5.
          Dim collapse As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("id")
          at.Value = "c" & id
          collapse.Attributes.Append(at)
          at = mRet.CreateAttribute("class")
          at.Value = "collapse"
          collapse.Attributes.Append(at)
          at = mRet.CreateAttribute("data-parent")
          at.Value = "#" & id
          collapse.Attributes.Append(at)
          card.AppendChild(collapse)
          '6.
          Dim cardB As XmlNode = mRet.CreateElement("div")
          at = mRet.CreateAttribute("class")
          at.Value = "card-body"
          cardB.Attributes.Append(at)
          collapse.AppendChild(cardB)
          cMenu = cardB
        Case "session"
          Dim session As XmlNode = mRet.CreateElement("a")
          at = mRet.CreateAttribute("id")
          at.Value = nd.Attributes("id").Value
          session.Attributes.Append(at)
          at = mRet.CreateAttribute("href")
          at.Value = nd.Attributes("href").Value
          session.Attributes.Append(at)
          at = mRet.CreateAttribute("title")
          at.Value = nd.Attributes("title").Value
          session.Attributes.Append(at)
          at = mRet.CreateAttribute("class")
          at.Value = "btn btn-outline-" & mLastClass
          session.Attributes.Append(at)
          session.InnerText = nd.ChildNodes(0).InnerText
          cMenu.AppendChild(session)
      End Select
    End If
    For Each cnd As XmlNode In nd.ChildNodes
      cMenu = GenerateMenu(cMenu, cnd)
    Next
    Return cMenu
  End Function
  Private Function RemoveIllegalXMLCharacters(ByVal Content As String) As String


    'Used to hold the output.
    Dim textOut As New StringBuilder()
    'Used to reference the current character.
    Dim current As Char
    'Exit out and return an empty string if nothing was passed in to method
    If Content Is Nothing OrElse Content = String.Empty Then
      Return String.Empty
    End If


    Content = Content.Replace("'", "&apos;")
    'Content = Content.Replace("""", "&quot;")
    Content = Content.Replace("&", "&amp;")
    'Content = Content.Replace("<", "&lt;")
    'Content = Content.Replace(">", "&gt;")

    'Loop through the lenght of the content (1) character at a time to see if there
    'are any illegal characters to be removed:
    For i As Integer = 0 To Content.Length - 1
      'Reference the current character
      current = Content(i)

      'Only append back to the StringBuilder valid non-illegal characters
      If (AscW(current) = &H9 OrElse AscW(current) = &HA OrElse AscW(current) = &HD) _
               OrElse ((AscW(current) >= &H20) AndAlso (AscW(current) <= &HD7FF)) _
               OrElse ((AscW(current) >= &HE000) AndAlso (AscW(current) <= &HFFFD)) _
               OrElse ((AscW(current) >= &H10000) AndAlso (AscW(current) <= &H10FFFF)) Then
        textOut.Append(current)
      End If
    Next


    'Return the screened content with only valid characters
    Return textOut.ToString()


  End Function
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

