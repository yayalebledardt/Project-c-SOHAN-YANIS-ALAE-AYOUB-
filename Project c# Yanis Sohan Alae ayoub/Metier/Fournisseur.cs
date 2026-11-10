namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public class Fournisseur
    {
        public int IdFournisseur { get; set; }
        public string NomFournisseur { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string TypeFournisseur { get; set; }

        public Fournisseur()
        {
        }

        public Fournisseur(int idFournisseur, string nomFournisseur, string adresse, string telephone, string typeFournisseur)
        {
            IdFournisseur = idFournisseur;
            NomFournisseur = nomFournisseur;
            Adresse = adresse;
            Telephone = telephone;
            TypeFournisseur = typeFournisseur;
        }

        public override string ToString()
        {
            return NomFournisseur + " (" + TypeFournisseur + ")";
        }
    }
}
