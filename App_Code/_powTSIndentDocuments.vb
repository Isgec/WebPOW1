Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  <DataObject()> _
  Partial Public Class powTSIndentDocuments
    Private Shared _RecordCount As Integer
    Private _DocNo As Int32 = 0
    Private _DocumentID As String = ""
    Private _DocumentRevision As String = ""
    Private _SerialNo As Int32 = 0
    Private _TSID As Int32 = 0
    Private _POW_TechnicalSpecifications1_TSDescription As String = ""
    Private _POW_TSIndents2_IndentNo As String = ""
    Private _FK_POW_TSIndentDocuments_TSID As SIS.POW.powTechnicalSpecifications = Nothing
    Private _FK_POW_TSIndentDocuments_SerialNo As SIS.POW.powTSIndents = Nothing
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
    Public Property DocNo() As Int32
      Get
        Return _DocNo
      End Get
      Set(ByVal value As Int32)
        _DocNo = value
      End Set
    End Property
    Public Property DocumentID() As String
      Get
        Return _DocumentID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentID = ""
         Else
           _DocumentID = value
         End If
      End Set
    End Property
    Public Property DocumentRevision() As String
      Get
        Return _DocumentRevision
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentRevision = ""
         Else
           _DocumentRevision = value
         End If
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property TSID() As Int32
      Get
        Return _TSID
      End Get
      Set(ByVal value As Int32)
        _TSID = value
      End Set
    End Property
    Public Property POW_TechnicalSpecifications1_TSDescription() As String
      Get
        Return _POW_TechnicalSpecifications1_TSDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_TechnicalSpecifications1_TSDescription = ""
         Else
           _POW_TechnicalSpecifications1_TSDescription = value
         End If
      End Set
    End Property
    Public Property POW_TSIndents2_IndentNo() As String
      Get
        Return _POW_TSIndents2_IndentNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_TSIndents2_IndentNo = ""
         Else
           _POW_TSIndents2_IndentNo = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _DocumentID.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TSID & "|" & _SerialNo & "|" & _DocNo
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
    Public Class PKpowTSIndentDocuments
      Private _TSID As Int32 = 0
      Private _SerialNo As Int32 = 0
      Private _DocNo As Int32 = 0
      Public Property TSID() As Int32
        Get
          Return _TSID
        End Get
        Set(ByVal value As Int32)
          _TSID = value
        End Set
      End Property
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
      Public Property DocNo() As Int32
        Get
          Return _DocNo
        End Get
        Set(ByVal value As Int32)
          _DocNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_POW_TSIndentDocuments_TSID() As SIS.POW.powTechnicalSpecifications
      Get
        If _FK_POW_TSIndentDocuments_TSID Is Nothing Then
          _FK_POW_TSIndentDocuments_TSID = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(_TSID)
        End If
        Return _FK_POW_TSIndentDocuments_TSID
      End Get
    End Property
    Public ReadOnly Property FK_POW_TSIndentDocuments_SerialNo() As SIS.POW.powTSIndents
      Get
        If _FK_POW_TSIndentDocuments_SerialNo Is Nothing Then
          _FK_POW_TSIndentDocuments_SerialNo = SIS.POW.powTSIndents.powTSIndentsGetByID(_TSID, _SerialNo)
        End If
        Return _FK_POW_TSIndentDocuments_SerialNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentDocumentsSelectList(ByVal OrderBy As String) As List(Of SIS.POW.powTSIndentDocuments)
      Dim Results As List(Of SIS.POW.powTSIndentDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DocumentID"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentDocumentsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.POW.powTSIndentDocuments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powTSIndentDocuments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentDocumentsGetNewRecord() As SIS.POW.powTSIndentDocuments
      Return New SIS.POW.powTSIndentDocuments()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentDocumentsGetByID(ByVal TSID As Int32, ByVal SerialNo As Int32, ByVal DocNo As Int32) As SIS.POW.powTSIndentDocuments
      Dim Results As SIS.POW.powTSIndentDocuments = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentDocumentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,TSID.ToString.Length, TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocNo",SqlDbType.Int,DocNo.ToString.Length, DocNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.POW.powTSIndentDocuments(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentDocumentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal TSID As Int32) As List(Of SIS.POW.powTSIndentDocuments)
      Dim Results As List(Of SIS.POW.powTSIndentDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DocumentID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppowTSIndentDocumentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppowTSIndentDocumentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TSID",SqlDbType.Int,10, IIf(TSID = Nothing, 0,TSID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.POW.powTSIndentDocuments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powTSIndentDocuments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function powTSIndentDocumentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal TSID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentDocumentsGetByID(ByVal TSID As Int32, ByVal SerialNo As Int32, ByVal DocNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_TSID As Int32) As SIS.POW.powTSIndentDocuments
      Return powTSIndentDocumentsGetByID(TSID, SerialNo, DocNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function powTSIndentDocumentsInsert(ByVal Record As SIS.POW.powTSIndentDocuments) As SIS.POW.powTSIndentDocuments
      Dim _Rec As SIS.POW.powTSIndentDocuments = SIS.POW.powTSIndentDocuments.powTSIndentDocumentsGetNewRecord()
      With _Rec
        .DocumentID = Record.DocumentID
        .DocumentRevision = Record.DocumentRevision
        .SerialNo = Record.SerialNo
        .TSID = Record.TSID
      End With
      Return SIS.POW.powTSIndentDocuments.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.POW.powTSIndentDocuments) As SIS.POW.powTSIndentDocuments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentDocumentsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,51, Iif(Record.DocumentID= "" ,Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision",SqlDbType.NVarChar,6, Iif(Record.DocumentRevision= "" ,Convert.DBNull, Record.DocumentRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,11, Record.TSID)
          Cmd.Parameters.Add("@Return_TSID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TSID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DocNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DocNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TSID = Cmd.Parameters("@Return_TSID").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.DocNo = Cmd.Parameters("@Return_DocNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function powTSIndentDocumentsUpdate(ByVal Record As SIS.POW.powTSIndentDocuments) As SIS.POW.powTSIndentDocuments
      Dim _Rec As SIS.POW.powTSIndentDocuments = SIS.POW.powTSIndentDocuments.powTSIndentDocumentsGetByID(Record.TSID, Record.SerialNo, Record.DocNo)
      With _Rec
        .DocumentID = Record.DocumentID
        .DocumentRevision = Record.DocumentRevision
      End With
      Return SIS.POW.powTSIndentDocuments.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.POW.powTSIndentDocuments) As SIS.POW.powTSIndentDocuments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentDocumentsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocNo",SqlDbType.Int,11, Record.DocNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,51, Iif(Record.DocumentID= "" ,Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision",SqlDbType.NVarChar,6, Iif(Record.DocumentRevision= "" ,Convert.DBNull, Record.DocumentRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,11, Record.TSID)
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
    Public Shared Function powTSIndentDocumentsDelete(ByVal Record As SIS.POW.powTSIndentDocuments) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentDocumentsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,Record.TSID.ToString.Length, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocNo",SqlDbType.Int,Record.DocNo.ToString.Length, Record.DocNo)
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
'    Autocomplete Method
    Public Shared Function SelectpowTSIndentDocumentsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentDocumentsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.POW.powTSIndentDocuments = New SIS.POW.powTSIndentDocuments(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
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
