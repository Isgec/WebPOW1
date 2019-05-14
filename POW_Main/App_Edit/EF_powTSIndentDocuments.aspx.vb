Imports System.Web.Script.Serialization
Partial Class EF_powTSIndentDocuments
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
  Protected Sub ODSpowTSIndentDocuments_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowTSIndentDocuments.Selected
    Dim tmp As SIS.POW.powTSIndentDocuments = CType(e.ReturnValue, SIS.POW.powTSIndentDocuments)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowTSIndentDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSIndentDocuments.Init
    DataClassName = "EpowTSIndentDocuments"
    SetFormView = FVpowTSIndentDocuments
  End Sub
  Protected Sub TBLpowTSIndentDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSIndentDocuments.Init
    SetToolBar = TBLpowTSIndentDocuments
  End Sub
  Protected Sub FVpowTSIndentDocuments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSIndentDocuments.PreRender
    TBLpowTSIndentDocuments.EnableSave = Editable
    TBLpowTSIndentDocuments.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powTSIndentDocuments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTSIndentDocuments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTSIndentDocuments", mStr)
    End If
  End Sub

End Class
