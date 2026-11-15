namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de gérer la fenêtre responsable
    /// </summary>
    public partial class FormResponsable : Form
    {
        /// <summary>
        /// ce code permet de créer la fenêtre
        /// </summary>
        public FormResponsable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ce code permet de remplir les listes les tableaux et les stats quand la fenêtre se lance
        /// </summary>
        /// <param name="sender">la fenêtre</param>
        /// <param name="e">les infos du chargement</param>
        private void FormResponsable_Load(object sender, EventArgs e)
        {
            cboNiveauT.SelectedIndex = 0;

            try
            {
                List<Region> regions = Bdd.GetRegions();
                foreach (Region r in regions)
                {
                    cboRegionU.Items.Add(r);
                    cboRegionT.Items.Add(r);
                }

                ChargerUtilisateurs();
                ChargerTechniciens();
                ChargerStatistiques();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données.\r\nVérifiez que MySQL est démarré dans XAMPP.\r\n\r\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ce code permet de donner un message clair quand il y a une erreur
        /// </summary>
        /// <param name="ex">le problème reçu</param>
        /// <returns>le message à montrer</returns>
        private string MessageErreur(Exception ex)
        {
            if (ex.Message.Contains("Duplicate"))
            {
                return "Ce login est déjà utilisé.\r\nPour ajouter une nouvelle personne, cliquez d'abord sur « Vider les champs ».";
            }
            if (ex.Message.Contains("foreign key"))
            {
                return "Impossible de supprimer cette personne : elle a déjà déclaré des incidents ou fait des interventions.";
            }
            return "Erreur : " + ex.Message;
        }

        /// <summary>
        /// ce code permet de choisir la bonne région dans une liste
        /// </summary>
        /// <param name="cbo">la liste des régions</param>
        /// <param name="region">la région à choisir</param>
        private void SelectionnerRegion(ComboBox cbo, Region region)
        {
            cbo.SelectedIndex = -1;
            if (region == null)
            {
                return;
            }

            for (int k = 0; k < cbo.Items.Count; k++)
            {
                Region r = (Region)cbo.Items[k];
                if (r.IdRegion == region.IdRegion)
                {
                    cbo.SelectedIndex = k;
                }
            }
        }

        /// <summary>
        /// ce code permet de remettre la sélection sur une personne dans un tableau
        /// </summary>
        /// <param name="dgv">le tableau</param>
        /// <param name="idPersonnel">le numéro de la personne</param>
        private void SelectionnerLigne(DataGridView dgv, int idPersonnel)
        {
            foreach (DataGridViewRow ligne in dgv.Rows)
            {
                Personnel p = (Personnel)ligne.Tag;
                if (p.IdPersonnel == idPersonnel)
                {
                    dgv.CurrentCell = ligne.Cells[0];
                }
            }
        }

        /// <summary>
        /// ce code permet de remplir le tableau des utilisateurs
        /// </summary>
        private void ChargerUtilisateurs()
        {
            dgvUtilisateurs.Rows.Clear();

            List<Personnel> utilisateurs = Bdd.GetPersonnels("utilisateur");
            foreach (Personnel p in utilisateurs)
            {
                string region = "";
                Region r = Bdd.GetRegionActuelle(p);
                if (r != null)
                {
                    region = r.LibelleRegion;
                }

                int ligne = dgvUtilisateurs.Rows.Add(p.Matricule, p.Nom, p.Prenom, p.Login, region);
                dgvUtilisateurs.Rows[ligne].Tag = p;
            }

            AfficherUtilisateur();
        }

        /// <summary>
        /// ce code permet de savoir quel utilisateur est choisi dans le tableau
        /// </summary>
        /// <returns>la personne choisie ou null si il y en a pas</returns>
        private Personnel UtilisateurSelectionne()
        {
            if (dgvUtilisateurs.SelectedRows.Count == 0)
            {
                return null;
            }
            return (Personnel)dgvUtilisateurs.SelectedRows[0].Tag;
        }

        /// <summary>
        /// ce code permet de remplir la fiche quand on clique sur une ligne
        /// </summary>
        /// <param name="sender">le tableau</param>
        /// <param name="e">les infos du clic</param>
        private void dgvUtilisateurs_SelectionChanged(object sender, EventArgs e)
        {
            AfficherUtilisateur();
        }

        /// <summary>
        /// ce code permet de remplir la fiche avec les infos de la personne choisie
        /// </summary>
        private void AfficherUtilisateur()
        {
            Personnel p = UtilisateurSelectionne();
            if (p == null)
            {
                return;
            }

            txtNomU.Text = p.Nom;
            txtPrenomU.Text = p.Prenom;
            txtAdresseU.Text = p.Adresse;
            if (p.DateEmbauche != null)
            {
                dtpDateEmbaucheU.Value = p.DateEmbauche.Value;
            }
            else
            {
                dtpDateEmbaucheU.Value = DateTime.Today;
            }
            txtLoginU.Text = p.Login;
            txtMdpU.Text = "";

            try
            {
                SelectionnerRegion(cboRegionU, Bdd.GetRegionActuelle(p));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de vider la fiche utilisateur
        /// </summary>
        private void ViderUtilisateur()
        {
            dgvUtilisateurs.ClearSelection();
            txtNomU.Text = "";
            txtPrenomU.Text = "";
            txtAdresseU.Text = "";
            dtpDateEmbaucheU.Value = DateTime.Today;
            txtLoginU.Text = "";
            txtMdpU.Text = "";
            cboRegionU.SelectedIndex = -1;
        }

        /// <summary>
        /// ce code permet de vider la fiche utilisateur
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnViderU_Click(object sender, EventArgs e)
        {
            ViderUtilisateur();
        }

        /// <summary>
        /// ce code permet de rajouter un utilisateur avec sa région
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnAjouterU_Click(object sender, EventArgs e)
        {
            if (txtNomU.Text.Trim() == "" || txtPrenomU.Text.Trim() == "" || txtLoginU.Text.Trim() == "" || txtMdpU.Text == "")
            {
                MessageBox.Show("Le nom, le prénom, le login et le mot de passe sont obligatoires.");
                return;
            }
            if (cboRegionU.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir la région.");
                return;
            }

            Personnel p = new Personnel(0, null, txtNomU.Text.Trim(), txtPrenomU.Text.Trim(), txtAdresseU.Text.Trim(), dtpDateEmbaucheU.Value.Date, txtLoginU.Text.Trim(), "utilisateur");

            try
            {
                Bdd.AjouterPersonnel(p, txtMdpU.Text);
                Bdd.AffecterRegion(p, (Region)cboRegionU.SelectedItem);
                MessageBox.Show("Utilisateur ajouté avec le matricule " + p.Matricule + ".");
                ChargerUtilisateurs();
                SelectionnerLigne(dgvUtilisateurs, p.IdPersonnel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageErreur(ex));
            }
        }

        /// <summary>
        /// ce code permet de modifier un utilisateur
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnModifierU_Click(object sender, EventArgs e)
        {
            Personnel ancien = UtilisateurSelectionne();
            if (ancien == null)
            {
                MessageBox.Show("Veuillez choisir un utilisateur dans la liste.");
                return;
            }
            if (txtNomU.Text.Trim() == "" || txtPrenomU.Text.Trim() == "" || txtLoginU.Text.Trim() == "")
            {
                MessageBox.Show("Le nom, le prénom et le login sont obligatoires.");
                return;
            }

            Personnel p = new Personnel(ancien.IdPersonnel, ancien.Matricule, txtNomU.Text.Trim(), txtPrenomU.Text.Trim(), txtAdresseU.Text.Trim(), dtpDateEmbaucheU.Value.Date, txtLoginU.Text.Trim(), "utilisateur");

            try
            {
                Bdd.ModifierPersonnel(p);

                if (txtMdpU.Text != "")
                {
                    Bdd.ModifierMotDePasse(p, txtMdpU.Text);
                }

                Region nouvelle = (Region)cboRegionU.SelectedItem;
                Region actuelle = Bdd.GetRegionActuelle(p);
                if (nouvelle != null && (actuelle == null || actuelle.IdRegion != nouvelle.IdRegion))
                {
                    Bdd.AffecterRegion(p, nouvelle);
                }

                MessageBox.Show("Utilisateur modifié.");
                ChargerUtilisateurs();
                SelectionnerLigne(dgvUtilisateurs, p.IdPersonnel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageErreur(ex));
            }
        }

        /// <summary>
        /// ce code permet de supprimer un utilisateur
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnSupprimerU_Click(object sender, EventArgs e)
        {
            Personnel p = UtilisateurSelectionne();
            if (p == null)
            {
                MessageBox.Show("Veuillez choisir un utilisateur dans la liste.");
                return;
            }

            DialogResult reponse = MessageBox.Show("Supprimer l'utilisateur " + p.Prenom + " " + p.Nom + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reponse != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Bdd.SupprimerPersonnel(p);
                ViderUtilisateur();
                ChargerUtilisateurs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageErreur(ex));
            }
        }

        /// <summary>
        /// ce code permet de remplir le tableau des techniciens
        /// </summary>
        private void ChargerTechniciens()
        {
            dgvTechniciens.Rows.Clear();

            List<Technicien> techniciens = Bdd.GetTechniciens();
            foreach (Technicien t in techniciens)
            {
                string region = "";
                Region r = Bdd.GetRegionActuelle(t);
                if (r != null)
                {
                    region = r.LibelleRegion;
                }

                int ligne = dgvTechniciens.Rows.Add(t.Matricule, t.Nom, t.Prenom, t.NiveauIntervention, region);
                dgvTechniciens.Rows[ligne].Tag = t;
            }

            AfficherTechnicien();
        }

        /// <summary>
        /// ce code permet de savoir quel technicien est choisi dans le tableau
        /// </summary>
        /// <returns>le technicien choisi ou null si il y en a pas</returns>
        private Technicien TechnicienSelectionne()
        {
            if (dgvTechniciens.SelectedRows.Count == 0)
            {
                return null;
            }
            return (Technicien)dgvTechniciens.SelectedRows[0].Tag;
        }

        /// <summary>
        /// ce code permet de remplir la fiche quand on clique sur une ligne
        /// </summary>
        /// <param name="sender">le tableau</param>
        /// <param name="e">les infos du clic</param>
        private void dgvTechniciens_SelectionChanged(object sender, EventArgs e)
        {
            AfficherTechnicien();
        }

        /// <summary>
        /// ce code permet de remplir la fiche avec les infos du technicien choisi
        /// </summary>
        private void AfficherTechnicien()
        {
            Technicien t = TechnicienSelectionne();
            if (t == null)
            {
                return;
            }

            txtNomT.Text = t.Nom;
            txtPrenomT.Text = t.Prenom;
            txtAdresseT.Text = t.Adresse;
            if (t.DateEmbauche != null)
            {
                dtpDateEmbaucheT.Value = t.DateEmbauche.Value;
            }
            else
            {
                dtpDateEmbaucheT.Value = DateTime.Today;
            }
            txtLoginT.Text = t.Login;
            txtMdpT.Text = "";
            cboNiveauT.SelectedIndex = t.NiveauIntervention - 1;
            txtFormationT.Text = t.Formation;
            txtCompetencesT.Text = t.Competences;

            try
            {
                SelectionnerRegion(cboRegionT, Bdd.GetRegionActuelle(t));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de vider la fiche technicien
        /// </summary>
        private void ViderTechnicien()
        {
            dgvTechniciens.ClearSelection();
            txtNomT.Text = "";
            txtPrenomT.Text = "";
            txtAdresseT.Text = "";
            dtpDateEmbaucheT.Value = DateTime.Today;
            txtLoginT.Text = "";
            txtMdpT.Text = "";
            cboRegionT.SelectedIndex = -1;
            cboNiveauT.SelectedIndex = 0;
            txtFormationT.Text = "";
            txtCompetencesT.Text = "";
        }

        /// <summary>
        /// ce code permet de vider la fiche technicien
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnViderT_Click(object sender, EventArgs e)
        {
            ViderTechnicien();
        }

        /// <summary>
        /// ce code permet de rajouter un technicien avec sa région
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnAjouterT_Click(object sender, EventArgs e)
        {
            if (txtNomT.Text.Trim() == "" || txtPrenomT.Text.Trim() == "" || txtLoginT.Text.Trim() == "" || txtMdpT.Text == "")
            {
                MessageBox.Show("Le nom, le prénom, le login et le mot de passe sont obligatoires.");
                return;
            }
            if (cboRegionT.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir la région.");
                return;
            }

            int niveau = cboNiveauT.SelectedIndex + 1;
            Technicien t = new Technicien(0, null, txtNomT.Text.Trim(), txtPrenomT.Text.Trim(), txtAdresseT.Text.Trim(), dtpDateEmbaucheT.Value.Date, txtLoginT.Text.Trim(), niveau, txtFormationT.Text.Trim(), txtCompetencesT.Text.Trim());

            try
            {
                Bdd.AjouterTechnicien(t, txtMdpT.Text);
                Bdd.AffecterRegion(t, (Region)cboRegionT.SelectedItem);
                MessageBox.Show("Technicien ajouté avec le matricule " + t.Matricule + ".");
                ChargerTechniciens();
                SelectionnerLigne(dgvTechniciens, t.IdPersonnel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageErreur(ex));
            }
        }

        /// <summary>
        /// ce code permet de modifier un technicien
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnModifierT_Click(object sender, EventArgs e)
        {
            Technicien ancien = TechnicienSelectionne();
            if (ancien == null)
            {
                MessageBox.Show("Veuillez choisir un technicien dans la liste.");
                return;
            }
            if (txtNomT.Text.Trim() == "" || txtPrenomT.Text.Trim() == "" || txtLoginT.Text.Trim() == "")
            {
                MessageBox.Show("Le nom, le prénom et le login sont obligatoires.");
                return;
            }

            int niveau = cboNiveauT.SelectedIndex + 1;
            Technicien t = new Technicien(ancien.IdPersonnel, ancien.Matricule, txtNomT.Text.Trim(), txtPrenomT.Text.Trim(), txtAdresseT.Text.Trim(), dtpDateEmbaucheT.Value.Date, txtLoginT.Text.Trim(), niveau, txtFormationT.Text.Trim(), txtCompetencesT.Text.Trim());

            try
            {
                Bdd.ModifierTechnicien(t);

                if (txtMdpT.Text != "")
                {
                    Bdd.ModifierMotDePasse(t, txtMdpT.Text);
                }

                Region nouvelle = (Region)cboRegionT.SelectedItem;
                Region actuelle = Bdd.GetRegionActuelle(t);
                if (nouvelle != null && (actuelle == null || actuelle.IdRegion != nouvelle.IdRegion))
                {
                    Bdd.AffecterRegion(t, nouvelle);
                }

                MessageBox.Show("Technicien modifié.");
                ChargerTechniciens();
                SelectionnerLigne(dgvTechniciens, t.IdPersonnel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageErreur(ex));
            }
        }

        /// <summary>
        /// ce code permet de supprimer un technicien
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnSupprimerT_Click(object sender, EventArgs e)
        {
            Technicien t = TechnicienSelectionne();
            if (t == null)
            {
                MessageBox.Show("Veuillez choisir un technicien dans la liste.");
                return;
            }

            DialogResult reponse = MessageBox.Show("Supprimer le technicien " + t.Prenom + " " + t.Nom + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reponse != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Bdd.SupprimerPersonnel(t);
                ViderTechnicien();
                ChargerTechniciens();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageErreur(ex));
            }
        }

        /// <summary>
        /// ce code permet de remplir les stats des incidents des utilisateurs et des techniciens
        /// </summary>
        private void ChargerStatistiques()
        {
            Statistiques s = Bdd.GetStatistiques();
            lblDeclares.Text = "Déclarés (pas encore pris en charge) : " + s.NbDeclares + " (" + s.PourcentageDeclares.ToString("0") + " %)";
            lblEnCharge.Text = "En cours de traitement : " + s.NbEnCharge + " (" + s.PourcentageEnCharge.ToString("0") + " %)";
            lblResolus.Text = "Résolus ou clôturés : " + s.NbResolus + " (" + s.PourcentageResolus.ToString("0") + " %)";
            lblTotal.Text = "Total : " + s.NbIncidents + " incident(s)";
            lblDelai.Text = "Délai moyen de résolution : " + s.DelaiMoyenJours.ToString("0.0") + " jour(s)";

            dgvStatsUtilisateurs.Rows.Clear();
            List<Personnel> utilisateurs = Bdd.GetPersonnels("utilisateur");
            foreach (Personnel p in utilisateurs)
            {
                string nom = p.Nom + " " + p.Prenom + " (" + p.Matricule + ")";
                dgvStatsUtilisateurs.Rows.Add(nom, Bdd.GetNbIncidents(p));
            }

            dgvStatsTechniciens.Rows.Clear();
            List<StatTechnicien> stats = Bdd.GetStatsTechniciens();
            foreach (StatTechnicien st in stats)
            {
                string nom = st.Technicien.Prenom + " " + st.Technicien.Nom;
                dgvStatsTechniciens.Rows.Add(nom, st.Technicien.NiveauIntervention, st.NbEnCharge, st.NbResolus, st.NbHeures.ToString("0.0"));
            }
        }

        /// <summary>
        /// ce code permet de recharger les stats
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            try
            {
                ChargerStatistiques();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de sauvegarder la base dans gsb_sauvegarde
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            try
            {
                Bdd.SauvegarderBase();
                MessageBox.Show("La base a été sauvegardée dans gsb_sauvegarde.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
