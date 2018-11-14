using DBUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BicicleteWeb
{
    public partial class AdministreazaConturi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((ResourceSet)Session["resourceSet"] != null)
                {
                    ResourceSet resourceSet = (ResourceSet)Session["resourceSet"];
                    foreach (DictionaryEntry entry in resourceSet)
                    {
                        if (entry.Key.ToString().Equals("GestioneazaCereri"))
                        {
                            lbGestionareUseri.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Nume"))
                        {
                            gvUsers.Columns[1].HeaderText = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Parola"))
                        {
                            gvUsers.Columns[2].HeaderText = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Email"))
                        {
                            gvUsers.Columns[3].HeaderText = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Data"))
                        {
                            gvUsers.Columns[4].HeaderText = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Activ"))
                        {
                            gvUsers.Columns[5].HeaderText = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Aprobat"))
                        {
                            gvUsers.Columns[6].HeaderText = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Admin"))
                        {
                            gvUsers.Columns[7].HeaderText = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Actiuni"))
                        {
                            gvUsers.Columns[8].HeaderText = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Inactivi"))
                        {
                            RadioButton1.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Neaprobati"))
                        {
                            RadioButton2.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Filtre"))
                        {
                            lbFiltreazaGridView.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("InactiviNeaprobati"))
                        {
                            RadioButton3.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("TotiUtilizatorii"))
                        {
                            RadioButton4.Text = entry.Value.ToString();
                        }

                    }

                }
                using (var context = new Biciclete())
                {
                    var lista = context.Users.ToList();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("UserId", typeof(Int32));
                    dt.Columns.Add("Nume", typeof(string));
                    dt.Columns.Add("Parola", typeof(string));
                    dt.Columns.Add("Email", typeof(string));
                    dt.Columns.Add("Data", typeof(DateTime));
                    dt.Columns.Add("Activ", typeof(bool));
                    dt.Columns.Add("Aprobat", typeof(bool));
                    dt.Columns.Add("Admin", typeof(bool));
                    foreach (var item in lista)
                    {
                        dt.Rows.Add(item.UserId, item.Nume, item.Parola, item.Email, item.Data, item.Activ, item.Aprobat, item.Admin);
                    }
                    gvUsers.DataSource = dt;
                    gvUsers.DataBind();
                }
            }
        }
        //Show Grid View
        public void ShowGrid()
        {
            if ((ResourceSet)Session["resourceSet"] != null)
            {
                ResourceSet resourceSet = (ResourceSet)Session["resourceSet"];
                foreach (DictionaryEntry entry in resourceSet)
                {
                    if (entry.Key.ToString().Equals("GestioneazaCereri"))
                    {
                        lbGestionareUseri.Text = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Nume"))
                    {
                        gvUsers.Columns[1].HeaderText = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Parola"))
                    {
                        gvUsers.Columns[2].HeaderText = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Email"))
                    {
                        gvUsers.Columns[3].HeaderText = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Data"))
                    {
                        gvUsers.Columns[4].HeaderText = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Activ"))
                    {
                        gvUsers.Columns[5].HeaderText = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Aprobat"))
                    {
                        gvUsers.Columns[6].HeaderText = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Admin"))
                    {
                        gvUsers.Columns[7].HeaderText = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Actiuni"))
                    {
                        gvUsers.Columns[8].HeaderText = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Inactivi"))
                    {
                        RadioButton1.Text = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Neaprobati"))
                    {
                        RadioButton2.Text = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("Filtre"))
                    {
                        lbFiltreazaGridView.Text = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("InactiviNeaprobati"))
                    {
                        RadioButton3.Text = entry.Value.ToString();
                    }
                    if (entry.Key.ToString().Equals("TotiUtilizatorii"))
                    {
                        RadioButton4.Text = entry.Value.ToString();
                    }
                }
            }
            using (var context = new Biciclete())
            {
                var lista = context.Users.ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserId", typeof(Int32));
                dt.Columns.Add("Nume", typeof(string));
                dt.Columns.Add("Parola", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));
                dt.Columns.Add("Activ", typeof(bool));
                dt.Columns.Add("Aprobat", typeof(bool));
                dt.Columns.Add("Admin", typeof(bool));
                foreach (var item in lista)
                {
                    dt.Rows.Add(item.UserId, item.Nume, item.Parola, item.Email, item.Data, item.Activ, item.Aprobat, item.Admin);
                }
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        //Filtreaza Useri Inactivi pe RadioButton
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Biciclete())
            {
                var lista = context.Users.Where(u => u.Activ == false).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserId", typeof(Int32));
                dt.Columns.Add("Nume", typeof(string));
                dt.Columns.Add("Parola", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));
                dt.Columns.Add("Activ", typeof(bool));
                dt.Columns.Add("Aprobat", typeof(bool));
                dt.Columns.Add("Admin", typeof(bool));
                foreach (var item in lista)
                {
                    dt.Rows.Add(item.UserId, item.Nume, item.Parola, item.Email, item.Data, item.Activ, item.Aprobat, item.Admin);
                }
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        //Filtreaza Useri Neaprobati pe RadioButton
        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Biciclete())
            {
                var lista = context.Users.Where(u => u.Aprobat == false).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserId", typeof(Int32));
                dt.Columns.Add("Nume", typeof(string));
                dt.Columns.Add("Parola", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));
                dt.Columns.Add("Activ", typeof(bool));
                dt.Columns.Add("Aprobat", typeof(bool));
                dt.Columns.Add("Admin", typeof(bool));
                foreach (var item in lista)
                {
                    dt.Rows.Add(item.UserId, item.Nume, item.Parola, item.Email, item.Data, item.Activ, item.Aprobat, item.Admin);
                }
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        //Filtreaza Useri Inactivi si Neaprobati pe RadioButton
        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Biciclete())
            {
                var lista = context.Users.Where(u => u.Activ == false && u.Aprobat==false).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserId", typeof(Int32));
                dt.Columns.Add("Nume", typeof(string));
                dt.Columns.Add("Parola", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));
                dt.Columns.Add("Activ", typeof(bool));
                dt.Columns.Add("Aprobat", typeof(bool));
                dt.Columns.Add("Admin", typeof(bool));
                foreach (var item in lista)
                {
                    dt.Rows.Add(item.UserId, item.Nume, item.Parola, item.Email, item.Data, item.Activ, item.Aprobat, item.Admin);
                }
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }

        }
        //Filtreaza AllUsers pe RadioButton
        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Biciclete())
            {
                var lista = context.Users.ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserId", typeof(Int32));
                dt.Columns.Add("Nume", typeof(string));
                dt.Columns.Add("Parola", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));
                dt.Columns.Add("Activ", typeof(bool));
                dt.Columns.Add("Aprobat", typeof(bool));
                dt.Columns.Add("Admin", typeof(bool));
                foreach (var item in lista)
                {
                    dt.Rows.Add(item.UserId, item.Nume, item.Parola, item.Email, item.Data, item.Activ, item.Aprobat, item.Admin);
                }
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Traduce butoanele in engleza
                if ((ResourceSet)Session["resourceSet"] != null)
                {
                    ResourceSet resourceSet = (ResourceSet)Session["resourceSet"];
                    foreach (DictionaryEntry entry in resourceSet)
                    {
                        if (entry.Key.ToString().Equals("Activ"))
                        {
                            LinkButton btnActiv1 = (LinkButton)e.Row.FindControl("btnActiv");
                            btnActiv1.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Inactiv"))
                        {
                            LinkButton btnInactiv1 = (LinkButton)e.Row.FindControl("btnInactiv");
                            btnInactiv1.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Aprobat"))
                        {
                            LinkButton btnAprobat1 = (LinkButton)e.Row.FindControl("btnAprobat");
                            btnAprobat1.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Respins"))
                        {
                            LinkButton btnRespins1 = (LinkButton)e.Row.FindControl("btnRespins");
                            btnRespins1.Text = entry.Value.ToString();
                        }
                    }
                }
                //Gasire linkBtn si atribuire Id
                DataRowView rand = (DataRowView)e.Row.DataItem;
                string id = rand["UserID"].ToString();
                LinkButton btnActiv = (LinkButton)e.Row.FindControl("btnActiv");
                if (btnActiv != null)
                {
                    btnActiv.CommandArgument = id;
                }
                LinkButton btnInactiv = (LinkButton)e.Row.FindControl("btnInactiv");
                if (btnInactiv != null)
                {
                    btnInactiv.CommandArgument = id;
                }
                LinkButton btnAprobat = (LinkButton)e.Row.FindControl("btnAprobat");
                if (btnAprobat != null)
                {
                    btnAprobat.CommandArgument = id;
                }
                LinkButton btnRespins = (LinkButton)e.Row.FindControl("btnRespins");
                if (btnRespins != null)
                {
                    btnRespins.CommandArgument = id;
                }

            }

        }

        //Gestioneaza butoane de actiuni
        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Activ")
            {
                string id = e.CommandArgument.ToString();
                int idi = Int32.Parse(id);

                using (var context=new Biciclete())
                {
                    var user = context.Users.Where(u => u.UserId ==idi).SingleOrDefault();

                    user.Activ = true;
                    context.SaveChanges();
                }
                if (RadioButton1.Checked)
                {
                    RadioButton1_CheckedChanged(sender, e);
                }
                else if (RadioButton2.Checked)
                {
                    RadioButton2_CheckedChanged(sender, e);
                }
                else if (RadioButton3.Checked)
                {
                    RadioButton3_CheckedChanged(sender, e);
                }
                else
                {
                    ShowGrid();
                }

            }
            if (e.CommandName == "Inactiv")
            {
                string id = e.CommandArgument.ToString();
                int idi = Int32.Parse(id);

                using (var context = new Biciclete())
                {
                    var user = context.Users.Where(u => u.UserId == idi).SingleOrDefault();

                    user.Activ = false;
                    context.SaveChanges();
                }
                if (RadioButton1.Checked)
                {
                    RadioButton1_CheckedChanged(sender, e);
                }
                else if (RadioButton2.Checked)
                {
                    RadioButton2_CheckedChanged(sender, e);
                }
                else if (RadioButton3.Checked)
                {
                    RadioButton3_CheckedChanged(sender, e);
                }
                else
                {
                    ShowGrid();
                }
            }
            if (e.CommandName == "Aprobat")
            {
                string id = e.CommandArgument.ToString();
                int idi = Int32.Parse(id);

                using (var context = new Biciclete())
                {
                    var user = context.Users.Where(u => u.UserId == idi).SingleOrDefault();

                    user.Aprobat = true;
                    context.SaveChanges();
                }
                if (RadioButton1.Checked)
                {
                    RadioButton1_CheckedChanged(sender, e);
                }
                else if (RadioButton2.Checked)
                {
                    RadioButton2_CheckedChanged(sender, e);
                }
                else if (RadioButton3.Checked)
                {
                    RadioButton3_CheckedChanged(sender, e);
                }
                else
                {
                    ShowGrid();
                }
            }
            if (e.CommandName == "Respins")
            {
                string id = e.CommandArgument.ToString();
                int idi = Int32.Parse(id);

                using (var context = new Biciclete())
                {
                    var user = context.Users.Where(u => u.UserId == idi).SingleOrDefault();

                    user.Aprobat = false;
                    context.SaveChanges();
                }
                LinkButton ctrl = e.CommandSource as LinkButton;
                if (ctrl != null)
                {
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    row.BackColor = System.Drawing.Color.Red;
                    LinkButton btnRespins = (LinkButton)row.FindControl("btnRespins");
                    gvUsers.Controls.Remove(btnRespins);
                }
                if (RadioButton1.Checked)
                {
                    RadioButton1_CheckedChanged(sender, e);
                }
                else if (RadioButton2.Checked)
                {
                    RadioButton2_CheckedChanged(sender, e);
                }
                else if (RadioButton3.Checked)
                {
                    RadioButton3_CheckedChanged(sender, e);
                }
                else
                {
                    ShowGrid();
                }
            }
        }
    }
}