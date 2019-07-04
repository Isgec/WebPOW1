Imports System.Web.Script.Serialization
Partial Class AF_powEnquiries
  Inherits SIS.SYS.InsertBase
  Public Property TSID As String
    Get
      If ViewState("TSID") IsNot Nothing Then
        Return ViewState("TSID")
      End If
      Return 0
    End Get
    Set(value As String)
      If value <> "" Then
        ViewState.Add("TSID", value)
      Else
        ViewState.Add("TSID", 0)
      End If
    End Set
  End Property
  Protected Sub FVpowEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowEnquiries.Init
    DataClassName = "ApowEnquiries"
    SetFormView = FVpowEnquiries
  End Sub
  Protected Sub TBLpowEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowEnquiries.Init
    SetToolBar = TBLpowEnquiries
  End Sub
  Protected Sub ODSpowEnquiries_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowEnquiries.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.POW.powEnquiries = CType(e.ReturnValue, SIS.POW.powEnquiries)
      '==============
      If Request.Files.Count > 0 Then
        SIS.EDI.ediAFile.UploadFiles(Request, oDC.AthHandle, oDC.AthIndex, "", oDC.AthProcess)
      End If
      If Not Forwarded Then
        Dim tmpURL As String = "?tmp=1"
        tmpURL &= "&TSID=" & oDC.TSID
        tmpURL &= "&EnquiryID=" & oDC.EnquiryID
        TBLpowEnquiries.AfterInsertURL &= tmpURL
      Else
        SIS.POW.powEnquiries.InitiateWF(oDC.TSID, oDC.EnquiryID)
        If Request.QueryString("shortcut") IsNot Nothing Then
          TBLpowEnquiries.AfterInsertURL = "~/POW_Main/App_Edit/EF_powTechnicalSpecifications.aspx?TSID=" & oDC.TSID
        Else
          TBLpowEnquiries.AfterInsertURL = ""
        End If
      End If
    End If
  End Sub
  Protected Sub FVpowEnquiries_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowEnquiries.DataBound
    SIS.POW.powEnquiries.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVpowEnquiries_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowEnquiries.PreRender
    Dim oF_TSID_Display As Label = FVpowEnquiries.FindControl("F_TSID_Display")
    oF_TSID_Display.Text = String.Empty
    If Not Session("F_TSID_Display") Is Nothing Then
      If Session("F_TSID_Display") <> String.Empty Then
        oF_TSID_Display.Text = Session("F_TSID_Display")
      End If
    End If
    Dim oF_TSID As TextBox = FVpowEnquiries.FindControl("F_TSID")
    oF_TSID.Enabled = True
    oF_TSID.Text = String.Empty
    If Not Session("F_TSID") Is Nothing Then
      If Session("F_TSID") <> String.Empty Then
        oF_TSID.Text = Session("F_TSID")
      End If
    End If
    Dim oF_SupplierID_Display As Label = FVpowEnquiries.FindControl("F_SupplierID_Display")
    Dim oF_SupplierID As TextBox = FVpowEnquiries.FindControl("F_SupplierID")
    Dim oF_SupplierLoginID_Display As Label = FVpowEnquiries.FindControl("F_SupplierLoginID_Display")
    Dim oF_SupplierLoginID As TextBox = FVpowEnquiries.FindControl("F_SupplierLoginID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Create") & "/AF_powEnquiries.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowEnquiries") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowEnquiries", mStr)
    End If
    If Request.QueryString("TSID") IsNot Nothing Then
      CType(FVpowEnquiries.FindControl("F_TSID"), TextBox).Text = Request.QueryString("TSID")
      CType(FVpowEnquiries.FindControl("F_TSID"), TextBox).Enabled = False
      Dim oVar As SIS.POW.powTechnicalSpecifications = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(Request.QueryString("TSID"))
      CType(FVpowEnquiries.FindControl("F_AdditionalEMailIDs"), TextBox).Text = oVar.AdditionalEMailIDs
      TSID = oVar.TSID
    End If
    If Request.QueryString("EnquiryID") IsNot Nothing Then
      CType(FVpowEnquiries.FindControl("F_EnquiryID"), TextBox).Text = Request.QueryString("EnquiryID")
      CType(FVpowEnquiries.FindControl("F_EnquiryID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SupplierLoginIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_POW_Enquiries_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1), String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Supplier not found in Joomla & ERP."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.EMailID
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_POW_Enquiries_SupplierLoginID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SupplierLoginID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(SupplierLoginID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Protected Sub F_TSAttachments_FilesUploaded(oUpload As HtmlInputFile, e As EventArgs)
    If CType(FVpowEnquiries.FindControl("F_SupplierID"), TextBox).Text = "" And CType(FVpowEnquiries.FindControl("F_SupplierName"), TextBox).Text = "" Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Supplier ID or Name is mandatory.") & "');", True)
    Else
      FVpowEnquiries.InsertItem(False)
    End If
  End Sub

  Private Sub FVpowEnquiries_ItemInserting(sender As Object, e As FormViewInsertEventArgs) Handles FVpowEnquiries.ItemInserting
    If CType(FVpowEnquiries.FindControl("F_SupplierID"), TextBox).Text = "" And CType(FVpowEnquiries.FindControl("F_SupplierName"), TextBox).Text = "" Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Supplier ID or Name is mandatory.") & "');", True)
      e.Cancel = True
    End If
  End Sub

  Private Sub AF_powEnquiries_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Request.QueryString("TSID") IsNot Nothing Then
      TSID = Request.QueryString("TSID")
    End If
  End Sub
  Private Forwarded As Boolean = False
  Private Sub TBLpowEnquiries_ForwardClicked(sender As Object, e As EventArgs) Handles TBLpowEnquiries.ForwardClicked
    If CType(FVpowEnquiries.FindControl("F_SupplierID"), TextBox).Text = "" And CType(FVpowEnquiries.FindControl("F_SupplierName"), TextBox).Text = "" Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Supplier ID or Name is mandatory.") & "');", True)
    Else
      Try
        Forwarded = True
        FVpowEnquiries.InsertItem(False)
      Catch ex As Exception
      End Try
    End If

  End Sub
End Class
