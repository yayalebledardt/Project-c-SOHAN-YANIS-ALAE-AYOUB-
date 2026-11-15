namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker les infos sur un technicien
    /// un technicien est une personne avec un niveau en plus
    /// </summary>
    public class Technicien : Personnel
    {
        public int NiveauIntervention { get; set; }
        public string Formation { get; set; }
        public string Competences { get; set; }

        /// <summary>
        /// ce code permet de créer un technicien vide
        /// </summary>
        public Technicien()
        {
            Role = "technicien";
        }

        /// <summary>
        /// ce code permet de créer un technicien avec toutes ses infos
        /// </summary>
        /// <param name="idPersonnel">son numéro</param>
        /// <param name="matricule">son matricule</param>
        /// <param name="nom">son nom</param>
        /// <param name="prenom">son prénom</param>
        /// <param name="adresse">son adresse</param>
        /// <param name="dateEmbauche">quand il a été embauché</param>
        /// <param name="login">son login</param>
        /// <param name="niveauIntervention">1 ou 2</param>
        /// <param name="formation">sa formation</param>
        /// <param name="competences">ses compétences</param>
        public Technicien(int idPersonnel, string matricule, string nom, string prenom, string adresse, DateTime? dateEmbauche, string login, int niveauIntervention, string formation, string competences)
            : base(idPersonnel, matricule, nom, prenom, adresse, dateEmbauche, login, "technicien")
        {
            NiveauIntervention = niveauIntervention;
            Formation = formation;
            Competences = competences;
        }

        /// <summary>
        /// ce code permet de montrer le technicien dans une liste
        /// </summary>
        /// <returns>le nom le prénom et le niveau</returns>
        public override string ToString()
        {
            return Nom + " " + Prenom + " (niveau " + NiveauIntervention + ")";
        }
    }
}
