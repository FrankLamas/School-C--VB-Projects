Imports MySql.Data.MySqlClient
Public Class movimientosfrm
    Dim adCon As MySqlConnection
    Dim cmCon As MySqlCommand
    Dim da As MySqlDataAdapter
    Private Sub inventariofrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarDGV()
    End Sub
    Public Sub ActualizarDGV()
        'dgvInv.Rows.Clear()
        dgvInv.DataSource = ""
        Dim inv As New Inventario
        dgvInv.DataSource = inv.datosProductos()
    End Sub
    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        agregarProducto.ShowDialog()
        ActualizarDGV()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInv.CellContentClick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        buscar(TextBox1.Text)
    End Sub

    Private Sub buscar(cad As String)
        dgvInv.DataSource = ""
        Dim inv As New Inventario
        dgvInv.DataSource = inv.buscarProductos(cad)
    End Sub
End Class