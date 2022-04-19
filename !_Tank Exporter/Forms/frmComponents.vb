Imports System.IO
Imports System.Windows.Forms
Public Class frmComponents

    Public selectedTurret As TurretComponent
    Public selectedGun, selectedHull, selectedChassis As Component

    Public turrets As List(Of TurretComponent)
    Public guns, hulls, chassis As List(Of Component)

    Public Sub RefreshDisplay()
        RefreshTurrets()
        RefreshHulls()
        RefreshChassis()
    End Sub

    Private Sub RefreshGuns()
        tv_guns.Nodes.Clear()

        guns = tv_turrets.SelectedNode.Tag.gunList

        For i = 0 To guns.Count - 1
            If frmMain.validate_path(guns(i).undamagedPath) = guns(i).undamagedPath Then

                Dim n = New TreeNode

                n.Text = guns(i).name
                If guns(i).undamagedPath.Contains("_skin") Then n.Text += " (Skin)"
                n.Tag = guns(i)
                tv_guns.Nodes.Add(n)
            End If
        Next
        tv_guns.SelectedNode = tv_guns.Nodes(0)
        tv_guns.SelectedNode.Checked = True
    End Sub

    Private Sub RefreshTurrets()
        tv_turrets.Nodes.Clear()

        For i = 0 To turrets.Count - 1
            If frmMain.validate_path(turrets(i).undamagedPath) = turrets(i).undamagedPath Then
                Dim n = New TreeNode
                n.Text = turrets(i).name
                If turrets(i).undamagedPath.Contains("_skin") Then n.Text += " (Skin)"
                n.Tag = turrets(i)
                tv_turrets.Nodes.Add(n)
            End If
        Next
        tv_turrets.SelectedNode = tv_turrets.Nodes(0)
        tv_turrets.SelectedNode.Checked = True

        RefreshGuns()
    End Sub

    Private Sub RefreshHulls()
        tv_hulls.Nodes.Clear()

        For i = 0 To hulls.Count - 1
            If frmMain.validate_path(hulls(i).undamagedPath) = hulls(i).undamagedPath Then
                Dim n = New TreeNode
                n.Text = hulls(i).name
                If hulls(i).undamagedPath.Contains("_skin") Then n.Text += " (Skin)"
                n.Tag = hulls(i)
                tv_hulls.Nodes.Add(n)
            End If
        Next
        tv_hulls.SelectedNode = tv_hulls.Nodes(0)
        tv_hulls.SelectedNode.Checked = True
    End Sub

    Private Sub RefreshChassis()
        tv_chassis.Nodes.Clear()
        For i = 0 To chassis.Count - 1
            If frmMain.validate_path(chassis(i).undamagedPath) = chassis(i).undamagedPath Then
                Dim n = New TreeNode
                n.Text = chassis(i).name
                If chassis(i).undamagedPath.Contains("_skin") Then n.Text += " (Skin)"
                n.Tag = chassis(i)
                tv_chassis.Nodes.Add(n)
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

        guns = e.Node.Tag.gunList

        RefreshGuns()
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
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmComponents_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = True 'cant destroy the viewtree data
        selectedTurret = tv_turrets.SelectedNode.Tag
        selectedGun = tv_guns.SelectedNode.Tag
        selectedHull = tv_hulls.SelectedNode.Tag
        selectedChassis = tv_chassis.SelectedNode.Tag

        Me.Hide()
    End Sub

End Class