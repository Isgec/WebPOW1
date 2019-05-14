Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  Partial Public Class powVendorEnquiries
    Public Shadows ReadOnly Property M_details As String
      Get
        Dim mRet As String = "<ul>"
        mRet &= "<li>" & EnquiryID & "</li>"
        mRet &= "<li>" & aspnet_Users5_UserFullName & "</li>"
        mRet &= "<li>" & EMailSubject & "</li>"
        mRet &= "<li>" & SentOn & "</li>"
        mRet &= "</ul>"
        Return mRet
      End Get
    End Property

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
    Public ReadOnly Property SelectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SelectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SelectWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powVendorEnquiries
      Dim Results As SIS.POW.powVendorEnquiries = powVendorEnquiriesGetByID(TSID, EnquiryID)
      Return Results
    End Function
    Public ReadOnly Property SendTechnicalOfferWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SendTechnicalOfferWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SendTechnicalOfferWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powVendorEnquiries
      Dim Results As SIS.POW.powVendorEnquiries = powVendorEnquiriesGetByID(TSID, EnquiryID)
      Return Results
    End Function
    Public ReadOnly Property SendCommercialOfferWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SendCommercialOfferWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SendCommercialOfferWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powVendorEnquiries
      Dim Results As SIS.POW.powVendorEnquiries = powVendorEnquiriesGetByID(TSID, EnquiryID)
      Return Results
    End Function
    Public ReadOnly Property SendOtherInformationWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SendOtherInformationWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SendOtherInformationWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powVendorEnquiries
      Dim Results As SIS.POW.powVendorEnquiries = powVendorEnquiriesGetByID(TSID, EnquiryID)
      Return Results
    End Function
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
    Public Shared Shadows Function ApproveWF(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powVendorEnquiries
      Dim Results As SIS.POW.powVendorEnquiries = powVendorEnquiriesGetByID(TSID, EnquiryID)
      Return Results
    End Function
    Public Shared Function UZ_powVendorEnquiriesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.POW.powVendorEnquiries)
      Dim Results As List(Of SIS.POW.powVendorEnquiries) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SentOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppow_LG_VendorEnquiriesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppow_LG_VendorEnquiriesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierLoginID",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.POW.powVendorEnquiries)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powVendorEnquiries(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_powVendorEnquiriesUpdate(ByVal Record As SIS.POW.powVendorEnquiries) As SIS.POW.powVendorEnquiries
      Dim _Result As SIS.POW.powVendorEnquiries = powVendorEnquiriesUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
