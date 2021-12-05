using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArchivoAccesoDirecto
{
    class Program
    {
        public static int pos = 0; //Posición del archivo
        class Estudiante
        {
            #region Atributos
                private string _stnumero;
                private string _stnombre;
                private int _recordSize;
            #endregion

            #region Propiedades
                public string StNumero {
                    get {
                        return _stnumero;
                    }
                    set {
                        _stnumero = value;
                    }
                }
                public string StNombre
                {
                    get
                    {
                        return _stnombre;
                    }
                    set
                    {
                        _stnombre = value;
                    }
                }
                public int RecordSize
                {
                    get
                    {
                        return _recordSize;
                    }
                }
            #endregion
            /// <summary>
            /// inicializa un objeto Estudiante
            /// </summary>
            /// <param name="numero">Numero de control del estudiante</param>
            /// <param name="nombre">Nombre del estudiante</param>
            #region Constructores
                public Estudiante(string numero, string nombre) {
                    StNumero = numero;
                    StNombre = nombre;
                    _recordSize = 2 * 15 + 2 * 20;
                }
                /// <summary>
                /// Constructor que inicializa el objeto Estudiante con valores arbitrarios
                /// </summary>
                public Estudiante() : this("¿Numero?", "¿Nombre?") { 
                    
                }
            #endregion

        }//Fin Estudiante

        //Metodo para escribir en el archivo
        
        /// <summary>
        /// Permite agregar un nuevo registro a un archivo especificado.
        /// En caso de no existir el archivo lo crea.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo a actualizar</param>
        /// <param name="objeto">Estudiante a ingresar</param>
        /// <param name="posicion">Posición del archivo a almacenar</param>
        /// <param name="tamaño">Tamaño del archivo</param>
        static void writeToFile(string nombreArchivo, Estudiante objeto, int posicion, int tamaño)
        {
            try
            {
                FileStream fout;
                BinaryWriter bw;

                //Nuevo flujo de datos asociado a un archivo
                fout = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);
                //Crea un nuevo objeto de tipo binrio asociado a un archivo especifico
                bw = new BinaryWriter(fout);
                //establece la posición en el archivo donde se escribirá el registro
                fout.Position = posicion * tamaño;
                //Se escribe el registro en el archivo
                bw.Write(objeto.StNumero);
                bw.Write(objeto.StNombre);
                //Se cierra el flujo de datos y el archivo
                bw.Close();
                fout.Close();
            }
            catch (Exception es) //controlamos lo  que pueda ocurrir
            {
                Console.WriteLine("Error al registrar el nuevo estudiante. \n"+"\nPresiona cualquier tecla para volver al menú.");
                Console.ReadLine();
            }
        }//Fin WriteToFile

        /// <summary>
        /// Lee los registros de un archivo especifico y los muestra en pantalla
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        static void readFromFile(string nombreArchivo) {
            try
            {
                if (File.Exists(nombreArchivo))
                {
                    FileStream fn;
                    BinaryReader br;
                    Estudiante stu = new Estudiante();

                    int registroActual = 0;
                    fn = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fn);

                    int i;

                    for (i = 1; i <= (int)(fn.Length) / stu.RecordSize; i++)
                    {
                        registroActual += 1;
                        fn.Seek(registroActual * stu.RecordSize, 0);
                        stu.StNumero = br.ReadString().ToString();
                        stu.StNombre = br.ReadString().ToString();
                        Console.WriteLine("\n" + stu.StNumero + "\t" + stu.StNombre);
                    }//end for

                    //actualiza la variable pos del registro actual
                    pos = registroActual;

                    //cierra los objetos
                    br.Close();
                    fn.Close();
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú.");
                    Console.ReadLine();
                }
                else
                    throw new Exception("No hay estudiante para consulta.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nPresiona cualquier tecla para volver al menú.");
                Console.ReadLine();
            }
        }//Fin ReadFromFile

        /// <summary>
        /// Permitira agregar un nuevo registro estudiante
        /// </summary>
        /// <param name="args"></param>
        static void agregarRegistro() {
            Estudiante nuevoEst = new Estudiante();
            string con = "y";
            while (con == "y")
            {
                Console.Write("Introduce el numero de control del estudiante: ");
                nuevoEst.StNumero = Console.ReadLine();
                Console.Write("Introduce el nombre del estudiante: ");
                nuevoEst.StNombre = Console.ReadLine();
                pos += 1; //actualiza la posición

                //Si el arhivo no existe
                string ruta = "C:\\Users\\falco\\Documents\\Visual Studio 2012\\Projects\\ArchivoAccesoDirecto\\Estudiante.txt";
                if (!File.Exists(@ruta))
                    File.Create(@ruta).Close();
                //llamada al método que permite escribir en el archivo
                writeToFile(@ruta,nuevoEst,pos,nuevoEst.RecordSize);
                Console.WriteLine("\n¿Continuar? y/n: ");
                con = Console.ReadLine();
            }

            Console.WriteLine("\nPresiona cualquier tecla para volver al menú.");
            Console.ReadLine();
        }//fin addRegistro

        /// <summary>
        /// Menú
        /// </summary>
        static void Main(string[] args)
        {
            char op = 'n';
            do
            {
                Console.Write("\nPractica 1 Manipulación de Archivo de Acceso Directo. \n");
                Console.Write("\nAgregar un nuevo estudiante.........................1");
                Console.Write("\nConsultar Estudiantes registrados...................2");
                Console.Write("\nSalir...............................................3\n");
                Console.Write("\nSeleccione una opción: ");
                op = Convert.ToChar(Console.ReadLine().ToString());
                switch (op)
                {
                    case '1': Console.Clear(); agregarRegistro(); break;
                    case '2': Console.Clear(); readFromFile("C:\\Users\\falco\\Documents\\Visual Studio 2012\\Projects\\ArchivoAccesoDirecto\\Estudiante.txt"); break;
                    case '3': Console.Clear(); Console.Write("Cerrando el sistema.") ; break;
                    default: Console.Clear(); Console.Write("Opción no valida, intente de nuevo."); break;
                }
            } while (op!='3');
        }
    }
}
