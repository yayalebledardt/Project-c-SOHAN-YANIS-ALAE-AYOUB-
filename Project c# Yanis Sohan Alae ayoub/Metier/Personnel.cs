namespace Project_c__Yanis_Sohan_Alae_ayoub
{
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

        public Personnel()
        {
        }

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

        public override string ToString()
        {
            return Nom + " " + Prenom + " (" + Matricule + ")";
        }
    }
}
