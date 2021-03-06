﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Partial Class CreateRFQ
  Inherits System.Web.UI.Page
  Public Property RedirectURL As String
    Get
      If ViewState("RedirectURL") IsNot Nothing Then
        Return CType(ViewState("RedirectURL"), String)
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("RedirectURL", value)
    End Set
  End Property
  Public Property UserID As String
    Get
      If ViewState("UserID") IsNot Nothing Then
        Return CType(ViewState("UserID"), String)
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("UserID", value)
    End Set
  End Property

  Private IndentNo As String = ""
  Private Comp As String = ""
  Private Sub CreateRFQ_Load(sender As Object, e As EventArgs) Handles Me.PreRender
    Dim aTmp() As String
    Dim cntI As Integer = 0
    Dim Err As String = ""
    Dim IndentNo As String = ""
    Dim LineNo As String = ""
    Dim UserID As String = ""
    Dim oTS As SIS.POW.powTechnicalSpecifications = Nothing
    If Request.QueryString("userid") IsNot Nothing Then
      UserID = Request.QueryString("userid")
      UserID = IIf(UserID.Length < 4, Right("0000" & UserID, 4), UserID)
    End If
    HttpContext.Current.Session("LoginID") = UserID
    While Request.QueryString("rfq" & cntI) IsNot Nothing
      IndentNo = ""
      LineNo = ""
      aTmp = Request.QueryString("rfq" & cntI).Split("|".ToCharArray)
      Try
        IndentNo = aTmp(0)
        LineNo = aTmp(1)
      Catch ex As Exception
      End Try
      Try
        oTS = SIS.POW.powTechnicalSpecifications.Import(IndentNo, LineNo, oTS, False)
      Catch ex As Exception
        If Err = "" Then Err = IndentNo Else Err &= ", " & IndentNo
      End Try
      cntI += 1
    End While
    If oTS IsNot Nothing Then
      '======Update CT======
      If CType(ConfigurationManager.AppSettings("UpdateCT"), Boolean) Then
        Dim Indents As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", oTS.TSID)
        Dim Comp As String = SIS.RFQ.rfqGeneral.GetERPCompanyByIndentNo(Indents(0).IndentNo)
        SIS.POW.powTechnicalSpecifications.Insert168(Indents(0), Comp)  'By First Indent 
        For Each Indent As SIS.POW.powTSIndents In Indents
          Dim Docs As List(Of SIS.POW.powTSIndentDocuments) = SIS.POW.powTSIndentDocuments.UZ_powTSIndentDocumentsSelectList(0, 9999, "", False, "", Indent.SerialNo, Indent.TSID)
          For Each doc As SIS.POW.powTSIndentDocuments In Docs
            Try
              SIS.POW.powTechnicalSpecifications.Insert167(doc, Comp)
            Catch ex As Exception
            End Try
          Next
        Next
      End If
      '======================
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        Dim RedirectURL As String = "~/POW_Main/App_Edit/EF_powTechnicalSpecifications.aspx?TSID=" & oTS.TSID
        Response.Redirect(RedirectURL)
      End If
    Else
      ShowMsg("RFQ Workflow NOT created.")
    End If
  End Sub
  Private Sub ShowMsg(ByVal str As String)
    msg.InnerHtml = "<h2>" & str & "</h2>"
  End Sub
End Class
