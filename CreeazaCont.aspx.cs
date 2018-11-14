using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtils;

namespace BicicleteWeb
{
    public partial class AdimistratorPage : System.Web.UI.Page
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
                        if (entry.Key.ToString().Equals("IntroducetiDatele"))
                        {
                            lbIntroducereDate.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Nume"))
                        {
                            lbNume.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Parola"))
                        {
                            lbParola.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("ConfirmareParola"))
                        {
                            lbConfirmareParola.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("Email"))
                        {
                            lbEmail.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("SalvareCont"))
                        {
                            btnSalvareCont.Text = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("rfvNume"))
                        {
                            rfvNume.ErrorMessage = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("rfvParola"))
                        {
                            rfvParola.ErrorMessage = entry.Value.ToString();
                            rfvConfirmareParola.ErrorMessage = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("rfvEmail"))
                        {
                            rfvEmail.ErrorMessage = entry.Value.ToString();
                        }
                        if (entry.Key.ToString().Equals("compareValidatorParola"))
                        {
                            compareValidatorParola.ErrorMessage = entry.Value.ToString();
                        }
                    }
                }
            }
        }

        protected void btnSalvareCont_Click(object sender, EventArgs e)
        {
            using (var context = new Biciclete())
            {
                var user = new User()
                {
                    Nume = tbNume.Text,
                    Parola = tbParola.Text,
                    Email = tbEmail.Text,
                    Data = DateTime.Now,
                    Activ = null,
                    Aprobat = null,
                    Admin = null
                };
                context.Users.Add(user);

                context.SaveChanges();
            }
            tbNume.Text = string.Empty;
            tbParola.Text = string.Empty;
            tbConfirmareParola.Text = string.Empty;
            tbEmail.Text = string.Empty;
            lbInregistrare.Visible = true;
            if ((ResourceSet)Session["resourceSet"] != null)
            {
                ResourceSet resourceSet = (ResourceSet)Session["resourceSet"];
                foreach (DictionaryEntry entry in resourceSet)
                {
                    if (entry.Key.ToString().Equals("InregistrareSucces"))
                    {
                        lbInregistrare.Text = entry.Value.ToString();
                    }

                }
            }
        }
    }
}