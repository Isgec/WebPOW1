Partial Class AF_powTSStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpowTSStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSStates.Init
    DataClassName = "ApowTSStates"
    SetFormView = FVpowTSStates
  End Sub
  Protected Sub TBLpowTSStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSStates.Init
    SetToolBar = TBLpowTSStates
  End Sub
  Protected Sub FVpowTSStates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSStates.DataBound
    SIS.POW.powTSStates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpowTSStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSStates.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powTSStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTSStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTSStates", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpowTSStates.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpowTSStates.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
