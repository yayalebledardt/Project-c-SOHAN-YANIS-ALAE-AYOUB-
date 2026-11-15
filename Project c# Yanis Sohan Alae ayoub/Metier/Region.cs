namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de stocker une région
    /// </summary>
    public class Region
    {
        public int IdRegion { get; set; }
        public string LibelleRegion { get; set; }

        /// <summary>
        /// ce code permet de créer une région
        /// </summary>
        /// <param name="idRegion">son numéro</param>
        /// <param name="libelleRegion">son nom</param>
        public Region(int idRegion, string libelleRegion)
        {
            IdRegion = idRegion;
            LibelleRegion = libelleRegion;
        }

        /// <summary>
        /// ce code permet de montrer la région dans une liste
        /// </summary>
        /// <returns>le nom de la région</returns>
        public override string ToString()
        {
            return LibelleRegion;
        }
    }
}
