<%@ Page Title="" Language="C#" MasterPageFile="~/ChasseurDeTete.Master" AutoEventWireup="true" CodeBehind="CreerEntreprise.aspx.cs" Inherits="ECFWeb.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHCreationEntreprise" runat="server">
    
    <div class ="CreationEntreprise">
    <asp:Panel ID="PanelCreation" CssClass="Panel" GroupingText="Informations générales" runat ="server">
        <p>
        <asp:Label CssClass="Label" ID="LabelNom" runat="server" Text="Nom"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxNom" runat="server" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNom" runat="server" ControlToValidate="TextBoxNom" ErrorMessage="Veuillez indiquer le nom de l'entreprise" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label CssClass="Label" ID="LabelAdresse" runat="server" Text="Adresse"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxAdresse" runat="server" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdresse" runat="server" ControlToValidate="TextBoxAdresse" ForeColor="Red" ErrorMessage="Veuillez indiquer l'adresse de l'entreprise" Text="*"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label CssClass="Label" ID="LabelComplement" runat="server" Text="Complément d'adresse"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxComplement" runat="server" MaxLength="30"></asp:TextBox>
        </p>
        <p>
            <asp:Label CssClass="Label" ID="LabelCodePostal" runat="server" Text="Code Postal"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxCodePostal" runat="server" MaxLength="5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCodePostal" runat="server" ControlToValidate="TextBoxCodePostal" ForeColor="Red" ErrorMessage="Veuillez indiquer le code postal" Text="*"></asp:RequiredFieldValidator>
        </p>
         <p>
            <asp:Label CssClass="Label" ID="LabelVille" runat="server" Text="Ville"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxVille" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorVille" runat="server" ControlToValidate="TextBoxVille" ErrorMessage="Veuillez indiquer la ville" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
        </p>
         <p>
            <asp:Label CssClass="Label" ID="LabelClient" runat="server" Text="Vous êtes client ?"></asp:Label>
             <asp:DropDownList CssClass="TextBox" ID="DropDownListClient" runat="server" AutoPostBack="True">
                 <asp:ListItem>Sélectionnez une réponse</asp:ListItem>
                 <asp:ListItem Value="1">Oui</asp:ListItem>
                 <asp:ListItem Value="0">Non</asp:ListItem>
             </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorClient" runat="server" ControlToValidate="DropDownListClient" Text="*" ForeColor="Red" ErrorMessage="Veuillez indiquer si vous êtes client ou non"></asp:RequiredFieldValidator>
        </p>
         <p>
            <asp:Label CssClass="Label" ID="LabelContact" runat="server" Text="Contact"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxContact" runat="server" MaxLength="50"></asp:TextBox>
            
        </p>
        <p>
            <asp:Label CssClass="Label" ID="LabelTel" runat="server" Text="Telephone"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxTel" runat="server" MaxLength="20"></asp:TextBox>
            
        </p>
        <p>
            <asp:Label CssClass="Label" ID="LabelMail" runat="server" Text="Adresse mail"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxMail" TextMode="Email" runat="server" MaxLength="30"></asp:TextBox>
           
        </p>
        <p>
            <asp:Label CssClass="Label" ID="LabelSecteur" runat="server" Text="Votre secteur d'activité"></asp:Label>
            <asp:DropDownList  CssClass="TextBox" ID="DropDownListSecteur" runat="server" AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>
        </p>
        <p>
            <asp:Label CssClass="Label" ID="LabelPole" runat="server" Text="Votre secteur géographique"></asp:Label>
            <asp:DropDownList  CssClass="TextBox" ID="DropDownListPole" runat="server" AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>
        </p>
        <asp:Panel  CssClass="Panel" ID="PanelIdentification" runat="server" GroupingText="Informations de connexion">
            <p>
            <asp:Label CssClass="Label" ID="LabelIdentification" runat="server" Text="Identification de Connexion"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxIdentification" TextMode="Email" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdentification" runat="server" ControlToValidate="TextBoxIdentification" Text="*" ForeColor="Red" ErrorMessage="Veuillez choisir un identifiant de connexion"></asp:RequiredFieldValidator>
        </p>
             <p>
            <asp:Label CssClass="Label" ID="LabelMotDePasse" runat="server" Text="Mot de passe"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxMdp" TextMode="Password" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorMdp" runat="server" ControlToValidate="TextBoxMdp" ErrorMessage="Veuillez choisir un mot de passe" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
        </p>
             <p>
            <asp:Label CssClass="Label" ID="LabelConfirmation" runat="server" Text="Confirmer le mot de passe"></asp:Label>
            <asp:TextBox CssClass="TextBox" ID="TextBoxConfirmation" TextMode="Password" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmation" ForeColor="Red" runat="server" ControlToValidate="TextBoxConfirmation" Text="*" ErrorMessage="Veuillez renseigner à nouveau le mot de passe"></asp:RequiredFieldValidator>                
        </p>
        </asp:Panel>

        <asp:Button CssClass="BoutonValider" ID="ButtonValider" runat="server" Text="Valider" Onclick="ButtonValider_Click"/>
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"  ShowMessageBox="True" />
  
    </asp:Panel>
        </div>
   
       
    
</asp:Content>
