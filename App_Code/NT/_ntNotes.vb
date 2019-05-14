Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NT
  <DataObject()> _
  Partial Public Class ntNotes
    Private Shared _RecordCount As Integer
    Private _Notes_RunningNo As Int32 = 0
    Private _NotesId As String = ""
    Private _NotesHandle As String = ""
    Private _IndexValue As String = ""
    Private _Title As String = ""
    Private _Description As String = ""
    Private _UserId As String = ""
    Private _Created_Date As String = ""
    Private _SendEmailTo As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _FK_Note_Notes_UserID As SIS.QCM.qcmUsers = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property Notes_RunningNo() As Int32
      Get
        Return _Notes_RunningNo
      End Get
      Set(ByVal value As Int32)
        _Notes_RunningNo = value
      End Set
    End Property
    Public Property NotesId() As String
      Get
        Return _NotesId
      End Get
      Set(ByVal value As String)
        _NotesId = value
      End Set
    End Property
    Public Property NotesHandle() As String
      Get
        Return _NotesHandle
      End Get
      Set(ByVal value As String)
        _NotesHandle = value
      End Set
    End Property
    Public Property IndexValue() As String
      Get
        Return _IndexValue
      End Get
      Set(ByVal value As String)
        _IndexValue = value
      End Set
    End Property
    Public Property Title() As String
      Get
        Return _Title
      End Get
      Set(ByVal value As String)
        _Title = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property UserId() As String
      Get
        Return _UserId
      End Get
      Set(ByVal value As String)
        _UserId = value
      End Set
    End Property
    Public Property Created_Date() As String
      Get
        If Not _Created_Date = String.Empty Then
          Return Convert.ToDateTime(_Created_Date).ToString("dd/MM/yyyy")
        End If
        Return _Created_Date
      End Get
      Set(ByVal value As String)
         _Created_Date = value
      End Set
    End Property
    Public Property SendEmailTo() As String
      Get
        Return _SendEmailTo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SendEmailTo = ""
         Else
           _SendEmailTo = value
         End If
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _NotesId
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
    Public Class PKntNotes
      Private _NotesId As String = ""
      Public Property NotesId() As String
        Get
          Return _NotesId
        End Get
        Set(ByVal value As String)
          _NotesId = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_Note_Notes_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_Note_Notes_UserID Is Nothing Then
          _FK_Note_Notes_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserId)
        End If
        Return _FK_Note_Notes_UserID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ntNotesGetNewRecord() As SIS.NT.ntNotes
      Return New SIS.NT.ntNotes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ntNotesGetByID(ByVal NotesId As String) As SIS.NT.ntNotes
      Dim Results As SIS.NT.ntNotes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spntNotesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesId",SqlDbType.VarChar,NotesId.ToString.Length, NotesId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NT.ntNotes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ntNotesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.NT.ntNotes)
      Dim Results As List(Of SIS.NT.ntNotes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spntNotesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spntNotesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NT.ntNotes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NT.ntNotes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ntNotesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function ntNotesInsert(ByVal Record As SIS.NT.ntNotes) As SIS.NT.ntNotes
      Dim _Rec As SIS.NT.ntNotes = SIS.NT.ntNotes.ntNotesGetNewRecord()
      With _Rec
        .Notes_RunningNo = Record.Notes_RunningNo
        .NotesId = Record.NotesId
        .NotesHandle = Record.NotesHandle
        .IndexValue = Record.IndexValue
        .Title = Record.Title
        .Description = Record.Description
        .UserId = Record.UserId
        .Created_Date = Record.Created_Date
        .SendEmailTo = Record.SendEmailTo
      End With
      Return SIS.NT.ntNotes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NT.ntNotes) As SIS.NT.ntNotes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spntNotesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Notes_RunningNo",SqlDbType.Int,11, Record.Notes_RunningNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesId",SqlDbType.VarChar,201, Record.NotesId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesHandle",SqlDbType.VarChar,201, Record.NotesHandle)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndexValue",SqlDbType.VarChar,201, Record.IndexValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Title",SqlDbType.VarChar,501, Record.Title)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.VarChar,20001, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserId",SqlDbType.NVarChar,9, Record.UserId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Created_Date",SqlDbType.DateTime,21, Record.Created_Date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendEmailTo",SqlDbType.VarChar,501, Iif(Record.SendEmailTo= "" ,Convert.DBNull, Record.SendEmailTo))
          Cmd.Parameters.Add("@Return_NotesId", SqlDbType.VarChar, 201)
          Cmd.Parameters("@Return_NotesId").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.NotesId = Cmd.Parameters("@Return_NotesId").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function ntNotesUpdate(ByVal Record As SIS.NT.ntNotes) As SIS.NT.ntNotes
      Dim _Rec As SIS.NT.ntNotes = SIS.NT.ntNotes.ntNotesGetByID(Record.NotesId)
      With _Rec
        .Title = Record.Title
        .Description = Record.Description
        .SendEmailTo = Record.SendEmailTo
      End With
      '1. Insert Reminder
      If Record.ReminderTo <> "" Then
        Dim tmpRem As New SIS.NT.ntReminder
        With tmpRem
          .ReminderID = 0
          .NotesId = Record.NotesId
          .ReminderTo = Record.ReminderTo
          .ReminderDateTime = Record.ReminderDateTime
          .Status = "New"
          .User = HttpContext.Current.Session("LoginID")
          .CreatedDate = Now
        End With
        tmpRem = SIS.NT.ntReminder.InsertData(tmpRem)
      End If
      '2. Send Notification
      Try
        SendEMail(_Rec)
      Catch ex As Exception
      End Try
      Return SIS.NT.ntNotes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NT.ntNotes) As SIS.NT.ntNotes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spntNotesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_NotesId",SqlDbType.VarChar,201, Record.NotesId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Notes_RunningNo",SqlDbType.Int,11, Record.Notes_RunningNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesId",SqlDbType.VarChar,201, Record.NotesId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesHandle",SqlDbType.VarChar,201, Record.NotesHandle)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndexValue",SqlDbType.VarChar,201, Record.IndexValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Title",SqlDbType.VarChar,501, Record.Title)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.VarChar,20001, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserId",SqlDbType.NVarChar,9, Record.UserId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Created_Date",SqlDbType.DateTime,21, Record.Created_Date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendEmailTo",SqlDbType.VarChar,501, Iif(Record.SendEmailTo= "" ,Convert.DBNull, Record.SendEmailTo))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function ntNotesDelete(ByVal Record As SIS.NT.ntNotes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spntNotesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_NotesId",SqlDbType.VarChar,Record.NotesId.ToString.Length, Record.NotesId)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
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
