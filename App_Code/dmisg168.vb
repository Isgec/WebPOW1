Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DM
  Public Class dmisg168
    Public Property t_wfid As Integer = 0
    Public Property t_pwfd As Integer = 0
    Public Property t_cprj As String = ""
    Public Property t_elem As String = ""
    Public Property t_spec As String = ""
    Public Property t_bpid As String = ""
    Public Property t_stat As String = ""
    Public Property t_user As String = ""
    Public Property t_date As DateTime
    Public Property t_supp As String = ""
    Public Property t_snam As String = ""
    Public Property t_rdno As String = ""
    Public Property t_docn As String = ""
    Public Property t_supc As String = ""
    Public Property t_rcno As String = ""
    Public Property t_mngr As String = ""
    Public Property t_esub As String = ""
    Public Property t_Refcntd As Integer = 0
    Public Property t_Refcntu As Integer = 0
    Public Shared Function InsertData(ByVal t As SIS.DM.dmisg168, Optional ByVal comp As String = "200") As String
      Dim Sql As String = ""
      Sql &= "   INSERT [tdmisg168" & comp & "] "
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
      Sql &= "     " & t.t_wfid
      Sql &= "   , " & t.t_pwfd
      Sql &= "   ,'" & t.t_cprj & "'"
      Sql &= "   ,'" & t.t_elem & "'"
      Sql &= "   ,'" & t.t_spec & "'"
      Sql &= "   ,'" & t.t_bpid & "'"
      Sql &= "   ,'" & t.t_stat & "'"
      Sql &= "   ,'" & t.t_user & "'"
      Sql &= "   ,convert(datetime,'" & t.t_date & "',103)"
      Sql &= "   ,'" & t.t_supp & "'"
      Sql &= "   ,'" & t.t_snam & "'"
      Sql &= "   ,'" & t.t_rdno & "'"
      Sql &= "   ,'" & t.t_docn & "'"
      Sql &= "   ,'" & t.t_supc & "'"
      Sql &= "   ,'" & t.t_rcno & "'"
      Sql &= "   ,'" & t.t_mngr & "'"
      Sql &= "   ,'" & t.t_esub & "'"
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

    Public Shared Function Getdmisg168(ByVal ts As SIS.POW.powTechnicalSpecifications) As SIS.DM.dmisg168
      Dim mRet As New SIS.DM.dmisg168
      Dim ind As SIS.POW.powTSIndents = SIS.POW.powTSIndents.powTSIndentsSelectList(0, 10, "", False, "", ts.TSID)(0)
      Dim LotItem As String = ""
      If ind.LotItem.Length > 50 Then
        LotItem = ind.LotItem.Substring(0, 50)
      Else
        LotItem = ind.LotItem
      End If

      With mRet
        .t_wfid = ts.TSID
        .t_pwfd = 0
        .t_cprj = ind.ProjectID
        .t_elem = ind.ElementID
        .t_spec = LotItem
        .t_bpid = ind.BuyerID
        Select Case ts.StatusID
          Case enumTSStates.TechnicalSpecificationReleased
            .t_stat = "Technical Specification Released"
          Case enumTSStates.EnquiryInProgress
            .t_stat = "Enquiry in progress"
          Case enumTSStates.AllOfferReceived
            .t_stat = "All Offer Received"
          Case enumTSStates.CommercialofferFinalized
            .t_stat = "Commercial offer Finalized"
        End Select
        .t_user = ts.CreatedBy
        .t_date = ts.CreatedOn
        .t_supp = ""
        .t_snam = ""
        .t_rdno = ""
        .t_docn = "Indent/Line No.: " & ind.IndentNo & "/" & ind.IndentLine
        .t_supc = ""
        .t_rcno = ""
        .t_mngr = ind.IndenterID
        .t_esub = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      Return mRet
    End Function
    Public Shared Function GetByID(ByVal t_wfid As Integer, Optional ByVal comp As String = "200") As SIS.DM.dmisg168
      Dim mRet As SIS.DM.dmisg168 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from tdmisg168" & comp & " where t_wfid=" & t_wfid
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          If rd.Read Then
            mRet = New SIS.DM.dmisg168(rd)
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetEnquiry(ByVal t_wfid As Integer, ByVal t_pwfd As Integer, Optional ByVal comp As String = "200") As SIS.DM.dmisg168
      Dim mRet As SIS.DM.dmisg168 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from tdmisg168" & comp & " where t_wfid=" & t_wfid & " and t_pwfd=" & t_pwfd
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          If rd.Read Then
            mRet = New SIS.DM.dmisg168(rd)
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetErpEnq(ByVal enq As SIS.POW.powEnquiries) As SIS.DM.dmisg168
      Dim mRet As New SIS.DM.dmisg168
      Dim ind As SIS.POW.powTSIndents = SIS.POW.powTSIndents.powTSIndentsSelectList(0, 10, "", False, "", enq.TSID)(0)
      With mRet
        .t_wfid = enq.EnquiryIDERP
        .t_pwfd = enq.TSID
        .t_cprj = ind.ProjectID
        .t_elem = ind.ElementID
        .t_spec = ind.LotItem
        .t_bpid = ind.BuyerID
        Select Case enq.StatusID
          Case enumEnquiryStates.EnquiryRaised
            .t_stat = "Enquiry Raised"
          Case enumEnquiryStates.OfferReceived
            .t_stat = "Technical offer Received"
          Case enumEnquiryStates.CommercialNegotiationCompleted
            .t_stat = "Enquiry For Techno Commercial Negotiation Completed"
        End Select
        .t_user = enq.CreatedBy
        .t_date = enq.CreatedOn
        .t_supp = enq.SupplierID
        .t_snam = enq.SupplierName
        .t_rdno = ""
        .t_docn = ""
        .t_supc = ""
        .t_rcno = ""
        .t_mngr = ind.IndenterID
        .t_esub = enq.EMailSubject
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With

      Return mRet
    End Function

    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub

  End Class
End Namespace
