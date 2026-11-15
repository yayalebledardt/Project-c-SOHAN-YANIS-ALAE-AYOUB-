namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker les infos sur une intervention
    /// </summary>
    public class Intervention
    {
        public int IdIntervention { get; set; }
        public DateTime DateIntervention { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public string TravailRealise { get; set; }
        public Incident Incident { get; set; }
        public Technicien Technicien { get; set; }

        /// <summary>
        /// ce code permet de créer une intervention vide
        /// </summary>
        public Intervention()
        {
        }

        /// <summary>
        /// ce code permet de créer une intervention avec toutes ses infos
        /// </summary>
        /// <param name="idIntervention">son numéro</param>
        /// <param name="dateIntervention">le jour</param>
        /// <param name="heureDebut">quand ça commence</param>
        /// <param name="heureFin">quand ça finit</param>
        /// <param name="travailRealise">ce qui a été fait</param>
        /// <param name="incident">un incident de la liste</param>
        /// <param name="technicien">le technicien qui a fait le travail</param>
        public Intervention(int idIntervention, DateTime dateIntervention, TimeSpan heureDebut, TimeSpan heureFin, string travailRealise, Incident incident, Technicien technicien)
        {
            IdIntervention = idIntervention;
            DateIntervention = dateIntervention;
            HeureDebut = heureDebut;
            HeureFin = heureFin;
            TravailRealise = travailRealise;
            Incident = incident;
            Technicien = technicien;
        }

        /// <summary>
        /// ce code permet de calculer combien de temps elle a duré
        /// </summary>
        /// <returns>la durée en heures</returns>
        public double DureeEnHeures()
        {
            return (HeureFin - HeureDebut).TotalHours;
        }

        /// <summary>
        /// ce code permet de montrer une intervention dans le détail
        /// </summary>
        /// <returns>la date les heures et le travail fait</returns>
        public override string ToString()
        {
            return DateIntervention.ToShortDateString() + " de " + HeureDebut.ToString(@"hh\:mm") + " à " + HeureFin.ToString(@"hh\:mm") + " : " + TravailRealise;
        }
    }
}
