namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker les infos sur un fournisseur
    /// </summary>
    public class Fournisseur
    {
        public int IdFournisseur { get; set; }
        public string NomFournisseur { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string TypeFournisseur { get; set; }

        /// <summary>
        /// ce code permet de créer un fournisseur vide
        /// </summary>
        public Fournisseur()
        {
        }

        /// <summary>
        /// ce code permet de créer un fournisseur avec toutes ses infos
        /// </summary>
        /// <param name="idFournisseur">son numéro</param>
        /// <param name="nomFournisseur">son nom</param>
        /// <param name="adresse">son adresse</param>
        /// <param name="telephone">son téléphone</param>
        /// <param name="typeFournisseur">vendeur ou loueur</param>
        public Fournisseur(int idFournisseur, string nomFournisseur, string adresse, string telephone, string typeFournisseur)
        {
            IdFournisseur = idFournisseur;
            NomFournisseur = nomFournisseur;
            Adresse = adresse;
            Telephone = telephone;
            TypeFournisseur = typeFournisseur;
        }

        /// <summary>
        /// ce code permet de montrer le fournisseur dans une liste
        /// </summary>
        /// <returns>le nom et le type</returns>
        public override string ToString()
        {
            return NomFournisseur + " (" + TypeFournisseur + ")";
        }
    }
}
