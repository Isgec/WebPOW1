Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  Partial Public Class powEnquiries
    Public Property AthProcess As String = "POW_ENQUIRY"
    Public Property AthHandle As String = "J_PREORDER_ENQUIRY"
    Public ReadOnly Property AthIndex As String
      Get
        Return TSID & "_" & EnquiryID
      End Get
    End Property
    Public ReadOnly Property EnquiryIDERP As Integer
      Get
        Return 2000000 + EnquiryID
      End Get
    End Property


    Public ReadOnly Property M_details As String
      Get
        Dim mRet As String = "<ul>"
        mRet &= "<li>" & EnquiryID & "</li>"
        mRet &= "<li>" & GetSupplier & "</li>"
        mRet &= "<li>" & EMailSubject & "</li>"
        mRet &= "<li>" & SentOn & "</li>"
        mRet &= "</ul>"
        Return mRet
      End Get
    End Property
    Public ReadOnly Property GetSupplier As String
      Get
        If SupplierID = "" Then
          Return SupplierName
        Else
          Return VR_BusinessPartner3_BPName
        End If
      End Get
    End Property
    Public Shared Function GetByEnquiryKey(ByVal Key As String) As SIS.POW.powEnquiries
      Dim Results As SIS.POW.powEnquiries = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppow_LG_GetByEnquiryKey"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Key", SqlDbType.NVarChar, 51, Key)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.POW.powEnquiries(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case enumEnquiryStates.EnquiryCreated
          mRet = Drawing.Color.LimeGreen
        Case enumEnquiryStates.EnquiryRaised
          mRet = Drawing.Color.Purple
        Case enumEnquiryStates.OfferReceived
          mRet = Drawing.Color.Green
        Case enumEnquiryStates.CommercialNegotiationCompleted
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
      Dim mRet As Boolean = False
      Try
        Select Case StatusID
          Case enumEnquiryStates.EnquiryCreated
            mRet = True
        End Select
      Catch ex As Exception
      End Try
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
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
#Region " Offer Received "
    Public ReadOnly Property RequestCommercialOfferUVOWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumEnquiryStates.EnquiryRaised
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RequestCommercialOfferUVOWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function RequestCommercialOfferUVOWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powEnquiries
      Dim Results As SIS.POW.powEnquiries = powEnquiriesGetByID(TSID, EnquiryID)
      With Results
        .StatusID = enumEnquiryStates.OfferReceived
        .OfferReceivedOn = Now
      End With
      Results = SIS.POW.powEnquiries.UpdateData(Results)
      '======Update CT======
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", Results.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        CT_Update_OfferReceived(Results, Comp)
        If Results.OfferReceivedOn <> "" Then
          CT_Update_140_OfferReceived(Results, Comp)
        End If
      End If
      '======================
      Return Results
    End Function
    Public Shared Sub CT_Update_140_OfferReceived(tmp As SIS.POW.powEnquiries, Comp As String)
      Dim tmpDocs As List(Of SIS.EDI.ediAFile) = SIS.EDI.ediAFile.ediAFileGetAllByHandleIndex(tmp.AthHandle, tmp.AthIndex, Comp)
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        For Each fl As SIS.EDI.ediAFile In tmpDocs
          Sql = ""
          Sql &= "   UPDATE [tdmisg140" & Comp & "] "
          Sql &= "   SET "
          Sql &= "   [t_ofdt] = convert(datetime,'" & tmp.OfferReceivedOn & "',103) "
          Sql &= "   WHERE "
          Sql &= "   upper([t_docn]) =upper('" & IO.Path.GetFileNameWithoutExtension(fl.t_fnam) & "') "
          Sql &= "   AND [t_ofdt] < convert(datetime,'01/01/2000',103) and t_ofdt < convert(datetime,'" & tmp.OfferReceivedOn & "',103)"
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

#End Region
#Region " Delete "
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumEnquiryStates.EnquiryCreated
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
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
    Public Shared Function DeleteWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powEnquiries
      Dim Results As SIS.POW.powEnquiries = powEnquiriesGetByID(TSID, EnquiryID)
      Return Results
    End Function

#End Region
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumEnquiryStates.EnquiryCreated, enumEnquiryStates.EnquiryRaised
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
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumEnquiryStates.EnquiryRaised, enumEnquiryStates.OfferReceived
              mRet = True
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
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumEnquiryStates.EnquiryRaised, enumEnquiryStates.OfferReceived
              mRet = True
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
    Public Shared Function InitiateWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powEnquiries
      Dim tmp As SIS.POW.powEnquiries = powEnquiriesGetByID(TSID, EnquiryID)
      Dim tmpTS As SIS.POW.powTechnicalSpecifications = tmp.FK_POW_Enquiries_TSID
      '1. Check Supplier's E-Mail IDs Entered
      If tmp.SupplierEMailID = "" Then
        Throw New Exception("Supplier E-Mail IDs not Entered.")
      End If
      '2.
      If tmp.SupplierEMailID.IndexOf("isgec.co.in") >= 0 Then
        Throw New Exception("ISGEC E-Mail IDs not allowed with Supplier.")
      End If
      '3.
      Select Case tmpTS.StatusID
        Case enumTSStates.TechnicalSpecificationReleased, enumTSStates.EnquiryInProgress
        Case Else
          'Do not stop further enquiry
          'Throw New Exception("Technical Specification status does not allow further enquiry to be sent.")
      End Select
      '4. Create Supplier Login
      Dim owUsr As SIS.QCM.qcmUsers = Nothing
      Dim LoginID As String = ""
      If tmp.SupplierLoginID = "" Then
        If tmp.SupplierID <> "" Then
          If tmp.SupplierID.Length = 9 Then
            LoginID = tmp.SupplierID.Substring(1, 8).Trim
          Else
            LoginID = SIS.QCM.qcmUsers.GetNextUserID("POW")
          End If
          owUsr = SIS.QCM.qcmUsers.qcmUsersGetByID(LoginID)
          If owUsr Is Nothing Then
            owUsr = New SIS.QCM.qcmUsers
            With owUsr
              .UserName = LoginID
              .UserFullName = tmp.FK_POW_Enquiries_SupplierID.BPName
              .ActiveState = 1
              .EMailID = tmp.SupplierEMailID
            End With
            owUsr.PW = SIS.QCM.qcmUsers.CreateWebUser(owUsr)
            SIS.QCM.qcmUsers.UpdateData(owUsr)
          End If
        Else
          LoginID = SIS.QCM.qcmUsers.GetNextUserID("POW")
          owUsr = SIS.QCM.qcmUsers.qcmUsersGetByID(LoginID)
          If owUsr Is Nothing Then
            owUsr = New SIS.QCM.qcmUsers
            With owUsr
              .UserName = LoginID
              .UserFullName = tmp.SupplierName
              .ActiveState = 1
              .EMailID = tmp.SupplierEMailID
            End With
            owUsr.PW = SIS.QCM.qcmUsers.CreateWebUser(owUsr)
            SIS.QCM.qcmUsers.UpdateData(owUsr)
          End If
        End If
      Else
        LoginID = tmp.SupplierLoginID
        owUsr = SIS.QCM.qcmUsers.qcmUsersGetByID(LoginID)
      End If
      '5. Give Authorization
      If owUsr IsNot Nothing Then
        owUsr = SIS.QCM.qcmUsers.ValidatePassword(owUsr)
        Dim oWS As New WebAuthorization.WebAuthorizationServiceSoapClient
        Dim Roles() As String = Web.Configuration.WebConfigurationManager.AppSettings("SupplierRoleID").ToString.Split(",".ToCharArray)
        Dim str As String = ""
        For Each role As String In Roles
          Try
            str = oWS.CreateWebAuthorization(102, owUsr.UserName, role)
          Catch ex As Exception
          End Try
          If str <> String.Empty Then
            Exit For
          End If
        Next
        If HttpContext.Current.Request.Url.Authority.ToLower = "localhost" Then
          Roles = Web.Configuration.WebConfigurationManager.AppSettings("SupplierRoleID1").ToString.Split(",".ToCharArray)
          For Each role As String In Roles
            Try
              str = oWS.CreateWebAuthorization(102, owUsr.UserName, role)
            Catch ex As Exception
            End Try
          Next
        End If
      End If
      '6. Update TS status, only once from Specification released to Enq In Progress
      If tmpTS.StatusID = enumTSStates.TechnicalSpecificationReleased Then
        tmpTS.StatusID = enumTSStates.EnquiryInProgress
        Try
          tmpTS = SIS.POW.powTechnicalSpecifications.UpdateData(tmpTS)
        Catch ex As Exception
          Throw New Exception("Error while updating TS")
        End Try
      End If
      '7. Update Enquiry data
      With tmp
        .SupplierLoginID = LoginID
        If tmp.StatusID = enumEnquiryStates.EnquiryCreated Then
          .SentOn = Now
          .StatusID = enumEnquiryStates.EnquiryRaised
        End If
      End With
      Try
        tmp = SIS.POW.powEnquiries.UpdateData(tmp)
      Catch ex As Exception
        Throw New Exception("Error while updating enquiry status")
      End Try
      '8. Send Alerts
      SIS.POW.Alerts.EnquirySent(tmp.TSID, tmp.EnquiryID)
      '9. Send LoginID
      SIS.POW.Alerts.SendAuthentication(tmp.TSID, tmp.EnquiryID)
      '10. 
      '======Update CT======
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", tmp.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        CT_Update_EnquiryRaised(Indents(0), tmp, tmpTS, Comp)  'By First Indent 
        If tmp.SentOn <> "" Then
          CT_Update_140_FirstEnquiryRaised(tmp, Comp)
        End If
      End If
      '======================
      Return tmp
    End Function
    Public Shared Sub CT_Update_140_FirstEnquiryRaised(tmp As SIS.POW.powEnquiries, Comp As String)
      Dim tmpDocs As List(Of SIS.EDI.ediAFile) = SIS.EDI.ediAFile.ediAFileGetAllByHandleIndex(tmp.AthHandle, tmp.AthIndex, Comp)
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        For Each fl As SIS.EDI.ediAFile In tmpDocs
          Sql = ""
          Sql &= "   UPDATE [tdmisg140" & Comp & "] "
          Sql &= "   SET "
          Sql &= "   [t_rfqd] = convert(datetime,'" & tmp.SentOn & "',103) "
          Sql &= "   WHERE "
          Sql &= "   upper([t_docn]) =upper('" & IO.Path.GetFileNameWithoutExtension(fl.t_fnam) & "') "
          Sql &= "   AND [t_rfqd] < convert(datetime,'01/01/2000',103) and t_rfqd < convert(datetime,'" & tmp.SentOn & "',103)"
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
    Public Shared Function ApproveWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powEnquiries
      Dim Results As SIS.POW.powEnquiries = powEnquiriesGetByID(TSID, EnquiryID)
      Return Results
    End Function
    Public Shared Function CompleteWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powEnquiries
      Dim Results As SIS.POW.powEnquiries = powEnquiriesGetByID(TSID, EnquiryID)
      With Results
        .StatusID = enumEnquiryStates.CommercialNegotiationCompleted
        .CommercialNegotiationCompletedOn = Now
      End With
      Results = SIS.POW.powEnquiries.UpdateData(Results)
      '======Update CT======
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", Results.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        CT_Update_OfferNegotiated(Results, Comp)
      End If
      '======================
      Return Results
    End Function
    Public Shared Function UZ_powEnquiriesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TSID As Int32) As List(Of SIS.POW.powEnquiries)
      Dim Results As List(Of SIS.POW.powEnquiries) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "EnquiryID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppow_LG_EnquiriesSelectListSearch"
            Cmd.CommandText = "sppowEnquiriesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppow_LG_EnquiriesSelectListFilteres"
            Cmd.CommandText = "sppowEnquiriesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TSID", SqlDbType.Int, 10, IIf(TSID = Nothing, 0, TSID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.POW.powEnquiries)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powEnquiries(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_powEnquiriesInsert(ByVal Record As SIS.POW.powEnquiries) As SIS.POW.powEnquiries
      Record = powEnquiriesInsert(Record)
      SIS.EDI.ediAFile.ediAFileCopy("J_PREORDER_TECHSPEC", Record.TSID, "J_PREORDER_ENQUIRY", Record.TSID & "_" & Record.EnquiryID)
      'Update E-mailID's in Supplier Master
      If Record.SupplierID <> "" Then
        Record.FK_POW_Enquiries_SupplierID.EMailID = Record.SupplierEMailID
        SIS.VR.vrBusinessPartner.UpdateData(Record.FK_POW_Enquiries_SupplierID)
      End If
      Return Record
    End Function
    Public Shared Function UZ_powEnquiriesUpdate(ByVal Record As SIS.POW.powEnquiries) As SIS.POW.powEnquiries
      Dim _Rec As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(Record.TSID, Record.EnquiryID)
      With _Rec
        If .StatusID = enumEnquiryStates.EnquiryCreated Then
          .SupplierID = Record.SupplierID
          .SupplierName = Record.SupplierName
          .SupplierLoginID = Record.SupplierLoginID
        End If
        .EMailSubject = Record.EMailSubject
        .AdditionalEMailIDs = Record.AdditionalEMailIDs
        .EMailBody = Record.EMailBody
        .SupplierEMailID = Record.SupplierEMailID
      End With
      _Rec = SIS.POW.powEnquiries.UpdateData(_Rec)
      'Update E-mailID's in Supplier Master
      If Record.SupplierID <> "" Then
        Record.FK_POW_Enquiries_SupplierID.EMailID = Record.SupplierEMailID
        SIS.VR.vrBusinessPartner.UpdateData(Record.FK_POW_Enquiries_SupplierID)
      End If
      Return _Rec
    End Function
    Public Shared Function UZ_powEnquiriesDelete(ByVal Record As SIS.POW.powEnquiries) As Integer
      Dim _Result As Integer = powEnquiriesDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_EnquiryID"), TextBox).Text = ""
          CType(.FindControl("F_SupplierID"), TextBox).Text = ""
          CType(.FindControl("F_SupplierID_Display"), Label).Text = ""
          CType(.FindControl("F_SupplierName"), TextBox).Text = ""
          CType(.FindControl("F_EMailSubject"), TextBox).Text = ""
          CType(.FindControl("F_TSID"), TextBox).Text = ""
          CType(.FindControl("F_TSID_Display"), Label).Text = ""
          CType(.FindControl("F_AdditionalEMailIDs"), TextBox).Text = ""
          CType(.FindControl("F_EMailBody"), TextBox).Text = ""
          CType(.FindControl("F_SupplierLoginID"), TextBox).Text = ""
          CType(.FindControl("F_SupplierLoginID_Display"), Label).Text = ""
          CType(.FindControl("F_SupplierEMailID"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function CopyEnquiry(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powEnquiries
      Dim Record As SIS.POW.powEnquiries = powEnquiriesGetByID(TSID, EnquiryID)
      Dim Results As New SIS.POW.powEnquiries
      With Results
        .SupplierID = ""
        .SupplierName = ""
        .EMailSubject = Record.EMailSubject
        .StatusID = enumEnquiryStates.EnquiryCreated
        .SentOn = ""
        .TSID = Record.TSID
        .EnquiryID = 0
        .AdditionalEMailIDs = Record.AdditionalEMailIDs
        .EMailBody = Record.EMailBody
        .SupplierLoginID = ""
        .VendorKey = Guid.NewGuid().ToString
        .SupplierEMailID = ""
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .SupplierFromEMailID = ""
        .CommercialNegotiationCompletedOn = ""
        .OfferReceivedOn = ""
      End With
      Results = SIS.POW.powEnquiries.InsertData(Results)
      'Copy Attachments
      SIS.EDI.ediAFile.ediAFileCopy(Record.AthHandle, Record.AthIndex, Results.AthHandle, Results.AthIndex)
      Return Results
    End Function

    Private Shared Sub CT_Update_OfferNegotiated(ByVal pEnq As SIS.POW.powEnquiries, Optional ByVal Comp As String = "200")
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Sql = ""
        Sql &= "   UPDATE [tdmisg168" & Comp & "] "
        Sql &= "   SET "
        Sql &= "   [t_stat] ='Enquiry For Techno Commercial Negotiation Completed' "
        Sql &= "   WHERE "
        Sql &= "   [t_wfid] =" & pEnq.EnquiryIDERP
        Sql &= "   AND [t_pwfd] =" & pEnq.TSID
        Sql &= "   AND [t_stat] ='Technical offer Received' "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
            'Throw New Exception(Sql)
            '====LogIt====
          End Try
        End Using
      End Using
    End Sub
    Private Shared Sub CT_Update_OfferReceived(ByVal pEnq As SIS.POW.powEnquiries, Optional ByVal Comp As String = "200")
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Sql = ""
        Sql &= "   UPDATE [tdmisg168" & Comp & "] "
        Sql &= "   SET "
        Sql &= "   [t_stat] ='Technical offer Received' "
        Sql &= "   WHERE "
        Sql &= "   [t_wfid] =" & pEnq.EnquiryIDERP
        Sql &= "   AND [t_pwfd] =" & pEnq.TSID
        Sql &= "   AND [t_stat] ='Enquiry Raised' "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
            'Throw New Exception(Sql)
            '====LogIt====
          End Try
        End Using
      End Using
    End Sub
    Private Shared Sub CT_Update_EnquiryRaised(ByVal pWF As SIS.POW.powTSIndents, ByVal pEnq As SIS.POW.powEnquiries, ByVal tmpTS As SIS.POW.powTechnicalSpecifications, Optional ByVal Comp As String = "200")
      '1. Insert Enquiry Line
      Dim Sql As String = ""
      Sql &= "   INSERT [tdmisg168" & Comp & "] "
      'Sql &= "   ( [t_wfid] ,[t_pwfd] ,[t_cprj] ,[t_elem] ,[t_spec] ,[t_bpid] ,[t_stat] ,[t_user] ,[t_date] ,[t_supp] ,[t_snam] ,[t_rdno] ,[t_docn] ,[t_supc] ,[t_rcno] ,[t_mngr] ,[t_esub] ,[t_Refcntd] ,[t_Refcntu] ) "
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
      Sql &= "     " & pEnq.EnquiryIDERP
      Sql &= "   , " & pEnq.TSID
      Sql &= "   ,'" & pWF.ProjectID & "'"
      Sql &= "   ,'" & pWF.ElementID & "'"
      Sql &= "   ,''"
      Sql &= "   ,'" & pWF.BuyerID & "'"
      Sql &= "   ,'" & "Enquiry Raised" & "'"
      Sql &= "   ,'" & pEnq.CreatedBy & "'"
      Sql &= "   ,convert(datetime,'" & pEnq.CreatedOn & "',103)"
      Sql &= "   ,'" & pEnq.SupplierID & "'"
      Sql &= "   ,'" & pEnq.SupplierName & "'"
      Sql &= "   ,''" '& pEnq.VendorKey & "'"
      Sql &= "   ,''" '& "Indent/Line No.: " & pWF.IndentNo & "/" & pWF.IndentLine & "'"
      Sql &= "   ,''" '& pWF.LotItem & "'"
      Sql &= "   ,''" '& pWF.ReceiptNo & "'"
      Sql &= "   ,'" & pWF.IndenterID & "'"
      Sql &= "   ,'" & pEnq.EMailSubject & "'"
      Sql &= "   ,0"
      Sql &= "   ,0"
      Sql &= "   ) "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
            'Throw New Exception(Sql)
            '====LogIt====
          End Try
        End Using
        '2. Update TS Status [Enquiry In Progress]
        Sql = ""
        Sql &= "   UPDATE [tdmisg168" & Comp & "] "
        Sql &= "   SET "
        Sql &= "   [t_stat] ='Enquiry in progress' "
        Sql &= "   WHERE "
        Sql &= "   [t_wfid] =" & tmpTS.TSID
        Sql &= "   AND [t_stat] ='Technical Specification Released' "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
            'Throw New Exception(Sql)
            '====LogIt====
          End Try
        End Using
      End Using
    End Sub
  End Class
End Namespace
