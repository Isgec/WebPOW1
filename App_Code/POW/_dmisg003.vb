Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DMISG
  <DataObject()> _
  Partial Public Class dmisg003
    Private Shared _RecordCount As Integer
    Private _t_docn As String = ""
    Private _t_revn As String = ""
    Private _t_drgt As String = ""
    Private _t_dcfn As String = ""
    Private _t_drev As String = ""
    Private _t_drgn As String = ""
    Private _t_pdff As String = ""
    Private _t_stat As String = ""
    Private _t_type As Int32 = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Public Property t_docn() As String
      Get
        Return _t_docn
      End Get
      Set(ByVal value As String)
        _t_docn = value
      End Set
    End Property
    Public Property t_revn() As String
      Get
        Return _t_revn
      End Get
      Set(ByVal value As String)
        _t_revn = value
      End Set
    End Property
    Public Property t_drgt() As String
      Get
        Return _t_drgt
      End Get
      Set(ByVal value As String)
        _t_drgt = value
      End Set
    End Property
    Public Property t_dcfn() As String
      Get
        Return _t_dcfn
      End Get
      Set(ByVal value As String)
        _t_dcfn = value
      End Set
    End Property
    Public Property t_drev() As String
      Get
        Return _t_drev
      End Get
      Set(ByVal value As String)
        _t_drev = value
      End Set
    End Property
    Public Property t_drgn() As String
      Get
        Return _t_drgn
      End Get
      Set(ByVal value As String)
        _t_drgn = value
      End Set
    End Property
    Public Property t_pdff() As String
      Get
        Return _t_pdff
      End Get
      Set(ByVal value As String)
        _t_pdff = value
      End Set
    End Property
    Public Property t_stat() As String
      Get
        Return _t_stat
      End Get
      Set(ByVal value As String)
        _t_stat = value
      End Set
    End Property
    Public Property t_type() As Int32
      Get
        Return _t_type
      End Get
      Set(ByVal value As Int32)
        _t_type = value
      End Set
    End Property
    Public Property t_Refcntd() As Int32
      Get
        Return _t_Refcntd
      End Get
      Set(ByVal value As Int32)
        _t_Refcntd = value
      End Set
    End Property
    Public Property t_Refcntu() As Int32
      Get
        Return _t_Refcntu
      End Get
      Set(ByVal value As Int32)
        _t_Refcntu = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_docn & "|" & _t_revn
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKdmisg003
      Private _t_docn As String = ""
      Private _t_revn As String = ""
      Public Property t_docn() As String
        Get
          Return _t_docn
        End Get
        Set(ByVal value As String)
          _t_docn = value
        End Set
      End Property
      Public Property t_revn() As String
        Get
          Return _t_revn
        End Get
        Set(ByVal value As String)
          _t_revn = value
        End Set
      End Property
    End Class
    Public Shared Function SelectRefDrawingList(ByVal t_docn As String, ByVal t_revn As String, Optional ByVal Comp As String = "200") As List(Of SIS.DMISG.dmisg003)
      Dim Results As List(Of SIS.DMISG.dmisg003) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from tdmisg003" & Comp & " where t_docn ='" & t_docn & "' and t_revn='" & t_revn & "'"
          Results = New List(Of SIS.DMISG.dmisg003)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.DMISG.dmisg003(Reader))
          End While
          Reader.Close()
          _RecordCount = Results.Count
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetLatestRevisionNoOfDocument(ByVal t_docn As String, Optional ByVal Comp As String = "200") As String
      Dim Results As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(max(t_revn),'') from tdmisg001" & Comp & " where t_docn ='" & t_docn & "'"
          Con.Open()
          Results = Cmd.ExecuteScalar
          _RecordCount = 1
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function dmisg003SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
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
