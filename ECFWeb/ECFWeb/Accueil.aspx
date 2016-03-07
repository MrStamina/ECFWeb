<%@ Page Title="" Language="C#" MasterPageFile="~/ChasseurDeTete.Master" AutoEventWireup="true" CodeBehind="Accueil.aspx.cs" Inherits="ECFWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHAccueil" runat="server">
    
    <div class="Choix">
        <strong>
        <asp:Label CssClass="LabelChoix" ID="LabelChoix" runat="server" Text="Vous êtes un(e)" style="font-size: x-large; color: #FFFFFF;"></asp:Label>
        </strong><br />
        <asp:Button CssClass="Bouton" ID="ButtonCandidat" runat="server" Text="Candidat" PostBackUrl="~/EspaceCandidat.aspx" />
        <asp:Button CssClass="Bouton" ID="ButtonEntreprise" runat="server" Text="Entreprise" PostBackUrl="~EspaceEntreprise.aspx" />
        
    </div>
    
    <div class="Identification">
         <strong>
     <asp:HyperLink CssClass="Lien" ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx" ForeColor="Black">Identifiez-vous</asp:HyperLink>
    </strong>
       
    </div>
    <div class="Categorie" style="font-weight: 700;  text-align: left">
        <asp:Label  ID="LabelCandidat" runat="server" Text="Vous êtes un candidat"></asp:Label>
    </div>
    <div class="Sous_categorie">
        <p>
            <span class="Titreblock"> Gérer votre carrière !</span>
        </p>
        <p>
            Accédez aux offres d'emploi<br />
            Répondez aux sollicitations des entreprises ==> 
                <asp:HyperLink ID="HyperLink3" NavigateUrl="~/EspaceCandidat.aspx" runat="server">Créer un compte</asp:HyperLink><br />
            Faites-vous accompagner par des consultants experts
        </p>
    </div>
    <div class="Categorie">
        <asp:Label ID="LabelEntreprise" runat="server" Text="Vous êtes un entreprise" style="font-weight: 700"></asp:Label>
    </div>
    <div class="Sous_categorie">
        <p>
            <span class="Titreblock">De nombreux candidats consultent les offres d'emploi chaque jour !</span>
        </p>
        <p>
            Publiez vos offres d'emploi ==> <asp:HyperLink ID="HyperLink4" NavigateUrl="~/CreerEntreprise.aspx" runat="server">Créer un compte</asp:HyperLink><br />
            Et bénéficiez de l'expertise de nos consultants pour vos recrutements ==>
                <asp:HyperLink  ID="HyperLink2" runat="server">Publier une offre</asp:HyperLink><br />
            Trouvez rapidement les meilleurs profils du marché<br />
            De nombreux CV publiés chaque mois
        </p>
    </div>
    <div class="Categorie">
        <asp:Label  ID="LabelNews" runat="server" Text="News" style="font-weight: 700"></asp:Label>
    </div>
    <div class="Sous_categorie">
        
        <p>
            Victus universis caro ferina est lactisque abundans copia qua sustentantur, et herbae multiplices et siquae alites capi <br />
            per aucupium possint, et plerosque mos vidimus frumenti usum et vini penitus ignorantes.<br />
            Ideoque fertur neminem aliquando ob haec vel similia poenae addictum oblato de more elogio revocari iussisse, quod inexorabiles.
        </p>
    </div>
        

</asp:Content>
