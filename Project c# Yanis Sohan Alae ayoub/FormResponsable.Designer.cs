namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    partial class FormResponsable
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
            tabControl1 = new TabControl();
            tabUtilisateurs = new TabPage();
            dgvUtilisateurs = new DataGridView();
            colMatriculeU = new DataGridViewTextBoxColumn();
            colNomU = new DataGridViewTextBoxColumn();
            colPrenomU = new DataGridViewTextBoxColumn();
            colLoginU = new DataGridViewTextBoxColumn();
            colRegionU = new DataGridViewTextBoxColumn();
            grpUtilisateur = new GroupBox();
            lblNomU = new Label();
            txtNomU = new TextBox();
            lblPrenomU = new Label();
            txtPrenomU = new TextBox();
            lblAdresseU = new Label();
            txtAdresseU = new TextBox();
            lblDateEmbaucheU = new Label();
            dtpDateEmbaucheU = new DateTimePicker();
            lblLoginU = new Label();
            txtLoginU = new TextBox();
            lblMdpU = new Label();
            txtMdpU = new TextBox();
            lblRegionU = new Label();
            cboRegionU = new ComboBox();
            btnAjouterU = new Button();
            btnModifierU = new Button();
            btnSupprimerU = new Button();
            btnViderU = new Button();
            tabTechniciens = new TabPage();
            dgvTechniciens = new DataGridView();
            colMatriculeT = new DataGridViewTextBoxColumn();
            colNomT = new DataGridViewTextBoxColumn();
            colPrenomT = new DataGridViewTextBoxColumn();
            colNiveauT = new DataGridViewTextBoxColumn();
            colRegionT = new DataGridViewTextBoxColumn();
            grpTechnicien = new GroupBox();
            lblNomT = new Label();
            txtNomT = new TextBox();
            lblPrenomT = new Label();
            txtPrenomT = new TextBox();
            lblAdresseT = new Label();
            txtAdresseT = new TextBox();
            lblDateEmbaucheT = new Label();
            dtpDateEmbaucheT = new DateTimePicker();
            lblLoginT = new Label();
            txtLoginT = new TextBox();
            lblMdpT = new Label();
            txtMdpT = new TextBox();
            lblRegionT = new Label();
            cboRegionT = new ComboBox();
            lblNiveauT = new Label();
            cboNiveauT = new ComboBox();
            lblFormationT = new Label();
            txtFormationT = new TextBox();
            lblCompetencesT = new Label();
            txtCompetencesT = new TextBox();
            btnAjouterT = new Button();
            btnModifierT = new Button();
            btnSupprimerT = new Button();
            btnViderT = new Button();
            tabStatistiques = new TabPage();
            grpStatsIncidents = new GroupBox();
            lblDeclares = new Label();
            lblEnCharge = new Label();
            lblResolus = new Label();
            lblTotal = new Label();
            lblDelai = new Label();
            grpStatsUtilisateurs = new GroupBox();
            dgvStatsUtilisateurs = new DataGridView();
            colUtilisateur = new DataGridViewTextBoxColumn();
            colNbIncidents = new DataGridViewTextBoxColumn();
            grpStatsTechniciens = new GroupBox();
            dgvStatsTechniciens = new DataGridView();
            colTechnicien = new DataGridViewTextBoxColumn();
            colNiveauStat = new DataGridViewTextBoxColumn();
            colEnCharge = new DataGridViewTextBoxColumn();
            colResolus = new DataGridViewTextBoxColumn();
            colHeures = new DataGridViewTextBoxColumn();
            btnActualiser = new Button();
            tabControl1.SuspendLayout();
            tabUtilisateurs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUtilisateurs).BeginInit();
            grpUtilisateur.SuspendLayout();
            tabTechniciens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTechniciens).BeginInit();
            grpTechnicien.SuspendLayout();
            tabStatistiques.SuspendLayout();
            grpStatsIncidents.SuspendLayout();
            grpStatsUtilisateurs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatsUtilisateurs).BeginInit();
            grpStatsTechniciens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatsTechniciens).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabUtilisateurs);
            tabControl1.Controls.Add(tabTechniciens);
            tabControl1.Controls.Add(tabStatistiques);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(876, 576);
            tabControl1.TabIndex = 0;
            // 
            // tabUtilisateurs
            // 
            tabUtilisateurs.Controls.Add(grpUtilisateur);
            tabUtilisateurs.Controls.Add(dgvUtilisateurs);
            tabUtilisateurs.Location = new Point(4, 24);
            tabUtilisateurs.Name = "tabUtilisateurs";
            tabUtilisateurs.Padding = new Padding(3);
            tabUtilisateurs.Size = new Size(868, 548);
            tabUtilisateurs.TabIndex = 0;
            tabUtilisateurs.Text = "Utilisateurs";
            tabUtilisateurs.UseVisualStyleBackColor = true;
            // 
            // dgvUtilisateurs
            // 
            dgvUtilisateurs.AllowUserToAddRows = false;
            dgvUtilisateurs.AllowUserToDeleteRows = false;
            dgvUtilisateurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUtilisateurs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUtilisateurs.Columns.AddRange(new DataGridViewColumn[] { colMatriculeU, colNomU, colPrenomU, colLoginU, colRegionU });
            dgvUtilisateurs.Location = new Point(10, 10);
            dgvUtilisateurs.MultiSelect = false;
            dgvUtilisateurs.Name = "dgvUtilisateurs";
            dgvUtilisateurs.ReadOnly = true;
            dgvUtilisateurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUtilisateurs.Size = new Size(480, 480);
            dgvUtilisateurs.TabIndex = 0;
            dgvUtilisateurs.SelectionChanged += dgvUtilisateurs_SelectionChanged;
            // 
            // colMatriculeU
            // 
            colMatriculeU.FillWeight = 90F;
            colMatriculeU.HeaderText = "Matricule";
            colMatriculeU.Name = "colMatriculeU";
            colMatriculeU.ReadOnly = true;
            // 
            // colNomU
            // 
            colNomU.HeaderText = "Nom";
            colNomU.Name = "colNomU";
            colNomU.ReadOnly = true;
            // 
            // colPrenomU
            // 
            colPrenomU.HeaderText = "Prénom";
            colPrenomU.Name = "colPrenomU";
            colPrenomU.ReadOnly = true;
            // 
            // colLoginU
            // 
            colLoginU.FillWeight = 90F;
            colLoginU.HeaderText = "Login";
            colLoginU.Name = "colLoginU";
            colLoginU.ReadOnly = true;
            // 
            // colRegionU
            // 
            colRegionU.HeaderText = "Région";
            colRegionU.Name = "colRegionU";
            colRegionU.ReadOnly = true;
            // 
            // grpUtilisateur
            // 
            grpUtilisateur.Controls.Add(btnViderU);
            grpUtilisateur.Controls.Add(btnSupprimerU);
            grpUtilisateur.Controls.Add(btnModifierU);
            grpUtilisateur.Controls.Add(btnAjouterU);
            grpUtilisateur.Controls.Add(cboRegionU);
            grpUtilisateur.Controls.Add(lblRegionU);
            grpUtilisateur.Controls.Add(txtMdpU);
            grpUtilisateur.Controls.Add(lblMdpU);
            grpUtilisateur.Controls.Add(txtLoginU);
            grpUtilisateur.Controls.Add(lblLoginU);
            grpUtilisateur.Controls.Add(dtpDateEmbaucheU);
            grpUtilisateur.Controls.Add(lblDateEmbaucheU);
            grpUtilisateur.Controls.Add(txtAdresseU);
            grpUtilisateur.Controls.Add(lblAdresseU);
            grpUtilisateur.Controls.Add(txtPrenomU);
            grpUtilisateur.Controls.Add(lblPrenomU);
            grpUtilisateur.Controls.Add(txtNomU);
            grpUtilisateur.Controls.Add(lblNomU);
            grpUtilisateur.Location = new Point(505, 10);
            grpUtilisateur.Name = "grpUtilisateur";
            grpUtilisateur.Size = new Size(350, 400);
            grpUtilisateur.TabIndex = 1;
            grpUtilisateur.TabStop = false;
            grpUtilisateur.Text = "Fiche utilisateur";
            // 
            // lblNomU
            // 
            lblNomU.AutoSize = true;
            lblNomU.Location = new Point(15, 33);
            lblNomU.Name = "lblNomU";
            lblNomU.Size = new Size(34, 15);
            lblNomU.TabIndex = 0;
            lblNomU.Text = "Nom :";
            // 
            // txtNomU
            // 
            txtNomU.Location = new Point(130, 30);
            txtNomU.Name = "txtNomU";
            txtNomU.Size = new Size(200, 23);
            txtNomU.TabIndex = 1;
            // 
            // lblPrenomU
            // 
            lblPrenomU.AutoSize = true;
            lblPrenomU.Location = new Point(15, 68);
            lblPrenomU.Name = "lblPrenomU";
            lblPrenomU.Size = new Size(52, 15);
            lblPrenomU.TabIndex = 2;
            lblPrenomU.Text = "Prénom :";
            // 
            // txtPrenomU
            // 
            txtPrenomU.Location = new Point(130, 65);
            txtPrenomU.Name = "txtPrenomU";
            txtPrenomU.Size = new Size(200, 23);
            txtPrenomU.TabIndex = 3;
            // 
            // lblAdresseU
            // 
            lblAdresseU.AutoSize = true;
            lblAdresseU.Location = new Point(15, 103);
            lblAdresseU.Name = "lblAdresseU";
            lblAdresseU.Size = new Size(58, 15);
            lblAdresseU.TabIndex = 4;
            lblAdresseU.Text = "Adresse :";
            // 
            // txtAdresseU
            // 
            txtAdresseU.Location = new Point(130, 100);
            txtAdresseU.Name = "txtAdresseU";
            txtAdresseU.Size = new Size(200, 23);
            txtAdresseU.TabIndex = 5;
            // 
            // lblDateEmbaucheU
            // 
            lblDateEmbaucheU.AutoSize = true;
            lblDateEmbaucheU.Location = new Point(15, 138);
            lblDateEmbaucheU.Name = "lblDateEmbaucheU";
            lblDateEmbaucheU.Size = new Size(107, 15);
            lblDateEmbaucheU.TabIndex = 6;
            lblDateEmbaucheU.Text = "Date d'embauche :";
            // 
            // dtpDateEmbaucheU
            // 
            dtpDateEmbaucheU.Format = DateTimePickerFormat.Short;
            dtpDateEmbaucheU.Location = new Point(130, 135);
            dtpDateEmbaucheU.Name = "dtpDateEmbaucheU";
            dtpDateEmbaucheU.Size = new Size(200, 23);
            dtpDateEmbaucheU.TabIndex = 7;
            // 
            // lblLoginU
            // 
            lblLoginU.AutoSize = true;
            lblLoginU.Location = new Point(15, 173);
            lblLoginU.Name = "lblLoginU";
            lblLoginU.Size = new Size(46, 15);
            lblLoginU.TabIndex = 8;
            lblLoginU.Text = "Login :";
            // 
            // txtLoginU
            // 
            txtLoginU.Location = new Point(130, 170);
            txtLoginU.Name = "txtLoginU";
            txtLoginU.Size = new Size(200, 23);
            txtLoginU.TabIndex = 9;
            // 
            // lblMdpU
            // 
            lblMdpU.AutoSize = true;
            lblMdpU.Location = new Point(15, 208);
            lblMdpU.Name = "lblMdpU";
            lblMdpU.Size = new Size(89, 15);
            lblMdpU.TabIndex = 10;
            lblMdpU.Text = "Mot de passe :";
            // 
            // txtMdpU
            // 
            txtMdpU.Location = new Point(130, 205);
            txtMdpU.Name = "txtMdpU";
            txtMdpU.PasswordChar = '*';
            txtMdpU.Size = new Size(200, 23);
            txtMdpU.TabIndex = 11;
            // 
            // lblRegionU
            // 
            lblRegionU.AutoSize = true;
            lblRegionU.Location = new Point(15, 243);
            lblRegionU.Name = "lblRegionU";
            lblRegionU.Size = new Size(52, 15);
            lblRegionU.TabIndex = 12;
            lblRegionU.Text = "Région :";
            // 
            // cboRegionU
            // 
            cboRegionU.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRegionU.FormattingEnabled = true;
            cboRegionU.Location = new Point(130, 240);
            cboRegionU.Name = "cboRegionU";
            cboRegionU.Size = new Size(200, 23);
            cboRegionU.TabIndex = 13;
            // 
            // btnAjouterU
            // 
            btnAjouterU.Location = new Point(15, 300);
            btnAjouterU.Name = "btnAjouterU";
            btnAjouterU.Size = new Size(100, 30);
            btnAjouterU.TabIndex = 14;
            btnAjouterU.Text = "Ajouter";
            btnAjouterU.UseVisualStyleBackColor = true;
            btnAjouterU.Click += btnAjouterU_Click;
            // 
            // btnModifierU
            // 
            btnModifierU.Location = new Point(125, 300);
            btnModifierU.Name = "btnModifierU";
            btnModifierU.Size = new Size(100, 30);
            btnModifierU.TabIndex = 15;
            btnModifierU.Text = "Modifier";
            btnModifierU.UseVisualStyleBackColor = true;
            btnModifierU.Click += btnModifierU_Click;
            // 
            // btnSupprimerU
            // 
            btnSupprimerU.Location = new Point(235, 300);
            btnSupprimerU.Name = "btnSupprimerU";
            btnSupprimerU.Size = new Size(100, 30);
            btnSupprimerU.TabIndex = 16;
            btnSupprimerU.Text = "Supprimer";
            btnSupprimerU.UseVisualStyleBackColor = true;
            btnSupprimerU.Click += btnSupprimerU_Click;
            // 
            // btnViderU
            // 
            btnViderU.Location = new Point(15, 345);
            btnViderU.Name = "btnViderU";
            btnViderU.Size = new Size(150, 30);
            btnViderU.TabIndex = 17;
            btnViderU.Text = "Vider les champs";
            btnViderU.UseVisualStyleBackColor = true;
            btnViderU.Click += btnViderU_Click;
            // 
            // tabTechniciens
            // 
            tabTechniciens.Controls.Add(grpTechnicien);
            tabTechniciens.Controls.Add(dgvTechniciens);
            tabTechniciens.Location = new Point(4, 24);
            tabTechniciens.Name = "tabTechniciens";
            tabTechniciens.Padding = new Padding(3);
            tabTechniciens.Size = new Size(868, 548);
            tabTechniciens.TabIndex = 1;
            tabTechniciens.Text = "Techniciens";
            tabTechniciens.UseVisualStyleBackColor = true;
            // 
            // dgvTechniciens
            // 
            dgvTechniciens.AllowUserToAddRows = false;
            dgvTechniciens.AllowUserToDeleteRows = false;
            dgvTechniciens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTechniciens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTechniciens.Columns.AddRange(new DataGridViewColumn[] { colMatriculeT, colNomT, colPrenomT, colNiveauT, colRegionT });
            dgvTechniciens.Location = new Point(10, 10);
            dgvTechniciens.MultiSelect = false;
            dgvTechniciens.Name = "dgvTechniciens";
            dgvTechniciens.ReadOnly = true;
            dgvTechniciens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTechniciens.Size = new Size(480, 480);
            dgvTechniciens.TabIndex = 0;
            dgvTechniciens.SelectionChanged += dgvTechniciens_SelectionChanged;
            // 
            // colMatriculeT
            // 
            colMatriculeT.FillWeight = 90F;
            colMatriculeT.HeaderText = "Matricule";
            colMatriculeT.Name = "colMatriculeT";
            colMatriculeT.ReadOnly = true;
            // 
            // colNomT
            // 
            colNomT.HeaderText = "Nom";
            colNomT.Name = "colNomT";
            colNomT.ReadOnly = true;
            // 
            // colPrenomT
            // 
            colPrenomT.HeaderText = "Prénom";
            colPrenomT.Name = "colPrenomT";
            colPrenomT.ReadOnly = true;
            // 
            // colNiveauT
            // 
            colNiveauT.FillWeight = 60F;
            colNiveauT.HeaderText = "Niveau";
            colNiveauT.Name = "colNiveauT";
            colNiveauT.ReadOnly = true;
            // 
            // colRegionT
            // 
            colRegionT.HeaderText = "Région";
            colRegionT.Name = "colRegionT";
            colRegionT.ReadOnly = true;
            // 
            // grpTechnicien
            // 
            grpTechnicien.Controls.Add(btnViderT);
            grpTechnicien.Controls.Add(btnSupprimerT);
            grpTechnicien.Controls.Add(btnModifierT);
            grpTechnicien.Controls.Add(btnAjouterT);
            grpTechnicien.Controls.Add(txtCompetencesT);
            grpTechnicien.Controls.Add(lblCompetencesT);
            grpTechnicien.Controls.Add(txtFormationT);
            grpTechnicien.Controls.Add(lblFormationT);
            grpTechnicien.Controls.Add(cboNiveauT);
            grpTechnicien.Controls.Add(lblNiveauT);
            grpTechnicien.Controls.Add(cboRegionT);
            grpTechnicien.Controls.Add(lblRegionT);
            grpTechnicien.Controls.Add(txtMdpT);
            grpTechnicien.Controls.Add(lblMdpT);
            grpTechnicien.Controls.Add(txtLoginT);
            grpTechnicien.Controls.Add(lblLoginT);
            grpTechnicien.Controls.Add(dtpDateEmbaucheT);
            grpTechnicien.Controls.Add(lblDateEmbaucheT);
            grpTechnicien.Controls.Add(txtAdresseT);
            grpTechnicien.Controls.Add(lblAdresseT);
            grpTechnicien.Controls.Add(txtPrenomT);
            grpTechnicien.Controls.Add(lblPrenomT);
            grpTechnicien.Controls.Add(txtNomT);
            grpTechnicien.Controls.Add(lblNomT);
            grpTechnicien.Location = new Point(505, 10);
            grpTechnicien.Name = "grpTechnicien";
            grpTechnicien.Size = new Size(350, 480);
            grpTechnicien.TabIndex = 1;
            grpTechnicien.TabStop = false;
            grpTechnicien.Text = "Fiche technicien";
            // 
            // lblNomT
            // 
            lblNomT.AutoSize = true;
            lblNomT.Location = new Point(15, 33);
            lblNomT.Name = "lblNomT";
            lblNomT.Size = new Size(34, 15);
            lblNomT.TabIndex = 0;
            lblNomT.Text = "Nom :";
            // 
            // txtNomT
            // 
            txtNomT.Location = new Point(130, 30);
            txtNomT.Name = "txtNomT";
            txtNomT.Size = new Size(200, 23);
            txtNomT.TabIndex = 1;
            // 
            // lblPrenomT
            // 
            lblPrenomT.AutoSize = true;
            lblPrenomT.Location = new Point(15, 68);
            lblPrenomT.Name = "lblPrenomT";
            lblPrenomT.Size = new Size(52, 15);
            lblPrenomT.TabIndex = 2;
            lblPrenomT.Text = "Prénom :";
            // 
            // txtPrenomT
            // 
            txtPrenomT.Location = new Point(130, 65);
            txtPrenomT.Name = "txtPrenomT";
            txtPrenomT.Size = new Size(200, 23);
            txtPrenomT.TabIndex = 3;
            // 
            // lblAdresseT
            // 
            lblAdresseT.AutoSize = true;
            lblAdresseT.Location = new Point(15, 103);
            lblAdresseT.Name = "lblAdresseT";
            lblAdresseT.Size = new Size(58, 15);
            lblAdresseT.TabIndex = 4;
            lblAdresseT.Text = "Adresse :";
            // 
            // txtAdresseT
            // 
            txtAdresseT.Location = new Point(130, 100);
            txtAdresseT.Name = "txtAdresseT";
            txtAdresseT.Size = new Size(200, 23);
            txtAdresseT.TabIndex = 5;
            // 
            // lblDateEmbaucheT
            // 
            lblDateEmbaucheT.AutoSize = true;
            lblDateEmbaucheT.Location = new Point(15, 138);
            lblDateEmbaucheT.Name = "lblDateEmbaucheT";
            lblDateEmbaucheT.Size = new Size(107, 15);
            lblDateEmbaucheT.TabIndex = 6;
            lblDateEmbaucheT.Text = "Date d'embauche :";
            // 
            // dtpDateEmbaucheT
            // 
            dtpDateEmbaucheT.Format = DateTimePickerFormat.Short;
            dtpDateEmbaucheT.Location = new Point(130, 135);
            dtpDateEmbaucheT.Name = "dtpDateEmbaucheT";
            dtpDateEmbaucheT.Size = new Size(200, 23);
            dtpDateEmbaucheT.TabIndex = 7;
            // 
            // lblLoginT
            // 
            lblLoginT.AutoSize = true;
            lblLoginT.Location = new Point(15, 173);
            lblLoginT.Name = "lblLoginT";
            lblLoginT.Size = new Size(46, 15);
            lblLoginT.TabIndex = 8;
            lblLoginT.Text = "Login :";
            // 
            // txtLoginT
            // 
            txtLoginT.Location = new Point(130, 170);
            txtLoginT.Name = "txtLoginT";
            txtLoginT.Size = new Size(200, 23);
            txtLoginT.TabIndex = 9;
            // 
            // lblMdpT
            // 
            lblMdpT.AutoSize = true;
            lblMdpT.Location = new Point(15, 208);
            lblMdpT.Name = "lblMdpT";
            lblMdpT.Size = new Size(89, 15);
            lblMdpT.TabIndex = 10;
            lblMdpT.Text = "Mot de passe :";
            // 
            // txtMdpT
            // 
            txtMdpT.Location = new Point(130, 205);
            txtMdpT.Name = "txtMdpT";
            txtMdpT.PasswordChar = '*';
            txtMdpT.Size = new Size(200, 23);
            txtMdpT.TabIndex = 11;
            // 
            // lblRegionT
            // 
            lblRegionT.AutoSize = true;
            lblRegionT.Location = new Point(15, 243);
            lblRegionT.Name = "lblRegionT";
            lblRegionT.Size = new Size(52, 15);
            lblRegionT.TabIndex = 12;
            lblRegionT.Text = "Région :";
            // 
            // cboRegionT
            // 
            cboRegionT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRegionT.FormattingEnabled = true;
            cboRegionT.Location = new Point(130, 240);
            cboRegionT.Name = "cboRegionT";
            cboRegionT.Size = new Size(200, 23);
            cboRegionT.TabIndex = 13;
            // 
            // lblNiveauT
            // 
            lblNiveauT.AutoSize = true;
            lblNiveauT.Location = new Point(15, 278);
            lblNiveauT.Name = "lblNiveauT";
            lblNiveauT.Size = new Size(52, 15);
            lblNiveauT.TabIndex = 14;
            lblNiveauT.Text = "Niveau :";
            // 
            // cboNiveauT
            // 
            cboNiveauT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNiveauT.FormattingEnabled = true;
            cboNiveauT.Items.AddRange(new object[] { "1", "2" });
            cboNiveauT.Location = new Point(130, 275);
            cboNiveauT.Name = "cboNiveauT";
            cboNiveauT.Size = new Size(80, 23);
            cboNiveauT.TabIndex = 15;
            // 
            // lblFormationT
            // 
            lblFormationT.AutoSize = true;
            lblFormationT.Location = new Point(15, 313);
            lblFormationT.Name = "lblFormationT";
            lblFormationT.Size = new Size(71, 15);
            lblFormationT.TabIndex = 16;
            lblFormationT.Text = "Formation :";
            // 
            // txtFormationT
            // 
            txtFormationT.Location = new Point(130, 310);
            txtFormationT.Name = "txtFormationT";
            txtFormationT.Size = new Size(200, 23);
            txtFormationT.TabIndex = 17;
            // 
            // lblCompetencesT
            // 
            lblCompetencesT.AutoSize = true;
            lblCompetencesT.Location = new Point(15, 348);
            lblCompetencesT.Name = "lblCompetencesT";
            lblCompetencesT.Size = new Size(83, 15);
            lblCompetencesT.TabIndex = 18;
            lblCompetencesT.Text = "Compétences :";
            // 
            // txtCompetencesT
            // 
            txtCompetencesT.Location = new Point(130, 345);
            txtCompetencesT.Name = "txtCompetencesT";
            txtCompetencesT.Size = new Size(200, 23);
            txtCompetencesT.TabIndex = 19;
            // 
            // btnAjouterT
            // 
            btnAjouterT.Location = new Point(15, 395);
            btnAjouterT.Name = "btnAjouterT";
            btnAjouterT.Size = new Size(100, 30);
            btnAjouterT.TabIndex = 20;
            btnAjouterT.Text = "Ajouter";
            btnAjouterT.UseVisualStyleBackColor = true;
            btnAjouterT.Click += btnAjouterT_Click;
            // 
            // btnModifierT
            // 
            btnModifierT.Location = new Point(125, 395);
            btnModifierT.Name = "btnModifierT";
            btnModifierT.Size = new Size(100, 30);
            btnModifierT.TabIndex = 21;
            btnModifierT.Text = "Modifier";
            btnModifierT.UseVisualStyleBackColor = true;
            btnModifierT.Click += btnModifierT_Click;
            // 
            // btnSupprimerT
            // 
            btnSupprimerT.Location = new Point(235, 395);
            btnSupprimerT.Name = "btnSupprimerT";
            btnSupprimerT.Size = new Size(100, 30);
            btnSupprimerT.TabIndex = 22;
            btnSupprimerT.Text = "Supprimer";
            btnSupprimerT.UseVisualStyleBackColor = true;
            btnSupprimerT.Click += btnSupprimerT_Click;
            // 
            // btnViderT
            // 
            btnViderT.Location = new Point(15, 435);
            btnViderT.Name = "btnViderT";
            btnViderT.Size = new Size(150, 30);
            btnViderT.TabIndex = 23;
            btnViderT.Text = "Vider les champs";
            btnViderT.UseVisualStyleBackColor = true;
            btnViderT.Click += btnViderT_Click;
            // 
            // tabStatistiques
            // 
            tabStatistiques.Controls.Add(btnActualiser);
            tabStatistiques.Controls.Add(grpStatsTechniciens);
            tabStatistiques.Controls.Add(grpStatsUtilisateurs);
            tabStatistiques.Controls.Add(grpStatsIncidents);
            tabStatistiques.Location = new Point(4, 24);
            tabStatistiques.Name = "tabStatistiques";
            tabStatistiques.Padding = new Padding(3);
            tabStatistiques.Size = new Size(868, 548);
            tabStatistiques.TabIndex = 2;
            tabStatistiques.Text = "Statistiques";
            tabStatistiques.UseVisualStyleBackColor = true;
            // 
            // grpStatsIncidents
            // 
            grpStatsIncidents.Controls.Add(lblDelai);
            grpStatsIncidents.Controls.Add(lblTotal);
            grpStatsIncidents.Controls.Add(lblResolus);
            grpStatsIncidents.Controls.Add(lblEnCharge);
            grpStatsIncidents.Controls.Add(lblDeclares);
            grpStatsIncidents.Location = new Point(10, 10);
            grpStatsIncidents.Name = "grpStatsIncidents";
            grpStatsIncidents.Size = new Size(400, 200);
            grpStatsIncidents.TabIndex = 0;
            grpStatsIncidents.TabStop = false;
            grpStatsIncidents.Text = "Incidents";
            // 
            // lblDeclares
            // 
            lblDeclares.AutoSize = true;
            lblDeclares.Location = new Point(15, 30);
            lblDeclares.Name = "lblDeclares";
            lblDeclares.Size = new Size(235, 15);
            lblDeclares.TabIndex = 0;
            lblDeclares.Text = "Déclarés (pas encore pris en charge) :";
            // 
            // lblEnCharge
            // 
            lblEnCharge.AutoSize = true;
            lblEnCharge.Location = new Point(15, 60);
            lblEnCharge.Name = "lblEnCharge";
            lblEnCharge.Size = new Size(150, 15);
            lblEnCharge.TabIndex = 1;
            lblEnCharge.Text = "En cours de traitement :";
            // 
            // lblResolus
            // 
            lblResolus.AutoSize = true;
            lblResolus.Location = new Point(15, 90);
            lblResolus.Name = "lblResolus";
            lblResolus.Size = new Size(132, 15);
            lblResolus.TabIndex = 2;
            lblResolus.Text = "Résolus ou clôturés :";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(15, 120);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(46, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total :";
            // 
            // lblDelai
            // 
            lblDelai.AutoSize = true;
            lblDelai.Location = new Point(15, 150);
            lblDelai.Name = "lblDelai";
            lblDelai.Size = new Size(168, 15);
            lblDelai.TabIndex = 4;
            lblDelai.Text = "Délai moyen de résolution :";
            // 
            // grpStatsUtilisateurs
            // 
            grpStatsUtilisateurs.Controls.Add(dgvStatsUtilisateurs);
            grpStatsUtilisateurs.Location = new Point(425, 10);
            grpStatsUtilisateurs.Name = "grpStatsUtilisateurs";
            grpStatsUtilisateurs.Size = new Size(430, 200);
            grpStatsUtilisateurs.TabIndex = 1;
            grpStatsUtilisateurs.TabStop = false;
            grpStatsUtilisateurs.Text = "Incidents par utilisateur";
            // 
            // dgvStatsUtilisateurs
            // 
            dgvStatsUtilisateurs.AllowUserToAddRows = false;
            dgvStatsUtilisateurs.AllowUserToDeleteRows = false;
            dgvStatsUtilisateurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatsUtilisateurs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStatsUtilisateurs.Columns.AddRange(new DataGridViewColumn[] { colUtilisateur, colNbIncidents });
            dgvStatsUtilisateurs.Location = new Point(15, 25);
            dgvStatsUtilisateurs.MultiSelect = false;
            dgvStatsUtilisateurs.Name = "dgvStatsUtilisateurs";
            dgvStatsUtilisateurs.ReadOnly = true;
            dgvStatsUtilisateurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStatsUtilisateurs.Size = new Size(400, 160);
            dgvStatsUtilisateurs.TabIndex = 0;
            // 
            // colUtilisateur
            // 
            colUtilisateur.FillWeight = 200F;
            colUtilisateur.HeaderText = "Utilisateur";
            colUtilisateur.Name = "colUtilisateur";
            colUtilisateur.ReadOnly = true;
            // 
            // colNbIncidents
            // 
            colNbIncidents.HeaderText = "Nb incidents";
            colNbIncidents.Name = "colNbIncidents";
            colNbIncidents.ReadOnly = true;
            // 
            // grpStatsTechniciens
            // 
            grpStatsTechniciens.Controls.Add(dgvStatsTechniciens);
            grpStatsTechniciens.Location = new Point(10, 220);
            grpStatsTechniciens.Name = "grpStatsTechniciens";
            grpStatsTechniciens.Size = new Size(845, 270);
            grpStatsTechniciens.TabIndex = 2;
            grpStatsTechniciens.TabStop = false;
            grpStatsTechniciens.Text = "Techniciens";
            // 
            // dgvStatsTechniciens
            // 
            dgvStatsTechniciens.AllowUserToAddRows = false;
            dgvStatsTechniciens.AllowUserToDeleteRows = false;
            dgvStatsTechniciens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatsTechniciens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStatsTechniciens.Columns.AddRange(new DataGridViewColumn[] { colTechnicien, colNiveauStat, colEnCharge, colResolus, colHeures });
            dgvStatsTechniciens.Location = new Point(15, 25);
            dgvStatsTechniciens.MultiSelect = false;
            dgvStatsTechniciens.Name = "dgvStatsTechniciens";
            dgvStatsTechniciens.ReadOnly = true;
            dgvStatsTechniciens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStatsTechniciens.Size = new Size(815, 230);
            dgvStatsTechniciens.TabIndex = 0;
            // 
            // colTechnicien
            // 
            colTechnicien.FillWeight = 200F;
            colTechnicien.HeaderText = "Technicien";
            colTechnicien.Name = "colTechnicien";
            colTechnicien.ReadOnly = true;
            // 
            // colNiveauStat
            // 
            colNiveauStat.FillWeight = 70F;
            colNiveauStat.HeaderText = "Niveau";
            colNiveauStat.Name = "colNiveauStat";
            colNiveauStat.ReadOnly = true;
            // 
            // colEnCharge
            // 
            colEnCharge.HeaderText = "En charge";
            colEnCharge.Name = "colEnCharge";
            colEnCharge.ReadOnly = true;
            // 
            // colResolus
            // 
            colResolus.HeaderText = "Résolus";
            colResolus.Name = "colResolus";
            colResolus.ReadOnly = true;
            // 
            // colHeures
            // 
            colHeures.HeaderText = "Heures";
            colHeures.Name = "colHeures";
            colHeures.ReadOnly = true;
            // 
            // btnActualiser
            // 
            btnActualiser.Location = new Point(10, 500);
            btnActualiser.Name = "btnActualiser";
            btnActualiser.Size = new Size(150, 30);
            btnActualiser.TabIndex = 3;
            btnActualiser.Text = "Actualiser";
            btnActualiser.UseVisualStyleBackColor = true;
            btnActualiser.Click += btnActualiser_Click;
            // 
            // FormResponsable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(tabControl1);
            Name = "FormResponsable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB - Espace responsable";
            Load += FormResponsable_Load;
            tabControl1.ResumeLayout(false);
            tabUtilisateurs.ResumeLayout(false);
            tabUtilisateurs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUtilisateurs).EndInit();
            grpUtilisateur.ResumeLayout(false);
            grpUtilisateur.PerformLayout();
            tabTechniciens.ResumeLayout(false);
            tabTechniciens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTechniciens).EndInit();
            grpTechnicien.ResumeLayout(false);
            grpTechnicien.PerformLayout();
            tabStatistiques.ResumeLayout(false);
            tabStatistiques.PerformLayout();
            grpStatsIncidents.ResumeLayout(false);
            grpStatsIncidents.PerformLayout();
            grpStatsUtilisateurs.ResumeLayout(false);
            grpStatsUtilisateurs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatsUtilisateurs).EndInit();
            grpStatsTechniciens.ResumeLayout(false);
            grpStatsTechniciens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatsTechniciens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabUtilisateurs;
        private DataGridView dgvUtilisateurs;
        private DataGridViewTextBoxColumn colMatriculeU;
        private DataGridViewTextBoxColumn colNomU;
        private DataGridViewTextBoxColumn colPrenomU;
        private DataGridViewTextBoxColumn colLoginU;
        private DataGridViewTextBoxColumn colRegionU;
        private GroupBox grpUtilisateur;
        private Label lblNomU;
        private TextBox txtNomU;
        private Label lblPrenomU;
        private TextBox txtPrenomU;
        private Label lblAdresseU;
        private TextBox txtAdresseU;
        private Label lblDateEmbaucheU;
        private DateTimePicker dtpDateEmbaucheU;
        private Label lblLoginU;
        private TextBox txtLoginU;
        private Label lblMdpU;
        private TextBox txtMdpU;
        private Label lblRegionU;
        private ComboBox cboRegionU;
        private Button btnAjouterU;
        private Button btnModifierU;
        private Button btnSupprimerU;
        private Button btnViderU;
        private TabPage tabTechniciens;
        private DataGridView dgvTechniciens;
        private DataGridViewTextBoxColumn colMatriculeT;
        private DataGridViewTextBoxColumn colNomT;
        private DataGridViewTextBoxColumn colPrenomT;
        private DataGridViewTextBoxColumn colNiveauT;
        private DataGridViewTextBoxColumn colRegionT;
        private GroupBox grpTechnicien;
        private Label lblNomT;
        private TextBox txtNomT;
        private Label lblPrenomT;
        private TextBox txtPrenomT;
        private Label lblAdresseT;
        private TextBox txtAdresseT;
        private Label lblDateEmbaucheT;
        private DateTimePicker dtpDateEmbaucheT;
        private Label lblLoginT;
        private TextBox txtLoginT;
        private Label lblMdpT;
        private TextBox txtMdpT;
        private Label lblRegionT;
        private ComboBox cboRegionT;
        private Label lblNiveauT;
        private ComboBox cboNiveauT;
        private Label lblFormationT;
        private TextBox txtFormationT;
        private Label lblCompetencesT;
        private TextBox txtCompetencesT;
        private Button btnAjouterT;
        private Button btnModifierT;
        private Button btnSupprimerT;
        private Button btnViderT;
        private TabPage tabStatistiques;
        private GroupBox grpStatsIncidents;
        private Label lblDeclares;
        private Label lblEnCharge;
        private Label lblResolus;
        private Label lblTotal;
        private Label lblDelai;
        private GroupBox grpStatsUtilisateurs;
        private DataGridView dgvStatsUtilisateurs;
        private DataGridViewTextBoxColumn colUtilisateur;
        private DataGridViewTextBoxColumn colNbIncidents;
        private GroupBox grpStatsTechniciens;
        private DataGridView dgvStatsTechniciens;
        private DataGridViewTextBoxColumn colTechnicien;
        private DataGridViewTextBoxColumn colNiveauStat;
        private DataGridViewTextBoxColumn colEnCharge;
        private DataGridViewTextBoxColumn colResolus;
        private DataGridViewTextBoxColumn colHeures;
        private Button btnActualiser;
    }
}
