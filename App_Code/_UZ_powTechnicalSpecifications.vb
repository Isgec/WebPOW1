Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  Partial Public Class powTechnicalSpecifications
    Private _Projects As String = ""
    Public ReadOnly Property Projects As String
      Get
        If _Projects <> "" Then Return _Projects
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", _TSID)
        For Each tmp As SIS.POW.powTSIndents In Indents
          If _Projects = "" Then _Projects = tmp.ProjectID Else _Projects &= "," & tmp.ProjectID
        Next
        Return _Projects
      End Get
    End Property
    Public ReadOnly Property M_details As String
      Get
        Dim mRet As String = "<ul>"
        mRet &= "<li>" & TSID & "</li>"
        mRet &= "<li>" & TSDescription & "</li>"
        mRet &= "<li>" & Projects & "</li>"
        mRet &= "<li>" & aspnet_Users1_UserFullName & "</li>"
        mRet &= "<li>" & CreatedOn & "</li>"
        mRet &= "</ul>"
        Return mRet
      End Get
    End Property
    Public Property AthProcess As String = "POW_TECHSPEC"
    Public Property AthHandle As String = "J_PREORDER_TECHSPEC"
    Public ReadOnly Property AthIndex As String
      Get
        Return TSID
      End Get
    End Property

    Public Property AllOfferReceivedOn As String = ""
    Public Property CommercialOfferFinalizedOn As String = ""
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case enumTSStates.TechnicalSpecificationReleased
          mRet = Drawing.Color.FromArgb(0, 102, 102)
        Case enumTSStates.EnquiryInProgress
          mRet = Drawing.Color.Maroon
        Case enumTSStates.AllOfferReceived
          mRet = Drawing.Color.Green
        Case enumTSStates.CommercialofferFinalized
          mRet = Drawing.Color.DarkGoldenrod
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumTSStates.TechnicalSpecificationReleased, enumTSStates.Created
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CreateEnquiryWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          Select Case StatusID
            Case enumTSStates.Created, enumTSStates.Acrchived
              mRet = False
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CreateEnquiryWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function CreateEnquiryWF(ByVal TSID As Int32) As SIS.POW.powTechnicalSpecifications
      'Handled in GV, redirected to Create Enquiry Page
      Dim Results As SIS.POW.powTechnicalSpecifications = powTechnicalSpecificationsGetByID(TSID)
      Return Results
    End Function
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Return Deleteable
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal TSID As Int32) As SIS.POW.powTechnicalSpecifications
      Dim Results As SIS.POW.powTechnicalSpecifications = powTechnicalSpecificationsGetByID(TSID)
      Return Results
    End Function
    Public ReadOnly Property ArchiveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ArchiveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ArchiveWF(ByVal TSID As Int32) As SIS.POW.powTechnicalSpecifications
      Dim Results As SIS.POW.powTechnicalSpecifications = powTechnicalSpecificationsGetByID(TSID)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumTSStates.Created
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          Select Case StatusID
            Case enumTSStates.Created, enumTSStates.Acrchived, enumTSStates.AllOfferReceived, enumTSStates.CommercialofferFinalized
              mRet = False
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          Select Case StatusID
            Case enumTSStates.Created, enumTSStates.Acrchived, enumTSStates.CommercialofferFinalized
              mRet = False
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function GetLastCreated() As SIS.POW.powTechnicalSpecifications
      Dim Results As SIS.POW.powTechnicalSpecifications = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppow_LG_GetLastCreated"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.POW.powTechnicalSpecifications(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function InitiateWF(ByVal TSID As Int32) As SIS.POW.powTechnicalSpecifications
      Dim cnt As Integer = SIS.POW.powTSIndentDocuments.GetCountByTSID(TSID)
      If cnt <= 0 Then
        Throw New Exception("There is NO specification document found, can not release.")
      End If
      Dim Results As SIS.POW.powTechnicalSpecifications = powTechnicalSpecificationsGetByID(TSID)
      If Results.TSDescription = "" Then
        Throw New Exception("Pl. Enter Description.")
      End If
      With Results
        .StatusID = enumTSStates.TechnicalSpecificationReleased
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Results = SIS.POW.powTechnicalSpecifications.UpdateData(Results)
      '======Update CT======
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", Results.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        Insert168(Indents(0), Comp)  'By First Indent 
        For Each Indent As SIS.POW.powTSIndents In Indents
          Dim Docs As List(Of SIS.POW.powTSIndentDocuments) = SIS.POW.powTSIndentDocuments.UZ_powTSIndentDocumentsSelectList(0, 9999, "", False, "", Indent.SerialNo, Indent.TSID)
          For Each doc As SIS.POW.powTSIndentDocuments In Docs
            Try
              Insert167(doc, Comp)
            Catch ex As Exception
            End Try
          Next
        Next
      End If
      '======================
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal TSID As Int32) As SIS.POW.powTechnicalSpecifications
      Dim Results As SIS.POW.powTechnicalSpecifications = powTechnicalSpecificationsGetByID(TSID)
      With Results
        .StatusID = enumTSStates.AllOfferReceived
        .AllOfferReceivedOn = Now
      End With
      Results = SIS.POW.powTechnicalSpecifications.UpdateData(Results)
      '====Update CT=============
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", Results.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        CT_Update_AllOfferReceived(Results, Comp)
      End If
      '==========================
      Return Results
    End Function
    Private Shared Sub CT_Update_AllOfferReceived(ByVal pTS As SIS.POW.powTechnicalSpecifications, Optional ByVal Comp As String = "200")
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Sql = ""
        Sql &= "   UPDATE [tdmisg168" & Comp & "] "
        Sql &= "   SET "
        Sql &= "   [t_stat] ='All Offer Received' "
        Sql &= "   WHERE "
        Sql &= "   [t_wfid] =" & pTS.TSID
        Sql &= "   AND [t_pwfd] = 0 "
        Sql &= "   AND [t_stat] <> 'Commercial offer Finalized' "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
            Throw New Exception(Sql)
          End Try
        End Using
      End Using
    End Sub

    Public Shared Function CompleteWF(ByVal TSID As Int32) As SIS.POW.powTechnicalSpecifications
      Dim Results As SIS.POW.powTechnicalSpecifications = powTechnicalSpecificationsGetByID(TSID)
      With Results
        .StatusID = enumTSStates.CommercialofferFinalized
        .CommercialOfferFinalizedOn = Now
      End With
      Results = SIS.POW.powTechnicalSpecifications.UpdateData(Results)
      '====Update CT=============
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", Results.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        CT_Update_CommercialFinalized(Results, Comp)
        CT_Update_140_CommercialFinalized(Results, Comp)
      End If
      '==========================
      Return Results
    End Function
    Public Shared Sub CT_Update_140_CommercialFinalized(tmp As SIS.POW.powTechnicalSpecifications, Comp As String)
      Dim tmpDocs As List(Of SIS.EDI.ediAFile) = SIS.EDI.ediAFile.ediAFileGetAllByHandleIndex(tmp.AthHandle, tmp.AthIndex, Comp)
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        For Each fl As SIS.EDI.ediAFile In tmpDocs
          Sql = ""
          Sql &= "   UPDATE [tdmisg140" & Comp & "] "
          Sql &= "   SET "
          Sql &= "   [t_cmfd] = convert(datetime,'" & tmp.CommercialOfferFinalizedOn & "',103) "
          Sql &= "   WHERE "
          Sql &= "   upper([t_docn]) =upper('" & IO.Path.GetFileNameWithoutExtension(fl.t_fnam) & "') "
          Sql &= "   AND [t_cmfd] < convert(datetime,'01/01/2000',103) and t_cmfd < convert(datetime,'" & tmp.CommercialOfferFinalizedOn & "',103)"
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Try
              Cmd.ExecuteNonQuery()
            Catch ex As Exception
              Dim aa = ex
            End Try
          End Using
        Next
      End Using
    End Sub
    Private Shared Sub CT_Update_CommercialFinalized(ByVal pTS As SIS.POW.powTechnicalSpecifications, Optional ByVal Comp As String = "200")
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Sql = ""
        Sql &= "   UPDATE [tdmisg168" & Comp & "] "
        Sql &= "   SET "
        Sql &= "   [t_stat] ='Commercial offer Finalized' "
        Sql &= "   WHERE "
        Sql &= "   [t_wfid] =" & pTS.TSID
        Sql &= "   AND [t_pwfd] = 0 "
        Sql &= "   AND [t_stat] <>'Commercial offer Finalized' "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
            Throw New Exception(Sql)
          End Try
        End Using
      End Using
    End Sub
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_TSID"), TextBox).Text = ""
          CType(.FindControl("F_TSTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_TSDescription"), TextBox).Text = ""
          CType(.FindControl("F_AdditionalEMailIDs"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function Insert168(ByVal pWF As SIS.POW.powTSIndents, ByVal Comp As String) As String
      Dim Sql As String = ""
      Dim LotItem As String = ""
      If pWF.LotItem.Length > 50 Then
        LotItem = pWF.LotItem.Substring(0, 50)
      Else
        LotItem = pWF.LotItem
      End If

      Sql &= "   INSERT [tdmisg168" & Comp & "] "
      Sql &= "   ( "
      Sql &= "    [t_wfid] " 'int
      Sql &= "   ,[t_pwfd] " 'int
      Sql &= "   ,[t_cprj] " '9
      Sql &= "   ,[t_elem] " '8
      Sql &= "   ,[t_spec] " '50
      Sql &= "   ,[t_bpid] " '8 ?should be 9
      Sql &= "   ,[t_stat] " '100
      Sql &= "   ,[t_user] " '8
      Sql &= "   ,[t_date] " 'dt
      Sql &= "   ,[t_supp] " '300
      Sql &= "   ,[t_snam] " '100
      Sql &= "   ,[t_rdno] " '8
      Sql &= "   ,[t_docn] " '256
      Sql &= "   ,[t_supc] " '50
      Sql &= "   ,[t_rcno] " '9
      Sql &= "   ,[t_mngr] " '8
      Sql &= "   ,[t_esub] " '215
      Sql &= "   ,[t_Refcntd] " '0
      Sql &= "   ,[t_Refcntu] " '0
      Sql &= "   ) "
      Sql &= "   VALUES "
      Sql &= "   ( "
      Sql &= "     " & pWF.TSID
      Sql &= "   , " & 0
      Sql &= "   ,'" & pWF.ProjectID & "'"
      Sql &= "   ,'" & pWF.ElementID & "'"
      Sql &= "   ,'" & LotItem & "'"
      Sql &= "   ,'" & pWF.BuyerID & "'"
      Sql &= "   ,'" & "Technical Specification Released" & "'"
      Sql &= "   ,'" & pWF.FK_POW_TSIndents_TSID.CreatedBy & "'"
      Sql &= "   ,convert(datetime,'" & pWF.FK_POW_TSIndents_TSID.CreatedOn & "',103)"
      Sql &= "   ,''" '& pWF.Supplierid & "'"
      Sql &= "   ,''" '& pWF.SupplierName & "'"
      Sql &= "   ,''" '& pWF.RandomNo & "'"
      Sql &= "   ,'" & "Indent/Line No.: " & pWF.IndentNo & "/" & pWF.IndentLine & "'"
      Sql &= "   ,''" '& pWF.LotItem & "'"
      Sql &= "   ,''" '& pWF.ReceiptNo & "'"
      Sql &= "   ,'" & pWF.IndenterID & "'"
      Sql &= "   ,''" '& pWF.EmailSubject & "'"
      Sql &= "   ,0"
      Sql &= "   ,0"
      Sql &= "   ) "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
            Throw New Exception(Sql)
          End Try
        End Using
      End Using
      Return ""
    End Function
    Public Shared Sub Insert167(ByVal pWFpmdl As SIS.POW.powTSIndentDocuments, Optional ByVal Comp As String = "200")
      Dim Sql As String = ""
      Sql &= "   INSERT [tdmisg167" & Comp & "] "
      Sql &= "   ( "
      Sql &= "    [t_wfid] "
      Sql &= "   ,[t_docn] "
      Sql &= "   ,[t_Refcntd] "
      Sql &= "   ,[t_Refcntu] "
      Sql &= "   ) "
      Sql &= "   VALUES "
      Sql &= "   ( "
      Sql &= "     " & pWFpmdl.TSID
      Sql &= "   ,UPPER('" & pWFpmdl.DocumentID & "') "
      Sql &= "   ,0 "
      Sql &= "   ,0 "
      Sql &= "   ) "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub
    Public Shared Function Import(ByVal IndentNo As String, ByVal LineNo As String, Optional ByVal oTS As SIS.POW.powTechnicalSpecifications = Nothing, Optional ByVal ImportingFromJoomla As Boolean = True) As SIS.POW.powTechnicalSpecifications
      If IndentNo = "" Then Return oTS
      If LineNo = "" Then LineNo = 0

      Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(IndentNo)
      '1. Get Indent From ERP
      Dim Indent As SIS.TDPUR.tdpur200 = SIS.TDPUR.tdpur200.tdpur200GetByID(IndentNo, Comp)
      If Indent Is Nothing Then Throw New Exception("Indent Not Found.")
      If Indent.t_rqst <> 3 Then
        Throw New Exception("Indent must be approved.")
      End If
      '2. Get Indent Lines From ERP
      Dim IndentLines As List(Of SIS.TDPUR.tdpur201) = SIS.TDPUR.tdpur201.GetByRQNo(IndentNo, LineNo, Comp)
      '3. Check RFQ for All Indent Lines
      For Each IndentLine As SIS.TDPUR.tdpur201 In IndentLines
        LineNo = IndentLine.t_pono
        '==============Check, If there is child Items then only Create=================
        Dim tmpDocs As List(Of SIS.TDISG.tdisg003) = SIS.TDISG.tdisg003.GetDocument(IndentLine.t_rqno, IndentLine.t_pono)
        If tmpDocs.Count <= 0 Then
          Continue For
        End If
        '===============End Of Check=============================
        '=================================
        '=================================
        If oTS Is Nothing Then
          If ImportingFromJoomla Then
            'Get Last Created oTS, to Add further Indent Line in Same TS
            oTS = SIS.POW.powTechnicalSpecifications.GetLastCreated()
          End If
          If oTS Is Nothing Then
            oTS = New SIS.POW.powTechnicalSpecifications
            With oTS
              .TSDescription = IndentLine.t_nids
              .TSTypeID = enumTSTypes.Boughtout
              If ImportingFromJoomla Then
                .StatusID = enumTSStates.Created
              Else
                .StatusID = enumTSStates.TechnicalSpecificationReleased
              End If
              .CreatedBy = HttpContext.Current.Session("LoginID")
              .CreatedOn = Now
            End With
            oTS = SIS.POW.powTechnicalSpecifications.InsertData(oTS)
          End If
        End If
        '====================================
        Dim oPVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(IndentLine.t_cprj)
        If oPVar Is Nothing Then oPVar = SIS.QCM.qcmProjects.GetProjectFromERP(IndentLine.t_cprj, Comp)
        Dim owUsr As SIS.QCM.qcmUsers = Nothing
        Dim usr As String = IIf(Indent.t_ccon.Length < 4, Right("0000" & Indent.t_ccon, 4), Indent.t_ccon)
        Dim tmpemp As SIS.QCM.qcmEmployees = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(usr)
        owUsr = SIS.QCM.qcmUsers.qcmUsersGetByID(usr)
        If owUsr Is Nothing Then
          owUsr = New SIS.QCM.qcmUsers
          With owUsr
            .UserName = usr
            .ActiveState = 1
            .UserFullName = IIf(tmpemp IsNot Nothing, tmpemp.EmployeeName, "Not In Employee Master")
            .EMailID = IIf(tmpemp IsNot Nothing, tmpemp.EMailID, "Not In Employee Master")
          End With
          owUsr.PW = SIS.QCM.qcmUsers.CreateWebUser(owUsr)
          SIS.QCM.qcmUsers.UpdateData(owUsr)
        End If

        usr = IIf(Indent.t_remn.Length < 4, Right("0000" & Indent.t_remn, 4), Indent.t_remn)
        tmpemp = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(usr)
        owUsr = SIS.QCM.qcmUsers.qcmUsersGetByID(usr)
        If owUsr Is Nothing Then
          owUsr = New SIS.QCM.qcmUsers
          With owUsr
            .UserName = usr
            .ActiveState = 1
            .UserFullName = IIf(tmpemp IsNot Nothing, tmpemp.EmployeeName, "Not In Employee Master")
            .EMailID = IIf(tmpemp IsNot Nothing, tmpemp.EMailID, "Not In Employee Master")
          End With
          owUsr.PW = SIS.QCM.qcmUsers.CreateWebUser(owUsr)
          SIS.QCM.qcmUsers.UpdateData(owUsr)
        End If
        '====================================
        '4. Create NEW WFID
        Dim oTSI As New SIS.POW.powTSIndents
        With oTSI
          .TSID = oTS.TSID
          .SerialNo = 0
          .BuyerID = IIf(Indent.t_ccon.Length < 4, Right("0000" & Indent.t_ccon, 4), Indent.t_ccon)
          .IndenterID = IIf(Indent.t_remn.Length < 4, Right("0000" & Indent.t_remn, 4), Indent.t_remn)
          .ElementID = IndentLine.t_cspa
          .IndentLine = IndentLine.t_pono
          .IndentNo = IndentLine.t_rqno
          .LotItem = IndentLine.t_item
          .ProjectID = IndentLine.t_cprj
          .Specification = IndentLine.t_nids
        End With
        oTSI = SIS.POW.powTSIndents.InsertData(oTSI)
        '6. Create WF PMDL Docs
        For Each doc As SIS.TDISG.tdisg003 In tmpDocs
          Dim oTSIDoc As SIS.POW.powTSIndentDocuments = Nothing
          Dim aFile As SIS.EDI.ediAFile = Nothing
          oTSIDoc = SIS.POW.powTSIndentDocuments.powTSIndentDocumentsGetByDocumentID(oTSI.TSID, oTSI.SerialNo, doc.t_docn)
          If oTSIDoc Is Nothing Then
            oTSIDoc = New SIS.POW.powTSIndentDocuments
            With oTSIDoc
              .TSID = oTSI.TSID
              .SerialNo = oTSI.SerialNo
              .DocNo = 0
              .DocumentID = doc.t_docn
              .DocumentRevision = doc.t_revi
            End With
            oTSIDoc = SIS.POW.powTSIndentDocuments.InsertData(oTSIDoc)
            '7. Copy Handle To WFID
            aFile = SIS.EDI.ediAFile.ediAFileGetByHandleIndex("DOCUMENTMASTERPDF_" & Comp, doc.t_docn & "_" & doc.t_revi)
            If aFile IsNot Nothing Then
              aFile.t_hndl = "J_PREORDER_TECHSPEC"
              aFile.t_indx = oTS.TSID
              If Convert.ToBoolean(ConfigurationManager.AppSettings("JoomlaLive")) Then
                SIS.EDI.ediAFile.InsertData(aFile, Comp)
              End If
            End If
          End If
          '8.======Get Ref.Dwg for this document======
          Dim Refs As List(Of SIS.DMISG.dmisg003) = SIS.DMISG.dmisg003.SelectRefDrawingList(doc.t_docn, doc.t_revi, Comp)
          For Each ref As SIS.DMISG.dmisg003 In Refs
            ref.t_drgn = IO.Path.GetFileNameWithoutExtension(ref.t_drgn)
            If ref.t_drev = "" Then
              ref.t_drev = SIS.DMISG.dmisg003.GetLatestRevisionNoOfDocument(ref.t_drgn)
            End If
            If ref.t_drev <> "" Then
              'Ref. Drawing is NOT yet Released
              'Do NOT Create Meta Data
              oTSIDoc = SIS.POW.powTSIndentDocuments.powTSIndentDocumentsGetByDocumentID(oTSI.TSID, oTSI.SerialNo, ref.t_drgn)
              If oTSIDoc Is Nothing Then
                oTSIDoc = New SIS.POW.powTSIndentDocuments
                With oTSIDoc
                  .TSID = oTSI.TSID
                  .SerialNo = oTSI.SerialNo
                  .DocNo = 0
                  .DocumentID = ref.t_drgn
                  .DocumentRevision = ref.t_drev
                End With
                oTSIDoc = SIS.POW.powTSIndentDocuments.InsertData(oTSIDoc)
                '9. Copy Handle To WFID
                aFile = SIS.EDI.ediAFile.ediAFileGetByHandleIndex("DOCUMENTMASTERPDF_" & Comp, ref.t_drgn & "_" & ref.t_drev)
                If aFile IsNot Nothing Then
                  aFile.t_hndl = "J_PREORDER_TECHSPEC"
                  aFile.t_indx = oTS.TSID
                  If Convert.ToBoolean(ConfigurationManager.AppSettings("JoomlaLive")) Then
                    SIS.EDI.ediAFile.InsertData(aFile, Comp)
                  End If
                End If
              End If
            End If
          Next
          '=====End Ref Drawing==========
        Next
        '================================
        'Update Flag in ERP-LN with TSID 
        SIS.TDPUR.tdpur201.UpdateTSID(oTSI.IndentNo, oTSI.IndentLine, oTSI.TSID)
        '================================
      Next
      Return oTS
    End Function

    'Private Shared Function Insert169(ByVal pWFh As SIS.WF.wfPreOrderHistory, ByVal Comp As String) As String
    '  Dim Sql As String = ""
    '  Sql &= "   INSERT [tdmisg169" & Comp & "] "
    '  Sql &= "   ( "
    '  Sql &= "    [t_hwfd] "
    '  Sql &= "   ,[t_wfid] "
    '  Sql &= "   ,[t_slno] "
    '  Sql &= "   ,[t_pwfd] "
    '  Sql &= "   ,[t_cprj] "
    '  Sql &= "   ,[t_elem] "
    '  Sql &= "   ,[t_spec] "
    '  Sql &= "   ,[t_bpid] "
    '  Sql &= "   ,[t_stat] "
    '  Sql &= "   ,[t_user] "
    '  Sql &= "   ,[t_date] "
    '  Sql &= "   ,[t_supp] "
    '  Sql &= "   ,[t_snam] "
    '  Sql &= "   ,[t_note] "
    '  Sql &= "   ,[t_docn] "
    '  Sql &= "   ,[t_mngr] "
    '  Sql &= "   ,[t_Refcntd] "
    '  Sql &= "   ,[t_Refcntu] "
    '  Sql &= "   ) "
    '  Sql &= "   VALUES "
    '  Sql &= "   ( "
    '  Sql &= "     " & pWFh.WF_HistoryID
    '  Sql &= "   , " & pWFh.WFID
    '  Sql &= "   , " & pWFh.WFID_SlNo
    '  Sql &= "   , " & pWFh.Parent_WFID
    '  Sql &= "   ,'" & pWFh.Project.Substring(0, 6) & "'"
    '  Sql &= "   ,'" & pWFh.Element.Substring(0, 8) & "'"
    '  Sql &= "   ,'" & pWFh.SpecificationNo & "'"
    '  Sql &= "   ,'" & pWFh.Buyer & "'"
    '  Sql &= "   ,'" & pWFh.WF_Status & "'"
    '  Sql &= "   ,'" & pWFh.UserId & "'"
    '  Sql &= "   ,convert(datetime,'" & pWFh.DateTime & "',103)"
    '  Sql &= "   ,'" & pWFh.Supplier & "'"
    '  Sql &= "   ,'" & pWFh.SupplierName & "'"
    '  Sql &= "   ,'" & pWFh.Notes & "'"
    '  Sql &= "   ,'" & pWFh.PMDLDocNo & "'"
    '  Sql &= "   ,'" & pWFh.Manager & "'"
    '  Sql &= "   ,0 "
    '  Sql &= "   ,0 "
    '  Sql &= "   ) "
    '  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
    '    Using Cmd As SqlCommand = Con.CreateCommand()
    '      Cmd.CommandType = CommandType.Text
    '      Cmd.CommandText = Sql
    '      Con.Open()
    '      Try
    '        Cmd.ExecuteNonQuery()
    '      Catch ex As Exception
    '        Throw New Exception(Sql)
    '      End Try
    '    End Using
    '  End Using
    '  Return ""
    'End Function


    Public Shared Function SyncCTData(ByVal FromDT As String, Optional ByVal tsid As Integer = 0) As Boolean
      Dim mRet As Boolean = True
      If FromDT = "" Then
        FromDT = "25/05/2019" '  "01/08/2019"   '
      End If
      '1. Get TS List
      Dim Sql As String = ""
      If tsid = 0 Then
        Sql = "select * from POW_TechnicalSpecifications where CreatedOn>=convert(datetime,'" & FromDT & "',103)"
        Sql = "select * from POW_TechnicalSpecifications where tsid>10596"
      Else
        Sql = "select * from POW_TechnicalSpecifications where tsid=" & tsid
      End If
      Dim tsList As New List(Of SIS.POW.powTechnicalSpecifications)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            tsList.Add(New SIS.POW.powTechnicalSpecifications(rd))
          End While
        End Using
      End Using
      '2. Process each TS
      For Each ts As SIS.POW.powTechnicalSpecifications In tsList
        If ts.StatusID = enumTSStates.Created Then Continue For
        Dim Indts As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.powTSIndentsSelectList(0, 10, "", False, "", ts.TSID)
        If Indts.Count <= 0 Then Continue For
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indts(0).IndentNo)
        '3. Search ts in ERP
        Dim erpTS As SIS.DM.dmisg168 = SIS.DM.dmisg168.GetByID(ts.TSID, Comp)
        If erpTS IsNot Nothing Then
          '4. if found update status
          Dim t_stat As String = ""
          Select Case ts.StatusID
            Case enumTSStates.TechnicalSpecificationReleased
              t_stat = "Technical Specification Released"
            Case enumTSStates.EnquiryInProgress
              t_stat = "Enquiry in progress"
            Case enumTSStates.AllOfferReceived
              t_stat = "All Offer Received"
            Case enumTSStates.CommercialofferFinalized
              t_stat = "Commercial offer Finalized"
          End Select
          Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
            Con.Open()
            Using Cmd As SqlCommand = Con.CreateCommand()
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = "   UPDATE [tdmisg168" & Comp & "]  set t_stat = '" & t_stat & "' where t_wfid=" & erpTS.t_wfid
              Cmd.ExecuteNonQuery()
            End Using
          End Using
        Else
          '5. if not found insert 
          erpTS = SIS.DM.dmisg168.Getdmisg168(ts)
          SIS.DM.dmisg168.InsertData(erpTS, Comp)
        End If
        '==================
        If ts.StatusID = enumTSStates.CommercialofferFinalized Then
          If ts.CommercialOfferFinalizedOn <> "" Then
            SIS.POW.powTechnicalSpecifications.CT_Update_140_CommercialFinalized(ts, Comp)
          End If
        End If
        '==================
        '6. Insert Update Documents
        Dim tsDocs As List(Of SIS.POW.powTSIndentDocuments) = SIS.POW.powTSIndentDocuments.powTSIndentDocumentsSelectList(0, 9999, "", False, "", 0, ts.TSID)
        For Each doc As SIS.POW.powTSIndentDocuments In tsDocs
          Dim erpDoc As SIS.DM.dmisg167 = SIS.DM.dmisg167.GetByID(doc.TSID, doc.DocumentID, Comp)
          If erpDoc Is Nothing Then
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
              Using Cmd As SqlCommand = Con.CreateCommand()
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "insert tdmisg167" & Comp & " (t_wfid,t_docn,t_Refcntd,t_Refcntu) values (" & doc.TSID & ",'" & doc.DocumentID & "',0,0)"
                Con.Open()
                Cmd.ExecuteNonQuery()
              End Using
            End Using
          End If
        Next
        '7. Insert Update Enquiries
        Dim tsEnqs As List(Of SIS.POW.powEnquiries) = SIS.POW.powEnquiries.powEnquiriesSelectList(0, 9999, "", False, "", ts.TSID)
        For Each enq As SIS.POW.powEnquiries In tsEnqs
          If enq.StatusID = enumEnquiryStates.EnquiryCreated Then Continue For
          '8. Search in ERP
          Dim erpEnq As SIS.DM.dmisg168 = SIS.DM.dmisg168.GetEnquiry(enq.EnquiryIDERP, enq.TSID, Comp)
          If erpEnq Is Nothing Then
            erpEnq = SIS.DM.dmisg168.GetErpEnq(enq)
            SIS.DM.dmisg168.InsertData(erpEnq, Comp)
          Else
            Dim t_stat As String = ""
            Select Case enq.StatusID
              Case enumEnquiryStates.EnquiryRaised
                t_stat = "Enquiry Raised"
              Case enumEnquiryStates.OfferReceived
                t_stat = "Technical offer Received"
              Case enumEnquiryStates.CommercialNegotiationCompleted
                t_stat = "Enquiry For Techno Commercial Negotiation Completed"
            End Select
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
              Con.Open()
              Using Cmd As SqlCommand = Con.CreateCommand()
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "   UPDATE [tdmisg168" & Comp & "]  set t_stat = '" & t_stat & "' where t_wfid=" & erpEnq.t_wfid & " and t_pwfd=" & erpEnq.t_pwfd
                Cmd.ExecuteNonQuery()
              End Using
            End Using
          End If
          '==============
          If enq.SentOn <> "" Then
            SIS.POW.powEnquiries.CT_Update_140_FirstEnquiryRaised(enq, Comp)
          End If
          If enq.OfferReceivedOn <> "" Then
            SIS.POW.powEnquiries.CT_Update_140_OfferReceived(enq, Comp)
          End If
          '==============
        Next
      Next
      Return mRet
    End Function
  End Class
End Namespace
