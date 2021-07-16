Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  <DataObject()> _
  Partial Public Class powOffers
    Private Shared _RecordCount As Integer
    Private _ForSupplier As Boolean = False
    Private _CreatedOn As String = ""
    Private _RecordID As Int32 = 0
    Private _RecordTypeID As String = ""
    Private _RecordRevision As String = ""
    Private _EMailSubject As String = ""
    Private _SubmittedBy As String = ""
    Private _SubmittedOn As String = ""
    Private _StatusID As String = ""
    Private _EMailBody As String = ""
    Private _EvaluatedBy As String = ""
    Private _EnquiryID As Int32 = 0
    Private _TSID As Int32 = 0
    Private _DistributedOn As String = ""
    Private _ReceiptID As String = ""
    Private _ReceiptRevision As String = ""
    Private _SubmittedByBuyer As Boolean = False
    Private _EValuatedOn As String = ""
    Private _AcknowledgedOn As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _POW_Enquiries3_EMailSubject As String = ""
    Private _POW_OfferStates4_Description As String = ""
    Private _POW_RecordTypes5_Description As String = ""
    Private _POW_TechnicalSpecifications6_TSDescription As String = ""
    Private _FK_POW_Offers_EvaluatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_POW_Offers_SubmittedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_POW_Offers_EnquiryID As SIS.POW.powEnquiries = Nothing
    Private _FK_POW_Offers_StatusID As SIS.POW.powOfferStates = Nothing
    Private _FK_POW_Offers_RecordTypeID As SIS.POW.powRecordTypes = Nothing
    Private _FK_POW_Offers_TSID As SIS.POW.powTechnicalSpecifications = Nothing
    Public Property ERPStatusID As String
    Public ReadOnly Property ERPStatusNM As String
      Get
        If ERPStatusID <> "" Then
          Return System.Enum.GetName(GetType(enumERPStates), Convert.ToInt32(ERPStatusID))
        End If
        Return ""
      End Get
    End Property

    Public Property ForSupplier() As Boolean
      Get
        Return _ForSupplier
      End Get
      Set(ByVal value As Boolean)
        _ForSupplier = value
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
    Public Property RecordID() As Int32
      Get
        Return _RecordID
      End Get
      Set(ByVal value As Int32)
        _RecordID = value
      End Set
    End Property
    Public Property RecordTypeID() As String
      Get
        Return _RecordTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RecordTypeID = ""
         Else
           _RecordTypeID = value
         End If
      End Set
    End Property
    Public Property RecordRevision() As String
      Get
        Return _RecordRevision
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RecordRevision = ""
         Else
           _RecordRevision = value
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
    Public Property SubmittedBy() As String
      Get
        Return _SubmittedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SubmittedBy = ""
         Else
           _SubmittedBy = value
         End If
      End Set
    End Property
    Public Property SubmittedOn() As String
      Get
        If Not _SubmittedOn = String.Empty Then
          Return Convert.ToDateTime(_SubmittedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _SubmittedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SubmittedOn = ""
         Else
           _SubmittedOn = value
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
    Public Property EvaluatedBy() As String
      Get
        Return _EvaluatedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EvaluatedBy = ""
         Else
           _EvaluatedBy = value
         End If
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
    Public Property TSID() As Int32
      Get
        Return _TSID
      End Get
      Set(ByVal value As Int32)
        _TSID = value
      End Set
    End Property
    Public Property DistributedOn() As String
      Get
        If Not _DistributedOn = String.Empty Then
          Return Convert.ToDateTime(_DistributedOn).ToString("dd/MM/yyyy")
        End If
        Return _DistributedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DistributedOn = ""
         Else
           _DistributedOn = value
         End If
      End Set
    End Property
    Public Property ReceiptID() As String
      Get
        Return _ReceiptID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReceiptID = ""
         Else
           _ReceiptID = value
         End If
      End Set
    End Property
    Public Property ReceiptRevision() As String
      Get
        Return _ReceiptRevision
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReceiptRevision = ""
         Else
           _ReceiptRevision = value
         End If
      End Set
    End Property
    Public Property SubmittedByBuyer() As Boolean
      Get
        Return _SubmittedByBuyer
      End Get
      Set(ByVal value As Boolean)
        _SubmittedByBuyer = value
      End Set
    End Property
    Public Property EValuatedOn() As String
      Get
        If Not _EValuatedOn = String.Empty Then
          Return Convert.ToDateTime(_EValuatedOn).ToString("dd/MM/yyyy")
        End If
        Return _EValuatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EValuatedOn = ""
         Else
           _EValuatedOn = value
         End If
      End Set
    End Property
    Public Property AcknowledgedOn() As String
      Get
        If Not _AcknowledgedOn = String.Empty Then
          Return Convert.ToDateTime(_AcknowledgedOn).ToString("dd/MM/yyyy")
        End If
        Return _AcknowledgedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AcknowledgedOn = ""
         Else
           _AcknowledgedOn = value
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
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Property POW_Enquiries3_EMailSubject() As String
      Get
        Return _POW_Enquiries3_EMailSubject
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_Enquiries3_EMailSubject = ""
         Else
           _POW_Enquiries3_EMailSubject = value
         End If
      End Set
    End Property
    Public Property POW_OfferStates4_Description() As String
      Get
        Return _POW_OfferStates4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_OfferStates4_Description = ""
         Else
           _POW_OfferStates4_Description = value
         End If
      End Set
    End Property
    Public Property POW_RecordTypes5_Description() As String
      Get
        Return _POW_RecordTypes5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_RecordTypes5_Description = ""
         Else
           _POW_RecordTypes5_Description = value
         End If
      End Set
    End Property
    Public Property POW_TechnicalSpecifications6_TSDescription() As String
      Get
        Return _POW_TechnicalSpecifications6_TSDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _POW_TechnicalSpecifications6_TSDescription = ""
         Else
           _POW_TechnicalSpecifications6_TSDescription = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TSID & "|" & _EnquiryID & "|" & _RecordID
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
    Public Class PKpowOffers
      Private _TSID As Int32 = 0
      Private _EnquiryID As Int32 = 0
      Private _RecordID As Int32 = 0
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
      Public Property RecordID() As Int32
        Get
          Return _RecordID
        End Get
        Set(ByVal value As Int32)
          _RecordID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_POW_Offers_EvaluatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_POW_Offers_EvaluatedBy Is Nothing Then
          _FK_POW_Offers_EvaluatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_EvaluatedBy)
        End If
        Return _FK_POW_Offers_EvaluatedBy
      End Get
    End Property
    Public ReadOnly Property FK_POW_Offers_SubmittedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_POW_Offers_SubmittedBy Is Nothing Then
          _FK_POW_Offers_SubmittedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_SubmittedBy)
        End If
        Return _FK_POW_Offers_SubmittedBy
      End Get
    End Property
    Public ReadOnly Property FK_POW_Offers_EnquiryID() As SIS.POW.powEnquiries
      Get
        If _FK_POW_Offers_EnquiryID Is Nothing Then
          _FK_POW_Offers_EnquiryID = SIS.POW.powEnquiries.powEnquiriesGetByID(_TSID, _EnquiryID)
        End If
        Return _FK_POW_Offers_EnquiryID
      End Get
    End Property
    Public ReadOnly Property FK_POW_Offers_StatusID() As SIS.POW.powOfferStates
      Get
        If _FK_POW_Offers_StatusID Is Nothing Then
          _FK_POW_Offers_StatusID = SIS.POW.powOfferStates.powOfferStatesGetByID(_StatusID)
        End If
        Return _FK_POW_Offers_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_POW_Offers_RecordTypeID() As SIS.POW.powRecordTypes
      Get
        If _FK_POW_Offers_RecordTypeID Is Nothing Then
          _FK_POW_Offers_RecordTypeID = SIS.POW.powRecordTypes.powRecordTypesGetByID(_RecordTypeID)
        End If
        Return _FK_POW_Offers_RecordTypeID
      End Get
    End Property
    Public ReadOnly Property FK_POW_Offers_TSID() As SIS.POW.powTechnicalSpecifications
      Get
        If _FK_POW_Offers_TSID Is Nothing Then
          _FK_POW_Offers_TSID = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(_TSID)
        End If
        Return _FK_POW_Offers_TSID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powOffersGetNewRecord() As SIS.POW.powOffers
      Return New SIS.POW.powOffers()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powOffersGetByID(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powOffers
      Dim Results As SIS.POW.powOffers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowOffersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,TSID.ToString.Length, TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnquiryID",SqlDbType.Int,EnquiryID.ToString.Length, EnquiryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID",SqlDbType.Int,RecordID.ToString.Length, RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.POW.powOffers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powOffersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EnquiryID As Int32, ByVal TSID As Int32) As List(Of SIS.POW.powOffers)
      Dim Results As List(Of SIS.POW.powOffers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RecordID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppowOffersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppowOffersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EnquiryID",SqlDbType.Int,10, IIf(EnquiryID = Nothing, 0,EnquiryID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TSID",SqlDbType.Int,10, IIf(TSID = Nothing, 0,TSID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function powOffersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EnquiryID As Int32, ByVal TSID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powOffersGetByID(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32, ByVal Filter_EnquiryID As Int32, ByVal Filter_TSID As Int32) As SIS.POW.powOffers
      Return powOffersGetByID(TSID, EnquiryID, RecordID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function powOffersInsert(ByVal Record As SIS.POW.powOffers) As SIS.POW.powOffers
      Dim _Rec As SIS.POW.powOffers = SIS.POW.powOffers.powOffersGetNewRecord()
      With _Rec
        .RecordTypeID = enumRecordType.Communication
        .RecordRevision = "00"
        .EMailSubject = Record.EMailSubject
        .SubmittedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .SubmittedOn = Now
        .StatusID = enumOfferStates.Created
        .EMailBody = Record.EMailBody
        .EnquiryID = Record.EnquiryID
        .TSID = Record.TSID
        .ForSupplier = False
        .CreatedOn = Now
      End With
      Return SIS.POW.powOffers.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.POW.powOffers) As SIS.POW.powOffers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowOffersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordTypeID",SqlDbType.Int,11, Iif(Record.RecordTypeID= "" ,Convert.DBNull, Record.RecordTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordRevision",SqlDbType.NVarChar,6, Iif(Record.RecordRevision= "" ,Convert.DBNull, Record.RecordRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailSubject",SqlDbType.NVarChar,101, Iif(Record.EMailSubject= "" ,Convert.DBNull, Record.EMailSubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedBy",SqlDbType.NVarChar,9, Iif(Record.SubmittedBy= "" ,Convert.DBNull, Record.SubmittedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedOn",SqlDbType.DateTime,21, Iif(Record.SubmittedOn= "" ,Convert.DBNull, Record.SubmittedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailBody",SqlDbType.NVarChar,4001, Iif(Record.EMailBody= "" ,Convert.DBNull, Record.EMailBody))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluatedBy",SqlDbType.NVarChar,9, Iif(Record.EvaluatedBy= "" ,Convert.DBNull, Record.EvaluatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnquiryID",SqlDbType.Int,11, Record.EnquiryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DistributedOn",SqlDbType.DateTime,21, Iif(Record.DistributedOn= "" ,Convert.DBNull, Record.DistributedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptID",SqlDbType.NVarChar,10, Iif(Record.ReceiptID= "" ,Convert.DBNull, Record.ReceiptID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptRevision",SqlDbType.NVarChar,6, Iif(Record.ReceiptRevision= "" ,Convert.DBNull, Record.ReceiptRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedByBuyer",SqlDbType.Bit,3, Record.SubmittedByBuyer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EValuatedOn",SqlDbType.DateTime,21, Iif(Record.EValuatedOn= "" ,Convert.DBNull, Record.EValuatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AcknowledgedOn",SqlDbType.DateTime,21, Iif(Record.AcknowledgedOn= "" ,Convert.DBNull, Record.AcknowledgedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForSupplier", SqlDbType.Bit, 3, Record.ForSupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPStatusID", SqlDbType.Int, 11, IIf(Record.ERPStatusID = "", Convert.DBNull, Record.ERPStatusID))
          Cmd.Parameters.Add("@Return_TSID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TSID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_EnquiryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_EnquiryID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RecordID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecordID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TSID = Cmd.Parameters("@Return_TSID").Value
          Record.EnquiryID = Cmd.Parameters("@Return_EnquiryID").Value
          Record.RecordID = Cmd.Parameters("@Return_RecordID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function powOffersUpdate(ByVal Record As SIS.POW.powOffers) As SIS.POW.powOffers
      Dim _Rec As SIS.POW.powOffers = SIS.POW.powOffers.powOffersGetByID(Record.TSID, Record.EnquiryID, Record.RecordID)
      With _Rec
        .RecordTypeID = Record.RecordTypeID
        .RecordRevision = Record.RecordRevision
        .EMailSubject = Record.EMailSubject
        .SubmittedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .SubmittedOn = Now
        .StatusID = Record.StatusID
        .EMailBody = Record.EMailBody
      End With
      Return SIS.POW.powOffers.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.POW.powOffers) As SIS.POW.powOffers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowOffersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,11, Record.RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EnquiryID",SqlDbType.Int,11, Record.EnquiryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordTypeID",SqlDbType.Int,11, Iif(Record.RecordTypeID= "" ,Convert.DBNull, Record.RecordTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordRevision",SqlDbType.NVarChar,6, Iif(Record.RecordRevision= "" ,Convert.DBNull, Record.RecordRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailSubject",SqlDbType.NVarChar,101, Iif(Record.EMailSubject= "" ,Convert.DBNull, Record.EMailSubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedBy",SqlDbType.NVarChar,9, Iif(Record.SubmittedBy= "" ,Convert.DBNull, Record.SubmittedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedOn",SqlDbType.DateTime,21, Iif(Record.SubmittedOn= "" ,Convert.DBNull, Record.SubmittedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailBody",SqlDbType.NVarChar,4001, Iif(Record.EMailBody= "" ,Convert.DBNull, Record.EMailBody))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluatedBy",SqlDbType.NVarChar,9, Iif(Record.EvaluatedBy= "" ,Convert.DBNull, Record.EvaluatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnquiryID",SqlDbType.Int,11, Record.EnquiryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,11, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DistributedOn",SqlDbType.DateTime,21, Iif(Record.DistributedOn= "" ,Convert.DBNull, Record.DistributedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptID",SqlDbType.NVarChar,10, Iif(Record.ReceiptID= "" ,Convert.DBNull, Record.ReceiptID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptRevision",SqlDbType.NVarChar,6, Iif(Record.ReceiptRevision= "" ,Convert.DBNull, Record.ReceiptRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedByBuyer",SqlDbType.Bit,3, Record.SubmittedByBuyer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EValuatedOn",SqlDbType.DateTime,21, Iif(Record.EValuatedOn= "" ,Convert.DBNull, Record.EValuatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AcknowledgedOn",SqlDbType.DateTime,21, Iif(Record.AcknowledgedOn= "" ,Convert.DBNull, Record.AcknowledgedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForSupplier", SqlDbType.Bit, 3, Record.ForSupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPStatusID", SqlDbType.Int, 11, IIf(Record.ERPStatusID = "", Convert.DBNull, Record.ERPStatusID))
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
    Public Shared Function powOffersDelete(ByVal Record As SIS.POW.powOffers) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowOffersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TSID",SqlDbType.Int,Record.TSID.ToString.Length, Record.TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EnquiryID",SqlDbType.Int,Record.EnquiryID.ToString.Length, Record.EnquiryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,Record.RecordID.ToString.Length, Record.RecordID)
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
