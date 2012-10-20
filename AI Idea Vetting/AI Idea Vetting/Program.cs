using System;

namespace AI_Idea_Vetting
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (IdeaVett game = new IdeaVett())
            {
                game.Run();
            }
        }
    }
#endif
}

