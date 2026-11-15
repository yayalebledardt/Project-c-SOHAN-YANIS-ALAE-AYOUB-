namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de gérer la fenêtre technicien
    /// </summary>
    public partial class FormTechnicien : Form
    {
        /// <summary>
        /// ce code permet de créer la fenêtre
        /// </summary>
        public FormTechnicien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ce code permet de remplir les listes quand la fenêtre se lance
        /// </summary>
        /// <param name="sender">la fenêtre</param>
        /// <param name="e">les infos du chargement</param>
        private void FormTechnicien_Load(object sender, EventArgs e)
        {
            cboTypePriseEnCharge.SelectedIndex = 0;
            cboMode.SelectedIndex = 0;
            dtpDebut.Value = DateTime.Today.AddHours(9);
            dtpFin.Value = DateTime.Today.AddHours(10);

            try
            {
                List<Technicien> techniciens = Bdd.GetTechniciens();
                foreach (Technicien t in techniciens)
                {
                    cboTechnicien.Items.Add(t);
                }

                ChargerListesMateriel();
                ChargerMateriels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données.\r\nVérifiez que MySQL est démarré dans XAMPP.\r\n\r\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ce code permet de charger les incidents quand on choisit un technicien
        /// </summary>
        /// <param name="sender">la liste déroulante</param>
        /// <param name="e">les infos du changement</param>
        private void cboTechnicien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChargerIncidents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de remplir le tableau des incidents du technicien
        /// </summary>
        private void ChargerIncidents()
        {
            dgvIncidents.Rows.Clear();

            Technicien t = (Technicien)cboTechnicien.SelectedItem;
            if (t == null)
            {
                return;
            }

            List<Incident> incidents = Bdd.GetIncidentsPourTechnicien(t);
            foreach (Incident i in incidents)
            {
                string declarant = i.Declarant.Prenom + " " + i.Declarant.Nom;
                int ligne = dgvIncidents.Rows.Add(i.IdIncident, i.Objet, i.NiveauUrgence, i.NiveauDemande, declarant, i.Etat);
                dgvIncidents.Rows[ligne].Tag = i;
            }

            AfficherDetail();
        }

        /// <summary>
        /// ce code permet de remettre la sélection sur un incident dans le tableau
        /// </summary>
        /// <param name="idIncident">le numéro à retrouver</param>
        private void SelectionnerIncident(int idIncident)
        {
            foreach (DataGridViewRow ligne in dgvIncidents.Rows)
            {
                Incident i = (Incident)ligne.Tag;
                if (i.IdIncident == idIncident)
                {
                    dgvIncidents.CurrentCell = ligne.Cells[0];
                }
            }
        }

        /// <summary>
        /// ce code permet de savoir quel incident est choisi dans le tableau
        /// </summary>
        /// <returns>incident choisi ou null si il y en a pas</returns>
        private Incident IncidentSelectionne()
        {
            if (dgvIncidents.SelectedRows.Count == 0)
            {
                return null;
            }
            return (Incident)dgvIncidents.SelectedRows[0].Tag;
        }

        /// <summary>
        /// ce code permet de montrer le détail quand on clique sur une ligne
        /// </summary>
        /// <param name="sender">le tableau</param>
        /// <param name="e">les infos du clic</param>
        private void dgvIncidents_SelectionChanged(object sender, EventArgs e)
        {
            AfficherDetail();
        }

        /// <summary>
        /// ce code permet de montrer le détail et les interventions dans la zone de texte
        /// si le matériel est loué on montre une alerte avec le loueur
        /// </summary>
        private void AfficherDetail()
        {
            Incident i = IncidentSelectionne();
            if (i == null)
            {
                txtDetail.Text = "";
                return;
            }

            string texte = "Incident n°" + i.IdIncident + " : " + i.Objet + "\r\n";
            texte = texte + "Déclaré par : " + i.Declarant.Prenom + " " + i.Declarant.Nom + " (" + i.Declarant.Matricule + ")\r\n";
            texte = texte + "Le : " + i.DateDeclaration.ToString("dd/MM/yyyy HH:mm") + "\r\n";
            texte = texte + "Matériel : n°" + i.Materiel.IdMateriel + " " + i.Materiel.TypeMateriel + " " + i.Materiel.Composants + "\r\n";
            texte = texte + "Urgence : " + i.NiveauUrgence + " - Niveau de la demande : " + i.NiveauDemande + "\r\n";
            texte = texte + "État : " + i.Etat + "\r\n";

            if (i.Technicien != null)
            {
                texte = texte + "Pris en charge par : " + i.Technicien.Prenom + " " + i.Technicien.Nom + " (" + i.TypePriseEnCharge + ")\r\n";
            }

            if (i.Materiel.ModeAcquisition == "location")
            {
                texte = texte + "\r\nATTENTION : MATÉRIEL LOUÉ, la réparation doit être transmise au loueur";
                if (i.Materiel.Fournisseur != null)
                {
                    texte = texte + " " + i.Materiel.Fournisseur.NomFournisseur + " (tél : " + i.Materiel.Fournisseur.Telephone + ")";
                }
                texte = texte + ".\r\n";
            }

            texte = texte + "\r\nDescription :\r\n" + i.Description + "\r\n";

            try
            {
                List<Intervention> interventions = Bdd.GetInterventions(i);
                texte = texte + "\r\nInterventions (" + interventions.Count + ") :\r\n";
                foreach (Intervention v in interventions)
                {
                    texte = texte + "- " + v.ToString() + " (" + v.Technicien.Prenom + " " + v.Technicien.Nom + ")\r\n";
                }
            }
            catch (Exception ex)
            {
                texte = texte + "\r\nImpossible de lire les interventions : " + ex.Message;
            }

            txtDetail.Text = texte;
        }

        /// <summary>
        /// ce code permet de vérifier que cet incident est en cours et pris par ce technicien
        /// </summary>
        /// <param name="i">un incident de la liste</param>
        /// <param name="t">le technicien choisi</param>
        /// <returns>true si oui sinon false</returns>
        private bool EstMonIncidentEnCours(Incident i, Technicien t)
        {
            if (i.Etat != "En cours de traitement")
            {
                return false;
            }
            if (i.Technicien == null)
            {
                return false;
            }
            return i.Technicien.IdPersonnel == t.IdPersonnel;
        }

        /// <summary>
        /// ce code permet de prendre en charge un incident
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnPrendreEnCharge_Click(object sender, EventArgs e)
        {
            Technicien t = (Technicien)cboTechnicien.SelectedItem;
            Incident i = IncidentSelectionne();
            if (t == null || i == null)
            {
                MessageBox.Show("Veuillez choisir le technicien puis un incident dans la liste.");
                return;
            }
            if (i.Etat != "Enregistrée")
            {
                MessageBox.Show("Cet incident est déjà pris en charge.");
                return;
            }

            try
            {
                Bdd.PrendreEnCharge(i, t, cboTypePriseEnCharge.SelectedItem.ToString());
                ChargerIncidents();
                SelectionnerIncident(i.IdIncident);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de rajouter une intervention sur un incident
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnAjouterIntervention_Click(object sender, EventArgs e)
        {
            Technicien t = (Technicien)cboTechnicien.SelectedItem;
            Incident i = IncidentSelectionne();
            if (t == null || i == null)
            {
                MessageBox.Show("Veuillez choisir le technicien puis un incident dans la liste.");
                return;
            }
            if (EstMonIncidentEnCours(i, t) == false)
            {
                MessageBox.Show("Vous pouvez seulement ajouter une intervention sur un incident que vous avez pris en charge et qui est en cours de traitement.");
                return;
            }
            if (txtTravail.Text.Trim() == "")
            {
                MessageBox.Show("Veuillez décrire le travail réalisé.");
                return;
            }

            TimeSpan debut = new TimeSpan(dtpDebut.Value.Hour, dtpDebut.Value.Minute, 0);
            TimeSpan fin = new TimeSpan(dtpFin.Value.Hour, dtpFin.Value.Minute, 0);
            Intervention v = new Intervention(0, dtpDateIntervention.Value.Date, debut, fin, txtTravail.Text.Trim(), i, t);

            try
            {
                Bdd.AjouterIntervention(v);
                MessageBox.Show("Intervention enregistrée.");
                txtTravail.Text = "";
                AfficherDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de passer un incident en résolue
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnResolu_Click(object sender, EventArgs e)
        {
            Technicien t = (Technicien)cboTechnicien.SelectedItem;
            Incident i = IncidentSelectionne();
            if (t == null || i == null)
            {
                MessageBox.Show("Veuillez choisir le technicien puis un incident dans la liste.");
                return;
            }
            if (EstMonIncidentEnCours(i, t) == false)
            {
                MessageBox.Show("Vous pouvez seulement résoudre un incident que vous avez pris en charge et qui est en cours de traitement.");
                return;
            }

            try
            {
                if (Bdd.GetInterventions(i).Count == 0)
                {
                    MessageBox.Show("Enregistrez au moins une intervention avant de marquer l'incident comme résolu.");
                    return;
                }

                Bdd.ResoudreIncident(i);
                ChargerIncidents();
                SelectionnerIncident(i.IdIncident);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de passer un incident en clôturée
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnCloturer_Click(object sender, EventArgs e)
        {
            Incident i = IncidentSelectionne();
            if (i == null)
            {
                MessageBox.Show("Veuillez choisir un incident dans la liste.");
                return;
            }
            if (i.Etat != "Résolue")
            {
                MessageBox.Show("Seul un incident résolu peut être clôturé.");
                return;
            }

            try
            {
                Bdd.CloturerIncident(i);
                ChargerIncidents();
                SelectionnerIncident(i.IdIncident);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de remplir les listes des personnes et des fournisseurs
        /// </summary>
        private void ChargerListesMateriel()
        {
            cboPersonnel.Items.Clear();
            cboPersonnel.Items.Add("(personne)");
            string[] roles = { "utilisateur", "technicien", "responsable" };
            foreach (string role in roles)
            {
                List<Personnel> personnels = Bdd.GetPersonnels(role);
                foreach (Personnel p in personnels)
                {
                    cboPersonnel.Items.Add(p);
                }
            }
            cboPersonnel.SelectedIndex = 0;

            cboFournisseur.Items.Clear();
            cboFournisseur.Items.Add("(aucun)");
            List<Fournisseur> fournisseurs = Bdd.GetFournisseurs();
            foreach (Fournisseur f in fournisseurs)
            {
                cboFournisseur.Items.Add(f);
            }
            cboFournisseur.SelectedIndex = 0;
        }

        /// <summary>
        /// ce code permet de remplir le tableau du matériel
        /// </summary>
        private void ChargerMateriels()
        {
            dgvMateriels.Rows.Clear();

            List<Materiel> materiels = Bdd.GetMateriels();
            foreach (Materiel m in materiels)
            {
                string affecteA = "";
                if (m.Personnel != null)
                {
                    affecteA = m.Personnel.Prenom + " " + m.Personnel.Nom;
                }

                string fournisseur = "";
                if (m.Fournisseur != null)
                {
                    fournisseur = m.Fournisseur.NomFournisseur;
                }

                int ligne = dgvMateriels.Rows.Add(m.IdMateriel, m.TypeMateriel, m.ModeAcquisition, affecteA, fournisseur);
                dgvMateriels.Rows[ligne].Tag = m;
            }
        }

        /// <summary>
        /// ce code permet de supprimer le matériel choisi
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnSupprimerMateriel_Click(object sender, EventArgs e)
        {
            if (dgvMateriels.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez choisir un matériel dans la liste.");
                return;
            }

            Materiel m = (Materiel)dgvMateriels.SelectedRows[0].Tag;
            DialogResult reponse = MessageBox.Show("Supprimer le matériel n°" + m.IdMateriel + " (" + m.TypeMateriel + ") ?\r\nSes anciens incidents seront supprimés aussi.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reponse != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Bdd.SupprimerMateriel(m);
                ChargerMateriels();
                ChargerIncidents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ce code permet de rajouter un matériel
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnAjouterMateriel_Click(object sender, EventArgs e)
        {
            if (txtTypeMateriel.Text.Trim() == "")
            {
                MessageBox.Show("Veuillez indiquer le type de matériel.");
                return;
            }

            Personnel personnel = null;
            if (cboPersonnel.SelectedIndex > 0)
            {
                personnel = (Personnel)cboPersonnel.SelectedItem;
            }

            Fournisseur fournisseur = null;
            if (cboFournisseur.SelectedIndex > 0)
            {
                fournisseur = (Fournisseur)cboFournisseur.SelectedItem;
            }

            string mode = cboMode.SelectedItem.ToString();
            if (mode == "location" && fournisseur == null)
            {
                MessageBox.Show("Un matériel loué doit avoir un fournisseur (le loueur).");
                return;
            }

            Materiel m = new Materiel(0, txtTypeMateriel.Text.Trim(), txtComposants.Text.Trim(), txtLogiciels.Text.Trim(), dtpDateAcquisition.Value.Date, txtGarantie.Text.Trim(), mode, personnel, fournisseur);

            try
            {
                Bdd.AjouterMateriel(m);
                MessageBox.Show("Matériel n°" + m.IdMateriel + " ajouté.");
                txtTypeMateriel.Text = "";
                txtComposants.Text = "";
                txtLogiciels.Text = "";
                txtGarantie.Text = "";
                cboMode.SelectedIndex = 0;
                cboPersonnel.SelectedIndex = 0;
                cboFournisseur.SelectedIndex = 0;
                ChargerMateriels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
