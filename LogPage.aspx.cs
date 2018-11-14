using BicicleteWeb.App_GlobalResources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BicicleteWeb
{
    public partial class LogPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void dllCulture_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLanguage = dllCulture.SelectedValue;
            Session["culture"] = selectedLanguage;
            UICulture = selectedLanguage;
            Culture = selectedLanguage;

            Thread.CurrentThread.CurrentCulture =
                CultureInfo.CreateSpecificCulture(selectedLanguage);
            Thread.CurrentThread.CurrentUICulture = new
                CultureInfo(selectedLanguage);
            base.InitializeCulture();

            ResourceManager MyResourceClass = new ResourceManager("BicicleteWeb.App_GlobalResources.Strings", typeof(Strings).Assembly);
            ResourceSet resourceSet = MyResourceClass.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            Session["resourceSet"] = resourceSet;
            foreach (DictionaryEntry entry in resourceSet)
            {
                if (entry.Key.ToString().Equals("BineAiVenit"))
                {
                    lbWelcome.Text = entry.Value.ToString();
                }
                if (entry.Key.ToString().Equals("Autentificare"))
                {
                    lbAutentificare.Text = entry.Value.ToString();
                    btnLogin.Text = entry.Value.ToString();
                }
                if (entry.Key.ToString().Equals("CreareCont"))
                {
                    lbCreazaCont.Text = entry.Value.ToString();
                }
                if (entry.Key.ToString().Equals("Nume"))
                {
                    lbUsername.Text = entry.Value.ToString();
                }
                if (entry.Key.ToString().Equals("Parola"))
                {
                    lbPassword.Text = entry.Value.ToString();
                }
                if (entry.Key.ToString().Equals("rfvNume"))
                {
                    rfvNume.ErrorMessage = entry.Value.ToString();
                }
                if (entry.Key.ToString().Equals("rfvParola"))
                {
                    rfvParola.ErrorMessage = entry.Value.ToString();
                }
                if (entry.Key.ToString().Equals("ValidareLogin"))
                {
                    lbValidation.Text = entry.Value.ToString();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (var ctx = new Biciclete())
            {
                string name = tbUsername.Text;
                string parola = tbPassword.Text;
                var user = ctx.Users.Where(s => s.Nume == name && s.Parola == parola && s.Aprobat == true && s.Activ == true).FirstOrDefault<User>();
                if (user != null)
                {
                    Session["UserId"] = user.UserId;
                    FormsAuthentication.RedirectFromLoginPage(user.Nume, true);
                    Response.Redirect("HomePage.aspx");
                    tbPassword.Text = string.Empty;
                    tbUsername.Text = string.Empty;
                }
                else
                {
                    lbValidation.Visible = true;
                    if ((ResourceSet)Session["resourceSet"] != null)
                    {
                        ResourceSet resourceSet = (ResourceSet)Session["resourceSet"];
                        foreach (DictionaryEntry entry in resourceSet)
                        {
                            if (entry.Key.ToString().Equals("ValidareLogin"))
                            {
                                lbValidation.Text = entry.Value.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}
