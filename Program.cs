using System;

namespace Simple {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            using (FGame game = new FGame()) {
                game.Run();
            }
        }
    }
}

