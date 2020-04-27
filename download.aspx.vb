Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports Ionic
Imports Ionic.Zip
Imports ejiVault
Partial Class docdownload
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim Value As String = ""
    If Request.QueryString("stmtl") IsNot Nothing Then
      Value = Request.QueryString("stmtl")
      DownloadSAll(Value)
    End If

  End Sub
  Private Sub DownloadSAll(ByVal pk As String)
    Dim aPK() As String = pk.Split("|".ToCharArray)
    Dim docHndl As String = aPK(0)
    Dim docIndex As String = aPK(1)
    Dim libPath As String = ""
    Dim filePath As String = ""
    Dim fileName As String = docIndex & ".zip"

    Dim tmpFilesToDelete As New ArrayList
    Response.Clear()
    Dim TmtlDocs As List(Of EJI.ediAFile) = EJI.ediAFile.GetFilesByHandleIndex(docHndl, docIndex)
    If TmtlDocs.Count > 0 Then
      Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(fileName)
      Using zip As New ZipFile
        zip.CompressionLevel = Zlib.CompressionLevel.Level5
        For Each rDoc As EJI.ediAFile In TmtlDocs
          If rDoc IsNot Nothing Then
            Dim rLib As EJI.ediALib = EJI.ediALib.GetLibraryByID(rDoc.t_lbcd)
            If Not EJI.DBCommon.IsLocalISGECVault Then
              EJI.ediALib.ConnectISGECVault(rLib)
            End If

            libPath = rLib.LibraryPath
            filePath = libPath & "\" & rDoc.t_dcid
            fileName = rDoc.t_fnam
            If IO.File.Exists(filePath) Then
              Dim tmpFile As String = Server.MapPath("~/..") & "App_Temp/" & fileName
              IO.File.Copy(filePath, tmpFile)
              zip.AddFile(tmpFile, "Files")
              tmpFilesToDelete.Add(tmpFile)
            End If
          End If
        Next
        zip.Save(Response.OutputStream)
      End Using
    End If
    For Each str As String In tmpFilesToDelete
      IO.File.Delete(str)
    Next
    If Not EJI.DBCommon.IsLocalISGECVault Then
      EJI.ediALib.DisconnectISGECVault()
    End If
    Response.End()
  End Sub
End Class
