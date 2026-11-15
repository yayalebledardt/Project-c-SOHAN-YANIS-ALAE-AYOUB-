namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker les infos sur un matériel
    /// </summary>
    public class Materiel
    {
        public int IdMateriel { get; set; }
        public string TypeMateriel { get; set; }
        public string Composants { get; set; }
        public string LogicielsInstalles { get; set; }
        public DateTime? DateAcquisition { get; set; }
        public string Garantie { get; set; }
        public string ModeAcquisition { get; set; }
        public Personnel Personnel { get; set; }
        public Fournisseur Fournisseur { get; set; }

        /// <summary>
        /// ce code permet de créer un matériel vide
        /// </summary>
        public Materiel()
        {
        }

        /// <summary>
        /// ce code permet de créer un matériel avec toutes ses infos
        /// </summary>
        /// <param name="idMateriel">son numéro</param>
        /// <param name="typeMateriel">le type genre pc ou imprimante</param>
        /// <param name="composants">les pièces dedans</param>
        /// <param name="logicielsInstalles">les logiciels dessus</param>
        /// <param name="dateAcquisition">quand il a été acheté</param>
        /// <param name="garantie">la garantie</param>
        /// <param name="modeAcquisition">achat ou location</param>
        /// <param name="personnel">la personne qui a le matériel ou null</param>
        /// <param name="fournisseur">le vendeur ou le loueur ou null</param>
        public Materiel(int idMateriel, string typeMateriel, string composants, string logicielsInstalles, DateTime? dateAcquisition, string garantie, string modeAcquisition, Personnel personnel, Fournisseur fournisseur)
        {
            IdMateriel = idMateriel;
            TypeMateriel = typeMateriel;
            Composants = composants;
            LogicielsInstalles = logicielsInstalles;
            DateAcquisition = dateAcquisition;
            Garantie = garantie;
            ModeAcquisition = modeAcquisition;
            Personnel = personnel;
            Fournisseur = fournisseur;
        }

        /// <summary>
        /// ce code permet de montrer le matériel dans une liste
        /// </summary>
        /// <returns>le numéro le type et les composants</returns>
        public override string ToString()
        {
            return "n°" + IdMateriel + " - " + TypeMateriel + " - " + Composants;
        }
    }
}
