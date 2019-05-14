Imports System.Web.Script.Serialization
Partial Class EF_powTSChangeBuyer
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
  Protected Sub ODSpowTSChangeBuyer_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowTSChangeBuyer.Selected
    Dim tmp As SIS.POW.powTSChangeBuyer = CType(e.ReturnValue, SIS.POW.powTSChangeBuyer)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowTSChangeBuyer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSChangeBuyer.Init
    DataClassName = "EpowTSChangeBuyer"
    SetFormView = FVpowTSChangeBuyer
  End Sub
  Protected Sub TBLpowTSChangeBuyer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSChangeBuyer.Init
    SetToolBar = TBLpowTSChangeBuyer
  End Sub
  Protected Sub FVpowTSChangeBuyer_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTSChangeBuyer.PreRender
    TBLpowTSChangeBuyer.EnableSave = Editable
    TBLpowTSChangeBuyer.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powTSChangeBuyer.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTSChangeBuyer") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTSChangeBuyer", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_POW_TS_CreatedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CreatedBy As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CreatedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
