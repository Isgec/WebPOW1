Imports System.Web.Script.Serialization
Partial Class GF_powOfferStates
  Inherits SIS.SYS.GridBase
  Protected Sub GVpowOfferStates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowOfferStates.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVpowOfferStates.DataKeys(e.CommandArgument).Values("StatusID")
        Dim RedirectUrl As String = TBLpowOfferStates.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpowOfferStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowOfferStates.Init
    DataClassName = "GpowOfferStates"
    SetGridView = GVpowOfferStates
  End Sub
  Protected Sub TBLpowOfferStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowOfferStates.Init
    SetToolBar = TBLpowOfferStates
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
