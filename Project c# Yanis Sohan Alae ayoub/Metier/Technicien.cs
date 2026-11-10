namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public class Technicien : Personnel
    {
        public int NiveauIntervention { get; set; }
        public string Formation { get; set; }
        public string Competences { get; set; }

        public Technicien()
        {
            Role = "technicien";
        }

        public Technicien(int idPersonnel, string matricule, string nom, string prenom, string adresse, DateTime? dateEmbauche, string login, int niveauIntervention, string formation, string competences)
            : base(idPersonnel, matricule, nom, prenom, adresse, dateEmbauche, login, "technicien")
        {
            NiveauIntervention = niveauIntervention;
            Formation = formation;
            Competences = competences;
        }

        public override string ToString()
        {
            return Nom + " " + Prenom + " (niveau " + NiveauIntervention + ")";
        }
    }
}
