Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DM
  Public Class dmisg167
    Public Property t_wfid As Integer = 0
    Public Property t_docn As String = ""
    Public Property t_Refcntd As Integer = 0
    Public Property t_Refcntu As Integer = 0

    Public Shared Function GetByID(ByVal t_wfid As Integer, ByVal t_docn As String, Optional ByVal comp As String = "200") As SIS.DM.dmisg167
      Dim mRet As SIS.DM.dmisg167 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from tdmisg167" & comp & " where t_wfid=" & t_wfid & " and t_docn='" & t_docn & "'"
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          If rd.Read Then
            mRet = New SIS.DM.dmisg167(rd)
          End If
        End Using
      End Using
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
