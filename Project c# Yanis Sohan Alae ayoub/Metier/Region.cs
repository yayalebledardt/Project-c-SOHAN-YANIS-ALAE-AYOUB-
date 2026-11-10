namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    public class Region
    {
        public int IdRegion { get; set; }
        public string LibelleRegion { get; set; }

        public Region(int idRegion, string libelleRegion)
        {
            IdRegion = idRegion;
            LibelleRegion = libelleRegion;
        }

        public override string ToString()
        {
            return LibelleRegion;
        }
    }
}
