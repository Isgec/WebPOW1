Partial Class RP_powVendorEnquiries
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim TSID As Int32 = CType(aVal(0), Int32)
    Dim EnquiryID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.POW.powVendorEnquiries = SIS.POW.powVendorEnquiries.powVendorEnquiriesGetByID(TSID, EnquiryID)
    Dim oTblpowVendorEnquiries As New Table
    oTblpowVendorEnquiries.Width = 1000
    oTblpowVendorEnquiries.GridLines = GridLines.Both
    oTblpowVendorEnquiries.Style.Add("margin-top", "15px")
    oTblpowVendorEnquiries.Style.Add("margin-left", "10px")
    Dim oColpowVendorEnquiries As TableCell = Nothing
    Dim oRowpowVendorEnquiries As TableRow = Nothing
    oRowpowVendorEnquiries = New TableRow
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = "Enquiry ID"
    oColpowVendorEnquiries.Font.Bold = True
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.EnquiryID
    oColpowVendorEnquiries.Style.Add("text-align", "right")
    oColpowVendorEnquiries.ColumnSpan = "2"
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = "TSID"
    oColpowVendorEnquiries.Font.Bold = True
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.TSID
    oColpowVendorEnquiries.Style.Add("text-align", "right")
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.POW_TechnicalSpecifications2_TSDescription
    oColpowVendorEnquiries.Style.Add("text-align", "right")
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oTblpowVendorEnquiries.Rows.Add(oRowpowVendorEnquiries)
    oRowpowVendorEnquiries = New TableRow
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = "Supplier"
    oColpowVendorEnquiries.Font.Bold = True
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.SupplierID
    oColpowVendorEnquiries.Style.Add("text-align", "left")
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.VR_BusinessPartner3_BPName
    oColpowVendorEnquiries.Style.Add("text-align", "left")
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = "Supplier Name"
    oColpowVendorEnquiries.Font.Bold = True
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.SupplierName
    oColpowVendorEnquiries.Style.Add("text-align", "left")
    oColpowVendorEnquiries.ColumnSpan = "2"
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oTblpowVendorEnquiries.Rows.Add(oRowpowVendorEnquiries)
    oRowpowVendorEnquiries = New TableRow
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = "E-Mail Subject"
    oColpowVendorEnquiries.Font.Bold = True
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.EMailSubject
    oColpowVendorEnquiries.Style.Add("text-align", "left")
    oColpowVendorEnquiries.ColumnSpan = "5"
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oTblpowVendorEnquiries.Rows.Add(oRowpowVendorEnquiries)
    oRowpowVendorEnquiries = New TableRow
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = "E Mail Body"
    oColpowVendorEnquiries.Font.Bold = True
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.EMailBody
    oColpowVendorEnquiries.Style.Add("text-align", "left")
    oColpowVendorEnquiries.ColumnSpan = "5"
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oTblpowVendorEnquiries.Rows.Add(oRowpowVendorEnquiries)
    oRowpowVendorEnquiries = New TableRow
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = "Sent On"
    oColpowVendorEnquiries.Font.Bold = True
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.SentOn
    oColpowVendorEnquiries.Style.Add("text-align", "center")
    oColpowVendorEnquiries.ColumnSpan = "2"
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = "Status"
    oColpowVendorEnquiries.Font.Bold = True
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.StatusID
    oColpowVendorEnquiries.Style.Add("text-align", "right")
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oColpowVendorEnquiries = New TableCell
    oColpowVendorEnquiries.Text = oVar.POW_EnquiryStates1_Description
    oColpowVendorEnquiries.Style.Add("text-align", "right")
    oRowpowVendorEnquiries.Cells.Add(oColpowVendorEnquiries)
    oTblpowVendorEnquiries.Rows.Add(oRowpowVendorEnquiries)
    form1.Controls.Add(oTblpowVendorEnquiries)
    Dim oTblpowOffers As Table = Nothing
    Dim oRowpowOffers As TableRow = Nothing
    Dim oColpowOffers As TableCell = Nothing
    Dim opowOfferss As List(Of SIS.POW.powOffers) = SIS.POW.powOffers.UZ_powOffersSelectList(0, 999, "", False, "", oVar.TSID, oVar.EnquiryID)
    If opowOfferss.Count > 0 Then
      Dim oTblhpowOffers As Table = New Table
      oTblhpowOffers.Width = 1000
      oTblhpowOffers.Style.Add("margin-top", "15px")
      oTblhpowOffers.Style.Add("margin-left", "10px")
      oTblhpowOffers.Style.Add("margin-right", "10px")
      Dim oRowhpowOffers As TableRow = New TableRow
      Dim oColhpowOffers As TableCell = New TableCell
      oColhpowOffers.Font.Bold = True
      oColhpowOffers.Font.Underline = True
      oColhpowOffers.Font.Size = 10
      oColhpowOffers.CssClass = "grpHD"
      oColhpowOffers.Text = "Offers"
      oRowhpowOffers.Cells.Add(oColhpowOffers)
      oTblhpowOffers.Rows.Add(oRowhpowOffers)
      form1.Controls.Add(oTblhpowOffers)
      oTblpowOffers = New Table
      oTblpowOffers.Width = 1000
      oTblpowOffers.GridLines = GridLines.Both
      oTblpowOffers.Style.Add("margin-left", "10px")
      oTblpowOffers.Style.Add("margin-right", "10px")
      oRowpowOffers = New TableRow
      oColpowOffers = New TableCell
      oColpowOffers.Text = "Record ID"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "right")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oColpowOffers = New TableCell
      oColpowOffers.Text = "Record Type"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "right")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oColpowOffers = New TableCell
      oColpowOffers.Text = "Revision"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "left")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oColpowOffers = New TableCell
      oColpowOffers.Text = "E-Mail Subject"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "left")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oColpowOffers = New TableCell
      oColpowOffers.Text = "Submitted By"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "left")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oColpowOffers = New TableCell
      oColpowOffers.Text = "Submitted On"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "center")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oColpowOffers = New TableCell
      oColpowOffers.Text = "IDMS Receipt"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "left")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oColpowOffers = New TableCell
      oColpowOffers.Text = "IDMS Revision"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "left")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oColpowOffers = New TableCell
      oColpowOffers.Text = "Status"
      oColpowOffers.Font.Bold = True
      oColpowOffers.CssClass = "colHD"
      oColpowOffers.Style.Add("text-align", "right")
      oRowpowOffers.Cells.Add(oColpowOffers)
      oTblpowOffers.Rows.Add(oRowpowOffers)
      For Each opowOffers As SIS.POW.powOffers In opowOfferss
        oRowpowOffers = New TableRow
        oColpowOffers = New TableCell
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Text = opowOffers.RecordID
        oColpowOffers.Style.Add("text-align", "right")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oColpowOffers = New TableCell
        oColpowOffers.Text = opowOffers.POW_RecordTypes5_Description
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Style.Add("text-align", "right")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oColpowOffers = New TableCell
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Text = opowOffers.RecordRevision
        oColpowOffers.Style.Add("text-align", "left")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oColpowOffers = New TableCell
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Text = opowOffers.EMailSubject
        oColpowOffers.Style.Add("text-align", "left")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oColpowOffers = New TableCell
        oColpowOffers.Text = opowOffers.aspnet_Users2_UserFullName
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Style.Add("text-align", "left")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oColpowOffers = New TableCell
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Text = opowOffers.SubmittedOn
        oColpowOffers.Style.Add("text-align", "center")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oColpowOffers = New TableCell
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Text = opowOffers.ReceiptID
        oColpowOffers.Style.Add("text-align", "left")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oColpowOffers = New TableCell
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Text = opowOffers.ReceiptRevision
        oColpowOffers.Style.Add("text-align", "left")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oColpowOffers = New TableCell
        oColpowOffers.Text = opowOffers.POW_OfferStates4_Description
        oColpowOffers.CssClass = "rowHD"
        oColpowOffers.Style.Add("text-align", "right")
        oRowpowOffers.Cells.Add(oColpowOffers)
        oTblpowOffers.Rows.Add(oRowpowOffers)
      Next
      form1.Controls.Add(oTblpowOffers)
    End If
  End Sub
End Class
