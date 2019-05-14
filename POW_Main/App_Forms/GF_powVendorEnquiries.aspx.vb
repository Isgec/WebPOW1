Imports System.Web.Script.Serialization
Partial Class GF_powVendorEnquiries
  Inherits SIS.SYS.GridBase
  Protected Sub GVpowVendorEnquiries_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowVendorEnquiries.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RedirectUrl As String = TBLpowVendorEnquiries.EditUrl & "?TSID=" & TSID & "&EnquiryID=" & EnquiryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Selectwf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        Dim RedirectUrl As String = "~/POW_Main/App_Create/AF_powVendorOffers.aspx?shortcut=1" & "&TSID=" & TSID & "&EnquiryID=" & EnquiryID
        Response.Redirect(RedirectUrl)
        'SIS.POW.powVendorEnquiries.SelectWF(TSID, EnquiryID)
        'GVpowVendorEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "SendTechnicalOfferwf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        SIS.POW.powVendorEnquiries.SendTechnicalOfferWF(TSID, EnquiryID)
        GVpowVendorEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "SendCommercialOfferwf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        SIS.POW.powVendorEnquiries.SendCommercialOfferWF(TSID, EnquiryID)
        GVpowVendorEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "SendOtherInformationwf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        SIS.POW.powVendorEnquiries.SendOtherInformationWF(TSID, EnquiryID)
        GVpowVendorEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("TSID")
        Dim EnquiryID As Int32 = GVpowVendorEnquiries.DataKeys(e.CommandArgument).Values("EnquiryID")
        SIS.POW.powVendorEnquiries.ApproveWF(TSID, EnquiryID)
        GVpowVendorEnquiries.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpowVendorEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowVendorEnquiries.Init
    DataClassName = "GpowVendorEnquiries"
    SetGridView = GVpowVendorEnquiries
  End Sub
  Protected Sub TBLpowVendorEnquiries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowVendorEnquiries.Init
    SetToolBar = TBLpowVendorEnquiries
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
