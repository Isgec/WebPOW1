Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail

Namespace SIS.NT
  Partial Public Class ntNotes
    Private _ReminderTo As String = ""
    Private _ReminderDateTime As String = ""
    Public Property ReminderTo() As String
      Get
        Return _ReminderTo
      End Get
      Set(ByVal value As String)
        _ReminderTo = value
      End Set
    End Property
    Public Property ReminderDateTime() As String
      Get
        If Not _ReminderDateTime = String.Empty Then
          Return Convert.ToDateTime(_ReminderDateTime).ToString("dd/MM/yyyy")
        End If
        Return _ReminderDateTime
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" Then
          _ReminderDateTime = ""
        Else
          _ReminderDateTime = value
        End If
      End Set
    End Property
    Public Property dt_ReminderDateTime() As String
      Get
        If Not _ReminderDateTime = String.Empty Then
          Return Convert.ToDateTime(_ReminderDateTime).ToString("yyyy-MM-dd")
        End If
        Return ""
      End Get
      Set(ByVal value As String)
        If value = "01/01/0001 00:00:00" Then
          _ReminderDateTime = ""
        Else
          _ReminderDateTime = value
        End If
      End Set
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
    Public Shared Function UZ_ntNotesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.NT.ntNotes)
      Dim Results As List(Of SIS.NT.ntNotes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnt_LG_NotesSelectListSearch"
            Cmd.CommandText = "spntNotesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnt_LG_NotesSelectListFilteres"
            Cmd.CommandText = "spntNotesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NT.ntNotes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NT.ntNotes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_ntNotesInsert(ByVal Record As SIS.NT.ntNotes) As SIS.NT.ntNotes
      Dim _Result As SIS.NT.ntNotes = ntNotesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_ntNotesUpdate(ByVal Record As SIS.NT.ntNotes) As SIS.NT.ntNotes
      Dim _Result As SIS.NT.ntNotes = ntNotesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_ntNotesDelete(ByVal Record As SIS.NT.ntNotes) As Integer
      Dim _Result As Integer = ntNotesDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_Notes_RunningNo"), TextBox).Text = 0
          CType(.FindControl("F_NotesId"), TextBox).Text = ""
          CType(.FindControl("F_NotesHandle"), TextBox).Text = ""
          CType(.FindControl("F_IndexValue"), TextBox).Text = ""
          CType(.FindControl("F_Title"), TextBox).Text = ""
          CType(.FindControl("F_Description"), TextBox).Text = ""
          CType(.FindControl("F_UserId"), TextBox).Text = ""
          CType(.FindControl("F_UserId_Display"), Label).Text = ""
          CType(.FindControl("F_Created_Date"), TextBox).Text = ""
          CType(.FindControl("F_SendEmailTo"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function AddRequestFiles(ByVal Request As HttpRequest, ByVal PrimaryKey As String) As Boolean
      Dim L_ScriptTimeOut As Integer = 0
      Dim L_SessionTimeOut As Integer = HttpContext.Current.Session.Timeout
      HttpContext.Current.Session.Timeout = 60
      L_ScriptTimeOut = HttpContext.Current.Server.ScriptTimeout
      HttpContext.Current.Server.ScriptTimeout = 3600
      Try
        Dim LibraryPath As String = ""
        Dim LibraryID As String = ""
        Dim tmpL As SIS.EDI.ediALib = SIS.EDI.ediALib.GetActiveLibrary
        LibraryPath = "D:\" & tmpL.t_path
        If Request.Url.Authority.ToLower = "localhost" Then
          LibraryPath = "D:\Temp"
        End If
        LibraryID = tmpL.t_lbcd

        Dim oFiles As HttpFileCollection = Request.Files
        For i As Integer = 0 To Request.Files.Count - 1
          Dim pfile As HttpPostedFile
          pfile = Request.Files.Item(i)
          If pfile.ContentLength <= 0 Then Continue For
          Dim LibFileName As String = ""
          LibFileName = SIS.EDI.ediASeries.GetNextFileName
          Dim LibFile As String = LibraryPath & "\\" & LibFileName
          pfile.SaveAs(LibFile)
          Try
            If IO.File.Exists(LibFile) Then
              Dim tmp As New SIS.EDI.ediAFile
              With tmp
                .t_dcid = LibFileName
                .t_hndl = "JOOMLA_NOTES"
                .t_indx = PrimaryKey
                .t_prcd = "By Mobile App"
                .t_fnam = pfile.FileName
                .t_lbcd = LibraryID
                .t_atby = HttpContext.Current.Session("LoginID")
                .t_aton = Now
                .t_Refcntd = 0
                .t_Refcntu = 0
              End With
              tmp = SIS.EDI.ediAFile.InsertData(tmp)
            End If
          Catch ex As Exception
          End Try
        Next
      Catch ex As Exception
        HttpContext.Current.Session.Timeout = L_SessionTimeOut
        HttpContext.Current.Server.ScriptTimeout = L_ScriptTimeOut
        Throw New Exception(ex.Message)
      End Try
      HttpContext.Current.Session.Timeout = L_SessionTimeOut
      HttpContext.Current.Server.ScriptTimeout = L_ScriptTimeOut
      Return True
    End Function
    Public Shared Function GetNextNotesNo(ByRef Prefix As String, ByRef NextNo As Integer) As String
      Dim tmp As SIS.EDI.ediASeries = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 * from Note_DocumentSeries	where Active = 'Y'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Prefix = Reader("Series")
            NextNo = Reader("RunningNo")
          End If
          Reader.Close()
        End Using
      End Using
      NextNo += 1
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "update Note_DocumentSeries set RunningNo = " & NextNo & " where Series = '" & Prefix & "'"
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Prefix & NextNo.ToString
    End Function
    Public Shared Sub SendEMail(ByVal nt As SIS.NT.ntNotes)
      Dim AErr As New ArrayList
      Dim bs As New MailAddress("baansupport@isgec.co.in", "BaaN Support")
      Dim ad As MailAddress = Nothing
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        Try
          Dim aIDs() As String = nt.SendEmailTo.Split(",; ".ToCharArray)
          For Each tmp As String In aIDs
            tmp = tmp.Trim
            .To.Add(New MailAddress(tmp, tmp))
          Next
        Catch ex As Exception
          AErr.Add("Err: Send Mail To " & nt.SendEmailTo & " Notes ID: " & nt.NotesId & " Detail :" & ex.Message)
          .To.Add(bs)
        End Try
        Try
          ad = New MailAddress(nt.FK_Note_Notes_UserID.EMailID, nt.FK_Note_Notes_UserID.UserFullName)
          .From = ad
          .CC.Add(ad)
        Catch ex As Exception
          AErr.Add("Err: From " & nt.UserId & " Notes ID: " & nt.NotesId & " Detail :" & ex.Message)
          .From = bs
          If Not .CC.Contains(bs) Then
            .CC.Add(bs)
          End If
        End Try
        .Subject = nt.Title
        .IsBodyHtml = True
        Dim Header As String = ""
        Header &= "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header &= "<head>"
        Header &= "<title></title>"
        Header &= "<style>"
        Header &= "table{"

        Header &= "border: solid 1pt black;"
        Header &= "border-collapse:collapse;"
        Header &= "font-family: Tahoma;}"

        Header &= "td{"
        Header &= "border: solid 1pt black;"
        Header &= "font-family: Tahoma;"
        Header &= "font-size: 12px;"
        Header &= "padding: 2px 2px 4px 4px;"
        Header &= "vertical-align:middle;}"

        Header &= "a{"
        Header &= "color: white;}"
        Header &= "a:hover{"
        Header &= "color: hotpink;}"

        Header &= "</style>"
        Header &= "</head>"
        Header &= "<body>"
        If AErr.Count > 0 Then
          Header &= "<br/>"
          Header &= "<br/>"
          Header &= "<table>"
          Header &= "<tr><td style=""color: red""><i><b>"
          Header &= "NOTE: Error during composing E-Mail."
          Header &= "</b></i></td></tr>"
          For Each Err As String In AErr
            Header &= "<tr><td color=""red""><i>"
            Header &= Err
            Header &= "</i></td></tr>"
          Next
          Header &= "</table>"
        End If
        Dim CloudLink As String = "http://cloud.isgec.co.in/Attachment/Notes.aspx?handle=P_PROJECTACTIVITY_200"
        Dim LocalLink As String = "http://192.9.200.146/Attachment/Notes.aspx?handle=P_PROJECTACTIVITY_200"
        Dim Index As String = nt.IndexValue
        Dim User As String = nt.UserId
        Dim canEdit As String = "n"
        CloudLink &= "&Index=" & Index & "&user=" & User & "&ed=" & canEdit
        LocalLink &= "&Index=" & Index & "&user=" & User & "&ed=" & canEdit

        'Header &= "<table style='margin-left:10px;width:1000px;'>"
        'Header &= "<tr><td style='background-color:DodgerBlue;text-align:center;color:white;font-size:16px;height:30px;verticle-align:middle;'><b>"
        'Header &= "<a href='" & CloudLink & "'>Open Notes [From Internet]</a>"
        'Header &= "</b></td>"
        'Header &= "<td style='background-color:DodgerBlue;text-align:center;color:white;font-size:16px;height:30px;verticle-align:middle;'><b>"
        'Header &= "<a href='" & LocalLink & "'>Open Notes [From Office LAN]</a>"
        'Header &= "</b></td></tr>"
        'Header &= "</table>"
        Header &= "<br/>"
        Header &= "<br/>"
        Header &= "<table style='margin-left:10px;width:1000px;'>"
        Header &= "<tr><td><p>"
        Header &= nt.Description.ToString().Replace("\n", "<br />")
        Header &= "</p></td></tr>"
        Header &= "</table>"
        Header &= "<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />This mail has been triggered to draw your attention on the respective ERP/Joomla module. Please login to respective module to see further details and file attachments"
        Header &= "</body></html>"

        .Body = Header
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
      End Try

    End Sub
  End Class
End Namespace
