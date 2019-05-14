Imports System.Web.Script.Serialization
Partial Class GF_powTSTypes
  Inherits SIS.SYS.GridBase
  Protected Sub GVpowTSTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowTSTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TSTypeID As Int32 = GVpowTSTypes.DataKeys(e.CommandArgument).Values("TSTypeID")
        Dim RedirectUrl As String = TBLpowTSTypes.EditUrl & "?TSTypeID=" & TSTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpowTSTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowTSTypes.Init
    DataClassName = "GpowTSTypes"
    SetGridView = GVpowTSTypes
  End Sub
  Protected Sub TBLpowTSTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSTypes.Init
    SetToolBar = TBLpowTSTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
