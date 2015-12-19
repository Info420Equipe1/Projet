using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Jeu;
using Texcel.Classes;

namespace Texcel.Interfaces.Jeu
{
    public partial class frmJeu : frmForm
    {
        //Variable Globale permettant de savoir si la Frm est en mode Modifier ou Ajouter
        bool modif;

        //Constructeur en Mode Ajouter
        public frmJeu()
        {
            InitializeComponent();
            fillLstBox();
            modif = false;
        }

        //Constructeur en Mode Modifier
        public frmJeu(cJeu _jeu)
        {
            InitializeComponent();
            fillLstBox();
            modif = true;
            btnEnregistrer.Text = "Modifier";
            txtID.Enabled = false;
            txtID.Text = _jeu.idJeu.ToString();
            cmbNom.Enabled = false;
            cmbNom.Text = _jeu.nomJeu;
            txtDeveloppeur.Text = _jeu.developeur;
            cmbClassification.Text = (_jeu.ClassificationJeu.codeClassification + " - " + _jeu.ClassificationJeu.nomClassification);
            rtbDescription.Text = _jeu.descJeu;
            rtbDescription.Focus();
            rtbDescription.SelectAll();
            rtbConfiguration.Text = _jeu.configMinimal;
            try
            {
                picJeu.Image = Image.FromFile(@"..\..\Images\Jeu\Jeux\" + _jeu.idJeu + ".jpg");
            }
            catch (FileNotFoundException)
            {
                picJeu.ImageLocation = @"..\..\Images\NoImage.png";
            }

            //Emplissage des listbox concernant les informations du jeu
            foreach (VersionJeu version in _jeu.VersionJeu)
            {
                lstBoxVersion.Items.Add(version.nomVersionJeu);
            }
            foreach (Plateforme plat in _jeu.Plateforme)
            {
                lstBoxPlat1.Items.Add(plat.nomPlateforme);
            }
            foreach (ThemeJeu theme in _jeu.ThemeJeu)
            {
                lstBoxTheme1.Items.Add(theme.nomTheme);
            }
            foreach (GenreJeu genre in _jeu.GenreJeu)
            {
                lstBoxGenre1.Items.Add(genre.nomGenre);
            }
        }

        //Emplissage des listbox globales
        private void fillLstBox()
        {
            //Emplissage de la list box des Plateforme Globales
            foreach (Plateforme plat in CtrlPlateforme.lstPlateformeJeu())
            {
                lstBoxPlat2.Items.Add(plat.nomPlateforme);
            }

            //Emplissage de la list box des Themes globaux
            foreach (ThemeJeu theme in CtrlThemeJeu.LstThemeJeu())
            {
                lstBoxTheme2.Items.Add(theme.nomTheme);
            }

            //Emplissage de la list box des Genres globaux
            foreach (GenreJeu genre in CtrlGenreJeu.LstGenreJeu())
            {
                lstBoxGenre2.Items.Add(genre.nomGenre);
            }

            //Emplissage de la list box des Classifications globales
            foreach (ClassificationJeu classJeu in CtrlClassificationJeu.getListClassification())
            {
                cmbClassification.Items.Add(classJeu.codeClassification + " - " + classJeu.nomClassification);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (cJeu jeu in CtrlJeu.LstJeu())
            {
                cmbNom.Items.Add(jeu.nomJeu);
            }
        }

        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoxPlat2.SelectedIndex = -1;
            lstBoxTheme2.SelectedIndex = -1;
            lstBoxGenre2.SelectedIndex = -1;

            string nomJeu = cmbNom.Text;
            btnEnregistrer.Text = "Modifier";

            //Emplissage des champs par rapport au Jeu
            cJeu jeu = CtrlJeu.GetJeu(nomJeu);
            txtID.Text = jeu.idJeu.ToString();
            txtDeveloppeur.Text = jeu.developeur;
            cmbClassification.Text = (jeu.ClassificationJeu.codeClassification + " - " + jeu.ClassificationJeu.nomClassification);
            rtbDescription.Text = jeu.descJeu;
            rtbConfiguration.Text = jeu.configMinimal;
            try
            {
                picJeu.Image = Image.FromFile(@"..\..\Images\Jeu\Jeux\" + jeu.idJeu + ".jpg");
            }
            catch (FileNotFoundException)
            {
                picJeu.ImageLocation = @"..\..\Images\NoImage.png";
            }

            
            //Emplissage de la list box des Plateformes par rapport au jeu
            lstBoxPlat1.Items.Clear();
            foreach (Plateforme plat in jeu.Plateforme)
            {
                lstBoxPlat1.Items.Add(plat.nomPlateforme);
            }
            //Emplissage de la list box des Themes par rapport au jeu
            lstBoxTheme1.Items.Clear();
            foreach (ThemeJeu themeJeu in jeu.ThemeJeu)
            {
                lstBoxTheme1.Items.Add(themeJeu.nomTheme);
            }

            //Emplissage de la list box des Genres par rapport au jeu
            lstBoxGenre1.Items.Clear();
            foreach (GenreJeu genreJeu in jeu.GenreJeu)
            {
                lstBoxGenre1.Items.Add(genreJeu.nomGenre);
            }

            //Emplissage de la list box des version par rapport au jeu
            lstBoxVersion.Items.Clear();
            foreach (VersionJeu VersionJeu in jeu.VersionJeu)
            {
                lstBoxVersion.Items.Add(VersionJeu.nomVersionJeu);
            }

            //Selectionne tous les LstBox afin de pouvoir remove rapidement(DemandeClient)
            string name;
            for (int i = 0; i < lstBoxPlat1.Items.Count; i++)
            {
                name = lstBoxPlat1.Items[i].ToString();
                lstBoxPlat2.Items.Remove(name);
                lstBoxPlat1.SetSelected(i, true);
            }
            for (int i = 0; i < lstBoxTheme1.Items.Count; i++)
            {
                name = lstBoxTheme1.Items[i].ToString();
                lstBoxTheme2.Items.Remove(name);
                lstBoxTheme1.SetSelected(i, true);
            }
            for (int i = 0; i < lstBoxGenre1.Items.Count; i++)
            {
                name = lstBoxGenre1.Items[i].ToString();
                lstBoxGenre2.Items.Remove(name);
                lstBoxGenre1.SetSelected(i, true);
            }
        }

        private void cmbNom_TextUpdate(object sender, EventArgs e)
        {
            btnEnregistrer.Text = "Enregistrer";
            txtID.Text = "";
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            DialogResult DR;
            string message;
            string classification;
            List<Plateforme> plateforme = new List<Plateforme>();
            List<ThemeJeu> themeJeu = new List<ThemeJeu>();
            List<GenreJeu> genreJeu = new List<GenreJeu>();
            List<VersionJeu> versionJeu = new List<VersionJeu>();

            //Validation
            if (cmbNom.Text == "")
            {
                CtrlController.MessageErreur("Veuillez ajouter un nom!");
                return;
            }
            if ((cmbClassification.Text == null) || (cmbClassification.Text == ""))
            {
                CtrlController.MessageErreur("Veuillez ajouter une classification!");
                return;
            }
            else
            {
                int cpt = 0, position = 0;
                foreach (char character in cmbClassification.Text)
                {
                    if (character == '-')
                    {
                        position = cpt - 1;
                        break;
                    }
                    cpt++;
                }
                classification = ((cmbClassification.Text).Substring(0, position));
            }

            //Recupère l'information sur le jeu
            foreach (string nomPlat in lstBoxPlat1.Items)
            {
                plateforme.Add(CtrlPlateforme.GetPlateforme(nomPlat));
            }
            foreach (string nomTheme in lstBoxTheme1.Items)
            {
                themeJeu.Add(CtrlThemeJeu.GetThemeByNom(nomTheme));
            }
            foreach (string nomGenre in lstBoxGenre1.Items)
            {
                genreJeu.Add(CtrlGenreJeu.GetGenreByNom(nomGenre));
            }
            foreach (string nomVersion in lstBoxVersion.Items)
            {
                versionJeu.Add(CtrlVersionJeu.GetVersionJeu(nomVersion));
            }

            //Validation
            if (CtrlJeu.VerifierJeu(cmbNom.Text.Trim()))
            {
                //Modifier un Jeu
                DR = CtrlController.getDR("Vous êtes en train de modifier un Jeu, voulez-vous continuer?");
                if (DR == DialogResult.Yes)
                {
                    message = CtrlJeu.Modifier(cmbNom.Text, txtDeveloppeur.Text, classification, rtbDescription.Text, rtbConfiguration.Text, plateforme, themeJeu, genreJeu, versionJeu);
                    if (message.Contains("erreur"))
                    {
                        CtrlController.MessageErreur(message);
                        return;
                    }
                    else
                    {
                        CtrlController.MessageSucces(message);
                        if (modif)
                        {
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                //Ajouter un Jeu
                message = CtrlJeu.Ajouter(cmbNom.Text.Trim(), txtDeveloppeur.Text.Trim(), classification, rtbDescription.Text.Trim(), rtbConfiguration.Text.Trim(), plateforme, themeJeu, genreJeu, versionJeu);
                if (message.Contains("erreur"))
                {
                    CtrlController.MessageErreur(message);
                }
                else
                {
                    CtrlController.MessageSucces(message);
                    txtID.Text = (CtrlJeu.GetCount()).ToString();
                }
            }
            lstBoxPlat2.SelectedIndex = -1;
            lstBoxTheme2.SelectedIndex = -1;
            lstBoxGenre2.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Efface tous les champs
            txtID.Text = "";
            cmbNom.Text = "";
            txtDeveloppeur.Text = "";
            cmbClassification.Text = "";
            rtbDescription.Text = "";
            rtbConfiguration.Text = "";
            lstBoxPlat1.Items.Clear();
            lstBoxTheme1.Items.Clear();
            lstBoxGenre1.Items.Clear();
            lstBoxVersion.Items.Clear();
            lstBoxPlat2.SelectedIndex = -1;
            lstBoxTheme2.SelectedIndex = -1;
            lstBoxGenre2.SelectedIndex = -1;
            btnEnregistrer.Text = "Enregistrer";
        }

        //Ajouter une Plateforme par rapport au jeu
        private void btnAjoutPlatJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxPlat2.Items.Count == 0) || (lstBoxPlat2.SelectedIndex == -1) || (lstBoxPlat2.SelectedItems.Count > 1))
            {
                CtrlController.MessageErreur("Veuillez selectionner une plateforme à ajouter.");
                return;
            }

            string nomPlateforme = (string)lstBoxPlat2.SelectedItem;
            lstBoxPlat2.Items.Remove(nomPlateforme);
            lstBoxPlat1.Items.Add(nomPlateforme);
        }

        //Ajouter plusieurs Plateformes par rapport au jeu
        private void btnAjoutMultiplePlatJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxPlat2.Items.Count == 0) || (lstBoxPlat2.SelectedIndex == -1) || (lstBoxPlat2.SelectedItems.Count < 2))
            {
                CtrlController.MessageErreur("Veuillez selectionner plusieurs plateformes à ajouter");
                return;
            }
            ListBox.SelectedObjectCollection lstBoxSOC = lstBoxPlat2.SelectedItems;
            string platName;
            int selectedItems = lstBoxSOC.Count;
            for (int i = 0; i < selectedItems; i++)
            {
                platName = lstBoxSOC[0].ToString();
                lstBoxPlat2.Items.Remove(platName);
                lstBoxPlat1.Items.Add(platName);
            }
        }

