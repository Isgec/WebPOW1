Imports System.Web.Script.Serialization
Partial Class EF_powVendorEnquiries
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
  Protected Sub ODSpowVendorEnquiries_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowVendorEnquiries.Selected
    Dim tmp As SIS.POW.powVendorEnquiries = CType(e.ReturnValue, SIS.POW.powVendorEnquiries)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowVendorEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowVendorEnquiries.Init
    DataClassName = "EpowVendorEnquiries"
    SetFormView = FVpowVendorEnquiries
  End Sub
  Protected Sub TBLpowVendorEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowVendorEnquiries.Init
    SetToolBar = TBLpowVendorEnquiries
  End Sub
  Protected Sub FVpowVendorEnquiries_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowVendorEnquiries.PreRender
    TBLpowVendorEnquiries.EnableSave = Editable
    TBLpowVendorEnquiries.EnableDelete = Deleteable
    TBLpowVendorEnquiries.PrintUrl &= Request.QueryString("TSID") & "|"
    TBLpowVendorEnquiries.PrintUrl &= Request.QueryString("EnquiryID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powVendorEnquiries.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowVendorEnquiries") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowVendorEnquiries", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpowVendorOffersCC As New gvBase
  Protected Sub GVpowVendorOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowVendorOffers.Init
    gvpowVendorOffersCC.DataClassName = "GpowVendorOffers"
    gvpowVendorOffersCC.SetGridView = GVpowVendorOffers
  End Sub
  Protected Sub TBLpowVendorOffers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowVendorOffers.Init
    gvpowVendorOffersCC.SetToolBar = TBLpowVendorOffers
  End Sub
  Protected Sub GVpowVendorOffers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowVendorOffers.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("TSID")  
        Dim EnquiryID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("EnquiryID")  
        Dim RecordID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("RecordID")  
        Dim RedirectUrl As String = TBLpowVendorOffers.EditUrl & "?TSID=" & TSID & "&EnquiryID=" & EnquiryID & "&RecordID=" & RecordID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("TSID")  
        Dim EnquiryID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("EnquiryID")  
        Dim RecordID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("RecordID")  
        SIS.POW.powVendorOffers.DeleteWF(TSID, EnquiryID, RecordID)
        GVpowVendorOffers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Revisewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("TSID")  
        Dim EnquiryID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("EnquiryID")  
        Dim RecordID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("RecordID")  
        SIS.POW.powVendorOffers.ReviseWF(TSID, EnquiryID, RecordID)
        GVpowVendorOffers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("TSID")  
        Dim EnquiryID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("EnquiryID")  
        Dim RecordID As Int32 = GVpowVendorOffers.DataKeys(e.CommandArgument).Values("RecordID")  
        SIS.POW.powVendorOffers.InitiateWF(TSID, EnquiryID, RecordID)
        GVpowVendorOffers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpowVendorOffers_AddClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowVendorOffers.AddClicked
    Dim TSID As Int32 = CType(FVpowVendorEnquiries.FindControl("F_TSID"), TextBox).Text
    Dim EnquiryID As Int32 = CType(FVpowVendorEnquiries.FindControl("F_EnquiryID"), TextBox).Text
    TBLpowVendorOffers.AddUrl &= "?TSID=" & TSID
    TBLpowVendorOffers.AddUrl &= "&EnquiryID=" & EnquiryID
  End Sub
  Protected Sub CmdAddNew_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim TSID As Int32 = CType(FVpowVendorEnquiries.FindControl("F_TSID"), TextBox).Text
    Dim EnquiryID As Int32 = CType(FVpowVendorEnquiries.FindControl("F_EnquiryID"), TextBox).Text
    TBLpowVendorOffers.AddUrl &= "?TSID=" & TSID
    TBLpowVendorOffers.AddUrl &= "&EnquiryID=" & EnquiryID
    Response.Redirect(TBLpowVendorOffers.AddUrl)
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_POW_Enquiries_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
