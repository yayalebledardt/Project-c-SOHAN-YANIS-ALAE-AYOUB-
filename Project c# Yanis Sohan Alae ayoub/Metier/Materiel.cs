namespace Project_c__Yanis_Sohan_Alae_ayoub
{
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

        public Materiel()
        {
        }

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

        public override string ToString()
        {
            return "n°" + IdMateriel + " - " + TypeMateriel + " - " + Composants;
        }
    }
}
