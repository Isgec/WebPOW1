Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  <DataObject()> _
  Partial Public Class powTSChangeBuyer
    Inherits SIS.POW.powTechnicalSpecifications
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSChangeBuyerGetNewRecord() As SIS.POW.powTSChangeBuyer
      Return New SIS.POW.powTSChangeBuyer()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSChangeBuyerSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal StatusID As Int32, ByVal CreatedBy As String) As List(Of SIS.POW.powTSChangeBuyer)
      Dim Results As List(Of SIS.POW.powTSChangeBuyer) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CreatedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppowTSChangeBuyerSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppowTSChangeBuyerSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.POW.powTSChangeBuyer)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.POW.powTSChangeBuyer(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function powTSChangeBuyerSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal StatusID As Int32, ByVal CreatedBy As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSChangeBuyerGetByID(ByVal TSID As Int32) As SIS.POW.powTSChangeBuyer
      Dim Results As SIS.POW.powTSChangeBuyer = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppowTechnicalSpecificationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TSID",SqlDbType.Int,TSID.ToString.Length, TSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.POW.powTSChangeBuyer(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function powTSChangeBuyerGetByID(ByVal TSID As Int32, ByVal Filter_StatusID As Int32, ByVal Filter_CreatedBy As String) As SIS.POW.powTSChangeBuyer
      Dim Results As SIS.POW.powTSChangeBuyer = SIS.POW.powTSChangeBuyer.powTSChangeBuyerGetByID(TSID)
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
