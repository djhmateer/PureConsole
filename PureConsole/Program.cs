using System;
using System.IO;

namespace PureConsole {
    class Program {
        static void Main(string[] args) {
            // Read a text file, logging to the screen

            // Composition Root - the only place we new up stuff
            var logger = new Logger();
            var reader = new TextFileReader(logger);

            // Start the program
            reader.ReadTextFile();
            Console.ReadLine();
        }
    }

    // TextFileReader class has a dependency on Logger
    public class TextFileReader {
        private readonly Logger logger;
        public TextFileReader(Logger logger) {
            this.logger = logger;
        }

        public void ReadTextFile() {
            logger.Log("Opening file");
            var sr = new StreamReader(@"c:\temp\test.txt");
            var line = sr.ReadToEnd();
            logger.Log("File contents are: " + line);
        }
    }

    public class Logger {
        public void Log(string message) {
            Console.WriteLine(message);
        }
    }
}
