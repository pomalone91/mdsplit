// Run using this in custom config:      /Users/paulmalone/Documents/Journal/index.md
using System;
using System.IO;
namespace mdsplit {
    // Class to read in a file at a given path
    public class FileReader {

        private string filepath;
        private string contents;

        public FileReader(string filepath) {
            this.filepath = filepath;
            this.contents = read(this.filepath);
        }

        // Function to read in a file at a given path
        private string read(string filepath) {
            String contents;
            try {
                using (StreamReader sr = new StreamReader(filepath)) {
                    contents = sr.ReadToEnd();
                    Console.WriteLine(contents);
                }
            } catch (IOException e) {
                Console.WriteLine("Could not read file");
                Console.WriteLine(e.Message);
                return null;
            }

            return contents;
        }
    }
}
