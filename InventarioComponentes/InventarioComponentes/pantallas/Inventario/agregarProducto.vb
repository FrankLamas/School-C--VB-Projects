Public Class agregarProducto

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim inv As New Inventario
        inv.agregarProducto(tModelo.Text, tDesc.Text, Convert.ToDouble(tPcompra.Text), Convert.ToDouble(tPventa.Text), Convert.ToInt16(tStock.Text))
        Me.Close()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles tDesc.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class