Imports System.Xml
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Text
Namespace SIS.POW
  Public Class Alerts
    Public Shared Function EnquirySent(ByVal TSID As Integer, ByVal EnquiryID As Integer) As Boolean
      Dim oEnq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(TSID, EnquiryID)
      Dim aErr As New ArrayList
      Dim mRet As String = ""
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        'From Buyer
        If oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.EMailID = String.Empty Then
          aErr.Add(oEnq.FK_POW_Enquiries_TSID.CreatedBy & " " & oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName)
          .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
          .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        Else
          .From = New MailAddress(oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.EMailID.Trim, oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName)
          .CC.Add(New MailAddress(oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.EMailID.Trim, oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName))
        End If
        'To
        Dim aTmp() As String = oEnq.SupplierEMailID.Split(",;".ToCharArray)
        For Each tmp As String In aTmp
          If tmp = String.Empty Then Continue For
          Dim ad As MailAddress = New MailAddress(tmp.Trim)
          If Not .To.Contains(ad) Then .To.Add(ad)
        Next
        aTmp = oEnq.AdditionalEMailIDs.Split(",;".ToCharArray)
        For Each tmp As String In aTmp
          If tmp = String.Empty Then Continue For
          Dim ad As MailAddress = New MailAddress(tmp.Trim)
          If Not .To.Contains(ad) AndAlso Not .CC.Contains(ad) Then .CC.Add(ad)
        Next
        .Subject = oEnq.EMailSubject
        .IsBodyHtml = True
        Dim tmpStr As String = ""
        tmpStr &= "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        tmpStr &= "<head>"
        tmpStr &= "<title></title>"
        tmpStr &= "<style>"
        tmpStr &= "body{padding: 10px auto auto 10px;}"
        tmpStr &= ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        tmpStr &= "table{"
        tmpStr &= "border: solid 1pt black;"
        tmpStr &= "border-collapse:collapse;"
        tmpStr &= "font-family: Tahoma;}"

        tmpStr &= "td{padding-left: 4px;"
        tmpStr &= "border: solid 1pt black;"
        tmpStr &= "font-family: Tahoma;"
        tmpStr &= "font-size: 9px;"
        tmpStr &= "vertical-align:top;}"

        tmpStr &= "</style>"
        tmpStr &= "</head>"
        tmpStr &= "<body>"
        'If aErr.Count > 0 Then
        '  tmpStr &= "<table>"
        '  tmpStr &= "<tr><td style=""color: red""><i><b>"
        '  tmpStr &= "NOTE: E-Mail Alert could not be delivered to following recipient(s), Please update their E-Mail ID in EITL/ERP Application."
        '  tmpStr &= "</b></i></td></tr>"
        '  For Each Err As String In aErr
        '    tmpStr &= "<tr><td color=""red""><i>"
        '    tmpStr &= Err
        '    tmpStr &= "</i></td></tr>"
        '  Next
        '  tmpStr &= "</table>"
        'End If
        '==================================
        tmpStr &= oEnq.EMailBody.Replace(Chr(10), "<br/>").Replace(Chr(13), "<br/>")
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "localhost" Then
          UrlAuthority = "cloud.isgec.co.in"
        End If
        tmpStr &= "<br/>"
        tmpStr &= "<br/>"
        tmpStr &= "<p>"
        tmpStr &= "<a href='http://" & UrlAuthority & "/WebPOW1/bsLogin.aspx?EnqKey=" & oEnq.VendorKey & "'>Click here to submit offer</a>"
        tmpStr &= "</p>"
        '==================================
        If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
          tmpStr &= "<br/>CC-Mail-ID: " & .CC.ToString
          oMsg.CC.Clear()
          tmpStr &= "<br/>TO-Mail-ID: " & .To.ToString
          oMsg.To.Clear()
          tmpStr &= "<br/>FROM-Mail-ID: " & .From.ToString
          oMsg.To.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))
          oMsg.From = New MailAddress("lalit@isgec.co.in", "Lalit Gupta")
        Else
          oMsg.Bcc.Add(New MailAddress("dcrlog@isgec.co.in", "POW Log"))
        End If

        tmpStr &= "</body></html>"
        .Body = tmpStr
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
        Throw New Exception("Error while sending Enquiry")
      End Try
      Return True
    End Function
    Public Shared Function SendAuthentication(ByVal TSID As Integer, ByVal EnquiryID As Integer) As Boolean
      Dim oEnq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(TSID, EnquiryID)
      Dim aErr As New ArrayList
      Dim mRet As String = ""
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        'From Buyer
        If oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.EMailID = String.Empty Then
          aErr.Add(oEnq.FK_POW_Enquiries_TSID.CreatedBy & " " & oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName)
          .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
        Else
          .From = New MailAddress(oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.EMailID.Trim, oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName)
        End If
        'To
        Dim aTmp() As String = oEnq.SupplierEMailID.Split(",;".ToCharArray)
        For Each tmp As String In aTmp
          If tmp = String.Empty Then Continue For
          Dim ad As MailAddress = New MailAddress(tmp.Trim)
          If Not .To.Contains(ad) Then .To.Add(ad)
        Next
        .Subject = "Authentication Details to Submit Offer"
        .IsBodyHtml = True
        Dim tmpStr As String = ""
        tmpStr &= "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        tmpStr &= "<head>"
        tmpStr &= "<title></title>"
        tmpStr &= "<style>"
        tmpStr &= "body{margin: 10px auto auto 60px;}"
        tmpStr &= ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        tmpStr &= "table{"
        tmpStr &= "border: solid 1pt black;"
        tmpStr &= "border-collapse:collapse;"
        tmpStr &= "font-family: Tahoma;}"

        tmpStr &= "td{padding-left: 4px;"
        tmpStr &= "border: solid 1pt black;"
        tmpStr &= "font-family: Tahoma;"
        tmpStr &= "font-size: 9px;"
        tmpStr &= "vertical-align:top;}"

        tmpStr &= "</style>"
        tmpStr &= "</head>"
        tmpStr &= "<body>"
        '==================================
        tmpStr &= "<b>Authentication Details</b>"
        tmpStr &= "<br /><b>URL:</b> http://cloud.isgec.co.in/WebPOW1/bsLogin.aspx"
        tmpStr &= "<br /><b>User ID:</b> " & oEnq.SupplierLoginID
        tmpStr &= "<br /><b>Password:</b> " & SIS.QCM.qcmUsers.qcmUsersGetByID(oEnq.SupplierLoginID).PW
        tmpStr &= "<br/><br/>"
        '==================================
        If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
          tmpStr &= "<br/>CC-Mail-ID: " & .CC.ToString
          oMsg.CC.Clear()
          tmpStr &= "<br/>TO-Mail-ID: " & .To.ToString
          oMsg.To.Clear()
          tmpStr &= "<br/>FROM-Mail-ID: " & .From.ToString
          oMsg.To.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))
          oMsg.From = New MailAddress("lalit@isgec.co.in", "Lalit Gupta")
        Else
          oMsg.Bcc.Add(New MailAddress("dcrlog@isgec.co.in", "POW Log"))
        End If

        tmpStr &= "</body></html>"
        .Body = tmpStr
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
        Throw New Exception("Error while sending Authentication details.")
      End Try
      Return True
    End Function

    Public Shared Function OfferSubmitted(ByVal TSID As Integer, ByVal EnquiryID As Integer, ByVal RecordID As Integer) As Boolean
      Dim oOfr As SIS.POW.powOffers = SIS.POW.powOffers.powOffersGetByID(TSID, EnquiryID, RecordID)
      Dim oEnq As SIS.POW.powEnquiries = oOfr.FK_POW_Offers_EnquiryID
      Dim aErr As New ArrayList
      Dim mRet As String = ""
      Dim ad As MailAddress = Nothing
      Dim aTmp() As String
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        If Not oOfr.SubmittedByBuyer Then
          .From = New MailAddress(oEnq.SupplierFromEMailID.Trim)
          .CC.Add(New MailAddress(oEnq.SupplierFromEMailID.Trim))
          'To Buyer
          If oEnq.FK_POW_Enquiries_CreatedBy.EMailID = "" Then
            aErr.Add("Enquiry Creater: " & oEnq.CreatedBy)
          Else
            ad = New MailAddress(oEnq.FK_POW_Enquiries_CreatedBy.EMailID)
            If Not .To.Contains(ad) Then .To.Add(ad)
          End If
          aTmp = oEnq.AdditionalEMailIDs.Split(",;".ToCharArray)
          For Each tmp As String In aTmp
            If tmp = String.Empty Then Continue For
            ad = New MailAddress(tmp.Trim)
            If Not .To.Contains(ad) AndAlso Not .CC.Contains(ad) Then .To.Add(ad)
          Next
          aTmp = oEnq.SupplierEMailID.Split(",;".ToCharArray)
          For Each tmp As String In aTmp
            If tmp = String.Empty Then Continue For
            ad = New MailAddress(tmp.Trim)
            If Not .To.Contains(ad) AndAlso Not .CC.Contains(ad) Then .CC.Add(ad)
          Next
        Else 'Submitted By Buyer
          If oOfr.FK_POW_Offers_SubmittedBy.EMailID = String.Empty Then
            aErr.Add(oOfr.SubmittedBy & " " & oOfr.FK_POW_Offers_SubmittedBy.UserFullName)
            .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
            .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
          Else
            ad = New MailAddress(oOfr.FK_POW_Offers_SubmittedBy.EMailID.Trim, oOfr.FK_POW_Offers_SubmittedBy.UserFullName)
            .From = ad
            .CC.Add(ad)
          End If
          'To
          aTmp = oEnq.SupplierEMailID.Split(",;".ToCharArray)
          For Each tmp As String In aTmp
            If tmp = String.Empty Then Continue For
            ad = New MailAddress(tmp.Trim)
            If Not .To.Contains(ad) AndAlso Not .CC.Contains(ad) Then .To.Add(ad)
          Next
          aTmp = oEnq.AdditionalEMailIDs.Split(",;".ToCharArray)
          For Each tmp As String In aTmp
            If tmp = String.Empty Then Continue For
            ad = New MailAddress(tmp.Trim)
            If Not .To.Contains(ad) AndAlso Not .CC.Contains(ad) Then .CC.Add(ad)
          Next

        End If
        .Subject = oOfr.EMailSubject
        .IsBodyHtml = True
        Dim tmpStr As String = ""
        tmpStr &= "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        tmpStr &= "<head>"
        tmpStr &= "<title></title>"
        tmpStr &= "<style>"
        tmpStr &= "body{padding: 10px auto auto 10px;}"
        tmpStr &= ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        tmpStr &= "table{"
        tmpStr &= "border: solid 1pt black;"
        tmpStr &= "border-collapse:collapse;"
        tmpStr &= "font-family: Tahoma;}"

        tmpStr &= "td{padding-left: 4px;"
        tmpStr &= "border: solid 1pt black;"
        tmpStr &= "font-family: Tahoma;"
        tmpStr &= "font-size: 9px;"
        tmpStr &= "vertical-align:top;}"

        tmpStr &= "</style>"
        tmpStr &= "</head>"
        tmpStr &= "<body>"
        'If aErr.Count > 0 Then
        '  tmpStr &= "<table>"
        '  tmpStr &= "<tr><td style=""color: red""><i><b>"
        '  tmpStr &= "NOTE: E-Mail Alert could not be delivered to following recipient(s), Please update their E-Mail ID in EITL/ERP Application."
        '  tmpStr &= "</b></i></td></tr>"
        '  For Each Err As String In aErr
        '    tmpStr &= "<tr><td color=""red""><i>"
        '    tmpStr &= Err
        '    tmpStr &= "</i></td></tr>"
        '  Next
        '  tmpStr &= "</table>"
        'End If
        '==================================
        tmpStr &= oOfr.EMailBody.Replace(Chr(10), "<br/>").Replace(Chr(13), "<br/>")
        If oOfr.SubmittedByBuyer Then
          Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
          If UrlAuthority.ToLower <> "localhost" Then
            UrlAuthority = "cloud.isgec.co.in"
          End If
          tmpStr &= "<br/>"
          tmpStr &= "<br/>"
          tmpStr &= "<p>"
          tmpStr &= "<a href='http://" & UrlAuthority & "/WebPOW1/bsLogin.aspx?EnqKey=" & oEnq.VendorKey & "'>Click here to submit offer / Reply</a>"
          tmpStr &= "</p>"

        End If
        '==================================
        If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
          tmpStr &= "<br/>CC-Mail-ID: " & .CC.ToString
          oMsg.CC.Clear()
          tmpStr &= "<br/>TO-Mail-ID: " & .To.ToString
          oMsg.To.Clear()
          tmpStr &= "<br/>FROM-Mail-ID: " & .From.ToString
          oMsg.To.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))
          oMsg.From = New MailAddress("lalit@isgec.co.in", "Lalit Gupta")
        Else
          oMsg.Bcc.Add(New MailAddress("dcrlog@isgec.co.in", "POW Log"))
        End If
        tmpStr &= "</body></html>"
        .Body = tmpStr
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
        Throw New Exception("Error while sending Offer")
      End Try
      Return True
    End Function

    Public Shared Function UnderEvaluation(ByVal tmpOfr As SIS.POW.powOffers) As Boolean
      Dim oEnq As SIS.POW.powEnquiries = SIS.POW.powEnquiries.powEnquiriesGetByID(tmpOfr.TSID, tmpOfr.EnquiryID)
      Dim aErr As New ArrayList
      Dim mRet As String = ""
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        'From Buyer
        If oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.EMailID = String.Empty Then
          aErr.Add(oEnq.FK_POW_Enquiries_TSID.CreatedBy & " " & oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName)
          .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
          .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        Else
          .From = New MailAddress(oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.EMailID.Trim, oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName)
          .CC.Add(New MailAddress(oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.EMailID.Trim, oEnq.FK_POW_Enquiries_TSID.FK_POW_TS_CreatedBy.UserFullName))
        End If
        'To
        Dim aTmp() As String = oEnq.SupplierEMailID.Split(",;".ToCharArray)
        'For Each tmp As String In aTmp
        '  If tmp = String.Empty Then Continue For
        '  Dim ad As MailAddress = New MailAddress(tmp.Trim)
        '  If Not .To.Contains(ad) Then .To.Add(ad)
        'Next
        aTmp = oEnq.AdditionalEMailIDs.Split(",;".ToCharArray)
        For Each tmp As String In aTmp
          If tmp = String.Empty Then Continue For
          Dim ad As MailAddress = New MailAddress(tmp.Trim)
          If Not .To.Contains(ad) AndAlso Not .CC.Contains(ad) Then .To.Add(ad)
        Next
        .Subject = "PreOrder Receipt: " & tmpOfr.ReceiptID & " submitted for Technical Evaluation"
        .IsBodyHtml = True
        Dim tmpStr As String = ""
        tmpStr &= "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        tmpStr &= "<head>"
        tmpStr &= "<title></title>"
        tmpStr &= "<style>"
        tmpStr &= "body{padding: 10px auto auto 10px;}"
        tmpStr &= ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        tmpStr &= "table{"
        tmpStr &= "border: solid 1pt black;"
        tmpStr &= "border-collapse:collapse;"
        tmpStr &= "font-family: Tahoma;}"

        tmpStr &= "td{padding-left: 4px;"
        tmpStr &= "border: solid 1pt black;"
        tmpStr &= "font-family: Tahoma;"
        tmpStr &= "font-size: 9px;"
        tmpStr &= "vertical-align:top;}"

        tmpStr &= "</style>"
        tmpStr &= "</head>"
        tmpStr &= "<body>"
        If aErr.Count > 0 Then
          tmpStr &= "<table>"
          tmpStr &= "<tr><td style=""color: red""><i><b>"
          tmpStr &= "NOTE: E-Mail Alert could not be delivered to following recipient(s), Please update their E-Mail ID in EITL/ERP Application."
          tmpStr &= "</b></i></td></tr>"
          For Each Err As String In aErr
            tmpStr &= "<tr><td color=""red""><i>"
            tmpStr &= Err
            tmpStr &= "</i></td></tr>"
          Next
          tmpStr &= "</table>"
        End If
        '==================================
        tmpStr &= tmpOfr.EMailBody.Replace(Chr(10), "<br/>").Replace(Chr(13), "<br/>")
        '==================================
        If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
          tmpStr &= "<br/>CC-Mail-ID: " & .CC.ToString
          oMsg.CC.Clear()
          tmpStr &= "<br/>TO-Mail-ID: " & .To.ToString
          oMsg.To.Clear()
          tmpStr &= "<br/>FROM-Mail-ID: " & .From.ToString
          oMsg.To.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))
          oMsg.From = New MailAddress("lalit@isgec.co.in", "Lalit Gupta")
        Else
          oMsg.Bcc.Add(New MailAddress("dcrlog@isgec.co.in", "POW Log"))
        End If

        tmpStr &= "</body></html>"
        .Body = tmpStr
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
        Throw New Exception("Error while sending Enquiry")
      End Try
      Return True
    End Function

  End Class
End Namespace
