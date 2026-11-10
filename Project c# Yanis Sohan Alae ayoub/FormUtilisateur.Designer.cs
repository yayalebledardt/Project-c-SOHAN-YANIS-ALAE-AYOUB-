namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    partial class FormUtilisateur
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
            lblUtilisateur = new Label();
            cboUtilisateur = new ComboBox();
            grpDeclarer = new GroupBox();
            btnDeclarer = new Button();
            cboUrgence = new ComboBox();
            lblUrgence = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtObjet = new TextBox();
            lblObjet = new Label();
            cboMateriel = new ComboBox();
            lblMateriel = new Label();
            grpSuivi = new GroupBox();
            txtDetail = new TextBox();
            lblDetail = new Label();
            dgvIncidents = new DataGridView();
            colNumero = new DataGridViewTextBoxColumn();
            colObjet = new DataGridViewTextBoxColumn();
            colMateriel = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colEtat = new DataGridViewTextBoxColumn();
            grpDeclarer.SuspendLayout();
            grpSuivi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).BeginInit();
            SuspendLayout();
            // 
            // lblUtilisateur
            // 
            lblUtilisateur.AutoSize = true;
            lblUtilisateur.Location = new Point(37, 38);
            lblUtilisateur.Margin = new Padding(6, 0, 6, 0);
            lblUtilisateur.Name = "lblUtilisateur";
            lblUtilisateur.Size = new Size(133, 32);
            lblUtilisateur.TabIndex = 0;
            lblUtilisateur.Text = "Utilisateur :";
            // 
            // cboUtilisateur
            // 
            cboUtilisateur.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUtilisateur.FormattingEnabled = true;
            cboUtilisateur.Location = new Point(186, 32);
            cboUtilisateur.Margin = new Padding(6, 6, 6, 6);
            cboUtilisateur.Name = "cboUtilisateur";
            cboUtilisateur.Size = new Size(368, 40);
            cboUtilisateur.TabIndex = 1;
            cboUtilisateur.SelectedIndexChanged += cboUtilisateur_SelectedIndexChanged;
            // 
            // grpDeclarer
            // 
            grpDeclarer.Controls.Add(btnDeclarer);
            grpDeclarer.Controls.Add(cboUrgence);
            grpDeclarer.Controls.Add(lblUrgence);
            grpDeclarer.Controls.Add(txtDescription);
            grpDeclarer.Controls.Add(lblDescription);
            grpDeclarer.Controls.Add(txtObjet);
            grpDeclarer.Controls.Add(lblObjet);
            grpDeclarer.Controls.Add(cboMateriel);
            grpDeclarer.Controls.Add(lblMateriel);
            grpDeclarer.Location = new Point(37, 107);
            grpDeclarer.Margin = new Padding(6, 6, 6, 6);
            grpDeclarer.Name = "grpDeclarer";
            grpDeclarer.Padding = new Padding(6, 6, 6, 6);
            grpDeclarer.Size = new Size(613, 896);
            grpDeclarer.TabIndex = 2;
            grpDeclarer.TabStop = false;
            grpDeclarer.Text = "Déclarer un incident";
            // 
            // btnDeclarer
            // 
            btnDeclarer.Location = new Point(28, 789);
            btnDeclarer.Margin = new Padding(6, 6, 6, 6);
            btnDeclarer.Name = "btnDeclarer";
            btnDeclarer.Size = new Size(535, 64);
            btnDeclarer.TabIndex = 8;
            btnDeclarer.Text = "Déclarer l'incident";
            btnDeclarer.UseVisualStyleBackColor = true;
            btnDeclarer.Click += btnDeclarer_Click;
            // 
            // cboUrgence
            // 
            cboUrgence.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUrgence.FormattingEnabled = true;
            cboUrgence.Items.AddRange(new object[] { "1 - Faible", "2 - Moyenne", "3 - Urgente" });
            cboUrgence.Location = new Point(28, 693);
            cboUrgence.Margin = new Padding(6, 6, 6, 6);
            cboUrgence.Name = "cboUrgence";
            cboUrgence.Size = new Size(275, 40);
            cboUrgence.TabIndex = 7;
            // 
            // lblUrgence
            // 
            lblUrgence.AutoSize = true;
            lblUrgence.Location = new Point(28, 651);
            lblUrgence.Margin = new Padding(6, 0, 6, 0);
            lblUrgence.Name = "lblUrgence";
            lblUrgence.Size = new Size(215, 32);
            lblUrgence.TabIndex = 6;
            lblUrgence.Text = "Niveau d'urgence :";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(28, 341);
            txtDescription.Margin = new Padding(6, 6, 6, 6);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(535, 273);
            txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(28, 299);
            lblDescription.Margin = new Padding(6, 0, 6, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(292, 32);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description du problème :";
            // 
            // txtObjet
            // 
            txtObjet.Location = new Point(28, 224);
            txtObjet.Margin = new Padding(6, 6, 6, 6);
            txtObjet.Name = "txtObjet";
            txtObjet.Size = new Size(535, 39);
            txtObjet.TabIndex = 3;
            // 
            // lblObjet
            // 
            lblObjet.AutoSize = true;
            lblObjet.Location = new Point(28, 181);
            lblObjet.Margin = new Padding(6, 0, 6, 0);
            lblObjet.Name = "lblObjet";
            lblObjet.Size = new Size(85, 32);
            lblObjet.TabIndex = 2;
            lblObjet.Text = "Objet :";
            // 
            // cboMateriel
            // 
            cboMateriel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMateriel.FormattingEnabled = true;
            cboMateriel.Location = new Point(28, 107);
            cboMateriel.Margin = new Padding(6, 6, 6, 6);
            cboMateriel.Name = "cboMateriel";
            cboMateriel.Size = new Size(535, 40);
            cboMateriel.TabIndex = 1;
            // 
            // lblMateriel
            // 
            lblMateriel.AutoSize = true;
            lblMateriel.Location = new Point(28, 64);
            lblMateriel.Margin = new Padding(6, 0, 6, 0);
            lblMateriel.Name = "lblMateriel";
            lblMateriel.Size = new Size(219, 32);
            lblMateriel.TabIndex = 0;
            lblMateriel.Text = "Matériel concerné :";
            // 
            // grpSuivi
            // 
            grpSuivi.Controls.Add(txtDetail);
            grpSuivi.Controls.Add(lblDetail);
            grpSuivi.Controls.Add(dgvIncidents);
            grpSuivi.Location = new Point(687, 107);
            grpSuivi.Margin = new Padding(6, 6, 6, 6);
            grpSuivi.Name = "grpSuivi";
            grpSuivi.Padding = new Padding(6, 6, 6, 6);
            grpSuivi.Size = new Size(761, 981);
            grpSuivi.TabIndex = 3;
            grpSuivi.TabStop = false;
            grpSuivi.Text = "Suivi de mes incidents";
            // 
            // txtDetail
            // 
            txtDetail.Location = new Point(28, 619);
            txtDetail.Margin = new Padding(6, 6, 6, 6);
            txtDetail.Multiline = true;
            txtDetail.Name = "txtDetail";
            txtDetail.ReadOnly = true;
            txtDetail.ScrollBars = ScrollBars.Vertical;
            txtDetail.Size = new Size(702, 315);
            txtDetail.TabIndex = 2;
            // 
            // lblDetail
            // 
            lblDetail.AutoSize = true;
            lblDetail.Location = new Point(28, 576);
            lblDetail.Margin = new Padding(6, 0, 6, 0);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(356, 32);
            lblDetail.TabIndex = 1;
            lblDetail.Text = "Détail de l'incident sélectionné :";
            // 
            // dgvIncidents
            // 
            dgvIncidents.AllowUserToAddRows = false;
            dgvIncidents.AllowUserToDeleteRows = false;
            dgvIncidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIncidents.Columns.AddRange(new DataGridViewColumn[] { colNumero, colObjet, colMateriel, colDate, colEtat });
            dgvIncidents.Location = new Point(28, 83);
            dgvIncidents.Margin = new Padding(6, 6, 6, 6);
            dgvIncidents.MultiSelect = false;
            dgvIncidents.Name = "dgvIncidents";
            dgvIncidents.ReadOnly = true;
            dgvIncidents.RowHeadersWidth = 82;
            dgvIncidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIncidents.Size = new Size(706, 461);
            dgvIncidents.TabIndex = 0;
            dgvIncidents.SelectionChanged += dgvIncidents_SelectionChanged;
            // 
            // colNumero
            // 
            colNumero.FillWeight = 40F;
            colNumero.HeaderText = "N°";
            colNumero.MinimumWidth = 10;
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            // 
            // colObjet
            // 
            colObjet.FillWeight = 120F;
            colObjet.HeaderText = "Objet";
            colObjet.MinimumWidth = 10;
            colObjet.Name = "colObjet";
            colObjet.ReadOnly = true;
            // 
            // colMateriel
            // 
            colMateriel.HeaderText = "Matériel";
            colMateriel.MinimumWidth = 10;
            colMateriel.Name = "colMateriel";
            colMateriel.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.FillWeight = 80F;
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 10;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colEtat
            // 
            colEtat.FillWeight = 110F;
            colEtat.HeaderText = "État";
            colEtat.MinimumWidth = 10;
            colEtat.Name = "colEtat";
            colEtat.ReadOnly = true;
            // 
            // FormUtilisateur
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 1131);
            Controls.Add(grpSuivi);
            Controls.Add(grpDeclarer);
            Controls.Add(cboUtilisateur);
            Controls.Add(lblUtilisateur);
            Margin = new Padding(6, 6, 6, 6);
            Name = "FormUtilisateur";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB - Espace utilisateur";
            Load += FormUtilisateur_Load;
            grpDeclarer.ResumeLayout(false);
            grpDeclarer.PerformLayout();
            grpSuivi.ResumeLayout(false);
            grpSuivi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncidents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUtilisateur;
        private ComboBox cboUtilisateur;
        private GroupBox grpDeclarer;
        private Label lblMateriel;
        private ComboBox cboMateriel;
        private Label lblObjet;
        private TextBox txtObjet;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblUrgence;
        private ComboBox cboUrgence;
        private Button btnDeclarer;
        private GroupBox grpSuivi;
        private DataGridView dgvIncidents;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colObjet;
        private DataGridViewTextBoxColumn colMateriel;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colEtat;
        private Label lblDetail;
        private TextBox txtDetail;
    }
}
