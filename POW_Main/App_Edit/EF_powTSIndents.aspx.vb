Imports System.Web.Script.Serialization
Partial Class EF_powTSIndents
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
  Protected Sub ODSpowTSIndents_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowTSIndents.Selected
    Dim tmp As SIS.POW.powTSIndents = CType(e.ReturnValue, SIS.POW.powTSIndents)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowTSIndents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSIndents.Init
    DataClassName = "EpowTSIndents"
    SetFormView = FVpowTSIndents
  End Sub
  Protected Sub TBLpowTSIndents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSIndents.Init
    SetToolBar = TBLpowTSIndents
  End Sub
  Protected Sub FVpowTSIndents_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSIndents.PreRender
    TBLpowTSIndents.EnableSave = Editable
    TBLpowTSIndents.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powTSIndents.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTSIndents") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTSIndents", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpowTSIndentDocumentsCC As New gvBase
  Protected Sub GVpowTSIndentDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowTSIndentDocuments.Init
    gvpowTSIndentDocumentsCC.DataClassName = "GpowTSIndentDocuments"
    gvpowTSIndentDocumentsCC.SetGridView = GVpowTSIndentDocuments
  End Sub
  Protected Sub TBLpowTSIndentDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSIndentDocuments.Init
    gvpowTSIndentDocumentsCC.SetToolBar = TBLpowTSIndentDocuments
  End Sub
  Protected Sub GVpowTSIndentDocuments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowTSIndentDocuments.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTSIndentDocuments.DataKeys(e.CommandArgument).Values("TSID")  
        Dim SerialNo As Int32 = GVpowTSIndentDocuments.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim DocNo As Int32 = GVpowTSIndentDocuments.DataKeys(e.CommandArgument).Values("DocNo")  
        Dim RedirectUrl As String = TBLpowTSIndentDocuments.EditUrl & "?TSID=" & TSID & "&SerialNo=" & SerialNo & "&DocNo=" & DocNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
