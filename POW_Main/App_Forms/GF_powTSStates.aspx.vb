Imports System.Web.Script.Serialization
Partial Class GF_powTSStates
  Inherits SIS.SYS.GridBase
  Protected Sub GVpowTSStates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowTSStates.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVpowTSStates.DataKeys(e.CommandArgument).Values("StatusID")
        Dim RedirectUrl As String = TBLpowTSStates.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpowTSStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowTSStates.Init
    DataClassName = "GpowTSStates"
    SetGridView = GVpowTSStates
  End Sub
  Protected Sub TBLpowTSStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSStates.Init
    SetToolBar = TBLpowTSStates
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
