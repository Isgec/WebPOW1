Imports System.Web.Script.Serialization
Partial Class EF_powOffers
  Inherits SIS.SYS.UpdateBase
  Public Property AthEditable() As Boolean
    Get
      If ViewState("AthEditable") IsNot Nothing Then
        Return CType(ViewState("AthEditable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("AthEditable", value)
    End Set
  End Property
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
  Protected Sub ODSpowOffers_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowOffers.Selected
    Dim tmp As SIS.POW.powOffers = CType(e.ReturnValue, SIS.POW.powOffers)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    Select Case tmp.StatusID
      Case enumOfferStates.Created
        AthEditable = True
      Case Else
        AthEditable = False
    End Select
  End Sub
  Protected Sub FVpowOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOffers.Init
    DataClassName = "EpowOffers"
    SetFormView = FVpowOffers
  End Sub
  Protected Sub TBLpowOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowOffers.Init
    SetToolBar = TBLpowOffers
  End Sub
  Protected Sub FVpowOffers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOffers.PreRender
    TBLpowOffers.EnableSave = Editable
    TBLpowOffers.EnableForward = Editable
    TBLpowOffers.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powOffers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowOffers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowOffers", mStr)
    End If
  End Sub

  Protected Sub F_TSAttachments_FilesUploaded(oUpload As HtmlInputFile, e As EventArgs)
    FVpowOffers.UpdateItem(False)
  End Sub

  Private Sub ODSpowOffers_Updated(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ODSpowOffers.Updated
    If e.Exception Is Nothing Then
      Dim oDC As SIS.POW.powOffers = CType(e.ReturnValue, SIS.POW.powOffers)
      '==============
      If Request.Files.Count > 0 Then
        SIS.EDI.ediAFile.UploadFiles(Request, oDC.AthHandle, oDC.AthIndex, "", oDC.AthProcess)
      End If
      '====================
      If Forwarded Then
        SIS.POW.powOffers.InitiateWF(oDC.TSID, oDC.EnquiryID, oDC.RecordID)
      End If
    End If
  End Sub
  Dim Forwarded As Boolean = False
  Private Sub TBLpowOffers_ForwardClicked(sender As Object, e As EventArgs) Handles TBLpowOffers.ForwardClicked
    Forwarded = True
    FVpowOffers.UpdateItem(False)
  End Sub
End Class
