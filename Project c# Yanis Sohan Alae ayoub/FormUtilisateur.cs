namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public partial class FormUtilisateur : Form
    {
        public FormUtilisateur()
        {
            InitializeComponent();
        }

        private void FormUtilisateur_Load(object sender, EventArgs e)
        {
            cboUrgence.SelectedIndex = 0;

            try
            {
                List<Personnel> utilisateurs = Bdd.GetPersonnels("utilisateur");
                foreach (Personnel p in utilisateurs)
                {
                    cboUtilisateur.Items.Add(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données.\r\nVérifiez que MySQL est démarré dans XAMPP.\r\n\r\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboUtilisateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChargerMateriels();
                ChargerIncidents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void ChargerMateriels()
        {
            cboMateriel.Items.Clear();

            Personnel utilisateur = (Personnel)cboUtilisateur.SelectedItem;
            List<Materiel> materiels = Bdd.GetMaterielsDuPersonnel(utilisateur);
            foreach (Materiel m in materiels)
            {
                cboMateriel.Items.Add(m);
            }

            if (cboMateriel.Items.Count > 0)
            {
                cboMateriel.SelectedIndex = 0;
            }
        }

        private void ChargerIncidents()
        {
            dgvIncidents.Rows.Clear();

            Personnel utilisateur = (Personnel)cboUtilisateur.SelectedItem;
            List<Incident> incidents = Bdd.GetIncidentsDuDeclarant(utilisateur);
            foreach (Incident i in incidents)
            {
                int ligne = dgvIncidents.Rows.Add(i.IdIncident, i.Objet, i.Materiel.TypeMateriel, i.DateDeclaration.ToString("dd/MM/yyyy"), i.Etat);
                dgvIncidents.Rows[ligne].Tag = i;
            }

            AfficherDetail();
        }

        private Incident IncidentSelectionne()
        {
            if (dgvIncidents.SelectedRows.Count == 0)
            {
                return null;
            }
            return (Incident)dgvIncidents.SelectedRows[0].Tag;
        }

        private void dgvIncidents_SelectionChanged(object sender, EventArgs e)
        {
            AfficherDetail();
        }

        private void AfficherDetail()
        {
            Incident i = IncidentSelectionne();
            if (i == null)
            {
                txtDetail.Text = "";
                return;
            }

            string texte = "Incident n°" + i.IdIncident + " : " + i.Objet + "\r\n";
            texte = texte + "Matériel : " + i.Materiel.TypeMateriel + " " + i.Materiel.Composants + "\r\n";
            texte = texte + "Urgence : " + i.NiveauUrgence + "\r\n";
            texte = texte + "État : " + i.Etat + "\r\n";
            texte = texte + "Déclaré le : " + i.DateDeclaration.ToString("dd/MM/yyyy HH:mm") + "\r\n";

            if (i.Technicien != null)
            {
                texte = texte + "Pris en charge par : " + i.Technicien.Prenom + " " + i.Technicien.Nom + " (" + i.TypePriseEnCharge + ")";
                if (i.DatePriseEnCharge != null)
                {
                    texte = texte + " le " + i.DatePriseEnCharge.Value.ToString("dd/MM/yyyy HH:mm");
                }
                texte = texte + "\r\n";
            }

            if (i.DateResolution != null)
            {
                texte = texte + "Résolu le : " + i.DateResolution.Value.ToString("dd/MM/yyyy HH:mm") + "\r\n";
            }

            texte = texte + "\r\nDescription :\r\n" + i.Description + "\r\n";

            try
            {
                List<Intervention> interventions = Bdd.GetInterventions(i);
                texte = texte + "\r\nInterventions (" + interventions.Count + ") :\r\n";
                foreach (Intervention v in interventions)
                {
                    texte = texte + "- " + v.ToString() + "\r\n";
                }
            }
            catch (Exception ex)
            {
                texte = texte + "\r\nImpossible de lire les interventions : " + ex.Message;
            }

            txtDetail.Text = texte;
        }

        private void btnDeclarer_Click(object sender, EventArgs e)
        {
            if (cboUtilisateur.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir l'utilisateur en haut de la fenêtre.");
                return;
            }
            if (cboMateriel.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir le matériel concerné.");
                return;
            }
            if (txtObjet.Text.Trim() == "")
            {
                MessageBox.Show("Veuillez écrire l'objet de l'incident.");
                return;
            }

            Personnel utilisateur = (Personnel)cboUtilisateur.SelectedItem;
            Materiel materiel = (Materiel)cboMateriel.SelectedItem;
            int urgence = cboUrgence.SelectedIndex + 1;
            Incident incident = new Incident(txtObjet.Text.Trim(), txtDescription.Text.Trim(), urgence, 1, utilisateur, materiel);

            try
            {
                Bdd.DeclarerIncident(incident);
                MessageBox.Show("L'incident n°" + incident.IdIncident + " a bien été enregistré.");
                txtObjet.Text = "";
                txtDescription.Text = "";
                cboUrgence.SelectedIndex = 0;
                ChargerIncidents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
