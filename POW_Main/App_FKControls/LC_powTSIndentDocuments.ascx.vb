Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

<ValidationProperty("SelectedValue")> _
Partial Class LC_powTSIndentDocuments
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLpowTSIndentDocuments.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLpowTSIndentDocuments.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLpowTSIndentDocuments.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLpowTSIndentDocuments.CssClass
    End Get
    Set(ByVal value As String)
      DDLpowTSIndentDocuments.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLpowTSIndentDocuments.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLpowTSIndentDocuments.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorpowTSIndentDocuments.Text
    End Get
    Set(ByVal value As String)
      If value = String.Empty Then
        RequiredFieldValidatorpowTSIndentDocuments.Enabled = False
      Else
        RequiredFieldValidatorpowTSIndentDocuments.Text = value
      End If
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorpowTSIndentDocuments.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorpowTSIndentDocuments.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLpowTSIndentDocuments.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLpowTSIndentDocuments.Enabled = value
      RequiredFieldValidatorpowTSIndentDocuments.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLpowTSIndentDocuments.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLpowTSIndentDocuments.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLpowTSIndentDocuments.DataTextField
    End Get
    Set(ByVal value As String)
      DDLpowTSIndentDocuments.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLpowTSIndentDocuments.DataValueField
    End Get
    Set(ByVal value As String)
      DDLpowTSIndentDocuments.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLpowTSIndentDocuments.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLpowTSIndentDocuments.SelectedValue = String.Empty
      Else
        DDLpowTSIndentDocuments.SelectedValue = value
      End If
    End Set
  End Property
  Public Property OrderBy() As String
    Get
      Return _OrderBy
    End Get
    Set(ByVal value As String)
      _OrderBy = value
    End Set
  End Property
  Public Property IncludeDefault() As Boolean
    Get
      Return _IncludeDefault
    End Get
    Set(ByVal value As Boolean)
      _IncludeDefault = value
    End Set
  End Property
  Public Property DefaultText() As String
    Get
      Return _DefaultText
    End Get
    Set(ByVal value As String)
      _DefaultText = value
    End Set
  End Property
  Public Property DefaultValue() As String
    Get
      Return _DefaultValue
    End Get
    Set(ByVal value As String)
      _DefaultValue = value
    End Set
  End Property
  Protected Sub OdsDdlpowTSIndentDocuments_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlpowTSIndentDocuments.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLpowTSIndentDocuments_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpowTSIndentDocuments.DataBinding
    If _IncludeDefault Then
      DDLpowTSIndentDocuments.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLpowTSIndentDocuments_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpowTSIndentDocuments.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
