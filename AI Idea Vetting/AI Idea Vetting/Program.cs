namespace AI_Idea_Vetting
{
#if WINDOWS || XBOX

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            using (IdeaVett game = new IdeaVett())
            {
                game.Run();
            }
        }
    }

#endif
}