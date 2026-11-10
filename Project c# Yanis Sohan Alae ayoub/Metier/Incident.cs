namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public class Incident
    {
        public int IdIncident { get; set; }
        public string Objet { get; set; }
        public string Description { get; set; }
        public int NiveauUrgence { get; set; }
        public int NiveauDemande { get; set; }
        public DateTime DateDeclaration { get; set; }
        public DateTime? DatePriseEnCharge { get; set; }
        public DateTime? DateResolution { get; set; }
        public string Etat { get; set; }
        public string TypePriseEnCharge { get; set; }
        public Personnel Declarant { get; set; }
        public Technicien Technicien { get; set; }
        public Materiel Materiel { get; set; }

        public Incident()
        {
        }

        public Incident(string objet, string description, int niveauUrgence, int niveauDemande, Personnel declarant, Materiel materiel)
        {
            Objet = objet;
            Description = description;
            NiveauUrgence = niveauUrgence;
            NiveauDemande = niveauDemande;
            Declarant = declarant;
            Materiel = materiel;
            Etat = "Enregistrée";
            DateDeclaration = DateTime.Now;
        }

        public override string ToString()
        {
            return "n°" + IdIncident + " - " + Objet + " (" + Etat + ")";
        }
    }
}
