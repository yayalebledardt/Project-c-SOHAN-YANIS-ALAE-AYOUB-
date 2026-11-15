namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker les stats des incidents
    /// </summary>
    public class Statistiques
    {
        public int NbIncidents { get; set; }
        public int NbDeclares { get; set; }
        public int NbEnCharge { get; set; }
        public int NbResolus { get; set; }
        public double PourcentageDeclares { get; set; }
        public double PourcentageEnCharge { get; set; }
        public double PourcentageResolus { get; set; }
        public double DelaiMoyenJours { get; set; }

        /// <summary>
        /// ce code permet de calculer le total et les pourcentages
        /// </summary>
        /// <param name="nbDeclares">combien sont enregistrés</param>
        /// <param name="nbEnCharge">combien sont en cours</param>
        /// <param name="nbResolus">combien sont résolus ou clôturés</param>
        /// <param name="delaiMoyenJours">le temps moyen pour résoudre en jours</param>
        public Statistiques(int nbDeclares, int nbEnCharge, int nbResolus, double delaiMoyenJours)
        {
            NbDeclares = nbDeclares;
            NbEnCharge = nbEnCharge;
            NbResolus = nbResolus;
            DelaiMoyenJours = delaiMoyenJours;

            NbIncidents = nbDeclares + nbEnCharge + nbResolus;
            PourcentageDeclares = Pourcentage(nbDeclares);
            PourcentageEnCharge = Pourcentage(nbEnCharge);
            PourcentageResolus = Pourcentage(nbResolus);
        }

        /// <summary>
        /// ce code permet de calculer un pourcentage
        /// </summary>
        /// <param name="nb">le nombre</param>
        /// <returns>le pourcentage sur le total</returns>
        private double Pourcentage(int nb)
        {
            if (NbIncidents == 0)
            {
                return 0;
            }
            return nb * 100.0 / NbIncidents;
        }
    }
}
