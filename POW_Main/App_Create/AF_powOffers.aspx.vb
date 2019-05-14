Partial Class AF_powOffers
  Inherits SIS.SYS.InsertBase
  Public Property ForSupplier As Boolean
    Get
      If ViewState("ForSupplier") IsNot Nothing Then
        Return CType(ViewState("ForSupplier"), Boolean)
      End If
      Return False
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("ForSupplier", value)
    End Set
  End Property
  Protected Sub FVpowOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOffers.Init
    DataClassName = "ApowOffers"
    SetFormView = FVpowOffers
  End Sub
  Protected Sub TBLpowOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowOffers.Init
    SetToolBar = TBLpowOffers
  End Sub
  Protected Sub FVpowOffers_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOffers.DataBound
    SIS.POW.powOffers.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpowOffers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowOffers.PreRender
    Dim oF_TSID_Display As Label  = FVpowOffers.FindControl("F_TSID_Display")
    oF_TSID_Display.Text = String.Empty
    If Not Session("F_TSID_Display") Is Nothing Then
      If Session("F_TSID_Display") <> String.Empty Then
        oF_TSID_Display.Text = Session("F_TSID_Display")
      End If
    End If
    Dim oF_TSID As TextBox  = FVpowOffers.FindControl("F_TSID")
    oF_TSID.Enabled = True
    oF_TSID.Text = String.Empty
    If Not Session("F_TSID") Is Nothing Then
      If Session("F_TSID") <> String.Empty Then
        oF_TSID.Text = Session("F_TSID")
      End If
    End If
    Dim oF_EnquiryID_Display As Label  = FVpowOffers.FindControl("F_EnquiryID_Display")
    oF_EnquiryID_Display.Text = String.Empty
    If Not Session("F_EnquiryID_Display") Is Nothing Then
      If Session("F_EnquiryID_Display") <> String.Empty Then
        oF_EnquiryID_Display.Text = Session("F_EnquiryID_Display")
      End If
    End If
    Dim oF_EnquiryID As TextBox  = FVpowOffers.FindControl("F_EnquiryID")
    oF_EnquiryID.Enabled = True
    oF_EnquiryID.Text = String.Empty
    If Not Session("F_EnquiryID") Is Nothing Then
      If Session("F_EnquiryID") <> String.Empty Then
        oF_EnquiryID.Text = Session("F_EnquiryID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powOffers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowOffers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowOffers", mStr)
    End If
    If Request.QueryString("TSID") IsNot Nothing Then
      CType(FVpowOffers.FindControl("F_TSID"), TextBox).Text = Request.QueryString("TSID")
      CType(FVpowOffers.FindControl("F_TSID"), TextBox).Enabled = False
    End If
    If Request.QueryString("EnquiryID") IsNot Nothing Then
      CType(FVpowOffers.FindControl("F_EnquiryID"), TextBox).Text = Request.QueryString("EnquiryID")
      CType(FVpowOffers.FindControl("F_EnquiryID"), TextBox).Enabled = False
    End If
    If Request.QueryString("RecordID") IsNot Nothing Then
      CType(FVpowOffers.FindControl("F_RecordID"), TextBox).Text = Request.QueryString("RecordID")
      CType(FVpowOffers.FindControl("F_RecordID"), TextBox).Enabled = False
    End If
    CType(FVpowOffers.FindControl("F_ForSupplier"), CheckBox).Checked = ForSupplier

  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TSIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.POW.powTechnicalSpecifications.SelectpowTechnicalSpecificationsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function EnquiryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.POW.powEnquiries.SelectpowEnquiriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_POW_Offers_EnquiryID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TSID As Int32 = CType(aVal(1),Int32)
    Dim EnquiryID As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(TSID,EnquiryID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_POW_Offers_TSID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TSID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.POW.powTechnicalSpecifications = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(TSID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  Protected Sub F_TSAttachments_FilesUploaded(oUpload As HtmlInputFile, e As EventArgs)
    FVpowOffers.InsertItem(False)
  End Sub

  Private Sub ODSpowOffers_Inserted(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ODSpowOffers.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.POW.powOffers = CType(e.ReturnValue, SIS.POW.powOffers)
      '==============
      If Request.Files.Count > 0 Then
        SIS.EDI.ediAFile.UploadFiles(Request, oDC.AthHandle, oDC.AthIndex, "", oDC.AthProcess)
      End If
      '====================
      If Not Forwarded Then
        Dim tmpURL As String = "?tmp=1"
        tmpURL &= "&TSID=" & oDC.TSID
        tmpURL &= "&EnquiryID=" & oDC.EnquiryID
        tmpURL &= "&RecordID=" & oDC.RecordID
        TBLpowOffers.AfterInsertURL &= tmpURL
      Else
        SIS.POW.powOffers.InitiateWF(oDC.TSID, oDC.EnquiryID, oDC.RecordID)
        If Request.QueryString("shortcut") IsNot Nothing Then
          TBLpowOffers.AfterInsertURL = "~/POW_Main/App_Edit/EF_powEnquiries.aspx?TSID=" & oDC.TSID & "&EnquiryID=" & oDC.EnquiryID
        Else
          TBLpowOffers.AfterInsertURL = ""
        End If
      End If
    End If

  End Sub
  Private Sub AF_powOffers_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Request.QueryString("ForSupplier") IsNot Nothing Then
      ForSupplier = True
    Else
      ForSupplier = False
    End If

  End Sub
  Private Forwarded As Boolean = False

  Private Sub TBLpowOffers_ForwardClicked(sender As Object, e As EventArgs) Handles TBLpowOffers.ForwardClicked
    Forwarded = True
    FVpowOffers.InsertItem(False)
  End Sub
End Class
