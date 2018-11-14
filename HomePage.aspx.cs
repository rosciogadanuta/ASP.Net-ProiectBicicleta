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
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BicicleteWeb
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserId"] != null)
            {
                int id = Int32.Parse(Session["UserId"].ToString());
                using (var context = new Biciclete())
                {
                    if (ViewState["top"] == null)
                    {
                        ViewState.Add("top", 3);
                        var listaComenzi = (from comenzi in context.Comenzis
                                            join comenziProdus in context.ComandaProdus on comenzi.ComandaId equals comenziProdus.ComandaId
                                            where comenzi.UserId == id                
                                            group new { comenzi, comenziProdus } by new { comenzi.ComandaId, comenzi.Data } into x
                                            select new
                                            {
                                                x.Key.ComandaId,
                                                x.Key.Data,
                                                Valoare = x.Sum(c => c.comenziProdus.Cantitate * c.comenziProdus.PretCumparare)
                                            }).ToList().OrderByDescending(x => x.Data).Take(3);
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ComandaId", typeof(Int32));
                        dt.Columns.Add("Data", typeof(DateTime));
                        dt.Columns.Add("Valoare", typeof(Decimal));
                        foreach (var itm in listaComenzi)
                        {
                            dt.Rows.Add(itm.ComandaId, itm.Data, itm.Valoare);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            gvComenzi.DataSource = dt;
                            gvComenzi.DataBind();
                        }
                        else
                        {
                            lbNuExistaComenzi.Visible = true;
                        }
                    }
                    else
                    {
                        var controlName = Request.Form["__EVENTTARGET"];
                        if (controlName.Equals("btnMaiMult"))
                        {
                            int top = Int32.Parse(ViewState["top"].ToString());
                            top += 3;
                            ViewState.Add("top", top);
                            var listaComenzi = (from comenzi in context.Comenzis
                                                join comenziProdus in context.ComandaProdus on comenzi.ComandaId equals comenziProdus.ComandaId
                                                where comenzi.UserId == id
                                                group new { comenzi, comenziProdus } by new { comenzi.ComandaId, comenzi.Data } into x    
                                                select new
                                                {
                                                    x.Key.ComandaId,
                                                    x.Key.Data,
                                                    Valoare = x.Sum(c => c.comenziProdus.Cantitate * c.comenziProdus.PretCumparare)
                                                }).ToList().OrderByDescending(x=>x.Data).Take(top);
                            DataTable dt = new DataTable();
                            dt.Columns.Add("ComandaId", typeof(Int32));
                            dt.Columns.Add("Data", typeof(DateTime));
                            dt.Columns.Add("Valoare", typeof(Decimal));
                            foreach (var itm in listaComenzi)
                            {
                                dt.Rows.Add(itm.ComandaId, itm.Data, itm.Valoare);
                            }
                            gvComenzi.DataSource = dt;
                            gvComenzi.DataBind();

                        }
                    }
                }   
                if (!IsPostBack)
                {
                    if ((ResourceSet)Session["resourceSet"] != null)
                    {
                        ResourceSet resourceSet = (ResourceSet)Session["resourceSet"];
                        foreach (DictionaryEntry entry in resourceSet)
                        {
                            if (entry.Key.ToString().Equals("AdministreazaConturi"))
                            {
                                btnAdministreazaConturi.Text = entry.Value.ToString();
                            }
                            if (entry.Key.ToString().Equals("NuAdmin"))
                            {
                                lbNuAdmin.Text = entry.Value.ToString();
                            }
                            if (entry.Key.ToString().Equals("maiMult"))
                            {
                                btnMaiMult.Text = entry.Value.ToString();
                            }
                            if (entry.Key.ToString().Equals("Data"))
                            {
                                gvComenzi.Columns[1].HeaderText = entry.Value.ToString();
                            }
                            if (entry.Key.ToString().Equals("ValoareComanda"))
                            {
                                gvComenzi.Columns[2].HeaderText = entry.Value.ToString();
                            }
                            if (entry.Key.ToString().Equals("Detalii"))
                            {
                                gvComenzi.Columns[3].HeaderText = entry.Value.ToString();
                            }
                            if (entry.Key.ToString().Equals("AdaugaComanda"))
                            {
                                btnAdaugaComanda.Text = entry.Value.ToString();
                            }
                            if (entry.Key.ToString().Equals("NuExistaComenzi"))
                            {
                                lbNuExistaComenzi.Text = entry.Value.ToString();
                            }
                            gvComenzi.DataBind();
                        }
                    }
                }
            }
        }
        protected void btnAdministreazaConturi_Click(object sender, EventArgs e)
        {

            if (Session["UserId"] != null)
            {
                if ((Session["UserId"].ToString()) != null)
                {
                    int userId = Int32.Parse(Session["UserId"].ToString());
                    using (var context = new Biciclete())
                    {
                        var user = context.Users.Where(u => u.UserId == userId).FirstOrDefault();
                        if (user.Admin == true)
                        {
                            string redirect = "<script>window.open('http://localhost:58241/AdministreazaConturi','AdministrareCont','menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes,width=1000,height=800');</script>";
                            Response.Write(redirect);
                        }
                        else
                        {
                            lbNuAdmin.Visible = true;
                        }
                    }
                }
            }


        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

      
        [WebMethod]
        public static List<string> PopUpDetaliiComanda(int param)
        {
            var myList = new List<string>();
            using(var context=new Biciclete())
            {
                var lista = (from comenziProduse in context.ComandaProdus
                             join comenzi in context.Comenzis on comenziProduse.ComandaId equals comenzi.ComandaId
                             join produse in context.Produses on comenziProduse.ProdusId equals produse.ProdusId
                             where comenzi.ComandaId == param
                             group new { comenzi, comenziProduse, produse } by new { produse.Denumire, produse.Producator, comenziProduse.Cantitate, comenziProduse.PretCumparare } into x
                             select new
                             {
                                 x.Key.Denumire,
                                 x.Key.Producator,
                                 x.Key.Cantitate,
                                 x.Key.PretCumparare,
                                 Total = x.Key.Cantitate * x.Key.PretCumparare
                            }).ToList();

                foreach(var itm in lista)
                {
                    myList.Add("{\"Denumire\":\"" + itm.Denumire+ "\",\"Producator\":\"" +itm.Producator + "\",\"Cantitate\":\"" + itm.Cantitate + "\",\"Pret\":\"" + itm.PretCumparare + "\",\"Total\":\"" + itm.Total + "\"}");
                }
                return myList;
            }
            
        }

        protected void gvComenzi_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataRowView rand = (DataRowView)e.Row.DataItem;
                string id = rand["ComandaId"].ToString();
                LinkButton linkBtnDetalii = (LinkButton)e.Row.FindControl("btnDetalii");
                if (linkBtnDetalii != null)
                {
                    linkBtnDetalii.OnClientClick = "return functie(\"" + id.ToString() + "\");";
                    linkBtnDetalii.CommandArgument = id;
                }
                if ((ResourceSet)Session["resourceSet"] != null)
                {
                    ResourceSet resourceSet = (ResourceSet)Session["resourceSet"];
                    foreach (DictionaryEntry entry in resourceSet)
                    {
                        if (entry.Key.ToString().Equals("Detalii"))
                        {
                            linkBtnDetalii.Text = entry.Value.ToString();
                        }
                    }
                }
            }
        }

        protected void btnAdaugaComanda_Click(object sender, EventArgs e)
        {          
            Response.Redirect("Comanda.aspx");
        }
        [WebMethod]
        public static int ComenziCos()
        {
            if (HttpContext.Current.Session["dataTableComenzi"] != null)
            {
                DataTable dataTableComenzi = (DataTable)(HttpContext.Current.Session["dataTableComenzi"]);
                int nrComenzi = dataTableComenzi.Rows.Count;
                return nrComenzi;
            }
            return 0;
        }
    }
}