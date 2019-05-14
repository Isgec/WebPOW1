Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  <DataObject()> _
  Partial Public Class powTSIndents
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _IndentNo As String = ""
    Private _IndentLine As String = ""
    Private _LotItem As String = ""
    Private _ProjectID As String = ""
    Private _ElementID As String = ""
    Private _IndenterID As String = ""
    Private _BuyerID As String = ""
    Private _TSID As Int32 = 0
    Private _Specification As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _IDM_Projects2_Description As String = ""
    Private _IDM_WBS3_Description As String = ""
    Private _POW_TechnicalSpecifications4_TSDescription As String = ""
    Private _aspnet_Users5_UserFullName As String = ""
    Private _FK_POW_TSIndents_BuyerID As SIS.QCM.qcmUsers = Nothing
    Private _FK_POW_TSIndents_IndenterID As SIS.QCM.qcmUsers = Nothing
    Private _FK_POW_TSIndents_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_POW_TSIndents_ElementID As SIS.PAK.pakWBS = Nothing
    Private _FK_POW_TSIndents_TSID As SIS.POW.powTechnicalSpecifications = Nothing
    Public Property LotItemName As String = ""
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property IndentNo() As String
      Get
        Return _IndentNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IndentNo = ""
         Else
           _IndentNo = value
         End If
      End Set
    End Property
    Public Property IndentLine() As String
      Get
        Return _IndentLine
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IndentLine = ""
         Else
           _IndentLine = value
         End If
      End Set
    End Property
    Public Property Specification() As String
      Get
        Return _Specification
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Specification = ""
        Else
          _Specification = value
        End If
      End Set
    End Property
    Public Property LotItem() As String
      Get
        Return _LotItem
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _LotItem = ""
        Else
          _LotItem = value
        End If
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ProjectID = ""
        Else
          _ProjectID = value
        End If
      End Set
    End Property
    Public Property ElementID() As String
      Get
        Return _ElementID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ElementID = ""
         Else
           _ElementID = value
         End If
      End Set
    End Property
    Public Property BuyerID() As String
      Get
        Return _BuyerID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BuyerID = ""
        Else
          _BuyerID = value
        End If
      End Set
    End Property
    Public Property IndenterID() As String
      Get
        Return _IndenterID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IndenterID = ""
        Else
          _IndenterID = value
        End If
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
    Public Property aspnet_Users5_UserFullName() As String
      Get
        Return _aspnet_Users5_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users5_UserFullName = value
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
    Public Property IDM_Projects2_Description() As String
      Get
        Return _IDM_Projects2_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects2_Description = value
      End Set
    End Property
    Public Property IDM_WBS3_Description() As String
      Get
        Return _IDM_WBS3_Description
      End Get
      Set(ByVal value As String)
        _IDM_WBS3_Description = value
      End Set
    End Property
    Public Property POW_TechnicalSpecifications4_TSDescription() As String
      Get
        Return _POW_TechnicalSpecifications4_TSDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_TechnicalSpecifications4_TSDescription = ""
         Else
           _POW_TechnicalSpecifications4_TSDescription = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _IndentNo.ToString.PadRight(9, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TSID & "|" & _SerialNo
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
    Public Class PKpowTSIndents
      Private _TSID As Int32 = 0
      Private _SerialNo As Int32 = 0
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
    End Class
    Public ReadOnly Property FK_POW_TSIndents_BuyerID() As SIS.QCM.qcmUsers
      Get
        If _FK_POW_TSIndents_BuyerID Is Nothing Then
          _FK_POW_TSIndents_BuyerID = SIS.QCM.qcmUsers.qcmUsersGetByID(_BuyerID)
        End If
        Return _FK_POW_TSIndents_BuyerID
      End Get
    End Property
    Public ReadOnly Property FK_POW_TSIndents_IndenterID() As SIS.QCM.qcmUsers
      Get
        If _FK_POW_TSIndents_IndenterID Is Nothing Then
          _FK_POW_TSIndents_IndenterID = SIS.QCM.qcmUsers.qcmUsersGetByID(_IndenterID)
        End If
        Return _FK_POW_TSIndents_IndenterID
      End Get
    End Property
    Public ReadOnly Property FK_POW_TSIndents_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_POW_TSIndents_ProjectID Is Nothing Then
          _FK_POW_TSIndents_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_POW_TSIndents_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_POW_TSIndents_ElementID() As SIS.PAK.pakWBS
      Get
        If _FK_POW_TSIndents_ElementID Is Nothing Then
          _FK_POW_TSIndents_ElementID = SIS.PAK.pakWBS.pakWBSGetByID(_ElementID)
        End If
        Return _FK_POW_TSIndents_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_POW_TSIndents_TSID() As SIS.POW.powTechnicalSpecifications
      Get
        If _FK_POW_TSIndents_TSID Is Nothing Then
          _FK_POW_TSIndents_TSID = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(_TSID)
        End If
        Return _FK_POW_TSIndents_TSID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentsSelectList(ByVal OrderBy As String) As List(Of SIS.POW.powTSIndents)
      Dim Results As List(Of SIS.POW.powTSIndents) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "IndentNo"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.POW.powTSIndents)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powTSIndents(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentsGetNewRecord() As SIS.POW.powTSIndents
      Return New SIS.POW.powTSIndents()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentsGetByID(ByVal TSID As Int32, ByVal SerialNo As Int32) As SIS.POW.powTSIndents
      Dim Results As SIS.POW.powTSIndents = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,TSID.ToString.Length, TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.POW.powTSIndents(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TSID As Int32) As List(Of SIS.POW.powTSIndents)
      Dim Results As List(Of SIS.POW.powTSIndents) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "IndentNo"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppowTSIndentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppowTSIndentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TSID",SqlDbType.Int,10, IIf(TSID = Nothing, 0,TSID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.POW.powTSIndents)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powTSIndents(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function powTSIndentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TSID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSIndentsGetByID(ByVal TSID As Int32, ByVal SerialNo As Int32, ByVal Filter_TSID As Int32) As SIS.POW.powTSIndents
      Return powTSIndentsGetByID(TSID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function powTSIndentsInsert(ByVal Record As SIS.POW.powTSIndents) As SIS.POW.powTSIndents
      Dim _Rec As SIS.POW.powTSIndents = SIS.POW.powTSIndents.powTSIndentsGetNewRecord()
      With _Rec
        .IndentNo = Record.IndentNo
        .IndentLine = Record.IndentLine
        .LotItem = Record.LotItem
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .IndenterID = Record.IndenterID
        .BuyerID = Record.BuyerID
        .Specification = Record.Specification
        .TSID = Record.TSID
      End With
      Return SIS.POW.powTSIndents.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.POW.powTSIndents) As SIS.POW.powTSIndents
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo",SqlDbType.NVarChar,10, Iif(Record.IndentNo= "" ,Convert.DBNull, Record.IndentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine",SqlDbType.Int,11, Iif(Record.IndentLine= "" ,Convert.DBNull, Record.IndentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotItem",SqlDbType.NVarChar,48, Iif(Record.LotItem= "" ,Convert.DBNull, Record.LotItem))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterID", SqlDbType.NVarChar, 9, IIf(Record.IndenterID = "", Convert.DBNull, Record.IndenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID", SqlDbType.NVarChar, 9, IIf(Record.BuyerID = "", Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Specification", SqlDbType.NVarChar, 100, IIf(Record.Specification = "", Convert.DBNull, Record.Specification))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotItemName", SqlDbType.NVarChar, 100, IIf(Record.LotItemName = "", Convert.DBNull, Record.LotItemName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID", SqlDbType.Int, 11, Record.TSID)
          Cmd.Parameters.Add("@Return_TSID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TSID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TSID = Cmd.Parameters("@Return_TSID").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function powTSIndentsUpdate(ByVal Record As SIS.POW.powTSIndents) As SIS.POW.powTSIndents
      Dim _Rec As SIS.POW.powTSIndents = SIS.POW.powTSIndents.powTSIndentsGetByID(Record.TSID, Record.SerialNo)
      With _Rec
        .IndentNo = Record.IndentNo
        .IndentLine = Record.IndentLine
        .LotItem = Record.LotItem
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .IndenterID = Record.IndenterID
        .BuyerID = Record.BuyerID
        .Specification = Record.Specification
      End With
      Return SIS.POW.powTSIndents.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.POW.powTSIndents) As SIS.POW.powTSIndents
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo",SqlDbType.NVarChar,10, Iif(Record.IndentNo= "" ,Convert.DBNull, Record.IndentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine",SqlDbType.Int,11, Iif(Record.IndentLine= "" ,Convert.DBNull, Record.IndentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotItem",SqlDbType.NVarChar,48, Iif(Record.LotItem= "" ,Convert.DBNull, Record.LotItem))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterID",SqlDbType.NVarChar,9, Iif(Record.IndenterID= "" ,Convert.DBNull, Record.IndenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID", SqlDbType.NVarChar, 9, IIf(Record.BuyerID = "", Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Specification", SqlDbType.NVarChar, 100, IIf(Record.Specification = "", Convert.DBNull, Record.Specification))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotItemName", SqlDbType.NVarChar, 100, IIf(Record.LotItemName = "", Convert.DBNull, Record.LotItemName))
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
    Public Shared Function powTSIndentsDelete(ByVal Record As SIS.POW.powTSIndents) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,Record.TSID.ToString.Length, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
    Public Shared Function SelectpowTSIndentsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTSIndentsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(9, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.POW.powTSIndents = New SIS.POW.powTSIndents(Reader)
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
