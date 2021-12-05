using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AgendaXMLCSharp
{
    class xmlOperaciones
    {
        string xmlRuta;
        XmlDocument documento;
        
        //Constructor
        public xmlOperaciones(string ruta)
        {
            this.xmlRuta = ruta;
            documento = new XmlDocument();
        }
        
        //Método para crear un archivo XML 
        public void crearXml(string ruta) {
            XmlDeclaration xmlDeclaration = documento.CreateXmlDeclaration("1.0","UTF-8", null);
            
            XmlNode root = documento.DocumentElement;
            documento.InsertBefore(xmlDeclaration,root);

            XmlNode element1 = documento.CreateElement("persona");
            documento.AppendChild(element1);
            documento.Save(ruta);
        }

        //Métodos para agregar un nuevo nodo
        public void addElemento(string id, string nom, string dom, string tel, string email) {
            documento.Load(xmlRuta);
            XmlNode contacto = crearContacto(id, nom, dom,tel, email);
            XmlNode nodoRaiz = documento.DocumentElement;
            nodoRaiz.InsertAfter(contacto, nodoRaiz.LastChild);
            documento.Save(xmlRuta);
        }

        private XmlNode crearContacto(string id, string nom, string dom, string tel, string email) {
            XmlNode contacto = documento.CreateElement("contacto");

            XmlElement xid = documento.CreateElement("id");
            xid.InnerText = id;
            contacto.AppendChild(xid);

            XmlElement xnombre = documento.CreateElement("nombre");
            xnombre.InnerText = nom;
            contacto.AppendChild(xnombre);

            XmlElement xdomicilio = documento.CreateElement("domicilio");
            xdomicilio.InnerText = dom;
            contacto.AppendChild(xdomicilio);

            XmlElement xtelefono = documento.CreateElement("telefono");
            xtelefono.InnerText = tel;
            contacto.AppendChild(xtelefono);

            XmlElement xemail = documento.CreateElement("correo");
            xemail.InnerText = email;
            contacto.AppendChild(xemail);

            return contacto;
        }

        //Método para obtener los elementos del xml
        public string[] leerXML() {
            documento.Load(xmlRuta);
            XmlNodeList listaContactos = documento.SelectNodes("persona/contacto");
            XmlNode unContacto;
            string[] registro = new string[listaContactos.Count];
            for (int i = 0; i < listaContactos.Count; i++)
            {
                unContacto = listaContactos.Item(i);
                registro[i] = unContacto.SelectSingleNode("id").InnerText + "," +
                    unContacto.SelectSingleNode("nombre").InnerText + "," +
                    unContacto.SelectSingleNode("domicilio").InnerText + "," +
                    unContacto.SelectSingleNode("telefono").InnerText + "," +
                    unContacto.SelectSingleNode("correo").InnerText;
            }
            return registro;
        }

        //Método para borrar un elemento de un archivo xml
        public void borrarElemento(string id) {
            documento.Load(xmlRuta);
            XmlNode contacto = documento.DocumentElement;
            XmlNodeList listaContactos = documento.SelectNodes("persona/contacto");

            foreach (XmlNode item in listaContactos)
            {
                if (item.SelectSingleNode("id").InnerText == id)
                {
                    XmlNode nodoOld = item;
                    contacto.RemoveChild(nodoOld);
                }
            }
            documento.Save(xmlRuta);
        }

        //Metodo para modificar los datos de un elemento del archivo xml
        public void actualizarXML(string id, string nom, string dom, string tel, string email)
        {
            documento.Load(xmlRuta);
            XmlNode contacto = documento.DocumentElement;
            XmlNodeList listaContactos = documento.SelectNodes("persona/contacto");
            XmlNode nodoNew = crearContacto(id, nom, dom, tel, email);

            foreach (XmlNode item in listaContactos)
            {
                if (item.FirstChild.InnerText == id)
                {
                    XmlNode nodoOld = item;
                    contacto.ReplaceChild(nodoNew, nodoOld);
                }
            }
            documento.Save(xmlRuta);
        }
    }
}
