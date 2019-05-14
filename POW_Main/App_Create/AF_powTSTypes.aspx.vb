Partial Class AF_powTSTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpowTSTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSTypes.Init
    DataClassName = "ApowTSTypes"
    SetFormView = FVpowTSTypes
  End Sub
  Protected Sub TBLpowTSTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSTypes.Init
    SetToolBar = TBLpowTSTypes
  End Sub
  Protected Sub FVpowTSTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSTypes.DataBound
    SIS.POW.powTSTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpowTSTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powTSTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTSTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTSTypes", mStr)
    End If
    If Request.QueryString("TSTypeID") IsNot Nothing Then
      CType(FVpowTSTypes.FindControl("F_TSTypeID"), TextBox).Text = Request.QueryString("TSTypeID")
      CType(FVpowTSTypes.FindControl("F_TSTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
