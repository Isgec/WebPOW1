Imports System.Web.Script.Serialization
Partial Class GF_ntNotes
  Inherits SIS.SYS.GridBase
  Protected Sub GVntNotes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVntNotes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim NotesId As String = GVntNotes.DataKeys(e.CommandArgument).Values("NotesId")
        Dim RedirectUrl As String = TBLntNotes.EditUrl & "?NotesId=" & NotesId
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVntNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVntNotes.Init
    DataClassName = "GntNotes"
    SetGridView = GVntNotes
  End Sub
  Protected Sub TBLntNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLntNotes.Init
    SetToolBar = TBLntNotes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
