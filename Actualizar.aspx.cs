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
            List<Albumes> a = new List<Albumes>();

            a = LeerP();

            DropDownList1.DataSource = null;
            DropDownList1.DataValueField = "Artista";
            DropDownList1.DataTextField = "Titulo";
            DropDownList1.DataSource = a;
            DropDownList1.DataBind(); DropDownList2.Enabled = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Albumes> a = new List<Albumes>(); int ind = 0; DropDownList2.Enabled = true;

            a = LeerP();

            for(int i = 0; i < a.Count; i++) if(DropDownList1.SelectedValue.Equals(a[i].Artista)) ind = i;

            TextBox1.Text = a[ind].Titulo; TextBox2.Text = a[ind].Artista; TextBox3.Text = a[ind].Fecha;

            DropDownList1.DataSource = null;
            DropDownList1.DataValueField = "Artista";
            DropDownList1.DataTextField = "Nombre";
            DropDownList1.DataSource = a[ind].C;
            DropDownList1.DataBind(); DropDownList2.Enabled = false;
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
    }
}