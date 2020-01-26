
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
            this.contents = "#" + filename + contents;
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
        public void write(string topDir, string ext) {
            this.filepath = topDir + filename + ext;
            //System.IO.File.WriteAllText(filepath, filename + contents);

            // TODO - Get this to fill in journal heirarchy when writting files
            DateTime date = DateTime.Parse(filename);
            string month = date.ToString("MMMM");
            int year = date.Year;
            string day = date.ToString("dd");

            // TODO - Check if year folder exists, if not make it
            string yearFolder = Path.Combine(topDir, year.ToString());
            Directory.CreateDirectory(yearFolder);

            // TODO - Check if month folder exists, if not make it
            string monthFolder = Path.Combine(yearFolder, month);
            Directory.CreateDirectory(monthFolder);

            // TODO - write to appropriate month folder
            string filePath = Path.Combine(monthFolder, day + ext);
            System.IO.File.WriteAllText(filePath, contents);

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
