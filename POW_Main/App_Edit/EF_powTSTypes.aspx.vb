Imports System.Web.Script.Serialization
Partial Class EF_powTSTypes
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
  Protected Sub ODSpowTSTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowTSTypes.Selected
    Dim tmp As SIS.POW.powTSTypes = CType(e.ReturnValue, SIS.POW.powTSTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowTSTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSTypes.Init
    DataClassName = "EpowTSTypes"
    SetFormView = FVpowTSTypes
  End Sub
  Protected Sub TBLpowTSTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSTypes.Init
    SetToolBar = TBLpowTSTypes
  End Sub
  Protected Sub FVpowTSTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSTypes.PreRender
    TBLpowTSTypes.EnableSave = Editable
    TBLpowTSTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powTSTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTSTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTSTypes", mStr)
    End If
  End Sub

End Class
