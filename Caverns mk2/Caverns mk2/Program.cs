namespace Caverns_mk2
{
#if WINDOWS || XBOX

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            using (Caverns game = new Caverns())
            {
                game.Run();
            }
        }
    }

#endif
}