Imports System.Web.Script.Serialization
Partial Class EF_powOfferStates
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
  Protected Sub ODSpowOfferStates_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowOfferStates.Selected
    Dim tmp As SIS.POW.powOfferStates = CType(e.ReturnValue, SIS.POW.powOfferStates)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowOfferStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOfferStates.Init
    DataClassName = "EpowOfferStates"
    SetFormView = FVpowOfferStates
  End Sub
  Protected Sub TBLpowOfferStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowOfferStates.Init
    SetToolBar = TBLpowOfferStates
  End Sub
  Protected Sub FVpowOfferStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOfferStates.PreRender
    TBLpowOfferStates.EnableSave = Editable
    TBLpowOfferStates.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powOfferStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowOfferStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowOfferStates", mStr)
    End If
  End Sub

End Class
