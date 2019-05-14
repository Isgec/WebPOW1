Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  <DataObject()> _
  Partial Public Class powTechnicalSpecifications
    Private Shared _RecordCount As Integer
    Private _TSID As Int32 = 0
    Private _TSTypeID As String = ""
    Private _TSDescription As String = ""
    Private _AdditionalEMailIDs As String = ""
    Private _StatusID As String = ""
    Private _CreatedOn As String = ""
    Private _CreatedBy As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _POW_TSStates2_Description As String = ""
    Private _POW_TSTypes3_Description As String = ""
    Private _FK_POW_TS_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_POW_TS_StatusID As SIS.POW.powTSStates = Nothing
    Private _FK_POW_TS_TSTypeID As SIS.POW.powTSTypes = Nothing
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
    Public Property TSID() As Int32
      Get
        Return _TSID
      End Get
      Set(ByVal value As Int32)
        _TSID = value
      End Set
    End Property
    Public Property TSTypeID() As String
      Get
        Return _TSTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TSTypeID = ""
         Else
           _TSTypeID = value
         End If
      End Set
    End Property
    Public Property TSDescription() As String
      Get
        Return _TSDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TSDescription = ""
         Else
           _TSDescription = value
         End If
      End Set
    End Property
    Public Property AdditionalEMailIDs() As String
      Get
        Return _AdditionalEMailIDs
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AdditionalEMailIDs = ""
         Else
           _AdditionalEMailIDs = value
         End If
      End Set
    End Property
    Public Property StatusID() As String
      Get
        Return _StatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StatusID = ""
         Else
           _StatusID = value
         End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedOn = ""
         Else
           _CreatedOn = value
         End If
      End Set
    End Property
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedBy = ""
         Else
           _CreatedBy = value
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
    Public Property POW_TSStates2_Description() As String
      Get
        Return _POW_TSStates2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_TSStates2_Description = ""
         Else
           _POW_TSStates2_Description = value
         End If
      End Set
    End Property
    Public Property POW_TSTypes3_Description() As String
      Get
        Return _POW_TSTypes3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_TSTypes3_Description = ""
         Else
           _POW_TSTypes3_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _TSDescription.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TSID
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
    Public Class PKpowTechnicalSpecifications
      Private _TSID As Int32 = 0
      Public Property TSID() As Int32
        Get
          Return _TSID
        End Get
        Set(ByVal value As Int32)
          _TSID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_POW_TS_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_POW_TS_CreatedBy Is Nothing Then
          _FK_POW_TS_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_POW_TS_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_POW_TS_StatusID() As SIS.POW.powTSStates
      Get
        If _FK_POW_TS_StatusID Is Nothing Then
          _FK_POW_TS_StatusID = SIS.POW.powTSStates.powTSStatesGetByID(_StatusID)
        End If
        Return _FK_POW_TS_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_POW_TS_TSTypeID() As SIS.POW.powTSTypes
      Get
        If _FK_POW_TS_TSTypeID Is Nothing Then
          _FK_POW_TS_TSTypeID = SIS.POW.powTSTypes.powTSTypesGetByID(_TSTypeID)
        End If
        Return _FK_POW_TS_TSTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTechnicalSpecificationsSelectList(ByVal OrderBy As String) As List(Of SIS.POW.powTechnicalSpecifications)
      Dim Results As List(Of SIS.POW.powTechnicalSpecifications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TSID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTechnicalSpecificationsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.POW.powTechnicalSpecifications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powTechnicalSpecifications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTechnicalSpecificationsGetNewRecord() As SIS.POW.powTechnicalSpecifications
      Return New SIS.POW.powTechnicalSpecifications()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTechnicalSpecificationsGetByID(ByVal TSID As Int32) As SIS.POW.powTechnicalSpecifications
      Dim Results As SIS.POW.powTechnicalSpecifications = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTechnicalSpecificationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,TSID.ToString.Length, TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTechnicalSpecificationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal StatusID As Int32) As List(Of SIS.POW.powTechnicalSpecifications)
      Dim Results As List(Of SIS.POW.powTechnicalSpecifications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TSID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppowTechnicalSpecificationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppowTechnicalSpecificationsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.POW.powTechnicalSpecifications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powTechnicalSpecifications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function powTechnicalSpecificationsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal StatusID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTechnicalSpecificationsGetByID(ByVal TSID As Int32, ByVal Filter_StatusID As Int32) As SIS.POW.powTechnicalSpecifications
      Return powTechnicalSpecificationsGetByID(TSID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function powTechnicalSpecificationsInsert(ByVal Record As SIS.POW.powTechnicalSpecifications) As SIS.POW.powTechnicalSpecifications
      Dim _Rec As SIS.POW.powTechnicalSpecifications = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetNewRecord()
      With _Rec
        .TSTypeID = Record.TSTypeID
        .TSDescription = Record.TSDescription
        .AdditionalEMailIDs = Record.AdditionalEMailIDs
        .StatusID = enumTSStates.TechnicalSpecificationReleased
        .CreatedOn = Now
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.POW.powTechnicalSpecifications.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.POW.powTechnicalSpecifications) As SIS.POW.powTechnicalSpecifications
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTechnicalSpecificationsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSTypeID",SqlDbType.Int,11, Iif(Record.TSTypeID= "" ,Convert.DBNull, Record.TSTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSDescription",SqlDbType.NVarChar,101, Iif(Record.TSDescription= "" ,Convert.DBNull, Record.TSDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdditionalEMailIDs",SqlDbType.NVarChar,501, Iif(Record.AdditionalEMailIDs= "" ,Convert.DBNull, Record.AdditionalEMailIDs))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllOfferReceivedOn", SqlDbType.DateTime, 21, IIf(Record.AllOfferReceivedOn = "", Convert.DBNull, Record.AllOfferReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CommercialOfferFinalizedOn", SqlDbType.DateTime, 21, IIf(Record.CommercialOfferFinalizedOn = "", Convert.DBNull, Record.CommercialOfferFinalizedOn))
          Cmd.Parameters.Add("@Return_TSID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TSID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TSID = Cmd.Parameters("@Return_TSID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function powTechnicalSpecificationsUpdate(ByVal Record As SIS.POW.powTechnicalSpecifications) As SIS.POW.powTechnicalSpecifications
      Dim _Rec As SIS.POW.powTechnicalSpecifications = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(Record.TSID)
      With _Rec
        Select Case .StatusID
          Case enumTSStates.Created, enumTSStates.TechnicalSpecificationReleased
            .StatusID = Record.StatusID
            .CreatedOn = Now
            .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        End Select
        .TSTypeID = Record.TSTypeID
        .TSDescription = Record.TSDescription
        .AdditionalEMailIDs = Record.AdditionalEMailIDs
      End With
      Return SIS.POW.powTechnicalSpecifications.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.POW.powTechnicalSpecifications) As SIS.POW.powTechnicalSpecifications
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTechnicalSpecificationsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSTypeID",SqlDbType.Int,11, Iif(Record.TSTypeID= "" ,Convert.DBNull, Record.TSTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSDescription",SqlDbType.NVarChar,101, Iif(Record.TSDescription= "" ,Convert.DBNull, Record.TSDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdditionalEMailIDs",SqlDbType.NVarChar,501, Iif(Record.AdditionalEMailIDs= "" ,Convert.DBNull, Record.AdditionalEMailIDs))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllOfferReceivedOn", SqlDbType.DateTime, 21, IIf(Record.AllOfferReceivedOn = "", Convert.DBNull, Record.AllOfferReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CommercialOfferFinalizedOn", SqlDbType.DateTime, 21, IIf(Record.CommercialOfferFinalizedOn = "", Convert.DBNull, Record.CommercialOfferFinalizedOn))
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
    Public Shared Function powTechnicalSpecificationsDelete(ByVal Record As SIS.POW.powTechnicalSpecifications) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTechnicalSpecificationsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,Record.TSID.ToString.Length, Record.TSID)
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
    Public Shared Function SelectpowTechnicalSpecificationsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTechnicalSpecificationsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.POW.powTechnicalSpecifications = New SIS.POW.powTechnicalSpecifications(Reader)
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
