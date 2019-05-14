Imports System.Web.Script.Serialization
Partial Class EF_powTSStates
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
  Protected Sub ODSpowTSStates_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowTSStates.Selected
    Dim tmp As SIS.POW.powTSStates = CType(e.ReturnValue, SIS.POW.powTSStates)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowTSStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSStates.Init
    DataClassName = "EpowTSStates"
    SetFormView = FVpowTSStates
  End Sub
  Protected Sub TBLpowTSStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSStates.Init
    SetToolBar = TBLpowTSStates
  End Sub
  Protected Sub FVpowTSStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSStates.PreRender
    TBLpowTSStates.EnableSave = Editable
    TBLpowTSStates.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powTSStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTSStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTSStates", mStr)
    End If
  End Sub

End Class
