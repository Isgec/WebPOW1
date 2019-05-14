Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  <DataObject()> _
  Partial Public Class powVendorOffers
    Inherits SIS.POW.powOffers
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powVendorOffersGetNewRecord() As SIS.POW.powVendorOffers
      Return New SIS.POW.powVendorOffers()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powVendorOffersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EnquiryID As Int32, ByVal TSID As Int32) As List(Of SIS.POW.powVendorOffers)
      Dim Results As List(Of SIS.POW.powVendorOffers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RecordID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppowVendorOffersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppowVendorOffersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EnquiryID",SqlDbType.Int,10, IIf(EnquiryID = Nothing, 0,EnquiryID))
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
    Public Shared Function powVendorOffersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EnquiryID As Int32, ByVal TSID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powVendorOffersGetByID(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32) As SIS.POW.powVendorOffers
      Dim Results As SIS.POW.powVendorOffers = Nothing
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
            Results = New SIS.POW.powVendorOffers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powVendorOffersGetByID(ByVal TSID As Int32, ByVal EnquiryID As Int32, ByVal RecordID As Int32, ByVal Filter_EnquiryID As Int32, ByVal Filter_TSID As Int32) As SIS.POW.powVendorOffers
      Dim Results As SIS.POW.powVendorOffers = SIS.POW.powVendorOffers.powVendorOffersGetByID(TSID, EnquiryID, RecordID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function powVendorOffersInsert(ByVal Record As SIS.POW.powVendorOffers) As SIS.POW.powVendorOffers
      Dim _Rec As SIS.POW.powVendorOffers = SIS.POW.powVendorOffers.powVendorOffersGetNewRecord()
      With _Rec
        .RecordTypeID = enumRecordType.Communication
        .RecordRevision = "00"
        .EMailSubject = Record.EMailSubject
        .SubmittedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .StatusID = enumOfferStates.Created
        .EMailBody = Record.EMailBody
        .EnquiryID = Record.EnquiryID
        .TSID = Record.TSID
      End With
      Return SIS.POW.powVendorOffers.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function powVendorOffersUpdate(ByVal Record As SIS.POW.powVendorOffers) As SIS.POW.powVendorOffers
      Dim _Rec As SIS.POW.powVendorOffers = SIS.POW.powVendorOffers.powVendorOffersGetByID(Record.TSID, Record.EnquiryID, Record.RecordID)
      With _Rec
        .EMailSubject = Record.EMailSubject
        .SubmittedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .EMailBody = Record.EMailBody
      End With
      Return SIS.POW.powVendorOffers.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
