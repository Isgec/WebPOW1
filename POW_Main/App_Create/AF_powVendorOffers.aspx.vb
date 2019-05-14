Imports System.Web.Script.Serialization
Partial Class AF_powVendorOffers
  Inherits SIS.SYS.InsertBase
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
  Protected Sub FVpowVendorOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowVendorOffers.Init
    DataClassName = "ApowVendorOffers"
    SetFormView = FVpowVendorOffers
  End Sub
  Protected Sub TBLpowVendorOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowVendorOffers.Init
    SetToolBar = TBLpowVendorOffers
  End Sub
  Protected Sub FVpowVendorOffers_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowVendorOffers.DataBound
    SIS.POW.powVendorOffers.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVpowVendorOffers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowVendorOffers.PreRender
    Dim oF_TSID_Display As Label = FVpowVendorOffers.FindControl("F_TSID_Display")
    oF_TSID_Display.Text = String.Empty
    If Not Session("F_TSID_Display") Is Nothing Then
      If Session("F_TSID_Display") <> String.Empty Then
        oF_TSID_Display.Text = Session("F_TSID_Display")
      End If
    End If
    Dim oF_TSID As TextBox = FVpowVendorOffers.FindControl("F_TSID")
    oF_TSID.Enabled = True
    oF_TSID.Text = String.Empty
    If Not Session("F_TSID") Is Nothing Then
      If Session("F_TSID") <> String.Empty Then
        oF_TSID.Text = Session("F_TSID")
      End If
    End If
    Dim oF_EnquiryID_Display As Label = FVpowVendorOffers.FindControl("F_EnquiryID_Display")
    oF_EnquiryID_Display.Text = String.Empty
    If Not Session("F_EnquiryID_Display") Is Nothing Then
      If Session("F_EnquiryID_Display") <> String.Empty Then
        oF_EnquiryID_Display.Text = Session("F_EnquiryID_Display")
      End If
    End If
    Dim oF_EnquiryID As TextBox = FVpowVendorOffers.FindControl("F_EnquiryID")
    oF_EnquiryID.Enabled = True
    oF_EnquiryID.Text = String.Empty
    If Not Session("F_EnquiryID") Is Nothing Then
      If Session("F_EnquiryID") <> String.Empty Then
        oF_EnquiryID.Text = Session("F_EnquiryID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powVendorOffers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowVendorOffers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowVendorOffers", mStr)
    End If
    Dim TSID As String = ""
    If Request.QueryString("TSID") IsNot Nothing Then
      TSID = Request.QueryString("TSID")
      CType(FVpowVendorOffers.FindControl("F_TSID"), TextBox).Text = TSID
      CType(FVpowVendorOffers.FindControl("F_TSID"), TextBox).Enabled = False
    End If
    If Request.QueryString("EnquiryID") IsNot Nothing Then
      Dim EnquiryID As String = Request.QueryString("EnquiryID")
      CType(FVpowVendorOffers.FindControl("F_EnquiryID"), TextBox).Text = EnquiryID
      CType(FVpowVendorOffers.FindControl("F_EnquiryID"), TextBox).Enabled = False
      Dim oEnq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(TSID, EnquiryID)
      Dim oF_OptionsFromEMailID As RadioButtonList = CType(FVpowVendorOffers.FindControl("F_OptionsFromEMailID"), RadioButtonList)
      Dim oF_FromEMailID As TextBox = CType(FVpowVendorOffers.FindControl("F_FromEMailID"), TextBox)
      Dim ds() As String = ((oEnq.SupplierEMailID.Replace(";", ",")) & ",As Given Below").Split(",".ToCharArray)
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
    End If
    If Request.QueryString("RecordID") IsNot Nothing Then
      CType(FVpowVendorOffers.FindControl("F_RecordID"), TextBox).Text = Request.QueryString("RecordID")
      CType(FVpowVendorOffers.FindControl("F_RecordID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TSIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.POW.powTechnicalSpecifications.SelectpowTechnicalSpecificationsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function EnquiryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.POW.powEnquiries.SelectpowEnquiriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_POW_Offers_EnquiryID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TSID As Int32 = CType(aVal(1), Int32)
    Dim EnquiryID As Int32 = CType(aVal(2), Int32)
    Dim oVar As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(TSID, EnquiryID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_POW_Offers_TSID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TSID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.POW.powTechnicalSpecifications = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(TSID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  Private Forwarded As Boolean = False

  Private Sub ODSpowVendorOffers_Inserted(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ODSpowVendorOffers.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.POW.powVendorOffers = CType(e.ReturnValue, SIS.POW.powVendorOffers)
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
        TBLpowVendorOffers.AfterInsertURL &= tmpURL
      Else
        SIS.POW.powVendorOffers.InitiateWF(oDC.TSID, oDC.EnquiryID, oDC.RecordID)
        If Request.QueryString("shortcut") IsNot Nothing Then
          TBLpowVendorOffers.AfterInsertURL = "~/POW_Main/App_Edit/EF_powVendorEnquiries.aspx?TSID=" & oDC.TSID & "&EnquiryID=" & oDC.EnquiryID
        Else
          TBLpowVendorOffers.AfterInsertURL = ""
        End If
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
    FVpowVendorOffers.InsertItem(False)
  End Sub

  Private Sub FVpowVendorOffers_ItemInserting(sender As Object, e As FormViewInsertEventArgs) Handles FVpowVendorOffers.ItemInserting
    Dim oF_OptionsFromEMailID As RadioButtonList = CType(FVpowVendorOffers.FindControl("F_OptionsFromEMailID"), RadioButtonList)
    Dim oF_FromEMailID As TextBox = CType(FVpowVendorOffers.FindControl("F_FromEMailID"), TextBox)
    If oF_OptionsFromEMailID.SelectedItem.Text = "As Given Below" Then
      If oF_FromEMailID.Text = "" Then
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("FROM EMail ID is mandatory.") & "');", True)
        e.Cancel = True
      End If
    End If

  End Sub

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
      FVpowVendorOffers.InsertItem(False)
    Catch ex As Exception
    End Try

  End Sub
End Class
