namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    partial class Form1
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
            lblTitre = new Label();
            lblChoix = new Label();
            btnUtilisateur = new Button();
            btnTechnicien = new Button();
            btnResponsable = new Button();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitre.Location = new Point(102, 53);
            lblTitre.Margin = new Padding(6, 0, 6, 0);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(511, 51);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "GSB - Gestion des incidents";
            // 
            // lblChoix
            // 
            lblChoix.AutoSize = true;
            lblChoix.Location = new Point(102, 160);
            lblChoix.Margin = new Padding(6, 0, 6, 0);
            lblChoix.Name = "lblChoix";
            lblChoix.Size = new Size(214, 32);
            lblChoix.TabIndex = 1;
            lblChoix.Text = "Choisir un espace :";
            // 
            // btnUtilisateur
            // 
            btnUtilisateur.Location = new Point(167, 224);
            btnUtilisateur.Margin = new Padding(6, 6, 6, 6);
            btnUtilisateur.Name = "btnUtilisateur";
            btnUtilisateur.Size = new Size(390, 75);
            btnUtilisateur.TabIndex = 2;
            btnUtilisateur.Text = "Espace utilisateur";
            btnUtilisateur.UseVisualStyleBackColor = true;
            btnUtilisateur.Click += btnUtilisateur_Click;
            // 
            // btnTechnicien
            // 
            btnTechnicien.Location = new Point(167, 331);
            btnTechnicien.Margin = new Padding(6, 6, 6, 6);
            btnTechnicien.Name = "btnTechnicien";
            btnTechnicien.Size = new Size(390, 75);
            btnTechnicien.TabIndex = 3;
            btnTechnicien.Text = "Espace technicien";
            btnTechnicien.UseVisualStyleBackColor = true;
            btnTechnicien.Click += btnTechnicien_Click;
            // 
            // btnResponsable
            // 
            btnResponsable.Location = new Point(167, 437);
            btnResponsable.Margin = new Padding(6, 6, 6, 6);
            btnResponsable.Name = "btnResponsable";
            btnResponsable.Size = new Size(390, 75);
            btnResponsable.TabIndex = 4;
            btnResponsable.Text = "Espace responsable";
            btnResponsable.UseVisualStyleBackColor = true;
            btnResponsable.Click += btnResponsable_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1882, 1080);
            Controls.Add(btnResponsable);
            Controls.Add(btnTechnicien);
            Controls.Add(btnUtilisateur);
            Controls.Add(lblChoix);
            Controls.Add(lblTitre);
            Margin = new Padding(6, 6, 6, 6);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB - Accueil";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitre;
        private Label lblChoix;
        private Button btnUtilisateur;
        private Button btnTechnicien;
        private Button btnResponsable;
    }
}
