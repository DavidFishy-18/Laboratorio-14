using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio__14
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Canciones> c = new List<Canciones>();

            c = LeerC();

            if(c == null) c = new List<Canciones>();

            Canciones c1 = new Canciones();

            c1.Nombre = TextBox4.Text; c1.Artista = TextBox5.Text; c1.Duracion = TextBox6.Text;

            c.Add(c1); GrabarC(c); Response.Write("<script>alert('Cancion agregada exitosamente')</script>");
            TextBox4.Text = ""; TextBox5.Text = ""; TextBox6.Text = "";
        }

        private List<Canciones> LeerC()
        {
            List<Canciones> l = new List<Canciones>();
            string archivo = Server.MapPath("Temp.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            l = JsonConvert.DeserializeObject<List<Canciones>>(json);

            return l;
        }

        private void GrabarC(List<Canciones> c)
        {
            string json = JsonConvert.SerializeObject(c);
            string archivo = Server.MapPath("Temp.json");
            System.IO.File.WriteAllText(archivo, json);
        }

        private List<Albumes> LeerP()
        {
            List<Albumes> l = new List<Albumes>();
            string archivo = Server.MapPath("Albumes.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            l = JsonConvert.DeserializeObject<List<Albumes>>(json);

            return l;
        }

        private void GrabarP(List<Albumes> c)
        {
            string json = JsonConvert.SerializeObject(c);
            string archivo = Server.MapPath("Albumes.json");
            System.IO.File.WriteAllText(archivo, json);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Albumes> a = new List<Albumes>();
            List<Canciones> c = new List<Canciones>();

            a = LeerP();
            c = LeerC();

            if(a == null) a = new List<Albumes>();

            Albumes al = new Albumes();

            al.Titulo = TextBox1.Text; al.Artista = TextBox2.Text; al.C = c; al.Fecha = TextBox3.Text;

            a.Add(al); GrabarP(a); c.Clear(); GrabarC(c); TextBox1.Text = ""; TextBox2.Text = ""; TextBox3.Text = "";
            Response.Write("<script>alert('Album registrado exitosamente')</script>");
        }
    }
}