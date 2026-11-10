namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUtilisateur_Click(object sender, EventArgs e)
        {
            FormUtilisateur f = new FormUtilisateur();
            f.Show();
        }

        private void btnTechnicien_Click(object sender, EventArgs e)
        {
            FormTechnicien f = new FormTechnicien();
            f.Show();
        }

        private void btnResponsable_Click(object sender, EventArgs e)
        {
            FormResponsable f = new FormResponsable();
            f.Show();
        }
    }
}
