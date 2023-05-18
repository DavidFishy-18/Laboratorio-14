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
    public partial class Actualizar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Albumes> a = new List<Albumes>();

                a = LeerP();

                DropDownList1.DataSource = null;
                DropDownList1.DataValueField = "Artista";
                DropDownList1.DataTextField = "Titulo";
                DropDownList1.DataSource = a;
                DropDownList1.DataBind(); DropDownList2.Enabled = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Albumes> a = new List<Albumes>(); int ind = 0; DropDownList2.Enabled = true;

            a = LeerP();

            for (int i = 0; i < a.Count; i++) if (DropDownList1.SelectedValue.Equals(a[i].Artista)) ind = i;

            TextBox1.Text = a[ind].Titulo; TextBox2.Text = a[ind].Artista; TextBox3.Text = a[ind].Fecha;

            DropDownList2.DataSource = null;
            DropDownList2.DataValueField = "Nombre";
            DropDownList2.DataTextField = "Nombre";
            DropDownList2.DataSource = a[ind].C;
            DropDownList2.DataBind();
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

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Albumes> a = new List<Albumes>(); int ind = 0, ind2 = 0; DropDownList2.Enabled = true;

            a = LeerP();

            for(int i = 0; i < a.Count; i++) if(DropDownList1.SelectedValue.Equals(a[i].Artista)) ind = i;

            int cant = a[ind].C.Count;

            for(int i = 0; i < cant; i++) if(DropDownList2.SelectedValue.Equals(a[ind].C[i].Nombre)) ind2 = i;

            TextBox4.Text = a[ind].C[ind2].Nombre; TextBox5.Text = a[ind].C[ind2].Artista;
            TextBox6.Text = a[ind].C[ind2].Duracion;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Albumes> a = new List<Albumes>(); int ind = 0, ind2 = 0;

            a = LeerP();

            for (int i = 0; i < a.Count; i++) if(DropDownList1.SelectedValue.Equals(a[i].Artista)) ind = i;

            int cant = a[ind].C.Count;

            for (int i = 0; i < cant; i++) if(DropDownList2.SelectedValue.Equals(a[ind].C[i].Nombre)) ind2 = i;

            a[ind].Titulo = TextBox1.Text; a[ind].Artista = TextBox2.Text; a[ind].Fecha = TextBox3.Text;
            a[ind].C[ind2].Nombre = TextBox4.Text; a[ind].C[ind2].Artista = TextBox5.Text; a[ind].C[ind2].Duracion = TextBox6.Text;

            GrabarP(a); Response.Write("<script>alert('Album actualizado exitosamente')</script>");

            TextBox1.Text = ""; TextBox2.Text = ""; TextBox3.Text = ""; TextBox4.Text = ""; TextBox5.Text = ""; TextBox6.Text = "";
        }
    }
}