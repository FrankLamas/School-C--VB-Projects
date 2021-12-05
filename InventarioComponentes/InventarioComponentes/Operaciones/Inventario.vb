Imports MySql.Data.MySqlClient
Public Class Inventario
    Dim adCon As MySqlConnection
    Dim cmCon As MySqlCommand
    Dim da As MySqlDataAdapter
    Public Sub agregarProducto(modelo As String, descripcion As String, precioc As Double, preciou As Double, stock As Integer)
        Try
            adCon = New MySqlConnection(cadena)
            cmCon = New MySqlCommand
            adCon.Open()
            cmCon.Connection = adCon
            cmCon.CommandText = "CALL `componenteselectricos`.`insertarProducto`(?modelo, ?desc, ?precioc, ?preciou, ?stock);"
            cmCon.Parameters.AddWithValue("?modelo", modelo)
            cmCon.Parameters.AddWithValue("?desc", descripcion)
            cmCon.Parameters.AddWithValue("?precioc", precioc)
            cmCon.Parameters.AddWithValue("?preciou", preciou)
            cmCon.Parameters.AddWithValue("?stock", stock)
            cmCon.ExecuteNonQuery()
            MsgBox("Los datos se han guardado con exíto.", MsgBoxStyle.Information, "Agregar Usuario")
        Catch ex As Exception
            MsgBox("Error al intentar agregar.", MsgBoxStyle.Critical, "Error")
        Finally
            adCon.Close()
        End Try
    End Sub

    Public Function datosProductos()
        Try
            adCon = New MySqlConnection(cadena)
            adCon.Open()

            Dim query As String = "SELECT * FROM componenteselectricos.productos;"
            Dim da As New MySqlDataAdapter(query, adCon)
            Dim ds As New DataSet
            da.Fill(ds, "productos")
            Return ds.Tables("productos")
        Catch ex As Exception
            MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            adCon.Close()
        End Try
        Return 0
    End Function

    Public Function buscarProductos(cad As String)
        Try
            adCon = New MySqlConnection(cadena)
            adCon.Open()

            Dim query As String = "select * FROM componenteselectricos.productos where modelo like('%" + cad + "%') or descripcion like('%" + cad + "%') or preciocompra like('%" + cad + "%') or preciounitario like('%" + cad + "%') or stock like('%" + cad + "%') "
            Dim da As New MySqlDataAdapter(query, adCon)
            Dim ds As New DataSet
            da.Fill(ds, "productos")
            Return ds.Tables("productos")
        Catch ex As Exception
            MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            adCon.Close()
        End Try
        Return 0
    End Function
End Class
