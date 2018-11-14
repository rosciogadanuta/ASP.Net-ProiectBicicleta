using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BicicleteWeb
{
    public partial class Comanda : System.Web.UI.Page
    {

        public DataTable dt;
        public string culoare;
        public StringBuilder stringBuilder;
        public DataTable dtCulori;
        public string url;

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {

            using (var context = new Biciclete())
            {
                var listaProduse = context.Produses.Where(p => p.Denumire.StartsWith(prefixText))
                    .Select(p => String.Concat(p.Denumire, ",", p.Producator)).ToList();
                return listaProduse;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((ResourceSet)Session["resourceSet"] != null)
                {
                    ResourceSet resourceSet = (ResourceSet)Session["resourceSet"];
                    foreach (DictionaryEntry entry in resourceSet)
                    {
                        if (entry.Key.ToString().Equals("CautaProdus"))
                        {
                            lbCautaProdus.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Produs"))
                        {
                            lDenumire.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Pret"))
                        {
                            lPret.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Producator"))
                        {
                            lProducator.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Culoare"))
                        {
                            lCuloare.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("AdaugaCos"))
                        {
                            btnAdauga.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("ProdusAdaugat"))
                        {
                            lbSalvareSucces.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Cantitate"))
                        {
                            lCantitate.Text = entry.Value.ToString();
                        }
                    }
                }
              
            }
        }

        [WebMethod]
        public static void SelectedColor(string param)
        {
            HttpContext.Current.Session["CuloareSelectata"] = param;
        }


        protected void btnAdauga_Click(object sender, EventArgs e)
        {
          
            tbAutocomplete.Text = String.Empty;
            lbSalvareSucces.Visible = true;
            lDenumire.Visible = false;
            lPret.Visible = false;
            lProducator.Visible = false;
            btnCresteCantitate.Visible = false;
            btnScadeCantitate.Visible = false;
            lCantitate.Visible = false;
            lCuloare.Visible = false;
            lbDenumire.Visible = false;
            lbPret.Visible = false;
            lbProducator.Visible = false;


            if (Session["dataTableComenzi"] == null)
            {
                string cantitateSelectata = String.Format("{0}", Request.Form["text"]);
                int culoareSelectata = 1;
                if (HttpContext.Current.Session["CuloareSelectata"] != null)
                {
                    culoareSelectata = Int32.Parse(HttpContext.Current.Session["CuloareSelectata"].ToString());
                }
                DataTable dataTable = new DataTable();
                DataColumn columnId = new DataColumn("ProdusId");
                DataColumn columnDenumire = new DataColumn("Denumire");
                DataColumn columnPret = new DataColumn("Pret");
                DataColumn columnProducator = new DataColumn("Producator");
                DataColumn columnCantitate = new DataColumn("Cantitate");
                DataColumn columnCuloare = new DataColumn("Culoare");
                dataTable.Columns.Add(columnId);
                dataTable.Columns.Add(columnDenumire);
                dataTable.Columns.Add(columnPret);
                dataTable.Columns.Add(columnProducator);
                dataTable.Columns.Add(columnCantitate);
                dataTable.Columns.Add(columnCuloare);
                DataRow dataRow = dataTable.NewRow();
                if (Session["produsId"] != null)
                {
                    dataRow["ProdusId"] = Int32.Parse(Session["produsId"].ToString());
                    Session["produsId"] = null;
                }
                dataRow[columnDenumire.ColumnName] = lbDenumire.Text;
                dataRow[columnPret.ColumnName] = lbPret.Text;
                dataRow[columnProducator.ColumnName] = lbProducator.Text;
                dataRow[columnCantitate.ColumnName] = cantitateSelectata;
                dataRow[columnCuloare.ColumnName] = culoareSelectata;
                dataTable.Rows.Add(dataRow);
                Session["dataTableComenzi"] = dataTable;
            }
            else
            {
                DataTable dataTable = (DataTable)Session["dataTableComenzi"];
                string cantitateSelectata = String.Format("{0}", Request.Form["text"]);
                int culoareSelectata = 1;
                if (HttpContext.Current.Session["CuloareSelectata"] != null)
                {
                    culoareSelectata = Int32.Parse(HttpContext.Current.Session["CuloareSelectata"].ToString());
                }
                DataRow dataRow = dataTable.NewRow();
                if (Session["produsId"] != null)
                {
                    dataRow["ProdusId"] = Int32.Parse(Session["produsId"].ToString());
                    Session["produsId"] = null;
                }
                dataRow["Denumire"] = lbDenumire.Text;
                dataRow["Pret"] = lbPret.Text;
                dataRow["Producator"] = lbProducator.Text;
                dataRow["Cantitate"] = cantitateSelectata;
                dataRow["Culoare"] = culoareSelectata;
                dataTable.Rows.Add(dataRow);
                Session["dataTableComenzi"] = dataTable;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("HomePage.aspx");
        }

        protected void btnAutocomplete_Click(object sender, EventArgs e)
        {
            //make labels visible
            lbSalvareSucces.Visible = false;
            btnCresteCantitate.Visible = true;
            btnScadeCantitate.Visible = true;
            btnAdauga.Visible = true;
            lPret.Visible = true;
            lProducator.Visible = true;
            lDenumire.Visible = true;
            lCuloare.Visible = true;
            lCantitate.Visible = true;
            lbDenumire.Visible = true;
            lbPret.Visible = true;
            lbProducator.Visible = true;
            
            
            string tbAutocompleteText = tbAutocomplete.Text;
            string[] splitText = tbAutocompleteText.Split(',');
            String denumire = (String)splitText[0].ToString();
            String producator = (String)splitText[1].ToString();

            using(var context=new Biciclete())
            {
                //gasire produsul selectat din lista
                var id = context.Produses.Where(p => p.Denumire == denumire.Trim() && p.Producator == producator.Trim()).FirstOrDefault();
                Session["produsId"] = id.ProdusId;

                //completarea campurilor
                var produsSelectat = context.Produses.Where(p => p.ProdusId == id.ProdusId).FirstOrDefault();
                lbDenumire.Text = produsSelectat.Denumire;
                lbPret.Text = produsSelectat.Pret.ToString();
                lbProducator.Text = produsSelectat.Producator;
                dt = new DataTable();
                dt.Columns.Add("Url", typeof(string));
                dt.Rows.Add(produsSelectat.Url);

                dtCulori = new DataTable();
                dtCulori.Columns.Add("CuloareId", typeof(Int32));
                dtCulori.Columns.Add("Denumire", typeof(string));
                var culori=context.Culoris.ToList();
                foreach(var itm in culori){
                    dtCulori.Rows.Add(itm.CuloareId, itm.Denumire);
                }
                Session["dtCulori"] = dtCulori;
                stringBuilder = new StringBuilder();
                stringBuilder.Append("<ul style='margin-left:250px'>");
                for (int i = 0; i < dtCulori.Rows.Count; i++)
                {
                    stringBuilder.Append("<li id='id" + dtCulori.Rows[i]["CuloareId"].ToString() + "' style='background-color:" + dtCulori.Rows[i]["Denumire"].ToString() + ";border-width:2px;border-style:solid; border-color:white; width:5%;' onclick='getSelectedLi(" + dtCulori.Rows[i]["CuloareId"].ToString() + "); return false;'></li>");

                }
                stringBuilder.Append("</ul");
            }
        }
    }
}








