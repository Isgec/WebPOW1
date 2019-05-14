Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  <DataObject()> _
  Partial Public Class powEnquiries
    Private Shared _RecordCount As Integer
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _aspnet_Users5_UserFullName As String = ""
    Private _FK_POW_Enquiries_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _EnquiryID As Int32 = 0
    Private _SupplierID As String = ""
    Private _SupplierName As String = ""
    Private _EMailSubject As String = ""
    Private _StatusID As String = ""
    Private _SentOn As String = ""
    Private _TSID As Int32 = 0
    Private _AdditionalEMailIDs As String = ""
    Private _EMailBody As String = ""
    Private _SupplierLoginID As String = ""
    Private _VendorKey As String = ""
    Private _SupplierEMailID As String = ""
    Private _POW_EnquiryStates1_Description As String = ""
    Private _POW_TechnicalSpecifications2_TSDescription As String = ""
    Private _VR_BusinessPartner3_BPName As String = ""
    Private _aspnet_Users4_UserFullName As String = ""
    Private _FK_POW_Enquiries_StatusID As SIS.POW.powEnquiryStates = Nothing
    Private _FK_POW_Enquiries_TSID As SIS.POW.powTechnicalSpecifications = Nothing
    Private _FK_POW_Enquiries_SupplierID As SIS.VR.vrBusinessPartner = Nothing
    Private _FK_POW_Enquiries_SupplierLoginID As SIS.QCM.qcmUsers = Nothing
    Public Property CommercialNegotiationCompletedOn As String = ""
    Public Property SupplierFromEMailID As String = ""
    Public Property OfferReceivedOn As String = ""
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CreatedBy = ""
        Else
          _CreatedBy = value
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
        If Convert.IsDBNull(value) Then
          _CreatedOn = ""
        Else
          _CreatedOn = value
        End If
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
    Public ReadOnly Property FK_POW_Enquiries_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_POW_Enquiries_CreatedBy Is Nothing Then
          _FK_POW_Enquiries_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_POW_Enquiries_CreatedBy
      End Get
    End Property
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
    Public Property EnquiryID() As Int32
      Get
        Return _EnquiryID
      End Get
      Set(ByVal value As Int32)
        _EnquiryID = value
      End Set
    End Property
    Public Property SupplierID() As String
      Get
        Return _SupplierID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierID = ""
         Else
           _SupplierID = value
         End If
      End Set
    End Property
    Public Property SupplierName() As String
      Get
        Return _SupplierName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierName = ""
         Else
           _SupplierName = value
         End If
      End Set
    End Property
    Public Property EMailSubject() As String
      Get
        Return _EMailSubject
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EMailSubject = ""
         Else
           _EMailSubject = value
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
    Public Property SentOn() As String
      Get
        If Not _SentOn = String.Empty Then
          Return Convert.ToDateTime(_SentOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _SentOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SentOn = ""
         Else
           _SentOn = value
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
    Public Property EMailBody() As String
      Get
        Return _EMailBody
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EMailBody = ""
         Else
           _EMailBody = value
         End If
      End Set
    End Property
    Public Property SupplierLoginID() As String
      Get
        Return _SupplierLoginID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierLoginID = ""
         Else
           _SupplierLoginID = value
         End If
      End Set
    End Property
    Public Property VendorKey() As String
      Get
        Return _VendorKey
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VendorKey = ""
         Else
           _VendorKey = value
         End If
      End Set
    End Property
    Public Property SupplierEMailID() As String
      Get
        Return _SupplierEMailID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierEMailID = ""
         Else
           _SupplierEMailID = value
         End If
      End Set
    End Property
    Public Property POW_EnquiryStates1_Description() As String
      Get
        Return _POW_EnquiryStates1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_EnquiryStates1_Description = ""
         Else
           _POW_EnquiryStates1_Description = value
         End If
      End Set
    End Property
    Public Property POW_TechnicalSpecifications2_TSDescription() As String
      Get
        Return _POW_TechnicalSpecifications2_TSDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_TechnicalSpecifications2_TSDescription = ""
         Else
           _POW_TechnicalSpecifications2_TSDescription = value
         End If
      End Set
    End Property
    Public Property VR_BusinessPartner3_BPName() As String
      Get
        Return _VR_BusinessPartner3_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner3_BPName = value
      End Set
    End Property
    Public Property aspnet_Users4_UserFullName() As String
      Get
        Return _aspnet_Users4_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users4_UserFullName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _EMailSubject.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TSID & "|" & _EnquiryID
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
    Public Class PKpowEnquiries
      Private _TSID As Int32 = 0
      Private _EnquiryID As Int32 = 0
      Public Property TSID() As Int32
        Get
          Return _TSID
        End Get
        Set(ByVal value As Int32)
          _TSID = value
        End Set
      End Property
      Public Property EnquiryID() As Int32
        Get
          Return _EnquiryID
        End Get
        Set(ByVal value As Int32)
          _EnquiryID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_POW_Enquiries_StatusID() As SIS.POW.powEnquiryStates
      Get
        If _FK_POW_Enquiries_StatusID Is Nothing Then
          _FK_POW_Enquiries_StatusID = SIS.POW.powEnquiryStates.powEnquiryStatesGetByID(_StatusID)
        End If
        Return _FK_POW_Enquiries_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_POW_Enquiries_TSID() As SIS.POW.powTechnicalSpecifications
      Get
        If _FK_POW_Enquiries_TSID Is Nothing Then
          _FK_POW_Enquiries_TSID = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(_TSID)
        End If
        Return _FK_POW_Enquiries_TSID
      End Get
    End Property
    Public ReadOnly Property FK_POW_Enquiries_SupplierID() As SIS.VR.vrBusinessPartner
      Get
        If _FK_POW_Enquiries_SupplierID Is Nothing Then
          _FK_POW_Enquiries_SupplierID = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(_SupplierID)
        End If
        Return _FK_POW_Enquiries_SupplierID
      End Get
    End Property
    Public ReadOnly Property FK_POW_Enquiries_SupplierLoginID() As SIS.QCM.qcmUsers
      Get
        If _FK_POW_Enquiries_SupplierLoginID Is Nothing Then
          _FK_POW_Enquiries_SupplierLoginID = SIS.QCM.qcmUsers.qcmUsersGetByID(_SupplierLoginID)
        End If
        Return _FK_POW_Enquiries_SupplierLoginID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powEnquiriesSelectList(ByVal OrderBy As String) As List(Of SIS.POW.powEnquiries)
      Dim Results As List(Of SIS.POW.powEnquiries) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SentOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowEnquiriesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powEnquiriesGetNewRecord() As SIS.POW.powEnquiries
      Return New SIS.POW.powEnquiries()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powEnquiriesGetByID(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powEnquiries
      Dim Results As SIS.POW.powEnquiries = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowEnquiriesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,TSID.ToString.Length, TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnquiryID",SqlDbType.Int,EnquiryID.ToString.Length, EnquiryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powEnquiriesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TSID As Int32) As List(Of SIS.POW.powEnquiries)
      Dim Results As List(Of SIS.POW.powEnquiries) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SentOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppowEnquiriesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppowEnquiriesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TSID",SqlDbType.Int,10, IIf(TSID = Nothing, 0,TSID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function powEnquiriesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TSID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powEnquiriesGetByID(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal Filter_TSID As Int32) As SIS.POW.powEnquiries
      Return powEnquiriesGetByID(TSID, EnquiryID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function powEnquiriesInsert(ByVal Record As SIS.POW.powEnquiries) As SIS.POW.powEnquiries
      Dim _Rec As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetNewRecord()
      With _Rec
        .SupplierID = Record.SupplierID
        .SupplierName = Record.SupplierName
        .EMailSubject = Record.EMailSubject
        .StatusID = enumEnquiryStates.EnquiryCreated
        .SentOn = Record.SentOn
        .TSID = Record.TSID
        .AdditionalEMailIDs = Record.AdditionalEMailIDs
        .EMailBody = Record.EMailBody
        .SupplierLoginID = Record.SupplierLoginID
        .VendorKey = Guid.NewGuid().ToString
        .SupplierEMailID = Record.SupplierEMailID
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        Try
          .SupplierFromEMailID = Record.SupplierEMailID.Split(",;".ToCharArray)(0).Trim
        Catch ex As Exception
        End Try
      End With
      Return SIS.POW.powEnquiries.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.POW.powEnquiries) As SIS.POW.powEnquiries
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowEnquiriesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,101, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailSubject",SqlDbType.NVarChar,101, Iif(Record.EMailSubject= "" ,Convert.DBNull, Record.EMailSubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SentOn",SqlDbType.DateTime,21, Iif(Record.SentOn= "" ,Convert.DBNull, Record.SentOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdditionalEMailIDs",SqlDbType.NVarChar,501, Iif(Record.AdditionalEMailIDs= "" ,Convert.DBNull, Record.AdditionalEMailIDs))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailBody",SqlDbType.NVarChar,4001, Iif(Record.EMailBody= "" ,Convert.DBNull, Record.EMailBody))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierLoginID",SqlDbType.NVarChar,9, Iif(Record.SupplierLoginID= "" ,Convert.DBNull, Record.SupplierLoginID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VendorKey",SqlDbType.NVarChar,51, Iif(Record.VendorKey= "" ,Convert.DBNull, Record.VendorKey))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierEMailID",SqlDbType.NVarChar,101, Iif(Record.SupplierEMailID= "" ,Convert.DBNull, Record.SupplierEMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CommercialNegotiationCompletedOn", SqlDbType.DateTime, 21, IIf(Record.CommercialNegotiationCompletedOn = "", Convert.DBNull, Record.CommercialNegotiationCompletedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierFromEMailID", SqlDbType.NVarChar, 101, IIf(Record.SupplierFromEMailID = "", Convert.DBNull, Record.SupplierFromEMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfferReceivedOn", SqlDbType.DateTime, 21, IIf(Record.OfferReceivedOn = "", Convert.DBNull, Record.OfferReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          Cmd.Parameters.Add("@Return_TSID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TSID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_EnquiryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_EnquiryID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TSID = Cmd.Parameters("@Return_TSID").Value
          Record.EnquiryID = Cmd.Parameters("@Return_EnquiryID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function powEnquiriesUpdate(ByVal Record As SIS.POW.powEnquiries) As SIS.POW.powEnquiries
      Dim _Rec As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(Record.TSID, Record.EnquiryID)
      With _Rec
        .SupplierID = Record.SupplierID
        .SupplierName = Record.SupplierName
        .EMailSubject = Record.EMailSubject
        .StatusID = Record.StatusID
        .SentOn = Record.SentOn
        .AdditionalEMailIDs = Record.AdditionalEMailIDs
        .EMailBody = Record.EMailBody
        .SupplierLoginID = Record.SupplierLoginID
        .SupplierEMailID = Record.SupplierEMailID
        .CreatedBy = HttpContext.Current.Session("LoginID")
      End With
      Return SIS.POW.powEnquiries.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.POW.powEnquiries) As SIS.POW.powEnquiries
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowEnquiriesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EnquiryID",SqlDbType.Int,11, Record.EnquiryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,101, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailSubject",SqlDbType.NVarChar,101, Iif(Record.EMailSubject= "" ,Convert.DBNull, Record.EMailSubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SentOn",SqlDbType.DateTime,21, Iif(Record.SentOn= "" ,Convert.DBNull, Record.SentOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdditionalEMailIDs",SqlDbType.NVarChar,501, Iif(Record.AdditionalEMailIDs= "" ,Convert.DBNull, Record.AdditionalEMailIDs))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailBody",SqlDbType.NVarChar,4001, Iif(Record.EMailBody= "" ,Convert.DBNull, Record.EMailBody))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierLoginID",SqlDbType.NVarChar,9, Iif(Record.SupplierLoginID= "" ,Convert.DBNull, Record.SupplierLoginID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VendorKey",SqlDbType.NVarChar,51, Iif(Record.VendorKey= "" ,Convert.DBNull, Record.VendorKey))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierEMailID",SqlDbType.NVarChar,101, Iif(Record.SupplierEMailID= "" ,Convert.DBNull, Record.SupplierEMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CommercialNegotiationCompletedOn", SqlDbType.DateTime, 21, IIf(Record.CommercialNegotiationCompletedOn = "", Convert.DBNull, Record.CommercialNegotiationCompletedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierFromEMailID", SqlDbType.NVarChar, 101, IIf(Record.SupplierFromEMailID = "", Convert.DBNull, Record.SupplierFromEMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfferReceivedOn", SqlDbType.DateTime, 21, IIf(Record.OfferReceivedOn = "", Convert.DBNull, Record.OfferReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
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
    Public Shared Function powEnquiriesDelete(ByVal Record As SIS.POW.powEnquiries) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowEnquiriesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,Record.TSID.ToString.Length, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EnquiryID",SqlDbType.Int,Record.EnquiryID.ToString.Length, Record.EnquiryID)
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
    Public Shared Function SelectpowEnquiriesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowEnquiriesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.POW.powEnquiries = New SIS.POW.powEnquiries(Reader)
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
