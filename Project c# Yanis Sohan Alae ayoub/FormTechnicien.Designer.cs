namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    partial class FormTechnicien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTechnicien = new Label();
            cboTechnicien = new ComboBox();
            tabControl1 = new TabControl();
            tabIncidents = new TabPage();
            lblListe = new Label();
            dgvIncidents = new DataGridView();
            colNumero = new DataGridViewTextBoxColumn();
            colObjet = new DataGridViewTextBoxColumn();
            colUrgence = new DataGridViewTextBoxColumn();
            colNiveau = new DataGridViewTextBoxColumn();
            colDeclarant = new DataGridViewTextBoxColumn();
            colEtat = new DataGridViewTextBoxColumn();
            lblDetail = new Label();
            txtDetail = new TextBox();
            grpPriseEnCharge = new GroupBox();
            lblType = new Label();
            cboTypePriseEnCharge = new ComboBox();
            btnPrendreEnCharge = new Button();
            grpIntervention = new GroupBox();
            lblDateIntervention = new Label();
            dtpDateIntervention = new DateTimePicker();
            lblDebut = new Label();
            dtpDebut = new DateTimePicker();
            lblFin = new Label();
            dtpFin = new DateTimePicker();
            lblTravail = new Label();
            txtTravail = new TextBox();
            btnAjouterIntervention = new Button();
            btnResolu = new Button();
            btnCloturer = new Button();
            tabMateriels = new TabPage();
            dgvMateriels = new DataGridView();
            colNumMateriel = new DataGridViewTextBoxColumn();
            colTypeMateriel = new DataGridViewTextBoxColumn();
            colMode = new DataGridViewTextBoxColumn();
            colAffecteA = new DataGridViewTextBoxColumn();
            colFournisseur = new DataGridViewTextBoxColumn();
            btnSupprimerMateriel = new Button();
            grpAjoutMateriel = new GroupBox();
            lblTypeMateriel = new Label();
            txtTypeMateriel = new TextBox();
            lblComposants = new Label();
            txtComposants = new TextBox();
            lblLogiciels = new Label();
            txtLogiciels = new TextBox();
            lblDateAcquisition = new Label();
            dtpDateAcquisition = new DateTimePicker();
            lblGarantie = new Label();
            txtGarantie = new TextBox();
            lblMode = new Label();
            cboMode = new ComboBox();
            lblAffecteA = new Label();
            cboPersonnel = new ComboBox();
            lblFournisseur = new Label();
            cboFournisseur = new ComboBox();
            btnAjouterMateriel = new Button();
            tabControl1.SuspendLayout();
            tabIncidents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).BeginInit();
            grpPriseEnCharge.SuspendLayout();
            grpIntervention.SuspendLayout();
            tabMateriels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMateriels).BeginInit();
            grpAjoutMateriel.SuspendLayout();
            SuspendLayout();
            // 
            // lblTechnicien
            // 
            lblTechnicien.AutoSize = true;
            lblTechnicien.Location = new Point(20, 18);
            lblTechnicien.Name = "lblTechnicien";
            lblTechnicien.Size = new Size(77, 15);
            lblTechnicien.TabIndex = 0;
            lblTechnicien.Text = "Technicien :";
            // 
            // cboTechnicien
            // 
            cboTechnicien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTechnicien.FormattingEnabled = true;
            cboTechnicien.Location = new Point(100, 15);
            cboTechnicien.Name = "cboTechnicien";
            cboTechnicien.Size = new Size(200, 23);
            cboTechnicien.TabIndex = 1;
            cboTechnicien.SelectedIndexChanged += cboTechnicien_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabIncidents);
            tabControl1.Controls.Add(tabMateriels);
            tabControl1.Location = new Point(20, 50);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(860, 530);
            tabControl1.TabIndex = 2;
            // 
            // tabIncidents
            // 
            tabIncidents.Controls.Add(btnCloturer);
            tabIncidents.Controls.Add(btnResolu);
            tabIncidents.Controls.Add(grpIntervention);
            tabIncidents.Controls.Add(grpPriseEnCharge);
            tabIncidents.Controls.Add(txtDetail);
            tabIncidents.Controls.Add(lblDetail);
            tabIncidents.Controls.Add(dgvIncidents);
            tabIncidents.Controls.Add(lblListe);
            tabIncidents.Location = new Point(4, 24);
            tabIncidents.Name = "tabIncidents";
            tabIncidents.Padding = new Padding(3);
            tabIncidents.Size = new Size(852, 502);
            tabIncidents.TabIndex = 0;
            tabIncidents.Text = "Incidents";
            tabIncidents.UseVisualStyleBackColor = true;
            // 
            // lblListe
            // 
            lblListe.AutoSize = true;
            lblListe.Location = new Point(10, 10);
            lblListe.Name = "lblListe";
            lblListe.Size = new Size(132, 15);
            lblListe.TabIndex = 0;
            lblListe.Text = "Incidents à traiter :";
            // 
            // dgvIncidents
            // 
            dgvIncidents.AllowUserToAddRows = false;
            dgvIncidents.AllowUserToDeleteRows = false;
            dgvIncidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIncidents.Columns.AddRange(new DataGridViewColumn[] { colNumero, colObjet, colUrgence, colNiveau, colDeclarant, colEtat });
            dgvIncidents.Location = new Point(10, 30);
            dgvIncidents.MultiSelect = false;
            dgvIncidents.Name = "dgvIncidents";
            dgvIncidents.ReadOnly = true;
            dgvIncidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIncidents.Size = new Size(480, 260);
            dgvIncidents.TabIndex = 1;
            dgvIncidents.SelectionChanged += dgvIncidents_SelectionChanged;
            // 
            // colNumero
            // 
            colNumero.FillWeight = 40F;
            colNumero.HeaderText = "N°";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            // 
            // colObjet
            // 
            colObjet.FillWeight = 120F;
            colObjet.HeaderText = "Objet";
            colObjet.Name = "colObjet";
            colObjet.ReadOnly = true;
            // 
            // colUrgence
            // 
            colUrgence.FillWeight = 70F;
            colUrgence.HeaderText = "Urgence";
            colUrgence.Name = "colUrgence";
            colUrgence.ReadOnly = true;
            // 
            // colNiveau
            // 
            colNiveau.FillWeight = 60F;
            colNiveau.HeaderText = "Niveau";
            colNiveau.Name = "colNiveau";
            colNiveau.ReadOnly = true;
            // 
            // colDeclarant
            // 
            colDeclarant.HeaderText = "Déclarant";
            colDeclarant.Name = "colDeclarant";
            colDeclarant.ReadOnly = true;
            // 
            // colEtat
            // 
            colEtat.FillWeight = 110F;
            colEtat.HeaderText = "État";
            colEtat.Name = "colEtat";
            colEtat.ReadOnly = true;
            // 
            // lblDetail
            // 
            lblDetail.AutoSize = true;
            lblDetail.Location = new Point(10, 300);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(52, 15);
            lblDetail.TabIndex = 2;
            lblDetail.Text = "Détail :";
            // 
            // txtDetail
            // 
            txtDetail.Location = new Point(10, 320);
            txtDetail.Multiline = true;
            txtDetail.Name = "txtDetail";
            txtDetail.ReadOnly = true;
            txtDetail.ScrollBars = ScrollBars.Vertical;
            txtDetail.Size = new Size(480, 170);
            txtDetail.TabIndex = 3;
            // 
            // grpPriseEnCharge
            // 
            grpPriseEnCharge.Controls.Add(btnPrendreEnCharge);
            grpPriseEnCharge.Controls.Add(cboTypePriseEnCharge);
            grpPriseEnCharge.Controls.Add(lblType);
            grpPriseEnCharge.Location = new Point(510, 10);
            grpPriseEnCharge.Name = "grpPriseEnCharge";
            grpPriseEnCharge.Size = new Size(330, 100);
            grpPriseEnCharge.TabIndex = 4;
            grpPriseEnCharge.TabStop = false;
            grpPriseEnCharge.Text = "Prise en charge";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(15, 30);
            lblType.Name = "lblType";
            lblType.Size = new Size(40, 15);
            lblType.TabIndex = 0;
            lblType.Text = "Type :";
            // 
            // cboTypePriseEnCharge
            // 
            cboTypePriseEnCharge.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTypePriseEnCharge.FormattingEnabled = true;
            cboTypePriseEnCharge.Items.AddRange(new object[] { "Téléphone", "Télémaintenance", "Déplacement sur site" });
            cboTypePriseEnCharge.Location = new Point(70, 27);
            cboTypePriseEnCharge.Name = "cboTypePriseEnCharge";
            cboTypePriseEnCharge.Size = new Size(240, 23);
            cboTypePriseEnCharge.TabIndex = 1;
            // 
            // btnPrendreEnCharge
            // 
            btnPrendreEnCharge.Location = new Point(70, 60);
            btnPrendreEnCharge.Name = "btnPrendreEnCharge";
            btnPrendreEnCharge.Size = new Size(140, 28);
            btnPrendreEnCharge.TabIndex = 2;
            btnPrendreEnCharge.Text = "Prendre en charge";
            btnPrendreEnCharge.UseVisualStyleBackColor = true;
            btnPrendreEnCharge.Click += btnPrendreEnCharge_Click;
            // 
            // grpIntervention
            // 
            grpIntervention.Controls.Add(btnAjouterIntervention);
            grpIntervention.Controls.Add(txtTravail);
            grpIntervention.Controls.Add(lblTravail);
            grpIntervention.Controls.Add(dtpFin);
            grpIntervention.Controls.Add(lblFin);
            grpIntervention.Controls.Add(dtpDebut);
            grpIntervention.Controls.Add(lblDebut);
            grpIntervention.Controls.Add(dtpDateIntervention);
            grpIntervention.Controls.Add(lblDateIntervention);
            grpIntervention.Location = new Point(510, 120);
            grpIntervention.Name = "grpIntervention";
            grpIntervention.Size = new Size(330, 270);
            grpIntervention.TabIndex = 5;
            grpIntervention.TabStop = false;
            grpIntervention.Text = "Enregistrer le travail effectué";
            // 
            // lblDateIntervention
            // 
            lblDateIntervention.AutoSize = true;
            lblDateIntervention.Location = new Point(15, 30);
            lblDateIntervention.Name = "lblDateIntervention";
            lblDateIntervention.Size = new Size(40, 15);
            lblDateIntervention.TabIndex = 0;
            lblDateIntervention.Text = "Date :";
            // 
            // dtpDateIntervention
            // 
            dtpDateIntervention.Format = DateTimePickerFormat.Short;
            dtpDateIntervention.Location = new Point(70, 27);
            dtpDateIntervention.Name = "dtpDateIntervention";
            dtpDateIntervention.Size = new Size(150, 23);
            dtpDateIntervention.TabIndex = 1;
            // 
            // lblDebut
            // 
            lblDebut.AutoSize = true;
            lblDebut.Location = new Point(15, 65);
            lblDebut.Name = "lblDebut";
            lblDebut.Size = new Size(28, 15);
            lblDebut.TabIndex = 2;
            lblDebut.Text = "De :";
            // 
            // dtpDebut
            // 
            dtpDebut.CustomFormat = "HH:mm";
            dtpDebut.Format = DateTimePickerFormat.Custom;
            dtpDebut.Location = new Point(70, 62);
            dtpDebut.Name = "dtpDebut";
            dtpDebut.ShowUpDown = true;
            dtpDebut.Size = new Size(80, 23);
            dtpDebut.TabIndex = 3;
            // 
            // lblFin
            // 
            lblFin.AutoSize = true;
            lblFin.Location = new Point(160, 65);
            lblFin.Name = "lblFin";
            lblFin.Size = new Size(22, 15);
            lblFin.TabIndex = 4;
            lblFin.Text = "à :";
            // 
            // dtpFin
            // 
            dtpFin.CustomFormat = "HH:mm";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.Location = new Point(190, 62);
            dtpFin.Name = "dtpFin";
            dtpFin.ShowUpDown = true;
            dtpFin.Size = new Size(80, 23);
            dtpFin.TabIndex = 5;
            // 
            // lblTravail
            // 
            lblTravail.AutoSize = true;
            lblTravail.Location = new Point(15, 100);
            lblTravail.Name = "lblTravail";
            lblTravail.Size = new Size(107, 15);
            lblTravail.TabIndex = 6;
            lblTravail.Text = "Travail réalisé :";
            // 
            // txtTravail
            // 
            txtTravail.Location = new Point(15, 120);
            txtTravail.Multiline = true;
            txtTravail.Name = "txtTravail";
            txtTravail.ScrollBars = ScrollBars.Vertical;
            txtTravail.Size = new Size(300, 100);
            txtTravail.TabIndex = 7;
            // 
            // btnAjouterIntervention
            // 
            btnAjouterIntervention.Location = new Point(15, 230);
            btnAjouterIntervention.Name = "btnAjouterIntervention";
            btnAjouterIntervention.Size = new Size(170, 28);
            btnAjouterIntervention.TabIndex = 8;
            btnAjouterIntervention.Text = "Enregistrer l'intervention";
            btnAjouterIntervention.UseVisualStyleBackColor = true;
            btnAjouterIntervention.Click += btnAjouterIntervention_Click;
            // 
            // btnResolu
            // 
            btnResolu.Location = new Point(510, 405);
            btnResolu.Name = "btnResolu";
            btnResolu.Size = new Size(160, 35);
            btnResolu.TabIndex = 6;
            btnResolu.Text = "Marquer comme résolu";
            btnResolu.UseVisualStyleBackColor = true;
            btnResolu.Click += btnResolu_Click;
            // 
            // btnCloturer
            // 
            btnCloturer.Location = new Point(680, 405);
            btnCloturer.Name = "btnCloturer";
            btnCloturer.Size = new Size(160, 35);
            btnCloturer.TabIndex = 7;
            btnCloturer.Text = "Clôturer l'incident";
            btnCloturer.UseVisualStyleBackColor = true;
            btnCloturer.Click += btnCloturer_Click;
            // 
            // tabMateriels
            // 
            tabMateriels.Controls.Add(grpAjoutMateriel);
            tabMateriels.Controls.Add(btnSupprimerMateriel);
            tabMateriels.Controls.Add(dgvMateriels);
            tabMateriels.Location = new Point(4, 24);
            tabMateriels.Name = "tabMateriels";
            tabMateriels.Padding = new Padding(3);
            tabMateriels.Size = new Size(852, 502);
            tabMateriels.TabIndex = 1;
            tabMateriels.Text = "Matériels";
            tabMateriels.UseVisualStyleBackColor = true;
            // 
            // dgvMateriels
            // 
            dgvMateriels.AllowUserToAddRows = false;
            dgvMateriels.AllowUserToDeleteRows = false;
            dgvMateriels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMateriels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMateriels.Columns.AddRange(new DataGridViewColumn[] { colNumMateriel, colTypeMateriel, colMode, colAffecteA, colFournisseur });
            dgvMateriels.Location = new Point(10, 10);
            dgvMateriels.MultiSelect = false;
            dgvMateriels.Name = "dgvMateriels";
            dgvMateriels.ReadOnly = true;
            dgvMateriels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMateriels.Size = new Size(500, 440);
            dgvMateriels.TabIndex = 0;
            // 
            // colNumMateriel
            // 
            colNumMateriel.FillWeight = 40F;
            colNumMateriel.HeaderText = "N°";
            colNumMateriel.Name = "colNumMateriel";
            colNumMateriel.ReadOnly = true;
            // 
            // colTypeMateriel
            // 
            colTypeMateriel.FillWeight = 110F;
            colTypeMateriel.HeaderText = "Type";
            colTypeMateriel.Name = "colTypeMateriel";
            colTypeMateriel.ReadOnly = true;
            // 
            // colMode
            // 
            colMode.FillWeight = 70F;
            colMode.HeaderText = "Mode";
            colMode.Name = "colMode";
            colMode.ReadOnly = true;
            // 
            // colAffecteA
            // 
            colAffecteA.FillWeight = 110F;
            colAffecteA.HeaderText = "Affecté à";
            colAffecteA.Name = "colAffecteA";
            colAffecteA.ReadOnly = true;
            // 
            // colFournisseur
            // 
            colFournisseur.FillWeight = 110F;
            colFournisseur.HeaderText = "Fournisseur";
            colFournisseur.Name = "colFournisseur";
            colFournisseur.ReadOnly = true;
            // 
            // btnSupprimerMateriel
            // 
            btnSupprimerMateriel.Location = new Point(10, 460);
            btnSupprimerMateriel.Name = "btnSupprimerMateriel";
            btnSupprimerMateriel.Size = new Size(220, 30);
            btnSupprimerMateriel.TabIndex = 1;
            btnSupprimerMateriel.Text = "Supprimer le matériel sélectionné";
            btnSupprimerMateriel.UseVisualStyleBackColor = true;
            btnSupprimerMateriel.Click += btnSupprimerMateriel_Click;
            // 
            // grpAjoutMateriel
            // 
            grpAjoutMateriel.Controls.Add(btnAjouterMateriel);
            grpAjoutMateriel.Controls.Add(cboFournisseur);
            grpAjoutMateriel.Controls.Add(lblFournisseur);
            grpAjoutMateriel.Controls.Add(cboPersonnel);
            grpAjoutMateriel.Controls.Add(lblAffecteA);
            grpAjoutMateriel.Controls.Add(cboMode);
            grpAjoutMateriel.Controls.Add(lblMode);
            grpAjoutMateriel.Controls.Add(txtGarantie);
            grpAjoutMateriel.Controls.Add(lblGarantie);
            grpAjoutMateriel.Controls.Add(dtpDateAcquisition);
            grpAjoutMateriel.Controls.Add(lblDateAcquisition);
            grpAjoutMateriel.Controls.Add(txtLogiciels);
            grpAjoutMateriel.Controls.Add(lblLogiciels);
            grpAjoutMateriel.Controls.Add(txtComposants);
            grpAjoutMateriel.Controls.Add(lblComposants);
            grpAjoutMateriel.Controls.Add(txtTypeMateriel);
            grpAjoutMateriel.Controls.Add(lblTypeMateriel);
            grpAjoutMateriel.Location = new Point(525, 10);
            grpAjoutMateriel.Name = "grpAjoutMateriel";
            grpAjoutMateriel.Size = new Size(315, 480);
            grpAjoutMateriel.TabIndex = 2;
            grpAjoutMateriel.TabStop = false;
            grpAjoutMateriel.Text = "Ajouter un matériel";
            // 
            // lblTypeMateriel
            // 
            lblTypeMateriel.AutoSize = true;
            lblTypeMateriel.Location = new Point(15, 25);
            lblTypeMateriel.Name = "lblTypeMateriel";
            lblTypeMateriel.Size = new Size(113, 15);
            lblTypeMateriel.TabIndex = 0;
            lblTypeMateriel.Text = "Type de matériel :";
            // 
            // txtTypeMateriel
            // 
            txtTypeMateriel.Location = new Point(15, 43);
            txtTypeMateriel.Name = "txtTypeMateriel";
            txtTypeMateriel.Size = new Size(280, 23);
            txtTypeMateriel.TabIndex = 1;
            // 
            // lblComposants
            // 
            lblComposants.AutoSize = true;
            lblComposants.Location = new Point(15, 75);
            lblComposants.Name = "lblComposants";
            lblComposants.Size = new Size(77, 15);
            lblComposants.TabIndex = 2;
            lblComposants.Text = "Composants :";
            // 
            // txtComposants
            // 
            txtComposants.Location = new Point(15, 93);
            txtComposants.Name = "txtComposants";
            txtComposants.Size = new Size(280, 23);
            txtComposants.TabIndex = 3;
            // 
            // lblLogiciels
            // 
            lblLogiciels.AutoSize = true;
            lblLogiciels.Location = new Point(15, 125);
            lblLogiciels.Name = "lblLogiciels";
            lblLogiciels.Size = new Size(132, 15);
            lblLogiciels.TabIndex = 4;
            lblLogiciels.Text = "Logiciels installés :";
            // 
            // txtLogiciels
            // 
            txtLogiciels.Location = new Point(15, 143);
            txtLogiciels.Name = "txtLogiciels";
            txtLogiciels.Size = new Size(280, 23);
            txtLogiciels.TabIndex = 5;
            // 
            // lblDateAcquisition
            // 
            lblDateAcquisition.AutoSize = true;
            lblDateAcquisition.Location = new Point(15, 175);
            lblDateAcquisition.Name = "lblDateAcquisition";
            lblDateAcquisition.Size = new Size(126, 15);
            lblDateAcquisition.TabIndex = 6;
            lblDateAcquisition.Text = "Date d'acquisition :";
            // 
            // dtpDateAcquisition
            // 
            dtpDateAcquisition.Format = DateTimePickerFormat.Short;
            dtpDateAcquisition.Location = new Point(15, 193);
            dtpDateAcquisition.Name = "dtpDateAcquisition";
            dtpDateAcquisition.Size = new Size(150, 23);
            dtpDateAcquisition.TabIndex = 7;
            // 
            // lblGarantie
            // 
            lblGarantie.AutoSize = true;
            lblGarantie.Location = new Point(15, 225);
            lblGarantie.Name = "lblGarantie";
            lblGarantie.Size = new Size(65, 15);
            lblGarantie.TabIndex = 8;
            lblGarantie.Text = "Garantie :";
            // 
            // txtGarantie
            // 
            txtGarantie.Location = new Point(15, 243);
            txtGarantie.Name = "txtGarantie";
            txtGarantie.Size = new Size(280, 23);
            txtGarantie.TabIndex = 9;
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(15, 275);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(126, 15);
            lblMode.TabIndex = 10;
            lblMode.Text = "Mode d'acquisition :";
            // 
            // cboMode
            // 
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.FormattingEnabled = true;
            cboMode.Items.AddRange(new object[] { "achat", "location" });
            cboMode.Location = new Point(15, 293);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(150, 23);
            cboMode.TabIndex = 11;
            // 
            // lblAffecteA
            // 
            lblAffecteA.AutoSize = true;
            lblAffecteA.Location = new Point(15, 325);
            lblAffecteA.Name = "lblAffecteA";
            lblAffecteA.Size = new Size(71, 15);
            lblAffecteA.TabIndex = 12;
            lblAffecteA.Text = "Affecté à :";
            // 
            // cboPersonnel
            // 
            cboPersonnel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersonnel.FormattingEnabled = true;
            cboPersonnel.Location = new Point(15, 343);
            cboPersonnel.Name = "cboPersonnel";
            cboPersonnel.Size = new Size(280, 23);
            cboPersonnel.TabIndex = 13;
            // 
            // lblFournisseur
            // 
            lblFournisseur.AutoSize = true;
            lblFournisseur.Location = new Point(15, 375);
            lblFournisseur.Name = "lblFournisseur";
            lblFournisseur.Size = new Size(83, 15);
            lblFournisseur.TabIndex = 14;
            lblFournisseur.Text = "Fournisseur :";
            // 
            // cboFournisseur
            // 
            cboFournisseur.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFournisseur.FormattingEnabled = true;
            cboFournisseur.Location = new Point(15, 393);
            cboFournisseur.Name = "cboFournisseur";
            cboFournisseur.Size = new Size(280, 23);
            cboFournisseur.TabIndex = 15;
            // 
            // btnAjouterMateriel
            // 
            btnAjouterMateriel.Location = new Point(15, 430);
            btnAjouterMateriel.Name = "btnAjouterMateriel";
            btnAjouterMateriel.Size = new Size(150, 30);
            btnAjouterMateriel.TabIndex = 16;
            btnAjouterMateriel.Text = "Ajouter le matériel";
            btnAjouterMateriel.UseVisualStyleBackColor = true;
            btnAjouterMateriel.Click += btnAjouterMateriel_Click;
            // 
            // FormTechnicien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(tabControl1);
            Controls.Add(cboTechnicien);
            Controls.Add(lblTechnicien);
            Name = "FormTechnicien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB - Espace technicien";
            Load += FormTechnicien_Load;
            tabControl1.ResumeLayout(false);
            tabIncidents.ResumeLayout(false);
            tabIncidents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).EndInit();
            grpPriseEnCharge.ResumeLayout(false);
            grpPriseEnCharge.PerformLayout();
            grpIntervention.ResumeLayout(false);
            grpIntervention.PerformLayout();
            tabMateriels.ResumeLayout(false);
            tabMateriels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMateriels).EndInit();
            grpAjoutMateriel.ResumeLayout(false);
            grpAjoutMateriel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTechnicien;
        private ComboBox cboTechnicien;
        private TabControl tabControl1;
        private TabPage tabIncidents;
        private Label lblListe;
        private DataGridView dgvIncidents;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colObjet;
        private DataGridViewTextBoxColumn colUrgence;
        private DataGridViewTextBoxColumn colNiveau;
        private DataGridViewTextBoxColumn colDeclarant;
        private DataGridViewTextBoxColumn colEtat;
        private Label lblDetail;
        private TextBox txtDetail;
        private GroupBox grpPriseEnCharge;
        private Label lblType;
        private ComboBox cboTypePriseEnCharge;
        private Button btnPrendreEnCharge;
        private GroupBox grpIntervention;
        private Label lblDateIntervention;
        private DateTimePicker dtpDateIntervention;
        private Label lblDebut;
        private DateTimePicker dtpDebut;
        private Label lblFin;
        private DateTimePicker dtpFin;
        private Label lblTravail;
        private TextBox txtTravail;
        private Button btnAjouterIntervention;
        private Button btnResolu;
        private Button btnCloturer;
        private TabPage tabMateriels;
        private DataGridView dgvMateriels;
        private DataGridViewTextBoxColumn colNumMateriel;
        private DataGridViewTextBoxColumn colTypeMateriel;
        private DataGridViewTextBoxColumn colMode;
        private DataGridViewTextBoxColumn colAffecteA;
        private DataGridViewTextBoxColumn colFournisseur;
        private Button btnSupprimerMateriel;
        private GroupBox grpAjoutMateriel;
        private Label lblTypeMateriel;
        private TextBox txtTypeMateriel;
        private Label lblComposants;
        private TextBox txtComposants;
        private Label lblLogiciels;
        private TextBox txtLogiciels;
        private Label lblDateAcquisition;
        private DateTimePicker dtpDateAcquisition;
        private Label lblGarantie;
        private TextBox txtGarantie;
        private Label lblMode;
        private ComboBox cboMode;
        private Label lblAffecteA;
        private ComboBox cboPersonnel;
        private Label lblFournisseur;
        private ComboBox cboFournisseur;
        private Button btnAjouterMateriel;
    }
}
