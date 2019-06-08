Imports System.Web.Script.Serialization
Partial Class EF_powTechnicalSpecifications
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
  Protected Sub ODSpowTechnicalSpecifications_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpowTechnicalSpecifications.Selected
    Dim tmp As SIS.POW.powTechnicalSpecifications = CType(e.ReturnValue, SIS.POW.powTechnicalSpecifications)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpowTechnicalSpecifications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTechnicalSpecifications.Init
    DataClassName = "EpowTechnicalSpecifications"
    SetFormView = FVpowTechnicalSpecifications
  End Sub
  Protected Sub TBLpowTechnicalSpecifications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTechnicalSpecifications.Init
    SetToolBar = TBLpowTechnicalSpecifications
  End Sub
  Protected Sub FVpowTechnicalSpecifications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpowTechnicalSpecifications.PreRender
    TBLpowTechnicalSpecifications.EnableSave = Editable
    TBLpowTechnicalSpecifications.EnableDelete = Deleteable
    TBLpowTechnicalSpecifications.PrintUrl &= Request.QueryString("TSID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/POW_Main/App_Edit") & "/EF_powTechnicalSpecifications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpowTechnicalSpecifications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpowTechnicalSpecifications", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpowTSIndentsCC As New gvBase
  Protected Sub GVpowTSIndents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowTSIndents.Init
    gvpowTSIndentsCC.DataClassName = "GpowTSIndents"
    gvpowTSIndentsCC.SetGridView = GVpowTSIndents
  End Sub
  Protected Sub TBLpowTSIndents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTSIndents.Init
    gvpowTSIndentsCC.SetToolBar = TBLpowTSIndents
  End Sub
  Protected Sub GVpowTSIndents_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowTSIndents.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTSIndents.DataKeys(e.CommandArgument).Values("TSID")  
        Dim SerialNo As Int32 = GVpowTSIndents.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpowTSIndents.EditUrl & "?TSID=" & TSID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Private WithEvents gvpowEnquiriesCC As New gvBase
  Protected Sub GVpowEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowEnquiries.Init
    gvpowEnquiriesCC.DataClassName = "GpowEnquiries"
    gvpowEnquiriesCC.SetGridView = GVpowEnquiries
  End Sub
  Protected Sub TBLpowEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowEnquiries.Init
    gvpowEnquiriesCC.SetToolBar = TBLpowEnquiries
  End Sub
  Private ShowPopup As Boolean = False
  Dim sTSID As Integer = 0
  Dim sEnquiryID As Integer = 0
  Protected Sub GVpowEnquiries_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowEnquiries.RowCommand
    If e.CommandName.ToLower = "lgEMailIDs".ToLower Then
      Try
        sTSID = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        sEnquiryID = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        ShowPopup = True
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "lgCopy".ToLower Then
      Try
        Dim TSID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim newEnq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.CopyEnquiry(TSID, EnquiryID)
        Dim RedirectUrl As String = TBLpowEnquiries.EditUrl & "?TSID=" & newEnq.TSID & "&EnquiryID=" & newEnq.EnquiryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TSID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RedirectUrl As String = TBLpowEnquiries.EditUrl & "?TSID=" & TSID & "&EnquiryID=" & EnquiryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "RequestCommercialOfferUVOwf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        SIS.POW.powEnquiries.RequestCommercialOfferUVOWF(TSID, EnquiryID)
        GVpowEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")  
        Dim EnquiryID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")  
        SIS.POW.powEnquiries.DeleteWF(TSID, EnquiryID)
        GVpowEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")  
        Dim EnquiryID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")  
        SIS.POW.powEnquiries.InitiateWF(TSID, EnquiryID)
        GVpowEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")  
        Dim EnquiryID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RedirectUrl As String = "~/POW_Main/App_Create/AF_powOffers.aspx?shortcut=1&ForSupplier=1" & "&TSID=" & TSID & "&EnquiryID=" & EnquiryID
        Response.Redirect(RedirectUrl)
        'SIS.POW.powEnquiries.ApproveWF(TSID, EnquiryID)
        'GVpowEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "replywf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RedirectUrl As String = "~/POW_Main/App_Create/AF_powOffers.aspx?shortcut=1" & "&TSID=" & TSID & "&EnquiryID=" & EnquiryID
        Response.Redirect(RedirectUrl)
        'SIS.POW.powEnquiries.ApproveWF(TSID, EnquiryID)
        'GVpowEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        SIS.POW.powEnquiries.CompleteWF(TSID, EnquiryID)
        GVpowEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpowEnquiries_AddClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowEnquiries.AddClicked
    Dim TSID As Int32 = CType(FVpowTechnicalSpecifications.FindControl("F_TSID"), TextBox).Text
    TBLpowEnquiries.AddUrl &= "&TSID=" & TSID
  End Sub
  Protected Sub CmdAddNew_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim TSID As Int32 = CType(FVpowTechnicalSpecifications.FindControl("F_TSID"), TextBox).Text
    TBLpowEnquiries.AddUrl &= "&TSID=" & TSID
    Response.Redirect(TBLpowEnquiries.AddUrl)
  End Sub

  Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
    Dim SupplierID As String = L_PrimaryKey.Text
    If SupplierID <> "" Then
      Dim EMailIDs As String = F_EMailIDs.Text
      If EMailIDs <> "" Then
        Dim BP As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(SupplierID)
        BP.EMailID = EMailIDs
        SIS.VR.vrBusinessPartner.UpdateData(BP)
      End If
    End If
  End Sub

  Private Sub EF_powTechnicalSpecifications_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If ShowPopup Then
      Dim Enquiry As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(sTSID, sEnquiryID)
      Dim Supplier As SIS.VR.vrBusinessPartner = Enquiry.FK_POW_Enquiries_SupplierID
      L_PrimaryKey.Text = Supplier.BPID
      HeaderText.Text = Supplier.BPName
      F_EMailIDs.Text = Supplier.EMailID
      mPopup.Show()
    End If

  End Sub
End Class
