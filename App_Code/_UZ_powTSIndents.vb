Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.POW
  Partial Public Class powTSIndents
    Public ReadOnly Property M_details As String
      Get
        Dim mRet As String = "<ul>"
        mRet &= "<li>" & IndentNo & "</li>"
        mRet &= "<li>" & IndentLine & "</li>"
        mRet &= "<li>" & LotItem & "</li>"
        mRet &= "<li>" & ProjectID & "</li>"
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
    Public Shared Function UZ_powTSIndentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TSID As Int32) As List(Of SIS.POW.powTSIndents)
      Dim Results As List(Of SIS.POW.powTSIndents) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "IndentNo"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppow_LG_TSIndentsSelectListSearch"
            Cmd.CommandText = "sppowTSIndentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppow_LG_TSIndentsSelectListFilteres"
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
    Public Shared Function UZ_powTSIndentsInsert(ByVal Record As SIS.POW.powTSIndents) As SIS.POW.powTSIndents
      Dim _Result As SIS.POW.powTSIndents = powTSIndentsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_powTSIndentsUpdate(ByVal Record As SIS.POW.powTSIndents) As SIS.POW.powTSIndents
      Dim _Result As SIS.POW.powTSIndents = powTSIndentsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_powTSIndentsDelete(ByVal Record As SIS.POW.powTSIndents) As Integer
      Dim _Result as Integer = powTSIndentsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_IndentNo"), TextBox).Text = ""
        CType(.FindControl("F_IndentLine"), TextBox).Text = 0
        CType(.FindControl("F_LotItem"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_ElementID"), TextBox).Text = ""
        CType(.FindControl("F_ElementID_Display"), Label).Text = ""
        CType(.FindControl("F_IndenterID"), TextBox).Text = ""
        CType(.FindControl("F_IndenterID_Display"), Label).Text = ""
        CType(.FindControl("F_TSID"), TextBox).Text = ""
        CType(.FindControl("F_TSID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
