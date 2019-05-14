Imports System.Web.Script.Serialization
Partial Class EF_powEnquiries
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
  Protected Sub ODSpowEnquiries_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowEnquiries.Selected
    Dim tmp As SIS.POW.powEnquiries = CType(e.ReturnValue, SIS.POW.powEnquiries)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    Select Case tmp.StatusID
      Case enumEnquiryStates.EnquiryCreated
        AthEditable = True
      Case Else
        AthEditable = False
    End Select
  End Sub
  Protected Sub FVpowEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowEnquiries.Init
    DataClassName = "EpowEnquiries"
    SetFormView = FVpowEnquiries
  End Sub
  Protected Sub TBLpowEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowEnquiries.Init
    SetToolBar = TBLpowEnquiries
  End Sub
  Protected Sub FVpowEnquiries_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowEnquiries.PreRender
    TBLpowEnquiries.EnableSave = Editable
    TBLpowEnquiries.EnableForward = Editable
    TBLpowEnquiries.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powEnquiries.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowEnquiries") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowEnquiries", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpowOffersCC As New gvBase
  Protected Sub GVpowOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowOffers.Init
    gvpowOffersCC.DataClassName = "GpowOffers"
    gvpowOffersCC.SetGridView = GVpowOffers
  End Sub
  Protected Sub TBLpowOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowOffers.Init
    gvpowOffersCC.SetToolBar = TBLpowOffers
  End Sub
  Protected Sub GVpowOffers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowOffers.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TSID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RecordID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("RecordID")
        Dim RedirectUrl As String = TBLpowOffers.EditUrl & "?TSID=" & TSID & "&EnquiryID=" & EnquiryID & "&RecordID=" & RecordID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RecordID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("RecordID")
        SIS.POW.powOffers.DeleteWF(TSID, EnquiryID, RecordID)
        GVpowOffers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Closewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RecordID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("RecordID")
        SIS.POW.powOffers.CloseWF(TSID, EnquiryID, RecordID)
        GVpowOffers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RecordID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("RecordID")
        SIS.POW.powOffers.InitiateWF(TSID, EnquiryID, RecordID)
        GVpowOffers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RecordID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("RecordID")
        SIS.POW.powOffers.ApproveWF(TSID, EnquiryID, RecordID)
        GVpowOffers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RecordID As Int32 = GVpowOffers.DataKeys(e.CommandArgument).Values("RecordID")
        SIS.POW.powOffers.CompleteWF(TSID, EnquiryID, RecordID)
        GVpowOffers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpowOffers_AddClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowOffers.AddClicked
    Dim TSID As Int32 = CType(FVpowEnquiries.FindControl("F_TSID"), TextBox).Text
    Dim EnquiryID As Int32 = CType(FVpowEnquiries.FindControl("F_EnquiryID"), TextBox).Text
    TBLpowOffers.AddUrl &= "?TSID=" & TSID
    TBLpowOffers.AddUrl &= "&EnquiryID=" & EnquiryID
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
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
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
      FVpowEnquiries.UpdateItem(False)
    End If
  End Sub

  Private Sub ODSpowEnquiries_Updated(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ODSpowEnquiries.Updated
    If e.Exception Is Nothing Then
      Dim oDC As SIS.POW.powEnquiries = CType(e.ReturnValue, SIS.POW.powEnquiries)
      '==============
      If Request.Files.Count > 0 Then
        SIS.EDI.ediAFile.UploadFiles(Request, oDC.AthHandle, oDC.AthIndex, "", oDC.AthProcess)
      End If
      If Forwarded Then
        SIS.POW.powEnquiries.InitiateWF(oDC.TSID, oDC.EnquiryID)
      End If
      '====================
    End If

  End Sub

  Private Sub FVpowEnquiries_ItemUpdating(sender As Object, e As FormViewUpdateEventArgs) Handles FVpowEnquiries.ItemUpdating
    If CType(FVpowEnquiries.FindControl("F_SupplierID"), TextBox).Text = "" And CType(FVpowEnquiries.FindControl("F_SupplierName"), TextBox).Text = "" Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Supplier ID or Name is mandatory.") & "');", True)
      e.Cancel = True
    End If
  End Sub
  Private Forwarded As Boolean = False
  Private Sub TBLpowEnquiries_ForwardClicked(sender As Object, e As EventArgs) Handles TBLpowEnquiries.ForwardClicked
    If CType(FVpowEnquiries.FindControl("F_SupplierID"), TextBox).Text = "" And CType(FVpowEnquiries.FindControl("F_SupplierName"), TextBox).Text = "" Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Supplier ID or Name is mandatory.") & "');", True)
    Else
      Try
        Forwarded = True
        FVpowEnquiries.UpdateItem(False)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
End Class
