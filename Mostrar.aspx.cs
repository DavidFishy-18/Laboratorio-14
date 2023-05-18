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
    public partial class Mostrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Albumes> a = new List<Albumes>();

            a = LeerP();

            GridView1.DataSource = null;
            GridView1 .DataSource = a; 
            GridView1.DataBind();

            if (!IsPostBack)
            {
                DropDownList1.DataSource = null;
                DropDownList1.DataValueField = "Artista";
                DropDownList1.DataTextField = "Titulo";
                DropDownList1.DataSource = a;
                DropDownList1.DataBind();
            }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ind = DropDownList1.SelectedIndex; List<Albumes> a = new List<Albumes>();

            a = LeerP();

            GridView2.DataSource = null;
            GridView2.DataSource = a[ind].C;
            GridView2.DataBind();
        }
    }
}