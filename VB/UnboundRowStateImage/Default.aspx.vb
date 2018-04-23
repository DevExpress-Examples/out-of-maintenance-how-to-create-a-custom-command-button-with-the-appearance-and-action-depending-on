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
Imports DevExpress.Web

Namespace UnboundRowStateImage
    Partial Public Class _Default
        Inherits System.Web.UI.Page

        Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
            ASPxGridView1.DataSource = GetDataTable()

        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsPostBack Then
                ASPxGridView1.DataBind()
            End If
        End Sub
        Private Function GetDataTable() As DataTable
            Dim table As New DataTable("Tasks")
            table.Columns.Add("ID", GetType(Integer))
            table.Columns.Add("Subject", GetType(String))
            table.Columns.Add("DueOn", GetType(Date))
            table.Rows.Add(1, "Feed the dog", Date.Today.AddHours(9))
            table.Rows.Add(2, "Shop for food", Date.Today.AddHours(12))
            table.Rows.Add(3, "Watch the race", Date.Today.AddHours(23))
            Return table
        End Function

        Private Function GetSate(ByVal id As Integer) As String
            Dim sessionKey As String = String.Format("Actions_{0}", id)
            Dim state As String = DirectCast(Session(sessionKey), String)
            If state Is Nothing Then
                state = "undone"
            End If
            Return state
        End Function

        Private Sub SetState(ByVal id As Integer, ByVal state As String)
            Dim sessionKey As String = String.Format("Actions_{0}", id)
            Session(sessionKey) = state
        End Sub

        Private Function GetNextState(ByVal currentSate As String) As String
            Select Case currentSate
                Case "deleted"
                    Return "undone"
                Case "undone"
                    Return "deleted"
                Case Else
                    Return currentSate
            End Select
        End Function

        Private Function GetImagePath(ByVal state As String) As String
            Select Case state
                Case "deleted"
                    Return "~/Images/undo.gif"
                Case "undone"
                    Return "~/Images/delete.gif"
                Case Else
                    Return String.Empty
            End Select
        End Function

        Protected Sub ASPxGridView1_HtmlRowPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewTableRowEventArgs)
            If e.RowType = GridViewRowType.Data Then

                Dim id_Renamed As Integer = CInt((e.KeyValue))
                Dim grid As ASPxGridView = DirectCast(sender, ASPxGridView)
                Dim colAction As GridViewDataColumn = CType(grid.Columns("colAction"), GridViewDataColumn)
                Dim btnAction As ASPxButton = CType(grid.FindRowCellTemplateControl(e.VisibleIndex, colAction, "btnAction"), ASPxButton)
                Dim state As String = GetSate(id_Renamed)
                btnAction.ImageUrl = GetImagePath(state)
                btnAction.ClientSideEvents.Click = GetActionScript(id_Renamed, state)
            End If
        End Sub

        Private Function GetActionScript(ByVal id As Integer, ByVal state As String) As String
            Dim changeState As String = "ChangeState;" & id.ToString()
            Dim nextState As String = GetNextState(state)
            Select Case nextState
                Case "deleted"
                    Return "function(s,e){ if(confirm('Delete?')) grid.PerformCallback('" & changeState & "'); }"
                Case "undone"
                    Return "function(s,e){ if(confirm('Undo?')) grid.PerformCallback('" & changeState & "'); }"
                Case Else
                    Return String.Empty
            End Select
        End Function

        Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
            Dim parameters() As String = e.Parameters.Split(";"c)
            If parameters.Length = 2 AndAlso parameters(0) = "ChangeState" Then

                Dim id_Renamed As Integer = Convert.ToInt32(parameters(1))
                Dim currentState As String = GetSate(id_Renamed)
                Dim newState As String = GetNextState(currentState)
                SetState(id_Renamed, newState)
            End If
        End Sub

    End Class
End Namespace
