Partial Class AF_powRecordTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpowRecordTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowRecordTypes.Init
    DataClassName = "ApowRecordTypes"
    SetFormView = FVpowRecordTypes
  End Sub
  Protected Sub TBLpowRecordTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowRecordTypes.Init
    SetToolBar = TBLpowRecordTypes
  End Sub
  Protected Sub FVpowRecordTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowRecordTypes.DataBound
    SIS.POW.powRecordTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpowRecordTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowRecordTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powRecordTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowRecordTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowRecordTypes", mStr)
    End If
    If Request.QueryString("RecordTypeID") IsNot Nothing Then
      CType(FVpowRecordTypes.FindControl("F_RecordTypeID"), TextBox).Text = Request.QueryString("RecordTypeID")
      CType(FVpowRecordTypes.FindControl("F_RecordTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
