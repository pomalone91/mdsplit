// Run using this in custom config:      /Users/paulmalone/Documents/Journal/test.md
using System;

namespace mdsplit {
    class MainClass {
        public static void Main(string[] args) {
            // Make a new file reader and read in the file
            if (args.Length > 0) {
                FileReader fr = new FileReader(args[0]);
                Splitter sp = new Splitter(fr);                

                foreach (string article in sp.getArticles()) {
                    Console.WriteLine("'{0}'", article);
                    Console.WriteLine("------------------------------------");
                }
            } else {
                Console.WriteLine("Could not read file");
            }
        }
    }
}
