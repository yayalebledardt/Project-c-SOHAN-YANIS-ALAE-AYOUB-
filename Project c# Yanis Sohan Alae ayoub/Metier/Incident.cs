namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker les infos sur un incident
    /// </summary>
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

        /// <summary>
        /// ce code permet de créer un incident vide
        /// </summary>
        public Incident()
        {
        }

        /// <summary>
        /// ce code permet de créer un nouvel incident
        /// il est mis en enregistrée avec la date de maintenant
        /// </summary>
        /// <param name="objet">le titre du problème</param>
        /// <param name="description">le problème expliqué</param>
        /// <param name="niveauUrgence">1 faible 2 moyenne 3 urgente</param>
        /// <param name="niveauDemande">1 ou 2</param>
        /// <param name="declarant">la personne qui déclare</param>
        /// <param name="materiel">le matériel en panne</param>
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

        /// <summary>
        /// ce code permet de montrer un incident dans une liste
        /// </summary>
        /// <returns>le numéro le titre et son état</returns>
        public override string ToString()
        {
            return "n°" + IdIncident + " - " + Objet + " (" + Etat + ")";
        }
    }
}
