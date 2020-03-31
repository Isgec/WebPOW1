Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  Partial Public Class powOffers
    Public Property FromEMailID As String = ""
    Public Property SelectedFromEMailID As String = "As Given Below"
    Public ReadOnly Property M_details As String
      Get
        Dim mRet As String = "<ul>"
        mRet &= "<li>" & RecordID & "</li>"
        mRet &= "<li>" & aspnet_Users2_UserFullName & "</li>"
        mRet &= "<li>" & EMailSubject & "</li>"
        mRet &= "<li>" & SubmittedOn & "</li>"
        mRet &= "</ul>"
        Return mRet
      End Get
    End Property

    Public Property AthProcess As String = "POW_OFFER"
    Public Property AthHandle As String = "J_PREORDER_OFFER"
    Public ReadOnly Property AthIndex As String
      Get
        Return TSID & "_" & EnquiryID & "_" & RecordID
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If Not SubmittedByBuyer Then
        Select Case StatusID
          Case enumOfferStates.Created
            mRet = Drawing.Color.LimeGreen
          Case enumOfferStates.Submitted
            mRet = Drawing.Color.Purple
          Case enumOfferStates.OfferReceived
            mRet = Drawing.Color.Green
          Case enumOfferStates.UnderEvaluation
            mRet = Drawing.Color.Orange
          Case enumOfferStates.TechnicallyCleared
            mRet = Drawing.Color.DarkOliveGreen
          Case enumOfferStates.CommentSubmitted
            mRet = Drawing.Color.Red
          Case enumOfferStates.Superseded
            mRet = Drawing.Color.CadetBlue
        End Select
      Else
        If StatusID = enumOfferStates.Submitted Then
          mRet = Drawing.Color.DarkGoldenrod
        End If
      End If
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
      Dim mRet As Boolean = False
      If StatusID = enumOfferStates.Created Then
        mRet = True
      End If
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = GetEditable()
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumOfferStates.Created
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
    Public Shared Function DeleteWF(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powOffers
      Dim Results As SIS.POW.powOffers = powOffersGetByID(TSID, EnquiryID, RecordID)
      Return Results
    End Function
    Public ReadOnly Property CloseWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          If StatusID = enumOfferStates.Created Or StatusID = enumOfferStates.ClosedByBuyer Then
            mRet = False
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CloseWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function CloseWF(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powOffers
      Dim Results As SIS.POW.powOffers = powOffersGetByID(TSID, EnquiryID, RecordID)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumOfferStates.Created
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
          Select Case RecordTypeID
            Case enumRecordType.TechnicalOffer
              If StatusID = enumOfferStates.Submitted And SubmittedByBuyer = False Then
                mRet = True
              End If
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
    'DTE
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case FK_POW_Offers_TSID.TSTypeID
            Case enumTSTypes.Boughtout, enumTSTypes.Package
              If Not SubmittedByBuyer Then
                Select Case StatusID
                  Case enumOfferStates.Submitted, enumOfferStates.OfferReceived
                    mRet = True
                End Select
              End If
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
    Public Shared Function InitiateWF(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powOffers
      Dim Results As SIS.POW.powOffers = powOffersGetByID(TSID, EnquiryID, RecordID)
      With Results
        .StatusID = enumOfferStates.Submitted
        .SubmittedBy = HttpContext.Current.Session("LoginID")
        .SubmittedOn = Now
        If .ForSupplier Then
          .SubmittedBy = .FK_POW_Offers_EnquiryID.SupplierLoginID
        End If
      End With
      Results = SIS.POW.powOffers.UpdateData(Results)
      '=======================================================
      SIS.POW.Alerts.OfferSubmitted(TSID, EnquiryID, RecordID)
      '=======================================================
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powOffers
      Dim Results As SIS.POW.powOffers = powOffersGetByID(TSID, EnquiryID, RecordID)
      Return Results
    End Function
    Public Shared Function GetNextRecNo() As String
      Dim NextNo As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select t_ffno from ttcmcs050200 where t_nrgr='VEN' and t_seri='REC'"
          Con.Open()
          NextNo = Cmd.ExecuteScalar
        End Using
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim tmp As Integer = Convert.ToInt32(NextNo) + 1
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "update ttcmcs050200 set t_ffno = " & tmp & " where t_nrgr='VEN' and t_seri='REC'"
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return "REC" & NextNo.PadLeft(6, "0")
    End Function
    Public Shared Function CompleteWF(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powOffers
      Dim tmpOffer As SIS.POW.powOffers = powOffersGetByID(TSID, EnquiryID, RecordID)
      Dim tmpERPReceipt As SIS.PAK.pakERPRecH = Nothing
      Dim ERPReceiptToRevise As SIS.PAK.pakERPRecH = Nothing
      Dim OfferToRevise As SIS.POW.powOffers = Nothing
      Dim tmpAtchs As New List(Of SIS.EDI.ediAFile)
      Dim I As Integer = 1
      Dim ReceiptID As String = ""
      Dim ReceiptRevision As String = ""
      Dim action As String = ""
      '==========================
      'A. Identify Action to Perform
      '==========================
      If tmpOffer.ReceiptID <> "" AndAlso tmpOffer.ReceiptRevision <> "" Then
        ReceiptID = tmpOffer.ReceiptID
        ReceiptRevision = tmpOffer.ReceiptRevision
        action = "UPD"
      Else
        'Check to Create New or Revise an Existing Receipt in ERP
        Dim tmpOffers As List(Of SIS.POW.powOffers) = powOffersSelectList(0, 9999, "", False, "", EnquiryID, TSID)
        For Each x As SIS.POW.powOffers In tmpOffers
          If x.ReceiptID <> "" AndAlso x.ReceiptRevision <> "" Then
            ERPReceiptToRevise = SIS.PAK.pakERPRecH.pakERPRecHGetByID(x.ReceiptID, x.ReceiptRevision)
            If ERPReceiptToRevise Is Nothing Then Continue For
            Select Case ERPReceiptToRevise.t_stat
              Case enumERPStates.CommentSubmitted, enumERPStates.TransmittalIssued
                OfferToRevise = x
                action = "REVISE"
                ReceiptID = OfferToRevise.ReceiptID
                ReceiptRevision = (Convert.ToInt32(OfferToRevise.ReceiptRevision) + 1).ToString.PadLeft(2, "0")
              Case enumERPStates.Closed, enumERPStates.Superseded
              Case enumERPStates.TechnicallyCleared
                Throw New Exception("Receipt: " & x.ReceiptID & "_" & x.ReceiptRevision & " is already TECHNICALLY CLEARED.")
              Case enumERPStates.Submitted, enumERPStates.UnderEvaluation, enumERPStates.DocumentLinked
                'Receipt is already created so DTE action can revise only
                'Return from DTE action and notify user
                Throw New Exception("Receipt: " & x.ReceiptID & "_" & x.ReceiptRevision & " is not COMMENT SUBMITTED, cannot revise.")
            End Select
            Exit For
          End If
        Next
        If OfferToRevise Is Nothing Then
          action = "NEW"
          ReceiptID = GetNextRecNo()
          ReceiptRevision = "00"
        End If
      End If
      '=========================
      'B. Perform Identified Action
      '=========================
      Select Case action
        Case "UPD"
          'Do Nothing
          'We may write to check attachment and physical file
          Return tmpOffer
        Case "REVISE"
          '1. Superseded Receipt in ERP
          With ERPReceiptToRevise
            .t_stat = enumERPStates.Superseded
          End With
          ERPReceiptToRevise = SIS.PAK.pakERPRecH.UpdateData(ERPReceiptToRevise)
          '2. Superseded Offer in WEB
          With OfferToRevise
            .StatusID = enumOfferStates.Superseded
          End With
          OfferToRevise = SIS.POW.powOffers.UpdateData(OfferToRevise)
          '3. Create Revised Receipt in ERP
          With tmpOffer
            .ReceiptID = ReceiptID
            .ReceiptRevision = ReceiptRevision
            .StatusID = enumOfferStates.UnderEvaluation
            .DistributedOn = Now
          End With
          tmpERPReceipt = SIS.POW.powOffers.GetERPRecH(tmpOffer)
          tmpERPReceipt = SIS.PAK.pakERPRecH.InsertData(tmpERPReceipt)
          '4. Create ERP Receipt Documents
          tmpAtchs = SIS.EDI.ediAFile.ediAFileSelectList(0, 999, "", False, "", tmpOffer.AthHandle, tmpOffer.AthIndex)
          I = 1
          For Each atch As SIS.EDI.ediAFile In tmpAtchs
            Dim ERPRecD As SIS.PAK.pakERPRecD = SIS.POW.powOffers.GetERPRecD(tmpOffer, atch, I)
            ERPRecD = SIS.PAK.pakERPRecD.InsertData(ERPRecD)
            Try
              SIS.EDI.ediAFile.ediAFileCopy(tmpOffer.AthHandle, tmpOffer.AthIndex, ERPRecD.AthHandle, ERPRecD.AthIndex)
            Catch ex As Exception
            End Try
            I += 1
          Next
          '5. Update Offer in WEB
          tmpOffer = SIS.POW.powOffers.UpdateData(tmpOffer)
        Case "NEW"
          '3. Create Revised Receipt in ERP
          With tmpOffer
            .ReceiptID = ReceiptID
            .ReceiptRevision = ReceiptRevision
            .StatusID = enumOfferStates.UnderEvaluation
            .DistributedOn = Now
          End With
          tmpERPReceipt = SIS.POW.powOffers.GetERPRecH(tmpOffer)
          tmpERPReceipt = SIS.PAK.pakERPRecH.InsertData(tmpERPReceipt)
          '4. Create ERP Receipt Documents
          tmpAtchs = SIS.EDI.ediAFile.ediAFileSelectList(0, 999, "", False, "", tmpOffer.AthHandle, tmpOffer.AthIndex)
          I = 1
          For Each atch As SIS.EDI.ediAFile In tmpAtchs
            Dim ERPRecD As SIS.PAK.pakERPRecD = SIS.POW.powOffers.GetERPRecD(tmpOffer, atch, I)
            ERPRecD = SIS.PAK.pakERPRecD.InsertData(ERPRecD)
            Try
              SIS.EDI.ediAFile.ediAFileCopy(tmpOffer.AthHandle, tmpOffer.AthIndex, ERPRecD.AthHandle, ERPRecD.AthIndex)
            Catch ex As Exception
            End Try
            I += 1
          Next
          '5. Update Offer in WEB
          tmpOffer = SIS.POW.powOffers.UpdateData(tmpOffer)
      End Select
      '=================
      'C. Distribute in ERP
      '=================
      Try
        DistributeInERP(tmpOffer.ReceiptID, tmpOffer.ReceiptRevision)
      Catch ex As Exception
      End Try
      '=======================
      'D. Send TC Alert E-Mail
      '=======================
      Try
        SIS.POW.Alerts.UnderEvaluation(tmpOffer)
      Catch ex As Exception
      End Try
      '====================
      'E. Update CT
      '====================
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", tmpOffer.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        Dim enq As SIS.POW.powEnquiries = tmpOffer.FK_POW_Offers_EnquiryID
        CT_Update_UnderEvaluation(tmpOffer, Comp)
      End If
      Return tmpOffer
    End Function

    Public Shared Function CompleteWF_delete(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powOffers
      Dim IsERPReceiptNoFound As Boolean = False
      Dim IsReceiptExistInERP As Boolean = False
      Dim tmpOfr As SIS.POW.powOffers = powOffersGetByID(TSID, EnquiryID, RecordID)
      '1.Check ERP Receipt ID is Updated
      If tmpOfr.ReceiptID <> "" AndAlso tmpOfr.ReceiptRevision <> "" Then
        IsERPReceiptNoFound = True
      End If
      Dim NextRecNo As String = tmpOfr.ReceiptID
      Dim DefaultRevisionNo As String = tmpOfr.ReceiptRevision
      If Not IsERPReceiptNoFound Then
        NextRecNo = GetNextRecNo()
        NextRecNo = "REC" & NextRecNo.ToString.PadLeft(6, "0")
        DefaultRevisionNo = "00"
      End If
      With tmpOfr
        .ReceiptID = NextRecNo
        .ReceiptRevision = DefaultRevisionNo
        .StatusID = enumOfferStates.UnderEvaluation
        .DistributedOn = Now
      End With
      '2. Get ERP Object of Receipt Header
      Dim ERPRecH As SIS.PAK.pakERPRecH = SIS.POW.powOffers.GetERPRecH(tmpOfr)
      '3. Check Whether Already Exists in ERP
      Dim tmpRH As SIS.PAK.pakERPRecH = SIS.PAK.pakERPRecH.pakERPRecHGetByID(ERPRecH.t_rcno, ERPRecH.t_revn)
      If tmpRH IsNot Nothing Then
        IsReceiptExistInERP = True
      End If
      If IsReceiptExistInERP Then
        ERPRecH = SIS.PAK.pakERPRecH.UpdateData(ERPRecH)
      Else
        ERPRecH = SIS.PAK.pakERPRecH.InsertData(ERPRecH)
      End If
      '4. Handle Insert/Update of document line
      'Dim tmpERPRecD As List(Of SIS.PAK.pakERPRecD) = SIS.PAK.pakERPRecD.UZ_pakERPRecDSelectList(0, 9999, "", False, "", ERPRecH.t_rcno, ERPRecH.t_revn)
      'For Each recD As SIS.PAK.pakERPRecD In tmpERPRecD
      '  SIS.PAK.pakERPRecD.pakERPRecDDelete(recD)
      '  SIS.EDI.ediAFile.DeleteByHandleIndex(recD.AthHandle, recD.AthIndex)
      'Next
      Dim tmpAtchs As List(Of SIS.EDI.ediAFile) = SIS.EDI.ediAFile.ediAFileSelectList(0, 999, "", False, "", tmpOfr.AthHandle, tmpOfr.AthIndex)
      Dim I As Integer = 1
      For Each td As SIS.EDI.ediAFile In tmpAtchs
        Dim ERPRecD As SIS.PAK.pakERPRecD = SIS.POW.powOffers.GetERPRecD(tmpOfr, td, I)
        ERPRecD = SIS.PAK.pakERPRecD.InsertData(ERPRecD)
        Try
          SIS.EDI.ediAFile.ediAFileCopy(tmpOfr.AthHandle, tmpOfr.AthIndex, ERPRecD.AthHandle, ERPRecD.AthIndex)
        Catch ex As Exception
        End Try
        I += 1
      Next
      tmpOfr = SIS.POW.powOffers.UpdateData(tmpOfr)
      '6. Distribute in ERP
      Try
        DistributeInERP(tmpOfr.ReceiptID, tmpOfr.ReceiptRevision)
      Catch ex As Exception
      End Try
      '7. Send TC Alert E-Mail
      Try
        SIS.POW.Alerts.UnderEvaluation(tmpOfr)
      Catch ex As Exception
      End Try
      '======Update CT======
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", tmpOfr.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        Dim enq As SIS.POW.powEnquiries = tmpOfr.FK_POW_Offers_EnquiryID
        CT_Update_UnderEvaluation(tmpOfr, Comp)
      End If
      '======================
      Return tmpOfr
    End Function
    Private Shared Sub CT_Update_UnderEvaluation(ByVal pEnq As SIS.POW.powOffers, Optional ByVal Comp As String = "200")
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Sql = ""
        Sql &= "   UPDATE [tdmisg168" & Comp & "] "
        Sql &= "   SET "
        Sql &= "   [t_stat] ='Technical offer Received' "
        Sql &= "   ,[t_rcno] ='" & pEnq.ReceiptID & "'"
        Sql &= "   WHERE "
        Sql &= "   [t_wfid] =" & pEnq.EnquiryID
        Sql &= "   AND [t_pwfd] =" & pEnq.TSID
        Sql &= "   AND [t_stat] <>'Enquiry For Techno Commercial Negotiation Completed' "
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

    Private Shared Sub DistributeInERP(ByVal ReceiptNo As String, ByVal RevisionNo As String)
      Dim CardNo As String = Convert.ToInt32(HttpContext.Current.Session("LoginID"))

      Dim mFileName As String = "REC" & CardNo & "_" & Now.ToString.Replace("/", "").Replace(":", "").Replace(" ", "") & ".xml"

      Dim tmpDir As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\TABill"
      If Not IO.Directory.Exists(tmpDir) Then
        IO.Directory.CreateDirectory(tmpDir)
        IO.Directory.CreateDirectory(tmpDir & "\s")
        IO.Directory.CreateDirectory(tmpDir & "\t")
      Else
        If Not IO.Directory.Exists(tmpDir & "\s") Then
          IO.Directory.CreateDirectory(tmpDir & "\s")
        End If
        If Not IO.Directory.Exists(tmpDir & "\t") Then
          IO.Directory.CreateDirectory(tmpDir & "\t")
        End If
      End If

      Dim oTW As IO.StreamWriter = New IO.StreamWriter(tmpDir & "\s\" & mFileName)
      oTW.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
      oTW.WriteLine("<ERPFunctions>")
      oTW.WriteLine("  <Function dll=""odmisgdll0100"" fun=""dmisgdll0100.forward.receipt.to.departments"" >" & ReceiptNo & "," & RevisionNo & ",</Function>")
      oTW.WriteLine("</ERPFunctions>")
      oTW.Close()
    End Sub
    Public Shared Function GetERPRecD(ByVal tmpOfr As SIS.POW.powOffers, ByVal STCPOLRD As SIS.EDI.ediAFile, ByVal NextNo As Integer) As SIS.PAK.pakERPRecD
      Dim tmp As New SIS.PAK.pakERPRecD
      With tmp
        .t_rcno = tmpOfr.ReceiptID
        .t_revn = tmpOfr.ReceiptRevision
        .t_srno = NextNo
        .t_docn = IO.Path.GetFileNameWithoutExtension(STCPOLRD.t_fnam)
        .t_revi = tmpOfr.ReceiptRevision
        .t_dsca = STCPOLRD.t_fnam
        .t_idoc = ""
        .t_irev = ""
        .t_date = "01/01/1970"
        .t_remk = ""
        .t_proc = 2 'No
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      Return tmp
    End Function

    Public Shared Function GetERPRecH(ByVal tmpOfr As SIS.POW.powOffers) As SIS.PAK.pakERPRecH
      '============================
      Dim TopIndent As New SIS.POW.powTSIndents
      Dim tmpIndents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 1, "", False, "", tmpOfr.TSID)
      If tmpIndents.Count > 0 Then
        TopIndent = tmpIndents(0)
      End If
      '============================
      Dim tmp As New SIS.PAK.pakERPRecH
      With tmp
        .t_rcno = tmpOfr.ReceiptID
        .t_revn = tmpOfr.ReceiptRevision
        .t_cprj = TopIndent.ProjectID
        .t_item = TopIndent.LotItem
        .t_bpid = tmpOfr.FK_POW_Offers_EnquiryID.SupplierID
        .t_nama = tmpOfr.FK_POW_Offers_EnquiryID.SupplierName
        .t_stat = 1 'submitted
        .t_user = tmpOfr.FK_POW_Offers_EnquiryID.CreatedBy
        .t_date = Now.AddHours(-5).AddMinutes(-30).ToString("dd/MM/yyyy HH:mm")
        .t_rqno = TopIndent.IndentNo
        .t_rqln = TopIndent.IndentLine
        .t_docn = "CRI"  'From Indent: " & TopIndent.IndentNo & " Line: " & TopIndent.IndentLine
        .t_pwfd = tmpOfr.TSID
        .t_wfid = tmpOfr.EnquiryID
        Dim eunt As String = ""
        Select Case TopIndent.IndentNo.Substring(0, 4)
          Case "R101"
            eunt = "EU200"
          Case "R201"
            eunt = "EU230"
          Case "R301"
            eunt = "EU210"
          Case "R401"
            eunt = "EU220"
          Case "R501"
            eunt = "EU240"
        End Select
        .t_eunt = eunt
        'Default Values
        '==============
        .t_orno = ""
        .t_pono = 0
        .t_nama = ""
        .t_sent_1 = 2 'No
        .t_sent_2 = 2
        .t_sent_3 = 2
        .t_sent_4 = 2
        .t_sent_5 = 2
        .t_sent_6 = 2
        .t_sent_7 = 2
        .t_rece_1 = 2
        .t_rece_2 = 2
        .t_rece_3 = 2
        .t_rece_4 = 2
        .t_rece_5 = 2
        .t_rece_6 = 2
        .t_rece_7 = 2
        .t_suer = ""
        .t_sdat = "01/01/1970"
        .t_appr = ""
        .t_adat = "01/01/1970"
        .t_subm_1 = 2
        .t_subm_2 = 2
        .t_subm_3 = 2
        .t_subm_4 = 2
        .t_subm_5 = 2
        .t_subm_6 = 2
        .t_subm_7 = 2
        .t_trno = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
        .t_atch = ""
        .t_apid_1 = ""
        .t_apid_2 = ""
        .t_apid_3 = ""
        .t_apid_4 = ""
        .t_apid_5 = ""
        .t_apid_6 = ""
        .t_apid_7 = ""
      End With
      Return tmp
    End Function

    Public Shared Function UZ_powOffersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EnquiryID As Int32, ByVal TSID As Int32) As List(Of SIS.POW.powOffers)
      Dim Results As List(Of SIS.POW.powOffers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RecordID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppow_LG_OffersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppow_LG_OffersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EnquiryID", SqlDbType.Int, 10, IIf(EnquiryID = Nothing, 0, EnquiryID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TSID", SqlDbType.Int, 10, IIf(TSID = Nothing, 0, TSID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.POW.powOffers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powOffers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_powOffersInsert(ByVal Record As SIS.POW.powOffers) As SIS.POW.powOffers
      Dim _Rec As SIS.POW.powOffers = SIS.POW.powOffers.powOffersGetNewRecord()
      With _Rec
        .RecordTypeID = enumRecordType.Communication
        .RecordRevision = "00"
        .EMailSubject = Record.EMailSubject
        .SubmittedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .StatusID = enumOfferStates.Created
        .EMailBody = Record.EMailBody
        .EnquiryID = Record.EnquiryID
        .TSID = Record.TSID
        .SubmittedByBuyer = True
        .ForSupplier = Record.ForSupplier
        If Record.ForSupplier Then
          .SubmittedBy = .FK_POW_Offers_EnquiryID.SupplierLoginID
          .SubmittedByBuyer = False
        End If
      End With
      Return SIS.POW.powOffers.InsertData(_Rec)
    End Function
    Public Shared Function UZ_powOffersUpdate(ByVal Record As SIS.POW.powOffers) As SIS.POW.powOffers
      Dim _Rec As SIS.POW.powOffers = SIS.POW.powOffers.powOffersGetByID(Record.TSID, Record.EnquiryID, Record.RecordID)
      With _Rec
        .EMailSubject = Record.EMailSubject
        .EMailBody = Record.EMailBody
      End With
      Return SIS.POW.powOffers.UpdateData(_Rec)
    End Function
    Public Shared Function UZ_powOffersDelete(ByVal Record As SIS.POW.powOffers) As Integer
      Dim _Result As Integer = powOffersDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_RecordID"), TextBox).Text = ""
          CType(.FindControl("F_RecordTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_EMailSubject"), TextBox).Text = ""
          CType(.FindControl("F_EMailBody"), TextBox).Text = ""
          CType(.FindControl("F_EnquiryID"), TextBox).Text = ""
          CType(.FindControl("F_EnquiryID_Display"), Label).Text = ""
          CType(.FindControl("F_TSID"), TextBox).Text = ""
          CType(.FindControl("F_TSID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
