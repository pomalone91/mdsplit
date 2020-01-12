using System;
using System.IO;
namespace mdsplit {
    // Class to read in a file at a given path
    public class FileReader {
        public FileReader() {
        }

        // Function to read in a file at a given path
        public void read(string filepath) {
            try {
                using (StreamReader sr = new StreamReader(filepath)) {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            } catch (IOException e) {
                Console.WriteLine("Could not read file");
                Console.WriteLine(e.Message);
            }
        }
    }
}
