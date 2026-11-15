namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker les infos sur une personne
    /// </summary>
    public class Personnel
    {
        public int IdPersonnel { get; set; }
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public DateTime? DateEmbauche { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }

        /// <summary>
        /// ce code permet de créer une personne vide
        /// </summary>
        public Personnel()
        {
        }

        /// <summary>
        /// ce code permet de créer une personne avec toutes ses infos
        /// </summary>
        /// <param name="idPersonnel">son numéro</param>
        /// <param name="matricule">son matricule</param>
        /// <param name="nom">son nom</param>
        /// <param name="prenom">son prénom</param>
        /// <param name="adresse">son adresse</param>
        /// <param name="dateEmbauche">quand elle a été embauchée</param>
        /// <param name="login">son login</param>
        /// <param name="role">utilisateur ou technicien ou responsable</param>
        public Personnel(int idPersonnel, string matricule, string nom, string prenom, string adresse, DateTime? dateEmbauche, string login, string role)
        {
            IdPersonnel = idPersonnel;
            Matricule = matricule;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            DateEmbauche = dateEmbauche;
            Login = login;
            Role = role;
        }

        /// <summary>
        /// ce code permet de créer le matricule
        /// on prend les 2 premières lettres du nom et du prénom puis le numéro sur 3 chiffres
        /// </summary>
        /// <returns>le matricule</returns>
        public string GenererMatricule()
        {
            string debutNom = Nom;
            if (Nom.Length > 2)
            {
                debutNom = Nom.Substring(0, 2);
            }

            string debutPrenom = Prenom;
            if (Prenom.Length > 2)
            {
                debutPrenom = Prenom.Substring(0, 2);
            }

            return debutNom.ToUpper() + debutPrenom.ToUpper() + IdPersonnel.ToString("000");
        }

        /// <summary>
        /// ce code permet de montrer la personne dans une liste
        /// </summary>
        /// <returns>le nom le prénom et le matricule</returns>
        public override string ToString()
        {
            return Nom + " " + Prenom + " (" + Matricule + ")";
        }
    }
}
