Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.Security.Principal
Imports System.Security
Partial Class LGDefault
  Inherits System.Web.UI.Page
  Public Property abcd As String = ""

  Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
    SIS.POW.powTechnicalSpecifications.SyncCTData("")
  End Sub

  Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If HttpContext.Current.Session("LoginID") = "0340" Then
      cmdUpdate.Visible = True
    End If
  End Sub
End Class