        //Ajouter un theme par rapport au jeu
        private void btnAjoutThemeJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxTheme2.Items.Count == 0) || (lstBoxTheme2.SelectedIndex == -1) || (lstBoxTheme2.SelectedItems.Count > 1))
            {
                CtrlController.MessageErreur("Veuillez selectionner un thème à ajouter.");
                return;
            }

            string nomTheme = (string)lstBoxTheme2.SelectedItem;
            lstBoxTheme2.Items.Remove(nomTheme);
            lstBoxTheme1.Items.Add(nomTheme);
        }

        //Ajouter plusieurs theme par rapport au jeu
        private void btnAjoutMultipleThemeJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxTheme2.Items.Count == 0) || (lstBoxTheme2.SelectedIndex == -1) || (lstBoxTheme2.SelectedItems.Count < 2))
            {
                CtrlController.MessageErreur("Veuillez selectionner plusieurs thèmes à ajouter.");
                return;
            }
            ListBox.SelectedObjectCollection lstBoxSOC = lstBoxTheme2.SelectedItems;
            string themeName;
            int selectedItems = lstBoxSOC.Count;
            for (int i = 0; i < selectedItems; i++)
            {
                themeName = lstBoxSOC[0].ToString();
                lstBoxTheme2.Items.Remove(themeName);
                lstBoxTheme1.Items.Add(themeName);
            }
        }

        //Ajouter un Genre par rapport au jeu
        private void btnAjoutGenreJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxGenre2.Items.Count == 0) || (lstBoxGenre2.SelectedIndex == -1) || (lstBoxGenre2.SelectedItems.Count > 1))
            {
                CtrlController.MessageErreur("Veuillez selectionner un genre à ajouter.");
                return;
            }

            string nomGenre = (string)lstBoxGenre2.SelectedItem;
            lstBoxGenre1.Items.Add(nomGenre);
            lstBoxGenre2.Items.Remove(nomGenre);
        }

        //Ajouter plusieurs Genre par rapport au jeu
        private void btnAjoutMultipleGenreJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxGenre2.Items.Count == 0) || (lstBoxGenre2.SelectedIndex == -1) || (lstBoxGenre2.SelectedItems.Count < 2))
            {
                CtrlController.MessageErreur("Veuillez selectionner plusieurs genres à ajouter.");
                return;
            }

            ListBox.SelectedObjectCollection lstBoxSOC = lstBoxGenre2.SelectedItems;
            string genreName;
            int selectedItems = lstBoxSOC.Count;
            for (int i = 0; i < selectedItems; i++)
            {
                genreName = lstBoxSOC[0].ToString();
                lstBoxGenre2.Items.Remove(genreName);
                lstBoxGenre1.Items.Add(genreName);
            }
        }

        //Remove une plateforme par rapport au jeu
        private void btnRemovePlatJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxPlat1.Items.Count == 0) || (lstBoxPlat1.SelectedIndex == -1)||(lstBoxPlat1.SelectedItems.Count > 1))
            {
                CtrlController.MessageErreur("Veuillez selectionner une plateforme à enlever.");
                return;
            }

            string nomPlateforme = (string)lstBoxPlat1.SelectedItem;
            lstBoxPlat1.Items.Remove(lstBoxPlat1.SelectedItem);
            lstBoxPlat2.Items.Add(nomPlateforme);
        }

        //Remove plusieurs plateformes par rapport au jeu
        private void btnRemoveMultiplePlatJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxPlat1.Items.Count == 0) || (lstBoxPlat1.SelectedIndex == -1) || (lstBoxPlat1.SelectedItems.Count < 2))
            {
                CtrlController.MessageErreur("Veuillez selectionner plusieurs plateformes à enlever.");
                return;
            }
            ListBox.SelectedObjectCollection lstBoxSOC = lstBoxPlat1.SelectedItems;
            string platName;
            int selectedItems = lstBoxSOC.Count;
            for (int i = 0; i < selectedItems; i++)
            {
                platName = lstBoxSOC[0].ToString();
                lstBoxPlat1.Items.Remove(platName);
                lstBoxPlat2.Items.Add(platName);
            }
        }

        //Remove un Thème par rapport au Jeu
        private void btnRemoveThemeJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxTheme1.Items.Count == 0) || (lstBoxTheme1.SelectedIndex == -1) || (lstBoxTheme1.SelectedItems.Count > 1))
            {
                CtrlController.MessageErreur("Veuillez selectionner un thème à enlever.");
                return;
            }

            string nomTheme = (string)lstBoxTheme1.SelectedItem;
            lstBoxTheme1.Items.Remove(nomTheme);
            lstBoxTheme2.Items.Add(nomTheme);
        }

        //Remove plusieurs Thèmes par rapport au Jeu
        private void btnRemoveMultipleTheme_Click(object sender, EventArgs e)
        {
            if ((lstBoxTheme1.Items.Count == 0) || (lstBoxTheme1.SelectedIndex == -1) || (lstBoxTheme1.SelectedItems.Count < 2))
            {
                CtrlController.MessageErreur("Veuillez selectionner plusieurs thèmes à enlever.");
                return;
            }

            ListBox.SelectedObjectCollection lstBoxSOC = lstBoxTheme1.SelectedItems;
            string themeName;
            int selectedItems = lstBoxSOC.Count;
            for (int i = 0; i < selectedItems; i++)
            {
                themeName = lstBoxSOC[0].ToString();
                lstBoxTheme1.Items.Remove(themeName);
                lstBoxTheme2.Items.Add(themeName);
            }
        }

        //Remove un Genre par rapport au jeu
        private void btnRemoveGenreJeu_Click(object sender, EventArgs e)
        {
            if ((lstBoxGenre1.Items.Count == 0) || (lstBoxGenre1.SelectedIndex == -1)|| (lstBoxGenre1.SelectedItems.Count > 1))
            {
                CtrlController.MessageErreur("Veuillez selectionner un genre à enlever.");
                return;
            }

            string nomGenre = (string)lstBoxGenre1.SelectedItem;
            lstBoxGenre1.Items.Remove(nomGenre);
            lstBoxGenre2.Items.Add(nomGenre);
        }

        //Remove plusieurs Genres par rapport au jeu
        private void btnRemoveMultipleGenre_Click(object sender, EventArgs e)
        {
            if ((lstBoxGenre1.Items.Count == 0) || (lstBoxGenre1.SelectedIndex == -1) || (lstBoxGenre1.SelectedItems.Count < 2))
            {
                CtrlController.MessageErreur("Veuillez selectionner plusieurs genres à enlever.");
                return;
            }

            ListBox.SelectedObjectCollection lstBoxSOC = lstBoxGenre1.SelectedItems;
            string genreName;
            int selectedItems = lstBoxSOC.Count;
            for (int i = 0; i < selectedItems; i++)
            {
                genreName = lstBoxSOC[0].ToString();
                lstBoxGenre1.Items.Remove(genreName);
                lstBoxGenre2.Items.Add(genreName);
            }
        }


        //Tous les boutons permettant d'ajouter des composants pour le Jeu
        //
        private void pcbAjouterPlateforme_Click(object sender, EventArgs e)
        {
            //Ouverture de la forme Plateforme
            frmPlateforme frmPlat = new frmPlateforme();
            frmPlat.ShowDialog();
            this.Refresh();
        }

        private void pcbAjouterTheme_Click(object sender, EventArgs e)
        {
            //Ouverture de la forme Theme
            frmTheme frmTheme = new frmTheme();
            frmTheme.ShowDialog();
            this.Refresh();
        }

        private void pcbAjouterGenre_Click(object sender, EventArgs e)
        {
            //Ouverture de la forme Genre
            frmGenre frmGenre = new frmGenre();
            frmGenre.ShowDialog();
            this.Refresh();
        }

        private void pcbAjouterVerJeu_Click(object sender, EventArgs e)
        {
            if (CtrlJeu.VerifierJeu(cmbNom.Text))
            {
                //Ouverture de la forme Version de Jeu
                string nomJeu = cmbNom.Text;
                frmAjouterVersionJeu frmVersionJeu = new frmAjouterVersionJeu(nomJeu);
                frmVersionJeu.ShowDialog();
                List<VersionJeu> lstVersionJeu = CtrlVersionJeu.LstVersionJeu(nomJeu);
                lstBoxVersion.Items.Clear();
                foreach (VersionJeu version in lstVersionJeu)
                {
                    lstBoxVersion.Items.Add(version.nomVersionJeu);
                }
            }
            else if (!CtrlJeu.VerifierJeu(cmbNom.Text))
            {
                CtrlController.MessageErreur("Veuillez enregistrer le jeu avant de lui ajouter une version.");
            }         
            else
            {
                CtrlController.MessageErreur("Veuillez choisir un jeu afin de pouvoir lui associer une version de test.");
            }
        }

        private void pcbModifVersion_Click(object sender, EventArgs e)
        {
            if (lstBoxVersion.SelectedIndex != -1)
            {
                //Ouverture de la forme Plateforme
                VersionJeu _Version = CtrlVersionJeu.GetVersionJeu(lstBoxVersion.SelectedItem.ToString());
                frmAjouterVersionJeu frmVersion = new frmAjouterVersionJeu(_Version);
                frmVersion.ShowDialog();
            }
            else
            {
                CtrlController.MessageErreur("Veuillez selectionner une version dans la liste afin de la modifier.");
            }
        }

        private void pcbSuprimmerVersion_Click(object sender, EventArgs e)
        {
            if (lstBoxVersion.SelectedIndex != -1)
            {
                string message;

                //Supprimer une version de jeu
                message = CtrlVersionJeu.Supprimer(lstBoxVersion.SelectedItem.ToString());
                if (message.Contains("erreur"))
                {
                    CtrlController.MessageErreur(message);
                    return;
                }
                else
                {
                    CtrlController.MessageSucces(message);
                    List<VersionJeu> lstVersionJeu = CtrlVersionJeu.LstVersionJeu(cmbNom.Text);
                    lstBoxVersion.Items.Clear();
                    foreach (VersionJeu version in lstVersionJeu)
                    {
                        lstBoxVersion.Items.Add(version.nomVersionJeu);
                    }
                }    
            }
            else
            {
                CtrlController.MessageErreur("Veuillez selectionner une version dans la liste afin de la supprimer.");
            }
        }

    }
}
