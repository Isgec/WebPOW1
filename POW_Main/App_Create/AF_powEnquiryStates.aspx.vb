Partial Class AF_powEnquiryStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpowEnquiryStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowEnquiryStates.Init
    DataClassName = "ApowEnquiryStates"
    SetFormView = FVpowEnquiryStates
  End Sub
  Protected Sub TBLpowEnquiryStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowEnquiryStates.Init
    SetToolBar = TBLpowEnquiryStates
  End Sub
  Protected Sub FVpowEnquiryStates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowEnquiryStates.DataBound
    SIS.POW.powEnquiryStates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpowEnquiryStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowEnquiryStates.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powEnquiryStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowEnquiryStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowEnquiryStates", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpowEnquiryStates.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpowEnquiryStates.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
