Imports System.Web.Script.Serialization
Partial Class GF_powEnquiryStates
  Inherits SIS.SYS.GridBase
  Protected Sub GVpowEnquiryStates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowEnquiryStates.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVpowEnquiryStates.DataKeys(e.CommandArgument).Values("StatusID")
        Dim RedirectUrl As String = TBLpowEnquiryStates.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpowEnquiryStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowEnquiryStates.Init
    DataClassName = "GpowEnquiryStates"
    SetGridView = GVpowEnquiryStates
  End Sub
  Protected Sub TBLpowEnquiryStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowEnquiryStates.Init
    SetToolBar = TBLpowEnquiryStates
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
