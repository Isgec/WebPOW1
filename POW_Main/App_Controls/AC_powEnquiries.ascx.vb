Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class AC_powEnquiries
  Inherits SIS.SYS.ctlInsertBase
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
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&TSID=" & oDC.TSID
      tmpURL &= "&EnquiryID=" & oDC.EnquiryID
      TBLpowEnquiries.AfterInsertURL &= tmpURL
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
    End If
    If Request.QueryString("EnquiryID") IsNot Nothing Then
      CType(FVpowEnquiries.FindControl("F_EnquiryID"), TextBox).Text = Request.QueryString("EnquiryID")
      CType(FVpowEnquiries.FindControl("F_EnquiryID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TSIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.POW.powTechnicalSpecifications.SelectpowTechnicalSpecificationsAutoCompleteList(prefixText, count, contextKey)
  End Function
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
  Public Shared Function validate_FK_POW_Enquiries_TSID(ByVal value As String) As String
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

End Class
