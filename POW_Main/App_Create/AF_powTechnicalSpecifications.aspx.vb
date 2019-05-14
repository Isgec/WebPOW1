Partial Class AF_powTechnicalSpecifications
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpowTechnicalSpecifications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTechnicalSpecifications.Init
    DataClassName = "ApowTechnicalSpecifications"
    SetFormView = FVpowTechnicalSpecifications
  End Sub
  Protected Sub TBLpowTechnicalSpecifications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTechnicalSpecifications.Init
    SetToolBar = TBLpowTechnicalSpecifications
  End Sub
  Protected Sub ODSpowTechnicalSpecifications_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowTechnicalSpecifications.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.POW.powTechnicalSpecifications = CType(e.ReturnValue,SIS.POW.powTechnicalSpecifications)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&TSID=" & oDC.TSID
      TBLpowTechnicalSpecifications.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpowTechnicalSpecifications_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTechnicalSpecifications.DataBound
    SIS.POW.powTechnicalSpecifications.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpowTechnicalSpecifications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTechnicalSpecifications.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powTechnicalSpecifications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTechnicalSpecifications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTechnicalSpecifications", mStr)
    End If
    If Request.QueryString("TSID") IsNot Nothing Then
      CType(FVpowTechnicalSpecifications.FindControl("F_TSID"), TextBox).Text = Request.QueryString("TSID")
      CType(FVpowTechnicalSpecifications.FindControl("F_TSID"), TextBox).Enabled = False
    End If
  End Sub

End Class
