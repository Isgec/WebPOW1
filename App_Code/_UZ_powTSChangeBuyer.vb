Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  Partial Public Class powTSChangeBuyer
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function ApproveWF(ByVal TSID As Int32) As SIS.POW.powTSChangeBuyer
      Dim Results As SIS.POW.powTSChangeBuyer = powTSChangeBuyerGetByID(TSID)
      Return Results
    End Function
    Public Shared Function powTSChangeBuyerUpdate(ByVal Record As SIS.POW.powTSChangeBuyer) As SIS.POW.powTSChangeBuyer
      Dim _Rec As SIS.POW.powTechnicalSpecifications = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(Record.TSID)
      _Rec.CreatedBy = Record.CreatedBy
      _Rec = SIS.POW.powTechnicalSpecifications.UpdateData(_Rec)
      '======Update CT======
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", Record.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = " UPDATE tdmisg168" & Comp & " set t_user='" & Record.CreatedBy & "' where t_wfid=" & Record.TSID
            Con.Open()
            Try
              Cmd.ExecuteNonQuery()
            Catch ex As Exception
              Throw New Exception("Buyer NOT Changed in ERP")
            End Try
          End Using
        End Using
      End If
      '======================
      Return Record
    End Function
  End Class
End Namespace
