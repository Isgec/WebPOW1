Imports System.Web.Script.Serialization
Partial Class GF_powRecordTypes
  Inherits SIS.SYS.GridBase
  Protected Sub GVpowRecordTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowRecordTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RecordTypeID As Int32 = GVpowRecordTypes.DataKeys(e.CommandArgument).Values("RecordTypeID")
        Dim RedirectUrl As String = TBLpowRecordTypes.EditUrl & "?RecordTypeID=" & RecordTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpowRecordTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowRecordTypes.Init
    DataClassName = "GpowRecordTypes"
    SetGridView = GVpowRecordTypes
  End Sub
  Protected Sub TBLpowRecordTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowRecordTypes.Init
    SetToolBar = TBLpowRecordTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
