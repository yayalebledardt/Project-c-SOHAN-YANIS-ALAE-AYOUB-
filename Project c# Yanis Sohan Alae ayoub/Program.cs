namespace Project_c__Yanis_Sohan_Alae_ayoub
{
    /// <summary>
    /// ce code permet de lancer le programme
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// ce code permet de démarrer le programme avec le menu
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}