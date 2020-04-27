Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports ejiVault
Partial Class filedownload
    Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim Value As String = ""
    If Request.QueryString("ath") IsNot Nothing Then
      Value = Request.QueryString("ath")
      DownloadSDoc(Value)
    End If
  End Sub

  Private Sub DownloadSDoc(ByVal dKey As String)
    Dim libPath As String = ""
    Dim filePath As String = ""
    Dim fileName As String = ""
    Response.Clear()
    Dim rDoc As ejiVault.EJI.ediAFile = ejiVault.EJI.ediAFile.GetFileByRecordID(dKey)
    If rDoc IsNot Nothing Then
      Dim rLib As ejiVault.EJI.ediALib = ejiVault.EJI.ediALib.GetLibraryByID(rDoc.t_lbcd)
      If rLib IsNot Nothing Then
        If Not EJI.DBCommon.IsLocalISGECVault Then
          EJI.ediALib.ConnectISGECVault(rLib)
        End If
        libPath = rLib.LibraryPath
        filePath = libPath & "\" & rDoc.t_dcid
        fileName = rDoc.t_fnam
        Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
        Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(fileName)
        If IO.File.Exists(filePath) Then
          Response.WriteFile(filePath)
        End If
        If Not EJI.DBCommon.IsLocalISGECVault Then
          EJI.ediALib.DisconnectISGECVault()
        End If
      End If
    End If
    Response.End()
  End Sub

End Class
