Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Partial Class GF_powTechnicalSpecifications
  Inherits SIS.SYS.GridBase
  Protected Sub GVpowTechnicalSpecifications_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpowTechnicalSpecifications.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTechnicalSpecifications.DataKeys(e.CommandArgument).Values("TSID")
        Dim RedirectUrl As String = TBLpowTechnicalSpecifications.EditUrl & "?TSID=" & TSID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "CreateEnquirywf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTechnicalSpecifications.DataKeys(e.CommandArgument).Values("TSID")
        Dim RedirectUrl As String = "~/POW_Main/App_Create/AF_powEnquiries.aspx?shortcut=1" & "&TSID=" & TSID
        Response.Redirect(RedirectUrl)

        'SIS.POW.powTechnicalSpecifications.CreateEnquiryWF(TSID)
        'GVpowTechnicalSpecifications.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTechnicalSpecifications.DataKeys(e.CommandArgument).Values("TSID")
        SIS.POW.powTechnicalSpecifications.DeleteWF(TSID)
        GVpowTechnicalSpecifications.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Archivewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTechnicalSpecifications.DataKeys(e.CommandArgument).Values("TSID")
        SIS.POW.powTechnicalSpecifications.ArchiveWF(TSID)
        GVpowTechnicalSpecifications.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTechnicalSpecifications.DataKeys(e.CommandArgument).Values("TSID")
        SIS.POW.powTechnicalSpecifications.InitiateWF(TSID)
        GVpowTechnicalSpecifications.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTechnicalSpecifications.DataKeys(e.CommandArgument).Values("TSID")
        SIS.POW.powTechnicalSpecifications.ApproveWF(TSID)
        GVpowTechnicalSpecifications.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim TSID As Int32 = GVpowTechnicalSpecifications.DataKeys(e.CommandArgument).Values("TSID")
        SIS.POW.powTechnicalSpecifications.CompleteWF(TSID)
        GVpowTechnicalSpecifications.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpowTechnicalSpecifications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpowTechnicalSpecifications.Init
    DataClassName = "GpowTechnicalSpecifications"
    SetGridView = GVpowTechnicalSpecifications
  End Sub
  Protected Sub TBLpowTechnicalSpecifications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpowTechnicalSpecifications.Init
    SetToolBar = TBLpowTechnicalSpecifications
  End Sub
  Protected Sub F_StatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.TextChanged
    Session("F_StatusID") = F_StatusID.Text
    Session("F_StatusID_Display") = F_StatusID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function StatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.POW.powTSStates.SelectpowTSStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_StatusID_Display.Text = String.Empty
    If Not Session("F_StatusID_Display") Is Nothing Then
      If Session("F_StatusID_Display") <> String.Empty Then
        F_StatusID_Display.Text = Session("F_StatusID_Display")
      End If
    End If
    F_StatusID.Text = String.Empty
    If Not Session("F_StatusID") Is Nothing Then
      If Session("F_StatusID") <> String.Empty Then
        F_StatusID.Text = Session("F_StatusID")
      End If
    End If
    Dim strScriptStatusID As String = "<script type=""text/javascript""> " & _
      "function ACEStatusID_Selected(sender, e) {" & _
      "  var F_StatusID = $get('" & F_StatusID.ClientID & "');" & _
      "  var F_StatusID_Display = $get('" & F_StatusID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_StatusID.value = p[0];" & _
      "  F_StatusID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_StatusID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_StatusID", strScriptStatusID)
      End If
    Dim strScriptPopulatingStatusID As String = "<script type=""text/javascript""> " & _
      "function ACEStatusID_Populating(o,e) {" & _
      "  var p = $get('" & F_StatusID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEStatusID_Populated(o,e) {" & _
      "  var p = $get('" & F_StatusID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_StatusIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_StatusIDPopulating", strScriptPopulatingStatusID)
      End If
    Dim validateScriptStatusID As String = "<script type=""text/javascript"">" & _
      "  function validate_StatusID(o) {" & _
      "    validated_FK_POW_TS_StatusID_main = true;" & _
      "    validate_FK_POW_TS_StatusID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateStatusID", validateScriptStatusID)
    End If
    Dim validateScriptFK_POW_TS_StatusID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_POW_TS_StatusID(o) {" & _
      "    var value = o.id;" & _
      "    var StatusID = $get('" & F_StatusID.ClientID & "');" & _
      "    try{" & _
      "    if(StatusID.value==''){" & _
      "      if(validated_FK_POW_TS_StatusID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + StatusID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_POW_TS_StatusID(value, validated_FK_POW_TS_StatusID);" & _
      "  }" & _
      "  validated_FK_POW_TS_StatusID_main = false;" & _
      "  function validated_FK_POW_TS_StatusID(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_POW_TS_StatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_POW_TS_StatusID", validateScriptFK_POW_TS_StatusID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_POW_TS_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim StatusID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.POW.powTSStates = SIS.POW.powTSStates.powTSStatesGetByID(StatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

  Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click
    Try
      Dim oTS As SIS.POW.powTechnicalSpecifications = SIS.POW.powTechnicalSpecifications.Import(F_IndentNo.Text, F_IndentLine.Text)
      GVpowTechnicalSpecifications.DataBind()
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(oTS.TSID & " Created / Updated successfully.") & "');", True)
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
  End Sub

  Private Sub GVpowTechnicalSpecifications_PreRender(sender As Object, e As EventArgs) Handles GVpowTechnicalSpecifications.PreRender
  End Sub
End Class
