namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public class Intervention
    {
        public int IdIntervention { get; set; }
        public DateTime DateIntervention { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public string TravailRealise { get; set; }
        public Incident Incident { get; set; }
        public Technicien Technicien { get; set; }

        public Intervention()
        {
        }

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

        public double DureeEnHeures()
        {
            return (HeureFin - HeureDebut).TotalHours;
        }

        public override string ToString()
        {
            return DateIntervention.ToShortDateString() + " de " + HeureDebut.ToString(@"hh\:mm") + " à " + HeureFin.ToString(@"hh\:mm") + " : " + TravailRealise;
        }
    }
}
