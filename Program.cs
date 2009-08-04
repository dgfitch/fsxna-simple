using System;

namespace Simple {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            using (Simple game = new Simple()) {
                game.Run();
            }
        }
    }
}

