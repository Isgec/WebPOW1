Partial Class RP_powTechnicalSpecifications
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim TSID As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.POW.powTechnicalSpecifications = SIS.POW.powTechnicalSpecifications.powTechnicalSpecificationsGetByID(TSID)
    Dim oTblpowTechnicalSpecifications As New Table
    oTblpowTechnicalSpecifications.Width = 1000
    oTblpowTechnicalSpecifications.GridLines = GridLines.Both
    oTblpowTechnicalSpecifications.Style.Add("margin-top", "15px")
    oTblpowTechnicalSpecifications.Style.Add("margin-left", "10px")
    Dim oColpowTechnicalSpecifications As TableCell = Nothing
    Dim oRowpowTechnicalSpecifications As TableRow = Nothing
    oRowpowTechnicalSpecifications = New TableRow
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = "TSID"
    oColpowTechnicalSpecifications.Font.Bold = True
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.TSID
    oColpowTechnicalSpecifications.Style.Add("text-align", "right")
    oColpowTechnicalSpecifications.ColumnSpan = "2"
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = "Status"
    oColpowTechnicalSpecifications.Font.Bold = True
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.StatusID
    oColpowTechnicalSpecifications.Style.Add("text-align", "right")
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.POW_TSStates2_Description
    oColpowTechnicalSpecifications.Style.Add("text-align", "right")
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oTblpowTechnicalSpecifications.Rows.Add(oRowpowTechnicalSpecifications)
    oRowpowTechnicalSpecifications = New TableRow
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = "TS Description"
    oColpowTechnicalSpecifications.Font.Bold = True
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.TSDescription
    oColpowTechnicalSpecifications.Style.Add("text-align", "left")
    oColpowTechnicalSpecifications.ColumnSpan = "5"
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oTblpowTechnicalSpecifications.Rows.Add(oRowpowTechnicalSpecifications)
    oRowpowTechnicalSpecifications = New TableRow
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = "Created By"
    oColpowTechnicalSpecifications.Font.Bold = True
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.CreatedBy
    oColpowTechnicalSpecifications.Style.Add("text-align", "left")
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.aspnet_Users1_UserFullName
    oColpowTechnicalSpecifications.Style.Add("text-align", "left")
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = "Created On"
    oColpowTechnicalSpecifications.Font.Bold = True
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.CreatedOn
    oColpowTechnicalSpecifications.Style.Add("text-align", "center")
    oColpowTechnicalSpecifications.ColumnSpan = "2"
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oTblpowTechnicalSpecifications.Rows.Add(oRowpowTechnicalSpecifications)
    oRowpowTechnicalSpecifications = New TableRow
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = "Additional E-MailIDs"
    oColpowTechnicalSpecifications.Font.Bold = True
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.AdditionalEMailIDs
    oColpowTechnicalSpecifications.Style.Add("text-align", "left")
    oColpowTechnicalSpecifications.ColumnSpan = "2"
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = "TS Type"
    oColpowTechnicalSpecifications.Font.Bold = True
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.TSTypeID
    oColpowTechnicalSpecifications.Style.Add("text-align", "right")
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oColpowTechnicalSpecifications = New TableCell
    oColpowTechnicalSpecifications.Text = oVar.POW_TSTypes3_Description
    oColpowTechnicalSpecifications.Style.Add("text-align", "right")
    oRowpowTechnicalSpecifications.Cells.Add(oColpowTechnicalSpecifications)
    oTblpowTechnicalSpecifications.Rows.Add(oRowpowTechnicalSpecifications)
    form1.Controls.Add(oTblpowTechnicalSpecifications)
    Dim oTblpowTSIndents As Table = Nothing
    Dim oRowpowTSIndents As TableRow = Nothing
    Dim oColpowTSIndents As TableCell = Nothing
    Dim opowTSIndentss As List(Of SIS.POW.powTSIndents) = SIS.POW.powTSIndents.UZ_powTSIndentsSelectList(0, 999, "", False, "", oVar.TSID)
    If opowTSIndentss.Count > 0 Then
      Dim oTblhpowTSIndents As Table = New Table
      oTblhpowTSIndents.Width = 1000
      oTblhpowTSIndents.Style.Add("margin-top", "15px")
      oTblhpowTSIndents.Style.Add("margin-left", "10px")
      oTblhpowTSIndents.Style.Add("margin-right", "10px")
      Dim oRowhpowTSIndents As TableRow = New TableRow
      Dim oColhpowTSIndents As TableCell = New TableCell
      oColhpowTSIndents.Font.Bold = True
      oColhpowTSIndents.Font.Underline = True
      oColhpowTSIndents.Font.Size = 10
      oColhpowTSIndents.CssClass = "grpHD"
      oColhpowTSIndents.Text = "TS Indents"
      oRowhpowTSIndents.Cells.Add(oColhpowTSIndents)
      oTblhpowTSIndents.Rows.Add(oRowhpowTSIndents)
      form1.Controls.Add(oTblhpowTSIndents)
      oTblpowTSIndents = New Table
      oTblpowTSIndents.Width = 1000
      oTblpowTSIndents.GridLines = GridLines.Both
      oTblpowTSIndents.Style.Add("margin-left", "10px")
      oTblpowTSIndents.Style.Add("margin-right", "10px")
      oRowpowTSIndents = New TableRow
      oColpowTSIndents = New TableCell
      oColpowTSIndents.Text = "Serial No"
      oColpowTSIndents.Font.Bold = True
      oColpowTSIndents.CssClass = "colHD"
      oColpowTSIndents.Style.Add("text-align", "right")
      oRowpowTSIndents.Cells.Add(oColpowTSIndents)
      oColpowTSIndents = New TableCell
      oColpowTSIndents.Text = "Indent No"
      oColpowTSIndents.Font.Bold = True
      oColpowTSIndents.CssClass = "colHD"
      oColpowTSIndents.Style.Add("text-align", "left")
      oRowpowTSIndents.Cells.Add(oColpowTSIndents)
      oColpowTSIndents = New TableCell
      oColpowTSIndents.Text = "Indent Line"
      oColpowTSIndents.Font.Bold = True
      oColpowTSIndents.CssClass = "colHD"
      oColpowTSIndents.Style.Add("text-align", "right")
      oRowpowTSIndents.Cells.Add(oColpowTSIndents)
      oColpowTSIndents = New TableCell
      oColpowTSIndents.Text = "LotItem"
      oColpowTSIndents.Font.Bold = True
      oColpowTSIndents.CssClass = "colHD"
      oColpowTSIndents.Style.Add("text-align", "left")
      oRowpowTSIndents.Cells.Add(oColpowTSIndents)
      oColpowTSIndents = New TableCell
      oColpowTSIndents.Text = "Project"
      oColpowTSIndents.Font.Bold = True
      oColpowTSIndents.CssClass = "colHD"
      oColpowTSIndents.Style.Add("text-align", "left")
      oRowpowTSIndents.Cells.Add(oColpowTSIndents)
      oColpowTSIndents = New TableCell
      oColpowTSIndents.Text = "Element"
      oColpowTSIndents.Font.Bold = True
      oColpowTSIndents.CssClass = "colHD"
      oColpowTSIndents.Style.Add("text-align", "left")
      oRowpowTSIndents.Cells.Add(oColpowTSIndents)
      oColpowTSIndents = New TableCell
      oColpowTSIndents.Text = "Indenter"
      oColpowTSIndents.Font.Bold = True
      oColpowTSIndents.CssClass = "colHD"
      oColpowTSIndents.Style.Add("text-align", "left")
      oRowpowTSIndents.Cells.Add(oColpowTSIndents)
      oTblpowTSIndents.Rows.Add(oRowpowTSIndents)
      For Each opowTSIndents As SIS.POW.powTSIndents In opowTSIndentss
        oRowpowTSIndents = New TableRow
        oColpowTSIndents = New TableCell
        oColpowTSIndents.CssClass = "rowHD"
        oColpowTSIndents.Text = opowTSIndents.SerialNo
        oColpowTSIndents.Style.Add("text-align", "right")
        oRowpowTSIndents.Cells.Add(oColpowTSIndents)
        oColpowTSIndents = New TableCell
        oColpowTSIndents.CssClass = "rowHD"
        oColpowTSIndents.Text = opowTSIndents.IndentNo
        oColpowTSIndents.Style.Add("text-align", "left")
        oRowpowTSIndents.Cells.Add(oColpowTSIndents)
        oColpowTSIndents = New TableCell
        oColpowTSIndents.CssClass = "rowHD"
        oColpowTSIndents.Text = opowTSIndents.IndentLine
        oColpowTSIndents.Style.Add("text-align", "right")
        oRowpowTSIndents.Cells.Add(oColpowTSIndents)
        oColpowTSIndents = New TableCell
        oColpowTSIndents.CssClass = "rowHD"
        oColpowTSIndents.Text = opowTSIndents.LotItem
        oColpowTSIndents.Style.Add("text-align", "left")
        oRowpowTSIndents.Cells.Add(oColpowTSIndents)
        oColpowTSIndents = New TableCell
        oColpowTSIndents.Text = opowTSIndents.IDM_Projects2_Description
        oColpowTSIndents.CssClass = "rowHD"
        oColpowTSIndents.Style.Add("text-align", "left")
        oRowpowTSIndents.Cells.Add(oColpowTSIndents)
        oColpowTSIndents = New TableCell
        oColpowTSIndents.Text = opowTSIndents.IDM_WBS3_Description
        oColpowTSIndents.CssClass = "rowHD"
        oColpowTSIndents.Style.Add("text-align", "left")
        oRowpowTSIndents.Cells.Add(oColpowTSIndents)
        oColpowTSIndents = New TableCell
        oColpowTSIndents.Text = opowTSIndents.aspnet_Users1_UserFullName
        oColpowTSIndents.CssClass = "rowHD"
        oColpowTSIndents.Style.Add("text-align", "left")
        oRowpowTSIndents.Cells.Add(oColpowTSIndents)
        oTblpowTSIndents.Rows.Add(oRowpowTSIndents)
        oRowpowTSIndents = New TableRow
        oColpowTSIndents = New TableCell
        oColpowTSIndents.ColumnSpan = oTblpowTSIndents.Rows(0).Cells.Count
        oRowpowTSIndents.Cells.Add(oColpowTSIndents)
        Dim oTblpowTSIndentDocuments As Table = Nothing
        Dim oRowpowTSIndentDocuments As TableRow = Nothing
        Dim oColpowTSIndentDocuments As TableCell = Nothing
        Dim opowTSIndentDocumentss As List(Of SIS.POW.powTSIndentDocuments) = SIS.POW.powTSIndentDocuments.UZ_powTSIndentDocumentsSelectList(0, 999, "", False, "", opowTSIndents.TSID, opowTSIndents.SerialNo)
        If opowTSIndentDocumentss.Count > 0 Then
          Dim oTblhpowTSIndentDocuments As Table = New Table
          oTblhpowTSIndentDocuments.Width = 980
          oTblhpowTSIndentDocuments.Style.Add("margin-top", "15px")
          oTblhpowTSIndentDocuments.Style.Add("margin-left", "10px")
          oTblhpowTSIndentDocuments.Style.Add("margin-right", "10px")
          Dim oRowhpowTSIndentDocuments As TableRow = New TableRow
          Dim oColhpowTSIndentDocuments As TableCell = New TableCell
          oColhpowTSIndentDocuments.Font.Bold = True
          oColhpowTSIndentDocuments.Font.Underline = True
          oColhpowTSIndentDocuments.Font.Size = 10
          oColhpowTSIndentDocuments.CssClass = "grpHD"
          oColhpowTSIndentDocuments.Text = "Indent Documents"
          oRowhpowTSIndentDocuments.Cells.Add(oColhpowTSIndentDocuments)
          oTblhpowTSIndentDocuments.Rows.Add(oRowhpowTSIndentDocuments)
          oColpowTSIndents.Controls.Add(oTblhpowTSIndentDocuments)
          oTblpowTSIndentDocuments = New Table
          oTblpowTSIndentDocuments.Width = 980
          oTblpowTSIndentDocuments.GridLines = GridLines.Both
          oTblpowTSIndentDocuments.Style.Add("margin-left", "10px")
          oTblpowTSIndentDocuments.Style.Add("margin-right", "10px")
          oRowpowTSIndentDocuments = New TableRow
          oColpowTSIndentDocuments = New TableCell
          oColpowTSIndentDocuments.Text = "Doc No"
          oColpowTSIndentDocuments.Font.Bold = True
          oColpowTSIndentDocuments.CssClass = "colHD"
          oColpowTSIndentDocuments.Style.Add("text-align", "right")
          oRowpowTSIndentDocuments.Cells.Add(oColpowTSIndentDocuments)
          oColpowTSIndentDocuments = New TableCell
          oColpowTSIndentDocuments.Text = "Document ID"
          oColpowTSIndentDocuments.Font.Bold = True
          oColpowTSIndentDocuments.CssClass = "colHD"
          oColpowTSIndentDocuments.Style.Add("text-align", "left")
          oRowpowTSIndentDocuments.Cells.Add(oColpowTSIndentDocuments)
          oColpowTSIndentDocuments = New TableCell
          oColpowTSIndentDocuments.Text = "Revision"
          oColpowTSIndentDocuments.Font.Bold = True
          oColpowTSIndentDocuments.CssClass = "colHD"
          oColpowTSIndentDocuments.Style.Add("text-align", "left")
          oRowpowTSIndentDocuments.Cells.Add(oColpowTSIndentDocuments)
          oTblpowTSIndentDocuments.Rows.Add(oRowpowTSIndentDocuments)
          For Each opowTSIndentDocuments As SIS.POW.powTSIndentDocuments In opowTSIndentDocumentss
            oRowpowTSIndentDocuments = New TableRow
            oColpowTSIndentDocuments = New TableCell
            oColpowTSIndentDocuments.CssClass = "rowHD"
            oColpowTSIndentDocuments.Text = opowTSIndentDocuments.DocNo
            oColpowTSIndentDocuments.Style.Add("text-align", "right")
            oRowpowTSIndentDocuments.Cells.Add(oColpowTSIndentDocuments)
            oColpowTSIndentDocuments = New TableCell
            oColpowTSIndentDocuments.CssClass = "rowHD"
            oColpowTSIndentDocuments.Text = opowTSIndentDocuments.DocumentID
            oColpowTSIndentDocuments.Style.Add("text-align", "left")
            oRowpowTSIndentDocuments.Cells.Add(oColpowTSIndentDocuments)
            oColpowTSIndentDocuments = New TableCell
            oColpowTSIndentDocuments.CssClass = "rowHD"
            oColpowTSIndentDocuments.Text = opowTSIndentDocuments.DocumentRevision
            oColpowTSIndentDocuments.Style.Add("text-align", "left")
            oRowpowTSIndentDocuments.Cells.Add(oColpowTSIndentDocuments)
            oTblpowTSIndentDocuments.Rows.Add(oRowpowTSIndentDocuments)
          Next
          oColpowTSIndents.Controls.Add(oTblpowTSIndentDocuments)
          oTblpowTSIndents.Rows.Add(oRowpowTSIndents)
        End If
      Next
      form1.Controls.Add(oTblpowTSIndents)
    End If
    Dim oTblpowEnquiries As Table = Nothing
    Dim oRowpowEnquiries As TableRow = Nothing
    Dim oColpowEnquiries As TableCell = Nothing
    Dim opowEnquiriess As List(Of SIS.POW.powEnquiries) = SIS.POW.powEnquiries.UZ_powEnquiriesSelectList(0, 999, "", False, "", oVar.TSID)
    If opowEnquiriess.Count > 0 Then
      Dim oTblhpowEnquiries As Table = New Table
      oTblhpowEnquiries.Width = 1000
      oTblhpowEnquiries.Style.Add("margin-top", "15px")
      oTblhpowEnquiries.Style.Add("margin-left", "10px")
      oTblhpowEnquiries.Style.Add("margin-right", "10px")
      Dim oRowhpowEnquiries As TableRow = New TableRow
      Dim oColhpowEnquiries As TableCell = New TableCell
      oColhpowEnquiries.Font.Bold = True
      oColhpowEnquiries.Font.Underline = True
      oColhpowEnquiries.Font.Size = 10
      oColhpowEnquiries.CssClass = "grpHD"
      oColhpowEnquiries.Text = "Enquiries"
      oRowhpowEnquiries.Cells.Add(oColhpowEnquiries)
      oTblhpowEnquiries.Rows.Add(oRowhpowEnquiries)
      form1.Controls.Add(oTblhpowEnquiries)
      oTblpowEnquiries = New Table
      oTblpowEnquiries.Width = 1000
      oTblpowEnquiries.GridLines = GridLines.Both
      oTblpowEnquiries.Style.Add("margin-left", "10px")
      oTblpowEnquiries.Style.Add("margin-right", "10px")
      oRowpowEnquiries = New TableRow
      oColpowEnquiries = New TableCell
      oColpowEnquiries.Text = "Enquiry ID"
      oColpowEnquiries.Font.Bold = True
      oColpowEnquiries.CssClass = "colHD"
      oColpowEnquiries.Style.Add("text-align", "right")
      oRowpowEnquiries.Cells.Add(oColpowEnquiries)
      oColpowEnquiries = New TableCell
      oColpowEnquiries.Text = "Supplier"
      oColpowEnquiries.Font.Bold = True
      oColpowEnquiries.CssClass = "colHD"
      oColpowEnquiries.Style.Add("text-align", "left")
      oRowpowEnquiries.Cells.Add(oColpowEnquiries)
      oColpowEnquiries = New TableCell
      oColpowEnquiries.Text = "Supplier Name"
      oColpowEnquiries.Font.Bold = True
      oColpowEnquiries.CssClass = "colHD"
      oColpowEnquiries.Style.Add("text-align", "left")
      oRowpowEnquiries.Cells.Add(oColpowEnquiries)
      oColpowEnquiries = New TableCell
      oColpowEnquiries.Text = "E-Mail Subject"
      oColpowEnquiries.Font.Bold = True
      oColpowEnquiries.CssClass = "colHD"
      oColpowEnquiries.Style.Add("text-align", "left")
      oRowpowEnquiries.Cells.Add(oColpowEnquiries)
      oColpowEnquiries = New TableCell
      oColpowEnquiries.Text = "Status"
      oColpowEnquiries.Font.Bold = True
      oColpowEnquiries.CssClass = "colHD"
      oColpowEnquiries.Style.Add("text-align", "right")
      oRowpowEnquiries.Cells.Add(oColpowEnquiries)
      oColpowEnquiries = New TableCell
      oColpowEnquiries.Text = "Sent On"
      oColpowEnquiries.Font.Bold = True
      oColpowEnquiries.CssClass = "colHD"
      oColpowEnquiries.Style.Add("text-align", "center")
      oRowpowEnquiries.Cells.Add(oColpowEnquiries)
      oTblpowEnquiries.Rows.Add(oRowpowEnquiries)
      For Each opowEnquiries As SIS.POW.powEnquiries In opowEnquiriess
        oRowpowEnquiries = New TableRow
        oColpowEnquiries = New TableCell
        oColpowEnquiries.CssClass = "rowHD"
        oColpowEnquiries.Text = opowEnquiries.EnquiryID
        oColpowEnquiries.Style.Add("text-align", "right")
        oRowpowEnquiries.Cells.Add(oColpowEnquiries)
        oColpowEnquiries = New TableCell
        oColpowEnquiries.Text = opowEnquiries.VR_BusinessPartner3_BPName
        oColpowEnquiries.CssClass = "rowHD"
        oColpowEnquiries.Style.Add("text-align", "left")
        oRowpowEnquiries.Cells.Add(oColpowEnquiries)
        oColpowEnquiries = New TableCell
        oColpowEnquiries.CssClass = "rowHD"
        oColpowEnquiries.Text = opowEnquiries.SupplierName
        oColpowEnquiries.Style.Add("text-align", "left")
        oRowpowEnquiries.Cells.Add(oColpowEnquiries)
        oColpowEnquiries = New TableCell
        oColpowEnquiries.CssClass = "rowHD"
        oColpowEnquiries.Text = opowEnquiries.EMailSubject
        oColpowEnquiries.Style.Add("text-align", "left")
        oRowpowEnquiries.Cells.Add(oColpowEnquiries)
        oColpowEnquiries = New TableCell
        oColpowEnquiries.Text = opowEnquiries.POW_EnquiryStates1_Description
        oColpowEnquiries.CssClass = "rowHD"
        oColpowEnquiries.Style.Add("text-align", "right")
        oRowpowEnquiries.Cells.Add(oColpowEnquiries)
        oColpowEnquiries = New TableCell
        oColpowEnquiries.CssClass = "rowHD"
        oColpowEnquiries.Text = opowEnquiries.SentOn
        oColpowEnquiries.Style.Add("text-align", "center")
        oRowpowEnquiries.Cells.Add(oColpowEnquiries)
        oTblpowEnquiries.Rows.Add(oRowpowEnquiries)
        oRowpowEnquiries = New TableRow
        oColpowEnquiries = New TableCell
        oColpowEnquiries.ColumnSpan = oTblpowEnquiries.Rows(0).Cells.Count
        oRowpowEnquiries.Cells.Add(oColpowEnquiries)
        Dim oTblpowOffers As Table = Nothing
        Dim oRowpowOffers As TableRow = Nothing
        Dim oColpowOffers As TableCell = Nothing
        Dim opowOfferss As List(Of SIS.POW.powOffers) = SIS.POW.powOffers.UZ_powOffersSelectList(0, 999, "", False, "", opowEnquiries.TSID, opowEnquiries.EnquiryID)
        If opowOfferss.Count > 0 Then
          Dim oTblhpowOffers As Table = New Table
          oTblhpowOffers.Width = 980
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
          oColpowEnquiries.Controls.Add(oTblhpowOffers)
          oTblpowOffers = New Table
          oTblpowOffers.Width = 980
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
          oColpowEnquiries.Controls.Add(oTblpowOffers)
          oTblpowEnquiries.Rows.Add(oRowpowEnquiries)
        End If
      Next
      form1.Controls.Add(oTblpowEnquiries)
    End If
  End Sub
End Class
