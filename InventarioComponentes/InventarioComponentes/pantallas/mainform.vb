Public Class mainform

    Private Sub AbrirFormEnPanel(ByVal Formhijo As Object)
        If Me.PanelPrincipal.Controls.Count > 0 Then
            Me.PanelPrincipal.Controls.RemoveAt(0)
        End If
        Dim fh As Form = TryCast(Formhijo, Form)
        fh.TopLevel = False
        fh.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.PanelPrincipal.Controls.Add(fh)
        Me.PanelPrincipal.Tag = fh
        fh.Show()
    End Sub

    Private Sub mainform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AbrirFormEnPanel(New movimientosfrm)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        AbrirFormEnPanel(New movimientosfrm)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        AbrirFormEnPanel(New movimientosfrm)
    End Sub

    Private Sub mainform_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        AbrirFormEnPanel(New movimientosfrm)
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub Label1_MouseHover(sender As Object, e As EventArgs) Handles Label1.MouseHover
        Label1.ForeColor = Color.DodgerBlue
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Azure
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Dispose()
    End Sub
End Class