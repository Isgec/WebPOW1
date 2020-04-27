Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports ejiVault
Namespace SIS.EDI
  <DataObject()>
  Partial Public Class ediAFile
    Private Shared _RecordCount As Integer
    Public Shared Property Comp As String = "200"
    Public Property t_drid As String = ""
    Public Property t_dcid As String = ""
    Public Property t_hndl As String = ""
    Public Property t_indx As String = ""
    Public Property t_prcd As String = ""
    Public Property t_fnam As String = ""
    Public Property t_lbcd As String = ""
    Public Property t_atby As String = ""
    Private _t_aton As String = ""
    Public Property t_Refcntd As Int32 = 0
    Public Property t_Refcntu As Int32 = 0
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/App_Downloads/athDownload.aspx?ath=" & t_drid & "', 'win" & t_drid & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
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
    Public Property t_aton() As String
      Get
        If Not _t_aton = String.Empty Then
          Return Convert.ToDateTime(_t_aton).ToString("dd/MM/yyyy")
        End If
        Return _t_aton
      End Get
      Set(ByVal value As String)
        _t_aton = value
      End Set
    End Property
    Public Shared Function GetNextFileName(Optional ByVal Comp As String = "200") As String
      Return EJI.ediASeries.GetNextFileID
    End Function
    Public Shared Function ediAFileGetByHandleIndex(ByVal t_hndl As String, ByVal t_indx As String, Optional ByVal Comp As String = "200") As SIS.EDI.ediAFile
      Dim Results As SIS.EDI.ediAFile = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select top 1 * from ttcisg132" & Comp & " where t_hndl='" & t_hndl & "' and t_indx='" & t_indx & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.EDI.ediAFile(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ediAFileGetAllByHandleIndex(ByVal t_hndl As String, ByVal t_indx As String, Optional ByVal Comp As String = "200") As List(Of SIS.EDI.ediAFile)
      Dim Results As New List(Of SIS.EDI.ediAFile)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from ttcisg132" & Comp & " where t_hndl='" & t_hndl & "' and t_indx='" & t_indx & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.EDI.ediAFile(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetEJI(x As SIS.EDI.ediAFile) As EJI.ediAFile
      Dim y As New EJI.ediAFile
      With y
        .t_atby = x.t_atby
        .t_aton = x.t_aton
        .t_dcid = x.t_dcid
        .t_drid = x.t_drid
        .t_fnam = x.t_fnam
        .t_hndl = x.t_hndl
        .t_indx = x.t_indx
        .t_lbcd = x.t_lbcd
        .t_prcd = x.t_prcd
        .t_Refcntd = x.t_Refcntd
        .t_Refcntu = x.t_Refcntu
      End With
      Return y
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.EDI.ediAFile, Optional ByVal Comp As String = "200") As SIS.EDI.ediAFile
      With Record
        .t_drid = EJI.ediASeries.GetNextRecordID
        .t_prcd = "EJIMAIN"
      End With
      Dim x As EJI.ediAFile = GetEJI(Record)
      EJI.ediAFile.InsertData(x)
      Return Record
    End Function
    Public Shared Function ediAFileSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_hndl As String, ByVal t_indx As String) As List(Of SIS.EDI.ediAFile)
      If CType(ConfigurationManager.AppSettings("RunLocally"), Boolean) Then Return New List(Of SIS.EDI.ediAFile)()
      Dim Results As List(Of SIS.EDI.ediAFile) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from ttcisg132" & Comp & " where t_hndl='" & t_hndl & "' and t_indx='" & t_indx & "'"
          _RecordCount = -1
          Results = New List(Of SIS.EDI.ediAFile)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EDI.ediAFile(Reader))
          End While
          Reader.Close()
          _RecordCount = Results.Count
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ediAFileSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_hndl As String, ByVal t_indx As String) As Integer
      Return _RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ediAFileGetByID(ByVal t_drid As String) As SIS.EDI.ediAFile
      Dim Results As SIS.EDI.ediAFile = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select top 1 * from ttcisg132" & Comp & " where t_drid='" & t_drid & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.EDI.ediAFile(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ediAFileGetByID(ByVal t_drid As String, ByVal Filter_t_hndl As String, ByVal Filter_t_indx As String) As SIS.EDI.ediAFile
      Return ediAFileGetByID(t_drid)
    End Function
    Public Shared Function ediAFileCopy(ByVal s_t_hndl As String, ByVal s_t_indx As String, ByVal t_t_hndl As String, ByVal t_t_indx As String) As List(Of SIS.EDI.ediAFile)
      If CType(ConfigurationManager.AppSettings("RunLocally"), Boolean) Then Return New List(Of SIS.EDI.ediAFile)()
      ejiVault.EJI.ediAFile.FileCopy(s_t_hndl, s_t_indx, t_t_hndl, t_t_indx, HttpContext.Current.Session("LoginID"))
      Dim Results As New List(Of SIS.EDI.ediAFile)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from ttcisg132" & Comp & " where t_hndl='" & t_t_hndl & "' and t_indx='" & t_t_indx & "'"
          _RecordCount = -1
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EDI.ediAFile(Reader))
          End While
          Reader.Close()
          _RecordCount = Results.Count
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ediAFileCopy(ByVal t_drid As String, ByVal t_t_hndl As String, ByVal t_t_indx As String) As SIS.EDI.ediAFile
      If CType(ConfigurationManager.AppSettings("RunLocally"), Boolean) Then Return New SIS.EDI.ediAFile
      Dim x As EJI.ediAFile = EJI.ediAFile.RecordCopy(t_drid, t_t_hndl, t_t_indx, HttpContext.Current.Session("LoginID"))
      Dim Results As SIS.EDI.ediAFile = ediAFileGetByID(x.t_drid)
      Return Results
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
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal t_drid As String, Optional ByVal Process As String = "") As SIS.EDI.ediAFile
      If CType(ConfigurationManager.AppSettings("RunLocally"), Boolean) Then Return New SIS.EDI.ediAFile
      Dim Results As SIS.EDI.ediAFile = ediAFileGetByID(t_drid)
      EJI.ediAFile.FileDelete(t_drid)

      Return Results
    End Function
    Public ReadOnly Property DownloadWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DownloadWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DownloadWF(ByVal t_drid As String) As SIS.EDI.ediAFile
      Dim Results As SIS.EDI.ediAFile = ediAFileGetByID(t_drid)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property PrimaryKey As String
      Get
        Return t_drid
      End Get
    End Property
    Public Shared Function DeleteByHandleIndex(ByVal t_hndl As String, ByVal t_indx As String, Optional ByVal Comp As String = "200") As Integer
      If CType(ConfigurationManager.AppSettings("RunLocally"), Boolean) Then Return 0
      Dim xs As List(Of EJI.ediAFile) = EJI.ediAFile.GetFilesByHandleIndex(t_hndl, t_indx)
      For Each x As EJI.ediAFile In xs
        EJI.ediAFile.FileDelete(x.t_drid)
      Next
      Return 1
    End Function
    Public Shared Function InitiateWF(ByVal t_drid As String) As SIS.EDI.ediAFile
      Dim Results As SIS.EDI.ediAFile = ediAFileGetByID(t_drid)
      Return Results
    End Function
    Public Shared Function UploadFiles(ByVal oRequest As HttpRequest, ByVal AthHandle As String, ByVal AthIndex As String, Optional ByVal CreatedBy As String = "", Optional ByVal AthProcess As String = "") As List(Of EJI.ediAFile)
      Dim mRet As New List(Of EJI.ediAFile)
      If oRequest.Files.Count > 0 Then
        Dim LibraryID As String = ""
        Dim LibPath As String = ""
        Dim tmp As EJI.ediALib = EJI.ediALib.GetActiveLibrary
        LibPath = tmp.LibraryPath
        LibraryID = tmp.t_lbcd
        If Not EJI.DBCommon.IsLocalISGECVault Then
          EJI.ediALib.ConnectISGECVault(tmp)
        End If
        Dim tmpFilesToDelete As New ArrayList

        For I As Integer = 0 To oRequest.Files.Count - 1
          Dim fu As HttpPostedFile = oRequest.Files(I)
          If fu.ContentLength <= 0 Then Continue For
          If fu.FileName = "" Then Continue For
          Dim tmpPath As String = HttpContext.Current.Server.MapPath("~/../App_Temp")
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          fu.SaveAs(tmpFile)
          tmpFilesToDelete.Add(tmpFile)

          Dim tmpVault As EJI.ediAFile = New EJI.ediAFile
          Dim LibPDFFile As String = ""
          With tmpVault
            LibPDFFile = EJI.ediASeries.GetNextFileID
            .t_drid = EJI.ediASeries.GetNextRecordID
            .t_dcid = LibPDFFile
            .t_hndl = AthHandle
            .t_indx = AthIndex
            .t_prcd = "EJIMAIN"
            .t_fnam = IO.Path.GetFileName(fu.FileName)
            .t_lbcd = LibraryID
            .t_atby = IIf(CreatedBy = "", HttpContext.Current.Session("LoginID"), CreatedBy)
            .t_aton = Now
            .t_Refcntd = 0
            .t_Refcntu = 0
          End With
          tmpVault = EJI.ediAFile.InsertData(tmpVault)
          Try
            If IO.File.Exists(LibPath & "\" & LibPDFFile) Then
              IO.File.Delete(LibPath & "\" & LibPDFFile)
            End If
            IO.File.Move(tmpFile, LibPath & "\" & LibPDFFile)
          Catch ex As Exception
          End Try
          mRet.Add(tmpVault)
        Next
        'Move command is used, Below code not required
        'For Each str As String In tmpFilesToDelete
        '  IO.File.Delete(str)
        'Next
        If Not EJI.DBCommon.IsLocalISGECVault Then
          EJI.ediALib.DisconnectISGECVault()
        End If
      End If
      Return mRet
    End Function
  End Class
End Namespace
