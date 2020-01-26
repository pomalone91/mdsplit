// Run using this in custom config:      /Users/paulmalone/Documents/Journal/test.md
using System;

namespace mdsplit {
    class MainClass {
        public static void Main(string[] args) {
            // Make a new file reader and read in the file
            if (args.Length > 0) {
                File file = new File(args[0]);
                Splitter sp = new Splitter(file);                

                foreach (File f in sp.getArticles()) {
                    Console.WriteLine(f.filename);
                    Console.WriteLine(f.contents);
                    Console.WriteLine("------------------------------------");
                }

                sp.getArticles()[1].write("/Users/paulmalone/Documents/Journal/", ".md");
            } else {
                Console.WriteLine("Could not read file");
            }
        }
    }
}
