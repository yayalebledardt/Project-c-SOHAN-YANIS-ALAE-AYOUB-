namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public class StatTechnicien
    {
        public Technicien Technicien { get; set; }
        public int NbEnCharge { get; set; }
        public int NbResolus { get; set; }
        public double NbHeures { get; set; }

        public StatTechnicien(Technicien technicien, int nbEnCharge, int nbResolus, double nbHeures)
        {
            Technicien = technicien;
            NbEnCharge = nbEnCharge;
            NbResolus = nbResolus;
            NbHeures = nbHeures;
        }
    }
}
