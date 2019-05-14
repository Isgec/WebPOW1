Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  <DataObject()> _
  Partial Public Class powVendorEnquiries
    Inherits SIS.POW.powEnquiries
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powVendorEnquiriesGetNewRecord() As SIS.POW.powVendorEnquiries
      Return New SIS.POW.powVendorEnquiries()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powVendorEnquiriesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.POW.powVendorEnquiries)
      Dim Results As List(Of SIS.POW.powVendorEnquiries) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SentOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppowVendorEnquiriesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppowVendorEnquiriesSelectListFilteres"
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
    Public Shared Function powVendorEnquiriesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powVendorEnquiriesGetByID(ByVal TSID As Int32, ByVal EnquiryID As Int32) As SIS.POW.powVendorEnquiries
      Dim Results As SIS.POW.powVendorEnquiries = Nothing
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
            Results = New SIS.POW.powVendorEnquiries(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function powVendorEnquiriesUpdate(ByVal Record As SIS.POW.powVendorEnquiries) As SIS.POW.powVendorEnquiries
      Dim _Rec As SIS.POW.powVendorEnquiries = SIS.POW.powVendorEnquiries.powVendorEnquiriesGetByID(Record.TSID, Record.EnquiryID)
      With _Rec
        .SupplierID = Record.SupplierID
        .SupplierName = Record.SupplierName
        .SupplierEMailID = Record.SupplierEMailID
        .EMailSubject = Record.EMailSubject
        .EMailBody = Record.EMailBody
        .AdditionalEMailIDs = Record.AdditionalEMailIDs
        .StatusID = Record.StatusID
        .SentOn = Record.SentOn
      End With
      Return SIS.POW.powVendorEnquiries.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
