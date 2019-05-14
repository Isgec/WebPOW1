Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  Partial Public Class powTSIndentDocuments
    Public ReadOnly Property M_details As String
      Get
        Dim mRet As String = "<ul>"
        mRet &= "<li>" & DocNo & "</li>"
        mRet &= "<li>" & DocumentID & "</li>"
        mRet &= "<li>" & DocumentRevision & "</li>"
        mRet &= "</ul>"
        Return mRet
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function GetCountByTSID(ByVal TSID As Integer) As Integer
      Dim Results As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(count(docno),0) from pow_tsIndentDocuments where tsid=" & TSID
          Con.Open()
          Results = Cmd.ExecuteScalar
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_powTSIndentDocumentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal TSID As Int32) As List(Of SIS.POW.powTSIndentDocuments)
      Dim Results As List(Of SIS.POW.powTSIndentDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DocumentID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppow_LG_TSIndentDocumentsSelectListSearch"
            Cmd.CommandText = "sppowTSIndentDocumentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppow_LG_TSIndentDocumentsSelectListFilteres"
            Cmd.CommandText = "sppowTSIndentDocumentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TSID", SqlDbType.Int, 10, IIf(TSID = Nothing, 0, TSID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function UZ_powTSIndentDocumentsInsert(ByVal Record As SIS.POW.powTSIndentDocuments) As SIS.POW.powTSIndentDocuments
      Dim _Result As SIS.POW.powTSIndentDocuments = powTSIndentDocumentsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_powTSIndentDocumentsUpdate(ByVal Record As SIS.POW.powTSIndentDocuments) As SIS.POW.powTSIndentDocuments
      Dim _Result As SIS.POW.powTSIndentDocuments = powTSIndentDocumentsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_powTSIndentDocumentsDelete(ByVal Record As SIS.POW.powTSIndentDocuments) As Integer
      Dim _Result as Integer = powTSIndentDocumentsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_DocNo"), TextBox).Text = ""
        CType(.FindControl("F_DocumentID"), TextBox).Text = ""
        CType(.FindControl("F_DocumentRevision"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_TSID"), TextBox).Text = ""
        CType(.FindControl("F_TSID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
