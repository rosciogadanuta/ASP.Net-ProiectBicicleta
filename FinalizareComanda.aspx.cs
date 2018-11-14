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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BicicleteWeb
{
    public partial class FinalizareComanda : System.Web.UI.Page
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
                        if (entry.Key.ToString().Equals("FinalizareComanda"))
                        {
                            lbFinalizareComanda.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("FinalizareComandaBtn"))
                        {
                            btnFinalizareComanda.Text = entry.Value.ToString();
                        }
                    }
                }
                this.BindRepeater();
            }
        }
        private void BindRepeater()
        {
            if (Session["dataTableComenzi"] != null)
            {
                DataTable dataTable = (DataTable)Session["dataTableComenzi"];
                repeater.DataSource = dataTable;
                repeater.DataBind();
            }
        }

        protected void btnFinalizareComanda_Click(object sender, EventArgs e)
        {
            lbFinalizare.Visible = true;

            using (var context = new Biciclete())
            {
                int userId = Int32.Parse(Session["UserId"].ToString());
                var com = new Comenzi();
                com.UserId = userId;
                com.Data = DateTime.Now;
                context.Comenzis.Add(com);
                if (Session["dataTableComenzi"] != null)
                {
                    DataTable dataTableComenzi = (DataTable)Session["dataTableComenzi"];
                    for (int i = 0; i < dataTableComenzi.Rows.Count; i++)
                    {
                        var comp = new ComandaProdu();
                        comp.ComandaId = com.ComandaId;
                        comp.ProdusId = Int32.Parse(dataTableComenzi.Rows[i]["ProdusId"].ToString());
                        comp.Cantitate = Int32.Parse(dataTableComenzi.Rows[i]["Cantitate"].ToString());
                        comp.PretCumparare = Decimal.Parse(dataTableComenzi.Rows[i]["Pret"].ToString());
                        context.ComandaProdus.Add(comp);
                        var culoare = new CuloareProdu();
                        culoare.CuloareId = Int32.Parse(dataTableComenzi.Rows[i]["Culoare"].ToString());
                        culoare.ProdusId = Int32.Parse(dataTableComenzi.Rows[i]["ProdusId"].ToString());
                        context.CuloareProdus.Add(culoare);
                    }
                }
                context.SaveChanges();
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["dataTableComenzi"] != null)
            {
                DataTable dataTable = (DataTable)Session["dataTableComenzi"];
                dataTable.Clear();
                Session["dataTableComenzi"] = dataTable;
            }
            Response.Redirect("HomePage.aspx");
        }


        protected void OnDelete(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int id = Int32.Parse((item.FindControl("lbId") as Label).Text);

            if (Session["dataTableComenzi"] != null)
            {
                DataTable datatable = (DataTable)Session["dataTableComenzi"];
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    if (Int32.Parse(datatable.Rows[i][0].ToString()) == id)
                    {
                        datatable.Rows.Remove(datatable.Rows[i]);
                    }
                }
            }
            this.BindRepeater();
        }


        protected void OnUpdate(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            HtmlTable tabelUpdate = (HtmlTable)FindControl("tabelUpdate");
            tabelUpdate.Attributes.Add("style", "visibility:visible");
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            lbModificaComanda.Visible = true;
            btnModificaComanda.Visible = true;
            int idProdus = int.Parse((item.FindControl("lbId") as Label).Text);
            Session["idProdusSelectat"] = idProdus;
            tbId.Text = (item.FindControl("lbId") as Label).Text;
            tbDenumire.Text = (item.FindControl("lbDenumire") as Label).Text;
            tbProducator.Text = (item.FindControl("lbProducator") as Label).Text;
            tbPret.Text = (item.FindControl("lbPret") as Label).Text;
            tbCuloare.BackColor = (item.FindControl("lbCuloare") as TextBox).BackColor;
            tbCantitate.Text = (item.FindControl("lbCantitate") as Label).Text;

            using (var context = new Biciclete())
            {
                var listaProduse = context.Produses.Select(p => new { p.ProdusId, Denumire=string.Concat(p.Denumire, ",", p.Producator) }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("ProdusId", typeof(Int32));
                dt.Columns.Add("Denumire", typeof(string));
                foreach (var p in listaProduse)
                {

                    dt.Rows.Add(p.ProdusId, p.Denumire.ToString());
                }
                ddlProduse.DataSource = dt;
                ddlProduse.DataTextField = "Denumire";
                ddlProduse.DataValueField = "ProdusId";
                ddlProduse.DataBind();
            }
        }


        protected void btnAdaugaProduse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Comanda.aspx");
        }

        protected void ddlProduse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = Int32.Parse(ddlProduse.SelectedValue);
            using(var context=new Biciclete())
            {
                var produs = context.Produses.Where(p => p.ProdusId == selectedIndex).FirstOrDefault();
                tbId.Text =produs.ProdusId.ToString();
                tbDenumire.Text = produs.Denumire.ToString();
                tbProducator.Text = produs.Producator.ToString();
                tbPret.Text = produs.Pret.ToString();
            }
        }

        protected void btnModificaComanda_Click(object sender, EventArgs e)
        {
            lbModificaComanda.Visible = false;
            btnModificaComanda.Visible = false;
            HtmlTable tabelUpdate = (HtmlTable)FindControl("tabelUpdate");
            tabelUpdate.Attributes.Add("style", "visibility:hidden");
            if (Session["dataTableComenzi"] !=null)
            {
                int idProdus = 0;
                if (Session["idProdusSelectat"] != null)
                {
                    idProdus =Int32.Parse(Session["idProdusSelectat"].ToString());
                }
                DataTable dt = (DataTable)Session["dataTableComenzi"];

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Int32.Parse(dt.Rows[i]["ProdusId"].ToString())==idProdus)
                    {
                        dt.Rows[i]["ProdusId"] = tbId.Text;
                        dt.Rows[i]["Denumire"] = tbDenumire.Text;
                        dt.Rows[i]["Producator"] = tbProducator.Text;
                        dt.Rows[i]["Pret"] = tbPret.Text;
                        if (tbCuloare.BackColor== System.Drawing.Color.Red)
                        {
                            dt.Rows[i]["Culoare"] = 1;
                        }
                        else
                        {
                            if (tbCuloare.BackColor == System.Drawing.Color.Green)
                            {
                                dt.Rows[i]["Culoare"] = 2;
                            }
                            else
                            {
                                if (tbCuloare.BackColor == System.Drawing.Color.Blue)
                                {
                                    dt.Rows[i]["Culoare"] = 3;
                                }
                                else
                                {
                                    dt.Rows[i]["Culoare"] = 4;
                                }
                            }
                        }
                        dt.Rows[i]["Cantitate"] = tbCantitate.Text;
                    }
                }
            }
            this.BindRepeater();
        }
    }
}