
using System;
using System.IO;
namespace mdsplit {
    // Class to read in a file at a given path
    public class File {

        private string filepath;
        public string contents;
        public string filename;

        // Read file to init
        public File(string filepath) {
            this.filepath = filepath;
            this.contents = read(this.filepath);
        }

        // Init file to write with contents
        public File(string filename, string contents) {
            this.filename = filename;
            this.contents = contents;
        }

        // Returns contents of the file
        public string getContents() {
            if (contents == null) {
                return read(filepath);
            } else {
                return contents;
            }
        }

        // Writes a given string to a file
        public void write(string dir, string ext) {
            this.filepath = dir + filename + ext;
            System.IO.File.WriteAllText(filepath, filename + contents);
        }

        // Function to read in a file at a given path
        private string read(string filepath) {
            String contents;
            try {
                using (StreamReader sr = new StreamReader(filepath)) {
                    contents = sr.ReadToEnd();
                    //Console.WriteLine(contents);
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
