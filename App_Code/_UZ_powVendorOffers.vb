Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  Partial Public Class powVendorOffers
    Public Shadows ReadOnly Property M_details As String
      Get
        Dim mRet As String = "<ul>"
        mRet &= "<li>" & RecordID & "</li>"
        mRet &= "<li>" & aspnet_Users2_UserFullName & "</li>"
        mRet &= "<li>" & EMailSubject & "</li>"
        mRet &= "<li>" & SubmittedOn & "</li>"
        mRet &= "</ul>"
        Return mRet
      End Get
    End Property
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      If StatusID = enumOfferStates.Created Then
        mRet = True
      End If
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = GetEditable()
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
    Public Shadows ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function DeleteWF(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powVendorOffers
      Dim Results As SIS.POW.powVendorOffers = powVendorOffersGetByID(TSID, EnquiryID, RecordID)
      Return Results
    End Function
    Public ReadOnly Property ReviseWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ReviseWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ReviseWF(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powVendorOffers
      Dim Results As SIS.POW.powVendorOffers = powVendorOffersGetByID(TSID, EnquiryID, RecordID)
      Return Results
    End Function
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function InitiateWF(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powVendorOffers
      Dim Results As SIS.POW.powVendorOffers = powVendorOffersGetByID(TSID, EnquiryID, RecordID)
      With Results
        .StatusID = enumOfferStates.Submitted
        .SubmittedBy = HttpContext.Current.Session("LoginID")
        .SubmittedOn = Now
      End With
      Results = SIS.POW.powVendorOffers.UpdateData(Results)
      '================
      SIS.POW.Alerts.OfferSubmitted(Results.TSID, Results.EnquiryID, Results.RecordID)
      '================
      Return Results
    End Function
    Public Shared Function UZ_powVendorOffersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EnquiryID As Int32, ByVal TSID As Int32) As List(Of SIS.POW.powVendorOffers)
      Dim Results As List(Of SIS.POW.powVendorOffers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RecordID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppow_LG_VendorOffersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppow_LG_VendorOffersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EnquiryID", SqlDbType.Int, 10, IIf(EnquiryID = Nothing, 0, EnquiryID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TSID",SqlDbType.Int,10, IIf(TSID = Nothing, 0,TSID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.POW.powVendorOffers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powVendorOffers(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_powVendorOffersInsert(ByVal Record As SIS.POW.powVendorOffers) As SIS.POW.powVendorOffers
      Dim _Result As SIS.POW.powVendorOffers = powVendorOffersInsert(Record)
      Dim oEnq As SIS.POW.powEnquiries = Record.FK_POW_Offers_EnquiryID
      If Record.SelectedFromEMailID <> "As Given Below" Then
        oEnq.SupplierFromEMailID = Record.SelectedFromEMailID
      Else
        oEnq.SupplierFromEMailID = Record.FromEMailID
      End If
      SIS.POW.powEnquiries.UpdateData(oEnq)
      Return _Result
    End Function
    Public Shared Function UZ_powVendorOffersUpdate(ByVal Record As SIS.POW.powVendorOffers) As SIS.POW.powVendorOffers
      Dim _Result As SIS.POW.powVendorOffers = powVendorOffersUpdate(Record)
      Dim oEnq As SIS.POW.powEnquiries = Record.FK_POW_Offers_EnquiryID
      If Record.SelectedFromEMailID <> "As Given Below" Then
        oEnq.SupplierFromEMailID = Record.SelectedFromEMailID
      Else
        oEnq.SupplierFromEMailID = Record.FromEMailID
      End If
      SIS.POW.powEnquiries.UpdateData(oEnq)
      Return _Result
    End Function
    Public Shared Function UZ_powVendorOffersDelete(ByVal Record As SIS.POW.powVendorOffers) As Int32
      'Dim _Result As Integer = powVendorOffersDelete(Record)
      'Return _Result
      Return 0
    End Function
  End Class
End Namespace
