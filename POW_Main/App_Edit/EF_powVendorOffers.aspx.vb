Imports System.Web.Script.Serialization
Partial Class EF_powVendorOffers
  Inherits SIS.SYS.UpdateBase
  Public ReadOnly Property seDS As String()
    Get
      Dim TSID As String = ""
      If Request.QueryString("TSID") IsNot Nothing Then
        TSID = Request.QueryString("TSID")
      End If
      If Request.QueryString("EnquiryID") IsNot Nothing Then
        Dim EnquiryID As String = Request.QueryString("EnquiryID")
        Dim oEnq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(TSID, EnquiryID)
        Dim ds() As String = ((oEnq.SupplierEMailID.Replace(";", ",")) & ",As Given Below").Split(",".ToCharArray)
        Return ds
      End If
      Return {"As Given Below"}
    End Get
  End Property
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
  Protected Sub ODSpowVendorOffers_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowVendorOffers.Selected
    Dim tmp As SIS.POW.powVendorOffers = CType(e.ReturnValue, SIS.POW.powVendorOffers)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    Select Case tmp.StatusID
      Case enumOfferStates.Created
        AthEditable = True
      Case Else
        AthEditable = False
    End Select
    oEnq = tmp.FK_POW_Offers_EnquiryID
  End Sub
  Protected Sub FVpowVendorOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowVendorOffers.Init
    DataClassName = "EpowVendorOffers"
    SetFormView = FVpowVendorOffers
  End Sub
  Protected Sub TBLpowVendorOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowVendorOffers.Init
    SetToolBar = TBLpowVendorOffers
  End Sub
  Dim oEnq As SIS.POW.powEnquiries = Nothing
  Protected Sub FVpowVendorOffers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowVendorOffers.PreRender
    TBLpowVendorOffers.EnableSave = Editable
    TBLpowVendorOffers.EnableForward = Editable
    TBLpowVendorOffers.EnableDelete = Deleteable

    Dim oF_OptionsFromEMailID As RadioButtonList = CType(FVpowVendorOffers.FindControl("F_OptionsFromEMailID"), RadioButtonList)
    Dim oF_FromEMailID As TextBox = CType(FVpowVendorOffers.FindControl("F_FromEMailID"), TextBox)
    Dim ds() As String = seDS
    oF_OptionsFromEMailID.DataSource = ds
    oF_OptionsFromEMailID.SelectedIndex = ds.Count - 1
    If oEnq.SupplierFromEMailID <> "" Then
      For i As Integer = 0 To ds.Count - 1
        If oEnq.SupplierFromEMailID.ToLower = ds(i).ToLower Then
          oF_OptionsFromEMailID.SelectedIndex = i
          Exit For
        End If
      Next
      oF_FromEMailID.Text = oEnq.SupplierFromEMailID
    End If

    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powVendorOffers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowVendorOffers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowVendorOffers", mStr)
    End If
  End Sub

  Private Sub ODSpowVendorOffers_Updated(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ODSpowVendorOffers.Updated
    If e.Exception Is Nothing Then
      Dim oDC As SIS.POW.powVendorOffers = CType(e.ReturnValue, SIS.POW.powVendorOffers)
      '==============
      If Request.Files.Count > 0 Then
        SIS.EDI.ediAFile.UploadFiles(Request, oDC.AthHandle, oDC.AthIndex, "", oDC.AthProcess)
      End If
      '====================
      If Forwarded Then
        SIS.POW.powVendorOffers.InitiateWF(oDC.TSID, oDC.EnquiryID, oDC.RecordID)
        Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar(True))
      End If
    End If

  End Sub
  Protected Sub F_TSAttachments_FilesUploaded(oUpload As HtmlInputFile, e As EventArgs)
    Dim oF_OptionsFromEMailID As RadioButtonList = CType(FVpowVendorOffers.FindControl("F_OptionsFromEMailID"), RadioButtonList)
    Dim oF_FromEMailID As TextBox = CType(FVpowVendorOffers.FindControl("F_FromEMailID"), TextBox)
    If oF_OptionsFromEMailID.SelectedItem.Text = "As Given Below" Then
      If oF_FromEMailID.Text = "" Then
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("FROM EMail ID is mandatory.") & "');", True)
        Exit Sub
      End If
    End If
    FVpowVendorOffers.UpdateItem(False)
  End Sub

  Private Sub FVpowVendorOffers_ItemUpdating(sender As Object, e As FormViewUpdateEventArgs) Handles FVpowVendorOffers.ItemUpdating
    Dim oF_OptionsFromEMailID As RadioButtonList = CType(FVpowVendorOffers.FindControl("F_OptionsFromEMailID"), RadioButtonList)
    Dim oF_FromEMailID As TextBox = CType(FVpowVendorOffers.FindControl("F_FromEMailID"), TextBox)
    If oF_OptionsFromEMailID.SelectedItem.Text = "As Given Below" Then
      If oF_FromEMailID.Text = "" Then
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("FROM EMail ID is mandatory.") & "');", True)
        e.Cancel = True
      End If
    End If

  End Sub
  Private Forwarded As Boolean = False

  Private Sub TBLpowVendorOffers_ForwardClicked(sender As Object, e As EventArgs) Handles TBLpowVendorOffers.ForwardClicked
    Dim oF_OptionsFromEMailID As RadioButtonList = CType(FVpowVendorOffers.FindControl("F_OptionsFromEMailID"), RadioButtonList)
    Dim oF_FromEMailID As TextBox = CType(FVpowVendorOffers.FindControl("F_FromEMailID"), TextBox)
    If oF_OptionsFromEMailID.SelectedItem.Text = "As Given Below" Then
      If oF_FromEMailID.Text = "" Then
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("FROM EMail ID is mandatory.") & "');", True)
        Exit Sub
      End If
    End If
    Try
      Forwarded = True
      FVpowVendorOffers.UpdateItem(False)
    Catch ex As Exception
    End Try

  End Sub
End Class
