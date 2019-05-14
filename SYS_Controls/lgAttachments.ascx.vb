Imports System.Web.Script.Serialization
Partial Class lgAttachments
  Inherits System.Web.UI.UserControl
  Public Property Process As String = ""
  Public Property Handle As String = ""
  Public Property Index As String = ""
  Public Property PrimaryKey As String = ""

  Public Property Editable As Boolean = False
  Public Event FilesUploaded(ByVal oUpload As HtmlInputFile, ByVal e As EventArgs)
  Public Property ValidateClient As Boolean = False
  Public Property ValidationGroup As String = ""
  Public ReadOnly Property GetSDownloadAllLink() As String
    Get
      Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/download.aspx?stmtl=" & Handle & "|" & Index & "', 'win" & Index & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
    End Get
  End Property

  Protected Sub GVediAFile_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVediAFile.RowCommand
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim t_drid As String = GVediAFile.DataKeys(e.CommandArgument).Values("t_drid")
        Dim tmp As SIS.EDI.ediAFile = SIS.EDI.ediAFile.DeleteWF(t_drid, Process)
        GVediAFile.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Downloadwf".ToLower Then
      Try
        Dim t_drid As String = GVediAFile.DataKeys(e.CommandArgument).Values("t_drid")
        SIS.EDI.ediAFile.DownloadWF(t_drid)
        GVediAFile.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim t_drid As String = GVediAFile.DataKeys(e.CommandArgument).Values("t_drid")
        SIS.EDI.ediAFile.InitiateWF(t_drid)
        GVediAFile.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

  Private Sub lgAttachments_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    UploadDiv.Visible = Editable
    GVediAFile.Columns(1).Visible = Editable
    If ValidateClient And ValidationGroup <> "" Then
      cmdFileUploadBulk.Attributes.Add("onclick", "return Page_ClientValidate('" & ValidationGroup & "') && show_submit();")  ' 
    End If
    If Editable Then
      GVediAFile.ShowHeader = True
    End If
  End Sub

  Private Sub cmdFileUploadBulk_Click(sender As Object, e As EventArgs) Handles cmdFileUploadBulk.Click
    RaiseEvent FilesUploaded(F_FileUploadBulk, New EventArgs)
  End Sub

  Private Sub cmdDownloadZip_Click(sender As Object, e As EventArgs) Handles cmdDownloadZip.Click

  End Sub
End Class
