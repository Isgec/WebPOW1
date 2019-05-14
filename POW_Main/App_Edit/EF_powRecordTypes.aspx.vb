Imports System.Web.Script.Serialization
Partial Class EF_powRecordTypes
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSpowRecordTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowRecordTypes.Selected
    Dim tmp As SIS.POW.powRecordTypes = CType(e.ReturnValue, SIS.POW.powRecordTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowRecordTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowRecordTypes.Init
    DataClassName = "EpowRecordTypes"
    SetFormView = FVpowRecordTypes
  End Sub
  Protected Sub TBLpowRecordTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowRecordTypes.Init
    SetToolBar = TBLpowRecordTypes
  End Sub
  Protected Sub FVpowRecordTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowRecordTypes.PreRender
    TBLpowRecordTypes.EnableSave = Editable
    TBLpowRecordTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powRecordTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowRecordTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowRecordTypes", mStr)
    End If
  End Sub

End Class
