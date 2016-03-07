using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassChasseurDT.Dao;
using ClassChasseurDT.Exceptions;
using ClassChasseurDT.Metier;

namespace ECFWeb
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    //Bind  dropdown Pole géographique
                    DropDownListPole.Items.Insert(0, new ListItem("Sélectionner le secteur géographique", "0"));
                    DropDownListPole.DataSource = DaoPoleEmbauche.GetAllPoleEmbauches();
                    DropDownListPole.DataTextField = "LibellePole";
                    DropDownListPole.DataValueField = "IdPole";
                    DropDownListPole.DataBind();
                    //bind dropdown secteur activité
                    DropDownListSecteur.Items.Insert(0, new ListItem("Sélectionner votre secteur d'activité", "0"));
                    DropDownListSecteur.DataSource = DaoSecteurActivite.GetAllActivites();
                    DropDownListSecteur.DataTextField = "LibelleActivite";
                    DropDownListSecteur.DataValueField = "IdActivite";
                    DropDownListSecteur.DataBind();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Impossible de se connecter');</script>" + ex);
                }
            }
        }



        protected void ButtonValider_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Entreprise ent = new Entreprise();
                ent.RaisonSociale = TextBoxNom.Text;
                ent.Adresse1Ent = TextBoxAdresse.Text;
                if (TextBoxComplement.Text == string.Empty)
                    ent.Adresse2Ent = null;
                else
                    ent.Adresse2Ent = TextBoxComplement.Text;
                ent.CpEnt = TextBoxCodePostal.Text;
                ent.VilleEnt = TextBoxVille.Text;
                if (DropDownListClient.SelectedIndex == 1)
                    ent.Cliente = true;
                else
                    ent.Cliente = false;
                if (TextBoxContact.Text == string.Empty)
                    ent.Contact = null;
                else
                    ent.Contact = TextBoxContact.Text;
                if (TextBoxTel.Text == string.Empty)
                    ent.TelContact = null;
                else
                    ent.TelContact = TextBoxTel.Text;
                if (TextBoxMail.Text == string.Empty)
                    ent.MailContact = null;
                else
                    ent.MailContact = TextBoxMail.Text;
                Activite act = new Activite();
                ent.SecteurActivite = act;
                if (DropDownListSecteur.SelectedIndex == 0)
                    act.IdActivite = null;
                else
                    act.IdActivite = Convert.ToSByte(DropDownListSecteur.SelectedIndex);
                PoleEmbauche polE = new PoleEmbauche();
                ent.PoleRattachement = polE;
                if (DropDownListPole.SelectedIndex == 0)
                    polE.IdPole = null;
                else
                    polE.IdPole = Convert.ToSByte(DropDownListPole.SelectedIndex);
                ent.DateCreation = DateTime.Now;

                try
                {
                    ent.IdEntreprise = DaoEntreprise.AddEntreprise(ent);
                    ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('L'entreprise a bien été ajouté');</script>");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Impossible d'ajouter l'entreprise');</script>" + ex);
                }


            }
        }
    }
}