Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrBusinessPartner
    Public Shared Function GetBPFromERP(ByVal BPID As String, Optional ByVal Comp As String = "200") As SIS.VR.vrBusinessPartner
      Dim Results As SIS.VR.vrBusinessPartner = Nothing
      Dim Sql As String = ""
      Sql &= "select                                                     "
      Sql &= "  suh.t_bpid as BPID,                                      "
      Sql &= "  suh.t_nama as BPName,                                    "
      Sql &= "  adh.t_ln01 as Address1Line,                              "
      Sql &= "  adh.t_ln02 as Address2Line,                                    "
      Sql &= "  adh.t_ln03 as Address3,                                        "
      Sql &= "  adh.t_ln04 as Address4,                                        "
      Sql &= "  adh.t_ln05 as City,                                            "
      Sql &= "  adh.t_ln06 as State,                                           "
      Sql &= "  adh.t_pstc as Zip,                                             "
      Sql &= "  adh.t_ccty as Country,                                         "
      Sql &= "  cnh.t_fuln as ContactPerson,                                   "
      Sql &= "  cnh.t_telp as ContactNo,                                       "
      Sql &= "  cnh.t_info as EMailID                                          "
      Sql &= "  from ttccom100" & Comp & " as suh                                       "
      Sql &= "  left outer join ttccom130" & Comp & " as adh on suh.t_cadr = adh.t_cadr "
      Sql &= "  left outer join ttccom140" & Comp & " as cnh on suh.t_ccnt = cnh.t_ccnt "
      Sql &= "  where suh.t_bpid ='" & BPID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.vrBusinessPartner(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      If Results IsNot Nothing Then
        If Comp <> "200" Then Results.BPID = "S" & Comp & Right(Results.BPID, 5)
        Try
          Results = SIS.VR.vrBusinessPartner.InsertData(Results)
        Catch ex As Exception
        End Try
      End If
      Return Results
    End Function

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
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_vrBusinessPartnerInsert(ByVal Record As SIS.VR.vrBusinessPartner) As SIS.VR.vrBusinessPartner
      Dim _Result As SIS.VR.vrBusinessPartner = vrBusinessPartnerInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrBusinessPartnerUpdate(ByVal Record As SIS.VR.vrBusinessPartner) As SIS.VR.vrBusinessPartner
      Dim _Result As SIS.VR.vrBusinessPartner = vrBusinessPartnerUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrBusinessPartnerDelete(ByVal Record As SIS.VR.vrBusinessPartner) As Integer
      Dim _Result As Integer = vrBusinessPartnerDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_BPID"), TextBox).Text = ""
          CType(.FindControl("F_BPName"), TextBox).Text = ""
          CType(.FindControl("F_Address1Line"), TextBox).Text = ""
          CType(.FindControl("F_Address2Line"), TextBox).Text = ""
          CType(.FindControl("F_City"), TextBox).Text = ""
          CType(.FindControl("F_EMailID"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
Public Class lgBP
	Public t_bpid As String = ""
	Public t_nama As String = ""
	Public CustomerID As String = ""
	Public CustomerName As String = ""
	Public Shared Function GetDataFromBaaN(ByVal Typ As String, Optional ByVal ProjectID As String = "") As List(Of lgBP)
		Dim Results As List(Of lgBP) = Nothing
		Dim Sql As String = ""
		If Typ <> "PRJ" Then
			Sql = Sql & "select t_bpid,t_nama from ttccom100200 where ltrim(t_nama)<>'' and t_prst=2 and substring(t_bpid,1,3) = '" & Typ & "' order by t_nama"
		Else
			Sql = Sql & "select aa.t_cprj as t_bpid, aa.t_dsca as t_nama, bb.t_ofbp as CustomerID, cc.t_nama as CustomerName from ttcmcs052200 aa inner join ttppdm740200 bb on aa.t_cprj = bb.t_cprj inner join ttccom100200 as cc on bb.t_ofbp = cc.t_bpid where aa.t_cprj='" & ProjectID & "'"
		End If
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Results = New List(Of lgBP)()
				Con.Open()
				Dim Reader As SqlDataReader = Cmd.ExecuteReader()
				While (Reader.Read())
					Results.Add(New lgBP(Reader))
				End While
				Reader.Close()
			End Using
		End Using
		Return Results
	End Function
  Public Sub New(ByVal Reader As SqlDataReader)
    Try
      For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
        If pi.MemberType = Reflection.MemberTypes.Property Then
          Try
            If Convert.IsDBNull(Reader(pi.Name)) Then
              CallByName(Me, pi.Name, CallType.Let, String.Empty)
            Else
              CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
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

End Class
