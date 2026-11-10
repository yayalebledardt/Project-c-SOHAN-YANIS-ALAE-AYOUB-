namespace Project_c__Yanis_Sohan_Alae_ayoub
{
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
