using MJFramework.mj.connections;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControlInventarios
{
    class Operaciones: MJMySqlConnection
    {
        #region Inventario
        public void agregarElemto(string modelo, string foto, string numeracion, int stock, string tipo,double precio, string color, double precioc,int proveedor)
        {
            string SqlQuery = "INSERT INTO `zapatos`(`Modelo`,`Foto`,`Numeracion`,`Stock`,`Tipo`,`Precio`,`Color`,`PrecioCompra`,`idProveedor`) VALUES(@Modelo,@Foto,@Numeracion,@Stock,@Tipo,@Precio,@Color,@PC,@Proveedor);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", modelo));
            parametros.Add(new MySqlParameter("@Foto", foto));
            parametros.Add(new MySqlParameter("@Numeracion", numeracion));
            parametros.Add(new MySqlParameter("@Stock", stock));
            parametros.Add(new MySqlParameter("@Tipo", tipo));
            parametros.Add(new MySqlParameter("@Precio", precio));
            parametros.Add(new MySqlParameter("@Color", color));
            parametros.Add(new MySqlParameter("@PC", precioc));
            parametros.Add(new MySqlParameter("@Proveedor", proveedor));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public void editarElemto(int id, string modelo, string foto, string numeracion, int stock, string tipo, double precio, string color, double precioc, int proveedor)
        {
            string SqlQuery = "UPDATE zapatos SET `Modelo` = @Modelo,`Foto`=@Foto,`Numeracion` = @Numeracion,`Stock`=@Stock,`Tipo`= @Tipo,`Precio`=@Precio,`Color`=@Color, PrecioCompra=@PC, idProveedor=@Proveedor WHERE idZapatos=@id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", modelo));
            parametros.Add(new MySqlParameter("@Foto", foto));
            parametros.Add(new MySqlParameter("@Numeracion", numeracion));
            parametros.Add(new MySqlParameter("@Stock", stock));
            parametros.Add(new MySqlParameter("@Tipo", tipo));
            parametros.Add(new MySqlParameter("@Precio", precio));
            parametros.Add(new MySqlParameter("@Color", color));
            parametros.Add(new MySqlParameter("@id", id));
            parametros.Add(new MySqlParameter("@PC", precioc));
            parametros.Add(new MySqlParameter("@Proveedor", proveedor));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public void eliminarElemento(int id) 
        {
            string SqlQuery = "DELETE FROM zapatos WHERE idZapatos=@id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id)); 
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        public DataTable gridInventario()
        {
            string sql = "SELECT * FROM zapatos z JOIN proveedores p ON z.idProveedor=p.idProveedor";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public DataTable gridFiltroInventario(string Campo,string fil)
        {
            string sql = "SELECT * FROM zapatos z JOIN proveedores p ON z.idProveedor=p.idProveedor WHERE " + Campo + " like ('%" + fil + "%')";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public bool valModelos(string modelo)
        {
            bool bandera=true;
            string sql = "SELECT Modelo FROM zapatos";
            DataTable dt = getListQuerySQL(sql, new List<MySqlParameter>());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Modelo"].ToString()==modelo)
                {
                    bandera = false;  
                }
                //object imagen = @dt.Rows[i]["Foto"];
            }
            return bandera;
        }

        public double calcularDineroInventario() 
        {
            double total = 0;
            string sql = "SELECT Stock,Precio FROM zapatos";
            DataTable dt = getListQuerySQL(sql, new List<MySqlParameter>());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total = total + (Convert.ToDouble(dt.Rows[i]["Stock"].ToString()) * Convert.ToDouble(dt.Rows[i]["Precio"].ToString()));
                //if (dt.Rows[i]["Modelo"].ToString() == modelo)
                //{
                //    bandera = false;
                //}
                //object imagen = @dt.Rows[i]["Foto"];
            }
            return total;
        }

        public DataTable obtenerElemto(int pid)
        {
            string sql = "SELECT * FROM zapatos z JOIN proveedores p ON z.idProveedor=p.idProveedor WHERE idZapatos = @pid";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@pid", pid));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }
        #endregion

        #region Movimientos
        public void agregarMovimiento(string fecha, double total, string Tipo)
        {
            string SqlQuery = "INSERT INTO `movimientos`(`Fecha`,`Total`,`Tipo`) VALUES(@fecha,@Total,@Tipo);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@fecha", fecha));
            parametros.Add(new MySqlParameter("@Total", total));
            parametros.Add(new MySqlParameter("@Tipo", Tipo));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        public void agregarMovimiento(string fecha, double total, string Tipo,int cliente)
        {
            string SqlQuery = "INSERT INTO `movimientos`(`Fecha`,`Total`,`Tipo`,idClientes) VALUES(@fecha,@Total,@Tipo,@idc);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@fecha", fecha));
            parametros.Add(new MySqlParameter("@Total", total));
            parametros.Add(new MySqlParameter("@Tipo", Tipo));
            parametros.Add(new MySqlParameter("@idc", cliente));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }
        //Para cuando editemos
        public void agregarMovimiento(int id,string fecha, double total, string Tipo)
        {
            string SqlQuery = "INSERT INTO `movimientos`(idMovimiento,`Fecha`,`Total`,`Tipo`) VALUES(@id,@fecha,@Total,@Tipo);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@fecha", fecha));
            parametros.Add(new MySqlParameter("@Total", total));
            parametros.Add(new MySqlParameter("@Tipo", Tipo));
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public void agregarMovimiento(int id, string fecha, double total, string Tipo,int idc)
        {
            string SqlQuery = "INSERT INTO `movimientos`(idMovimiento,`Fecha`,`Total`,`Tipo`,idClientes) VALUES(@id,@fecha,@Total,@Tipo,@idc);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@fecha", fecha));
            parametros.Add(new MySqlParameter("@Total", total));
            parametros.Add(new MySqlParameter("@Tipo", Tipo));
            parametros.Add(new MySqlParameter("@id", id));
            parametros.Add(new MySqlParameter("@idc", idc));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public void agregarDetalle(int idMovimiento,int idZapatos,int cantidad)
        {
            string SqlQuery = "INSERT INTO `detallemovimiento`(`idMovimiento`,`idZapatos`,`Cantidad`) VALUES(@idMovimiento,@idZapatos,@cantidad);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@idMovimiento", idMovimiento));
            parametros.Add(new MySqlParameter("@idZapatos", idZapatos));
            parametros.Add(new MySqlParameter("@cantidad", cantidad));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public void modStock(string num, string id)
        {
            string SqlQuery = "UPDATE zapatos SET `Stock`= stock " + num + " WHERE idZapatos=" + id;
            bool res = executeQueryUpdate(SqlQuery, new List<MySqlParameter>());
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        public DataTable obtenerElemto(string modelo,string numeracion, string color)
        {
            string sql = "SELECT * FROM zapatos WHERE Modelo = @pid AND Numeracion = @Num AND Color = @Color";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@pid", modelo));
            parametros.Add(new MySqlParameter("@Num", numeracion));
            parametros.Add(new MySqlParameter("@Color", color));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public DataTable obtenerElemto(string modelo)
        {
            string sql = "SELECT Foto, Modelo, Numeracion, Stock, Tipo, Precio, Color,idZapatos FROM zapatos WHERE Modelo = @pid";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@pid", modelo));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public DataTable obtenerMovimiento(int id)
        {
            string sql = "SELECT * FROM movimientos WHERE idMovimiento = @pid";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@pid", id));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public DataTable obtenerDetalles(int id)
        {
            string sql = "SELECT * FROM detallemovimiento WHERE idMovimiento = @pid";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@pid", id));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public DataTable obtenerMovimientos()
        {
            string sql = "SELECT * FROM movimientos";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public DataTable gridMovimientos()
        {
            string sql = "SELECT m.idMovimiento,d.idZapatos, Precio, Total, Cantidad,Color,Numeracion,Modelo,Fecha,m.Tipo FROM movimientos m JOIN detallemovimiento d ON m.idMovimiento=d.idMovimiento JOIN zapatos z ON d.idZapatos=z.idZapatos";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public DataTable filtroMovimientos(string filtro, string word, string tipom) {
            string sql = "SELECT m.idMovimiento,d.idZapatos, Precio, Total, Cantidad,Color,Numeracion,Modelo,Fecha,m.Tipo FROM movimientos m JOIN detallemovimiento d ON m.idMovimiento=d.idMovimiento JOIN zapatos z ON d.idZapatos=z.idZapatos WHERE m.Tipo" + tipom + " and " + filtro + " like ('%" + word + "%')";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public void eliminarMovimiento(int id)
        {
            string SqlQuery = "DELETE FROM movimientos WHERE idMovimiento=@id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        public void eliminarDetalle(int id)
        {
            string SqlQuery = "DELETE FROM detallemovimiento WHERE idMovimiento=@id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }
        #endregion

        #region Reportes
        public DataTable datosReporte(string tipo, string fecha1,string fecha2,string prov)
        {
            string sql = "SELECT Fecha,m.Tipo as Tipo, Modelo, Total, Cantidad,Precio,Color,Numeracion,PrecioCompra FROM movimientos m JOIN detallemovimiento d ON m.idMovimiento=d.idMovimiento JOIN zapatos z ON d.idZapatos=z.idZapatos WHERE (fecha BETWEEN @Fecha1 and @Fecha2) AND z.idProveedor" +prov+" AND m.Tipo"+tipo;
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Fecha1", fecha1));
            parametros.Add(new MySqlParameter("@Fecha2", fecha2));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public DataTable datosRM(string tipo, string fecha1, string fecha2)
        {
            string sql = "SELECT * FROM movimientos WHERE (fecha BETWEEN @Fecha1 and @Fecha2) AND Tipo" + tipo;
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Fecha1", fecha1));
            parametros.Add(new MySqlParameter("@Fecha2", fecha2));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }
        #endregion

        #region Proveedores

        public void agregarProveedor(string nombre, string telefono, double cuenta)
        {
            string SqlQuery = "INSERT INTO `proveedores`(`Nombre`,`Telefono`,`Cuenta`) VALUES(@fecha,@Total,@Tipo);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@fecha", nombre));
            parametros.Add(new MySqlParameter("@Total", telefono));
            parametros.Add(new MySqlParameter("@Tipo", cuenta));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public DataTable datosProveedor()
        {
            string sql = "SELECT * FROM proveedores ORDER BY Nombre ASC";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public DataTable datosProveedor(int id)
        {
            string sql = "SELECT * FROM proveedores WHERE idProveedor=@id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public void editarProveedor(int id,string nombre, string telefono, double cuenta)
        {
            string SqlQuery = "UPDATE proveedores SET `Nombre` = @Nombre,`Telefono`=@Telefono, Cuenta= @Cuenta WHERE idProveedor = @id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Nombre", nombre));
            parametros.Add(new MySqlParameter("@Telefono", telefono));
            parametros.Add(new MySqlParameter("@Cuenta", cuenta));
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public DataTable FiltroProveedor(string Campo, string fil)
        {
            string sql = "SELECT * FROM proveedores WHERE " + Campo + " like ('%" + fil + "%')";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public double calcularDeudaProveedores()
        {
            double total = 0;
            string sql = "SELECT * FROM proveedores";
            DataTable dt = getListQuerySQL(sql, new List<MySqlParameter>());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total = total + (Convert.ToDouble(dt.Rows[i]["Cuenta"].ToString()));
                //if (dt.Rows[i]["Modelo"].ToString() == modelo)
                //{
                //    bandera = false;
                //}
                //object imagen = @dt.Rows[i]["Foto"];
            }
            return total;
        }

        #endregion

        #region Clientes

        public void agregarCliente(string Nombre, string Ciudad, string Domicilio, string Ruta, string telefono,string Cp)
        {
            string SqlQuery = "INSERT INTO `clientes`(`Nombre`,`Ciudad`,`Domicilio`,`Ruta`,`Telefono`,`CP`) VALUES(@Modelo,@Foto,@Numeracion,@Stock,@Tipo,@Precio);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", Nombre));
            parametros.Add(new MySqlParameter("@Foto", Ciudad));
            parametros.Add(new MySqlParameter("@Numeracion", Domicilio));
            parametros.Add(new MySqlParameter("@Stock", Ruta));
            parametros.Add(new MySqlParameter("@Tipo", telefono));
            parametros.Add(new MySqlParameter("@Precio", Cp));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public DataTable datosClientes()
        {
            string sql = "SELECT * FROM clientes ORDER BY Nombre ASC";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public double calcularDeudaClientes()
        {
            double total = 0;
            string sql = "SELECT * FROM clientes";
            DataTable dt = getListQuerySQL(sql, new List<MySqlParameter>());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total = total + (Convert.ToDouble(dt.Rows[i]["Adeudo"].ToString()));
                //if (dt.Rows[i]["Modelo"].ToString() == modelo)
                //{
                //    bandera = false;
                //}
                //object imagen = @dt.Rows[i]["Foto"];
            }
            return total;
        }

        public DataTable FiltroClientes(string Campo, string fil)
        {
            string sql = "SELECT * FROM clientes WHERE " + Campo + " like ('%" + fil + "%')";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public DataTable datosClientes(int id)
        {
            string sql = "SELECT * FROM clientes WHERE idClientes = @id ORDER BY Nombre ASC";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public void editarCliente(int id,string Nombre, string Ciudad, string Domicilio, string Ruta, string telefono, string Cp)
        {
            string SqlQuery = "UPDATE `clientes` SET `Nombre`=@Modelo,`Ciudad`=@Foto,`Domicilio`=@Numeracion,`Ruta`=@Stock,`Telefono`=@Tipo,`CP`=@Precio WHERE idClientes=@id;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", Nombre));
            parametros.Add(new MySqlParameter("@Foto", Ciudad));
            parametros.Add(new MySqlParameter("@Numeracion", Domicilio));
            parametros.Add(new MySqlParameter("@Stock", Ruta));
            parametros.Add(new MySqlParameter("@Tipo", telefono));
            parametros.Add(new MySqlParameter("@Precio", Cp));
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        public void editarAdeudoCliente(int id, double cantidad)
        {
            string SqlQuery = "UPDATE `clientes` SET `Adeudo`= Adeudo + @Cantidad WHERE idClientes=@id;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Cantidad", cantidad));
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        public void editarGastadoCliente(int id, double cantidad)
        {
            string SqlQuery = "UPDATE `clientes` SET `Gastado`= Gastado + @Cantidad WHERE idClientes=@id;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Cantidad", cantidad));
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        public void editarParesCliente(int id, double cantidad)
        {
            string SqlQuery = "UPDATE `clientes` SET `ParesComprados`= ParesComprados + @Cantidad WHERE idClientes=@id;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Cantidad", cantidad));
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        #endregion

        #region abonos cliente

        public DataTable datosAbonosClientes(int id)
        {
            string sql = "SELECT * FROM abonosclientes WHERE idClientes = @id ORDER BY Fecha DESC";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public void agregarAbonoCliente(int idcliente, string fecha, double cantidad, double estado)
        {
            string SqlQuery = "INSERT INTO `abonosclientes`(`idClientes`,`Cantidad`,`Fecha`,`EstadoAdeudo`) VALUES(@Modelo,@Cantidad,@Fecha,@Estado);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", idcliente));
            parametros.Add(new MySqlParameter("@Fecha", fecha));
            parametros.Add(new MySqlParameter("@Cantidad", cantidad));
            parametros.Add(new MySqlParameter("@Estado", estado));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        #endregion

        #region Notas Proveedor

        public void agregarNota(string idNota, double Deuda, string Fecha, int idProveedor)
        {
            string SqlQuery = "INSERT INTO `notasproveedor`(`IdNota`,`Deuda`,`Fecha`,`idProveedor`) VALUES(@Modelo,@Foto,@Numeracion,@Stock);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", idNota));
            parametros.Add(new MySqlParameter("@Foto", Deuda));
            parametros.Add(new MySqlParameter("@Numeracion", Fecha));
            parametros.Add(new MySqlParameter("@Stock", idProveedor));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public void EditarNota(int id,string idNota, double Deuda, string Fecha, int idProveedor)
        {
            string SqlQuery = "UPDATE `notasproveedor` SET `IdNota`= @Modelo,`Deuda`=@Foto,`Fecha`=@Numeracion,`idProveedor`=@Stock WHERE idNotasProveedor=@id;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", idNota));
            parametros.Add(new MySqlParameter("@Foto", Deuda));
            parametros.Add(new MySqlParameter("@Numeracion", Fecha));
            parametros.Add(new MySqlParameter("@Stock", idProveedor));
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        public DataTable datosNotas()
        {
            string sql = "SELECT * FROM notasproveedor n JOIN proveedores p ON n.idProveedor=p.idProveedor";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public DataTable datosNota(int id)
        {
            string sql = "SELECT * FROM notasproveedor n JOIN proveedores p ON n.idProveedor=p.idProveedor WHERE idNotasProveedor=@id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public DataTable FiltroNotas(string Campo, string fil)
        {
            string sql = "SELECT * FROM notasproveedor n JOIN proveedores p ON n.idProveedor=p.idProveedor WHERE " + Campo + " like ('%" + fil + "%')";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public void editarDeudaProv(int id, double cantidad)
        {
            string SqlQuery = "UPDATE `notasproveedor` SET `Adeudo`= Adeudo + @Cantidad WHERE idNotasProveedor=@id;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Cantidad", cantidad));
            parametros.Add(new MySqlParameter("@id", id));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }
        }

        #endregion

        #region AbonosProv

        public DataTable datosAbonosProv(int id)
        {
            string sql = "SELECT * FROM abonosprov n JOIN notasproveedor p  ON n.idNotasProveedor = p.idNotasProveedor WHERE n.idNotasProveedor=@id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public double calcularDeudaProv()
        {
            double total = 0;
            string sql = "SELECT * FROM notasproveedor";
            DataTable dt = getListQuerySQL(sql, new List<MySqlParameter>());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total = total + (Convert.ToDouble(dt.Rows[i]["Deuda"].ToString()));
            }
            return total;
        }

        public void agregarAbonoProv(int idcliente, string fecha, double cantidad)
        {
            string SqlQuery = "INSERT INTO `abonosprov`(`idNotasProveedor`,`Cantidad`,`Fecha`) VALUES(@Modelo,@Cantidad,@Fecha);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", idcliente));
            parametros.Add(new MySqlParameter("@Fecha", fecha));
            parametros.Add(new MySqlParameter("@Cantidad", cantidad));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }

        #endregion

        #region Cargos
        public DataTable datosCargos(int id)
        {
            string sql = "SELECT * FROM cargoscliente cc JOIN clientes c  ON cc.idClientes = c.idClientes WHERE c.idClientes=@id";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@id", id));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public void agregarCargo(int idcliente, string fecha, double cantidad)
        {
            string SqlQuery = "INSERT INTO `cargoscliente`(`idClientes`,`Cantidad`,`Fecha`) VALUES(@Modelo,@Cantidad,@Fecha);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Modelo", idcliente));
            parametros.Add(new MySqlParameter("@Fecha", fecha));
            parametros.Add(new MySqlParameter("@Cantidad", cantidad));
            bool res = executeQueryUpdate(SqlQuery, parametros);
            if (res)
            {
                Console.WriteLine("Se Grabó");
            }
            else
            {
                Console.WriteLine("Algo paso Aiiiuuuudddaaaaaa");
            }

        }
        #endregion
    }
}
