Imports System.IO
Imports System.Windows.Forms
Public Class frmComponents
    Public c_idx, h_idx, g_idx, t_idx As Integer


    Public turrets, guns, hulls, chassis As List(Of String)

    Public Sub RefreshDisplay()
        RefreshGuns()
        RefreshTurrets()
        RefreshHulls()
        RefreshChassis()
    End Sub

    Private Sub RefreshGuns()
        tv_guns.Nodes.Clear()

        Dim cn = 0
        For i = 0 To guns.Count - 1
            If frmMain.validate_path(guns(i)) = guns(i) Then
                Dim n = New TreeNode

                n.Text = Path.GetFileNameWithoutExtension(guns(i))
                If guns(i).Contains("_skin") Then n.Text += " (Skin)"
                n.Tag = i
                tv_guns.Nodes.Add(n)
                cn += 1
            End If
        Next
        tv_guns.SelectedNode = tv_guns.Nodes(0)
        tv_guns.SelectedNode.Checked = True
    End Sub

    Private Sub RefreshTurrets()
        tv_turrets.Nodes.Clear()

        Dim cn = 0
        For i = 0 To turrets.Count - 1
            If frmMain.validate_path(turrets(i)) = turrets(i) Then
                Dim n = New TreeNode
                n.Text = Path.GetFileNameWithoutExtension(turrets(i))
                If turrets(i).Contains("_skin") Then n.Text += " (Skin)"
                n.Tag = i
                tv_turrets.Nodes.Add(n)
                cn += 1
            End If
        Next
        tv_turrets.SelectedNode = tv_turrets.Nodes(0)
        tv_turrets.SelectedNode.Checked = True
    End Sub

    Private Sub RefreshHulls()
        tv_hulls.Nodes.Clear()

        Dim cn = 0
        For i = 0 To hulls.Count - 1
            If frmMain.validate_path(hulls(i)) = hulls(i) Then
                Dim n = New TreeNode
                n.Text = Path.GetFileNameWithoutExtension(hulls(i))
                If hulls(i).Contains("_skin") Then n.Text += " (Skin)"
                n.Tag = i
                tv_hulls.Nodes.Add(n)
                cn += 1
            End If
        Next
        tv_hulls.SelectedNode = tv_hulls.Nodes(0)
        tv_hulls.SelectedNode.Checked = True
    End Sub

    Private Sub RefreshChassis()
        tv_chassis.Nodes.Clear()
        Dim cn = 0
        For i = 0 To chassis.Count - 1
            If frmMain.validate_path(chassis(i)) = chassis(i) Then
                Dim n = New TreeNode
                n.Text = Path.GetFileNameWithoutExtension(chassis(i))
                If chassis(i).Contains("_skin") Then n.Text += " (Skin)"
                n.Tag = i
                tv_chassis.Nodes.Add(n)
                cn += 1
            End If
        Next
        tv_chassis.SelectedNode = tv_chassis.Nodes(0)
        tv_chassis.SelectedNode.Checked = True
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    End Sub

    Private Sub tv_guns_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tv_guns.NodeMouseClick
        Dim tv = DirectCast(sender, TreeView)
        tv.SelectedNode = Nothing
        For i = 0 To tv.Nodes.Count - 1
            tv.Nodes(i).Checked = False
        Next
        tv.SelectedNode = e.Node
        tv.SelectedNode.Checked = True
    End Sub

    Private Sub tv_turrets_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tv_turrets.NodeMouseClick
        Dim tv = DirectCast(sender, TreeView)
        tv.SelectedNode = Nothing
        For i = 0 To tv.Nodes.Count - 1
            tv.Nodes(i).Checked = False
        Next
        tv.SelectedNode = e.Node
        tv.SelectedNode.Checked = True
    End Sub

    Private Sub tv_hulls_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tv_hulls.NodeMouseClick
        Dim tv = DirectCast(sender, TreeView)
        tv.SelectedNode = Nothing
        For i = 0 To tv.Nodes.Count - 1
            tv.Nodes(i).Checked = False
        Next
        tv.SelectedNode = e.Node
        tv.SelectedNode.Checked = True
    End Sub

    Private Sub tv_chassis_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tv_chassis.NodeMouseClick
        Dim tv = DirectCast(sender, TreeView)
        tv.SelectedNode = Nothing
        For i = 0 To tv.Nodes.Count - 1
            tv.Nodes(i).Checked = False
        Next
        tv.SelectedNode = e.Node
        tv.SelectedNode.Checked = True
    End Sub

    Private Sub continue_bt_Click(sender As Object, e As EventArgs) Handles continue_bt.Click
        Me.Close()
    End Sub

    Private Sub frmComponents_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True 'cant destroy the viewtree data
        c_idx = tv_chassis.SelectedNode.Index
        h_idx = tv_hulls.SelectedNode.Index
        g_idx = tv_guns.SelectedNode.Index
        t_idx = tv_turrets.SelectedNode.Index
        Me.Hide()
    End Sub

End Class