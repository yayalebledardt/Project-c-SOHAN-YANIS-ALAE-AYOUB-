namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker les stats pour un technicien
    /// </summary>
    public class StatTechnicien
    {
        public Technicien Technicien { get; set; }
        public int NbEnCharge { get; set; }
        public int NbResolus { get; set; }
        public double NbHeures { get; set; }

        /// <summary>
        /// ce code permet de créer les stats du technicien
        /// </summary>
        /// <param name="technicien">le technicien</param>
        /// <param name="nbEnCharge">combien il en a en cours</param>
        /// <param name="nbResolus">combien il en a résolu</param>
        /// <param name="nbHeures">le total des heures</param>
        public StatTechnicien(Technicien technicien, int nbEnCharge, int nbResolus, double nbHeures)
        {
            Technicien = technicien;
            NbEnCharge = nbEnCharge;
            NbResolus = nbResolus;
            NbHeures = nbHeures;
        }
    }
}
