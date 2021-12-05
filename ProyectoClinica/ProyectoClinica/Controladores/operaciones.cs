using MJFramework.mj.connections;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoClinica.Controladores
{
    class operaciones : MJMySqlConnection
    {
        //Trae todo de la tabla especificada para mostrar en el dgv
        public DataTable datosParaGrid(string tab)
        {
            string sql = "SELECT * FROM " + tab;
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }
        #region pacientes
        //Agrega un registro de paciente a la base de datos
        public void agregarPaciente(string nombre,string edad,string sexo,double estatura,double peso, string ss)
        {
            string SqlQuery = "INSERT INTO `paciente`(`nombre`,`edad`,`sexo`,`estatura`,`peso`,`segurosocial`) VALUES(@Nombre,@Edad,@Sexo,@Estatura,@Peso,@SeguroSocial);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Nombre", nombre));
            parametros.Add(new MySqlParameter("@Edad", edad));
            parametros.Add(new MySqlParameter("@Sexo", sexo));
            parametros.Add(new MySqlParameter("@Estatura", estatura));
            parametros.Add(new MySqlParameter("@Peso", peso));
            parametros.Add(new MySqlParameter("@SeguroSocial", ss));
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
        //Edita el registro en la base de datos
        public void editarPaciente(int id,string nombre, string edad, string sexo, double estatura, double peso, string ss)
        {
            string SqlQuery = "UPDATE paciente SET nombre= @Nombre,edad = @Edad, sexo = @Sexo, estatura = @Estatura, peso = @Peso,segurosocial=@SeguroSocial WHERE idpaciente = @id;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Nombre", nombre));
            parametros.Add(new MySqlParameter("@Edad", edad));
            parametros.Add(new MySqlParameter("@Sexo", sexo));
            parametros.Add(new MySqlParameter("@Estatura", estatura));
            parametros.Add(new MySqlParameter("@Peso", peso));
            parametros.Add(new MySqlParameter("@SeguroSocial", ss));
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
        //Recupera el registro que se especifica en el dgv
        public string[] obtenerPaciente(int id)
        {
            string SqlQuery = "sp_obtener_paciente";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pid", id));

            MySqlDataReader reader = findRecordsStoredProcedure(SqlQuery, parametros);

            string Nombre = "";
            string Edad = "";
            string Sexo = "";
            string Estatura = "";
            string peso = "";
            string ss = "";
            while (reader.Read())
            {
                Nombre = reader.GetString("nombre");
                Edad = reader.GetString("edad");
                Sexo = reader.GetString("sexo");
                Estatura = reader.GetDouble("estatura").ToString();
                peso = reader.GetDouble("peso").ToString();
                ss = reader.GetString("segurosocial");
            }
            string[] datos = new string[6];
            datos[0] = Nombre;
            datos[1] = Edad;
            datos[2] = Sexo;
            datos[3] = Estatura;
            datos[4] = peso;
            datos[5] = ss;
            closeConexion();
            return datos;
        }
        //Filtro
        public DataTable filtroParaPaciente(string pf)
        {
            string sql = "SELECT * FROM paciente WHERE idpaciente like ('%" + pf + "%') or nombre like ('%" + pf + "%') or edad like ('%" + pf + "%') or sexo like ('%" + pf + "%') or estatura like ('%" + pf + "%') or peso like ('%" + pf + "%') or segurosocial like ('%" + pf + "%')";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }
        #endregion

        #region citas

        public DataTable datosParaGridCitas()
        {
            string sql = "SELECT nombre as NombrePaciente,idcita as ClaveCita, fecha as Fecha, hora as Hora, medico as Medico FROM paciente p, cita c where p.idpaciente=c.idpaciente";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public void agregarCita(int idpaciente,string fecha, string hora, string medico)
        {
            string SqlQuery = "INSERT INTO `cita`(`idpaciente`,`fecha`,`hora`,`medico`) VALUES(@IDpaciente,@Fecha,@Hora,@Medico);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@IDpaciente", idpaciente));
            parametros.Add(new MySqlParameter("@Fecha", fecha));
            parametros.Add(new MySqlParameter("@Hora", hora));
            parametros.Add(new MySqlParameter("@Medico", medico));
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

        public void editarCita(int idcita, int idpaciente, string fecha, string hora, string medico)
        {
            string SqlQuery = "UPDATE cita SET idpaciente = @IDpaciente, fecha = @Fecha, hora = @Hora,medico = @Medico where idcita = @idcita;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@IDpaciente", idpaciente));
            parametros.Add(new MySqlParameter("@Fecha", fecha));
            parametros.Add(new MySqlParameter("@Hora", hora));
            parametros.Add(new MySqlParameter("@Medico", medico));
            parametros.Add(new MySqlParameter("@idcita", idcita));
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

        public string[] obtenerCita(int id)
        {
            string SqlQuery = "sp_obtener_cita";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pid", id));

            MySqlDataReader reader = findRecordsStoredProcedure(SqlQuery, parametros);

            string idpaciente = "";
            string fecha = "";
            string hora = "";
            string medico = "";
            while (reader.Read())
            {
                idpaciente = reader.GetInt16("idpaciente").ToString();
                fecha = reader.GetString("fecha");
                hora = reader.GetString("hora");
                medico = reader.GetString("medico");
            }
            string[] datos = new string[4];
            datos[0] = idpaciente;
            datos[1] = fecha;
            datos[2] = hora;
            datos[3] = medico;
            closeConexion();
            return datos;
        }

        public DataTable filtroCita(string pf)
        {
            string sql = "SELECT nombre as NombrePaciente,idcita as ClaveCita, fecha as Fecha, hora as Hora, medico as Medico FROM cita c, paciente p WHERE (idcita like ('%" + pf + "%') or c.idpaciente like ('%" + pf + "%') or fecha like ('%" + pf + "%') or hora like ('%" + pf + "%') or medico like ('%" + pf + "%') or nombre like ('%" + pf + "%')) and p.idpaciente = c.idpaciente";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }
        #endregion

        #region historias clinicas
        public DataTable datosParaGridHistoriasClinicas()
        {
            string sql = "SELECT idhistoriasclinicas as IDHistoria, nombre as NombrePaciente,h.idcita as ClaveCita, padecimiento as Padecimiento, tratamiento as Tratamiento, medico as NombreMedico FROM paciente p, cita c,historiasclinicas h WHERE  h.idcita=c.idcita and p.idpaciente=c.idpaciente";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }

        public void agregarHistoria(int idcita, string padecimiento, string tratamiento)
        {
            string SqlQuery = "INSERT INTO historiasclinicas(idcita,Padecimiento,tratamiento) VALUES(@IDcita,@Padecimiento,@tratamiento);";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@IDcita", idcita));
            parametros.Add(new MySqlParameter("@Padecimiento", padecimiento));
            parametros.Add(new MySqlParameter("@tratamiento", tratamiento));
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

        public void editarHistoria(int idh,int idcita, string padecimiento, string tratamiento)
        {
            string SqlQuery = "UPDATE historiasclinicas SET idcita = @IDcita,Padecimiento = @Padecimiento, tratamiento = @tratamiento WHERE idhistoriasclinicas = @id;";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@IDcita", idcita));
            parametros.Add(new MySqlParameter("@Padecimiento", padecimiento));
            parametros.Add(new MySqlParameter("@tratamiento", tratamiento));
            parametros.Add(new MySqlParameter("@id", idh));
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

        public string[] obtenerHistoria(int id)
        {
            string SqlQuery = "sp_obtener_historia";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pid", id));

            MySqlDataReader reader = findRecordsStoredProcedure(SqlQuery, parametros);

            string idcita = "";
            string padecimiento = "";
            string tratamiento = "";
            while (reader.Read())
            {
                idcita = reader.GetInt16("idcita").ToString();
                padecimiento = reader.GetString("Padecimiento");
                tratamiento = reader.GetString("tratamiento");
            }
            string[] datos = new string[4];
            datos[0] = idcita;
            datos[1] = padecimiento;
            datos[2] = tratamiento;
            closeConexion();
            return datos;
        }

        public DataTable filtroHistoria(string pf)
        {
            string sql = "SELECT idhistoriasclinicas as IDHistoria, nombre as NombrePaciente,h.idcita as ClaveCita, padecimiento as Padecimiento, tratamiento as Tratamiento, medico as NombreMedico FROM paciente p, cita c,historiasclinicas h WHERE (idhistoriasclinicas like ('%" + pf + "%') or nombre like ('%" + pf + "%') or h.idcita like ('%" + pf + "%') or padecimiento like ('%" + pf + "%') or tratamiento like ('%" + pf + "%') or medico like ('%" + pf + "%')) and (h.idcita=c.idcita and p.idpaciente=c.idpaciente)";
            DataTable datos = getListQuerySQL(sql, new List<MySqlParameter>());
            return datos;
        }
        #endregion

        #region reportes
        public DataTable datosParaGridReporte(string fecha1, string fecha2)
        {
            string sql = "SELECT medico as Medico, nombre as NombrePaciente,fecha as FechaCita, hora as HoraCita, padecimiento as Padecimiento, tratamiento as Tratamiento FROM paciente p, cita c,historiasclinicas h WHERE (h.idcita=c.idcita and p.idpaciente=c.idpaciente) and (fecha>=@Fecha1 and fecha<=@Fecha2)";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("@Fecha1", fecha1));
            parametros.Add(new MySqlParameter("@Fecha2", fecha2));
            DataTable datos = getListQuerySQL(sql, parametros);
            return datos;
        }

        public string[] obtenerDatosReceta(int id)
        {
            string SqlQuery = "sp_obtener_datosreceta";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pidh", id));

            MySqlDataReader reader = findRecordsStoredProcedure(SqlQuery, parametros);

            string nombre = "";
            string edad = "";
            string sexo = "";
            string ss = "";
            string medico = "";
            while (reader.Read())
            {
                nombre = reader.GetString("nombre");
                edad = reader.GetString("edad");
                sexo = reader.GetString("sexo");
                ss = reader.GetString("segurosocial");
                medico = reader.GetString("medico");
            }
            string[] datos = new string[5];
            datos[0] = nombre;
            datos[1] = edad;
            datos[2] = sexo;
            datos[3] = ss;
            datos[4] = medico;
            closeConexion();
            return datos;
        }
        #endregion
    }
}
