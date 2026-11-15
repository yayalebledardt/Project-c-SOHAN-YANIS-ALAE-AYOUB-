namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de choisir son espace au début
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// ce code permet de créer la fenêtre du menu
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ce code permet de montrer la fenêtre utilisateur
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnUtilisateur_Click(object sender, EventArgs e)
        {
            FormUtilisateur f = new FormUtilisateur();
            f.Show();
        }

        /// <summary>
        /// ce code permet de montrer la fenêtre technicien
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnTechnicien_Click(object sender, EventArgs e)
        {
            FormTechnicien f = new FormTechnicien();
            f.Show();
        }

        /// <summary>
        /// ce code permet de montrer la fenêtre responsable
        /// </summary>
        /// <param name="sender">le bouton</param>
        /// <param name="e">les infos du clic</param>
        private void btnResponsable_Click(object sender, EventArgs e)
        {
            FormResponsable f = new FormResponsable();
            f.Show();
        }
    }
}
