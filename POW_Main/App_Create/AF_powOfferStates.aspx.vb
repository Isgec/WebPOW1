Partial Class AF_powOfferStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpowOfferStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOfferStates.Init
    DataClassName = "ApowOfferStates"
    SetFormView = FVpowOfferStates
  End Sub
  Protected Sub TBLpowOfferStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowOfferStates.Init
    SetToolBar = TBLpowOfferStates
  End Sub
  Protected Sub FVpowOfferStates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOfferStates.DataBound
    SIS.POW.powOfferStates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpowOfferStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOfferStates.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powOfferStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowOfferStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowOfferStates", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpowOfferStates.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpowOfferStates.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
