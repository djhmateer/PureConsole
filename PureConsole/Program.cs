using System;
using System.IO;

namespace PureConsole {
    class Program {
        static void Main(string[] args) {
            // Read a text file, logging to the screen

            // Composition Root - the 'only' place we new up stuff
            var logger = new Logger();
            var textFileReader = new TextFileReader(logger);

            // Start the program
            textFileReader.Read();
            Console.ReadLine();
        }
    }

    // TextFileReader class has a dependency on ILogger
    // Using ILogger (and not Logger) as then can inject in a 'fake' logger for testing
    public class TextFileReader {
        private readonly Logger logger;
        public TextFileReader(Logger logger) {
            this.logger = logger;
        }

        public void Read() {
            var sr = new StreamReader(@"..\..\test.txt");
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
